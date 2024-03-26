using System.Diagnostics.Tracing;
using System.Runtime.InteropServices;

namespace SecondProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            string text = "the sick brown fox jumps over the lazy dog";
            char nonRepeated = FirstNonRepeated(text);
            Console.WriteLine(nonRepeated);
            string example = "successss!!!!!!!!!!!!!!!!";
            string compressedStr = StringCompression(example);
            Console.WriteLine(compressedStr);
            string test = "is this this what what you you mean mean";
            
            Console.WriteLine(RemoveDuplicateWords(test));
        }
        public static string RemoveDuplicateWords(string text)
        {
            string[] words = SplitString(text);
            string result = "";

            for(int i = 0; i < words.Length - 1; i++)
            {
                if (i == 0)
                {
                    result += words[i];
                    continue;
                }
                if (words[i].Length == words[i + 1].Length
                    && words[i] == words[i+1])
                {
                    result += " " + words[i];
                    i++;                
                }
                else
                {
                    result += " " + words[i];
                }
            }           
            return result;
        }
        
        public static string[] SplitString(string text)
        {
            int count = CountSeperators(text) + 1;
            string[] result = new string[count];
            int arrayIndex = 0;
            int startIndex = -1;
            int subLength = 0;

            for(int i = 0; i <= text.Length; i++) 
            {
                if(i == text.Length || !IsLetter(text[i]))
                { 
                    if(startIndex != -1)
                    {
                        char[] substring = new char[subLength];
                        for(int j = 0;  j < subLength; j++)
                        {
                            substring[j] = text[startIndex + j];
                        }
                        result[arrayIndex++] = AddCharsToString(substring);
                        startIndex = -1;
                        subLength = 0;
                    }                  
                }
                else if(startIndex == -1)
                {
                    startIndex = i;
                    subLength++;
                }
                else
                {
                    subLength++;
                }
            }
            return result;
        }
        public static string AddCharsToString(char[] charArray)
        {
            string str = "";
            foreach(char c in charArray)
            {
                str += c;
            }
            return str;
        }
        public static int CountSeperators(string text)
        {
            int count = 0;
            foreach(char ch in text)
            {
                if (!IsLetter(ch))
                {
                    count++;
                }
            }
            return count;
        }
        public static bool IsLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z');
        }
        public static char FirstNonRepeated(string text)
        {
            if (text.Length < 2)
            {
                return '\0';
            }

            for (int i = 0; i < text.Length; i++)
            {
                bool repeated = false;
                for (int j = 0; j < text.Length; j++)
                {
                    if (i != j && text[i] == text[j])
                    {
                        repeated = true;
                        break;
                    }
                }
                if (!repeated)
                {
                    return text[i];
                }
            }
            return '\0';
        }
        
        public static string StringCompression(string text)
        {
            char[] compressedArray = new char[text.Length * 2];
            int count = 1;
            for (int i = 0; i < text.Length - 1; i++)
            {
                if (text[i] == text[i + 1])
                {
                    count++;
                }
                else
                {
                    bool multipleLetters = count > 1;
                    if (multipleLetters)
                    {
                        NumbersInFrontOFLetters(ref compressedArray, ref count, ref text, i);
                    }
                    else
                    {
                        compressedArray[i] = text[i];
                    }
                }
            }
            string compressedStr = "";
            ClearNullChars(compressedArray, ref compressedStr);
            LastLetterNumbers(ref compressedStr, text, ref count);
            
            return compressedStr;
            
        }
        public static void NumbersInFrontOFLetters(ref char[] compressedArray, ref int count, ref string text, int i)
        {
            char[] countChars = ToCharArray(count);
            for (int j = 0; j < countChars.Length; j++)
            {
                compressedArray[i - 1] = countChars[j];
            }
            compressedArray[i] = text[i];
            count = 1;
        }
        public static void ClearNullChars(char[] compressedArray, ref string compressedStr)
        {
            foreach (var ch in compressedArray)
            {
                if (ch != '\0')
                {
                    compressedStr += ch;
                }
            }
        }
        public static void LastLetterNumbers(ref string compressedStr, string text, ref int count)
        {
            if (count > 1) 
            {
                char[] countChars = ToCharArray(count);
                for (int j = 0; j < countChars.Length; j++)
                {
                    compressedStr += countChars[j];
                }
                count = 1;
            }
            compressedStr += text[text.Length - 1];
        }
        public static char[] ToCharArray(int count)
        {
            int tempCount = count;
            int digits = 0;
            while(tempCount > 0)
            {
                tempCount /= 10;
                digits++;
            }
            char[] countChars = new char[digits];
            for(int i = digits - 1; i >= 0; i--)
            {
                countChars[i] = (char)('0' + count % 10);
                count /= 10;
            }
            return countChars;
        }
    }
}