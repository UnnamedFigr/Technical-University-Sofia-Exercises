using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawler2._2
{
    public static class CustomStringExtensions
    {
        public static int CustomIndexOf(this string source, string target)
        {
            return CustomIndexOf(source, target, 0, source.Length);
        }
        public static int CustomIndexOf(this string source, string target, int startIndex)
        {
            return CustomIndexOf(source, target, startIndex, source.Length - startIndex);
        }
        public static int CustomIndexOf(this string source, string target, int startIndex, int count)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(target))
                return -1;
            if (startIndex < 0 || string.IsNullOrEmpty(target))
                return -1;
            if(startIndex + count > source.Length)
                count = source.Length - startIndex;

            for(int i = startIndex; i <= startIndex  + count - target.Length; i++)
            {
                bool found = true;
                for(int j =0; j < target.Length; j++) 
                {
                    if (source[i + j] != target[j])
                    {
                        found = false;
                        break;
                    }
                }
                if (found) { return i; }
            }
            return -1;
        }
        public static string CustomTrim(this string input)
        {
            return CustomTrim(input, null);
        }
        public static string CustomTrim(this string input, char[] charsToTrim)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentNullException(nameof(input));

            int startIndex = 0;
            int endIndex = input.Length - 1;
            if (charsToTrim == null)
            {
                while (startIndex <= endIndex && char.IsWhiteSpace(input[startIndex]))
                {
                    startIndex++;
                }

                while (endIndex >= startIndex && char.IsWhiteSpace(input[endIndex]))
                {
                    endIndex--;
                }
            }
            else
            {
                while (startIndex < input.Length && Contains(charsToTrim, input[startIndex])) ;
                {
                    startIndex++;
                }

                while (endIndex >= startIndex && Contains(charsToTrim, input[startIndex])) ;
                {
                    endIndex--;
                }
            }
            int length = endIndex - startIndex + 1;

            if (length <= 0)
                return string.Empty;

            return input.CustomSubstring(startIndex, length);
        }
        public static string CustomSubstring(this string str, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of range.");
            }

            if (length < 0 || startIndex + length > str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Length is out of range.");
            }

            char[] substringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                substringChars[i] = str[startIndex + i];
            }

            return new string(substringChars);
        }

        public static string CustomSubstring(this string str, int startIndex)
        {
            if (startIndex < 0 || startIndex >= str.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startIndex), "Start index is out of range.");
            }

            int length = str.Length - startIndex;
            char[] substringChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                substringChars[i] = str[startIndex + i];
            }

            return new string(substringChars);
        }
        private static bool Contains(char[] chars, char _value)
        {
            foreach(char c in chars)
            {
                if(c == _value) 
                    return true;
            }
            return false;
        }
    }
}
