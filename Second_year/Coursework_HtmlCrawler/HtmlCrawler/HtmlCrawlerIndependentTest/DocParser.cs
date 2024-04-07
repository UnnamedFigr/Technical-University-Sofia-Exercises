using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HtmlCrawlerIndependentTest
{
    public class DocParser
    {
        private NodeCollection _items;
        private Node? _documentnode;
        private int index;
        private int _c;
        internal Node _currentnode;
        
        public string Text { get; set; }

        public DocParser(string path)
        {
            StreamReader sr  = new StreamReader(path);
            Text = sr.ReadToEnd();
        }

        public void Parse(string htmlContent)
        {
            while (index < Text.Length)
            {
                 _c = Text[index++];
            }

        }

        enum ParseState
        {
            BetweenTag,
            Text
        }
        //private string GetTagName(string tagContent)
        //{
        //    int index = 0;
        //    while (index < tagContent.Length && !char.IsWhiteSpace(tagContent[index]) && tagContent[index] != '>')
        //    {
        //        index++;
        //    }

        //    if (index == 0)
        //    {
        //        return null;
        //    }

        //    return tagContent.Substring(0, index);
        //}

        private bool IsWhitespace(int c)
        {
            if ((c == 10) || (c == 13) || (c == 32) || (c == 9))
            {
                return true;
            }

            return false;
        }

        private void ParseAttributes(string tagContent, Node node)
        {
            int index = 0;
            int tagNameEnd = tagContent.IndexOf(" ");
            if (tagNameEnd == -1)
            {
                tagNameEnd = tagContent.IndexOf(">");
                if (tagNameEnd == -1)
                {
                    return;
                }
            }
            index = tagNameEnd;
            while (index < tagContent.Length)
            {
                while (index < tagContent.Length && (char.IsWhiteSpace(tagContent[index]) || tagContent[index] == '>'))
                {
                    index++;
                }

                if (index >= tagContent.Length)
                {
                    break;
                }

                int equalIndex = tagContent.IndexOf("=", index);
                if (equalIndex == -1)
                {
                    break;
                }

                string attributeName = tagContent.Substring(index, equalIndex - index).Trim();
                int valueStartIndex = equalIndex + 1;

                if (valueStartIndex >= tagContent.Length)
                {
                    break;
                }

                char quote = tagContent[valueStartIndex];
                int valueEndIndex = tagContent.IndexOf(quote.ToString(), valueStartIndex + 1);

                if (valueEndIndex == -1)
                {
                    break;
                }

                string attributeValue = tagContent.Substring(valueStartIndex + 1, valueEndIndex - valueStartIndex - 1);

                node.Attributes.Add(new Attribute { Key = attributeName, Value = attributeValue });

                index = valueEndIndex + 1;
            }
        }
        //public string GetFullHtmlContent(Node node)
        //{
        //    StringBuilder fullContent = new StringBuilder();
        //    TraverseAndConcatenate(node, fullContent);
        //    return fullContent.ToString();
        }
        //private void TraverseAndConcatenate(Node node, StringBuilder fullContent, int depth = 0)
        //{
        //    if (node != null)
        //    {
        //        fullContent.Append(new string(' ', depth * 4));
        //        fullContent.Append($"<{node.Tag}");
        //        if(node.Attributes.Count > 0)
        //        {
        //            foreach(Attribute attribute in node.Attributes)
        //            {
        //                fullContent.Append($" {attribute.Key}='{attribute.Value}'");
        //            }
        //        }
        //        fullContent.Append('>');

        //        if(!string.IsNullOrEmpty(node.Content))
        //        {
        //            fullContent.Append(node.Content);
        //        }

        //        if(node.Children.Count > 0)
        //        {
        //            fullContent.AppendLine();
        //        }

        //        foreach(Node child in node.Children)
        //        {
        //            TraverseAndConcatenate(child, fullContent, depth + 1);
        //            fullContent.AppendLine();
        //        }
        //        if(node.ChildrenNode.Count > 0)
        //        {
        //            /*fullContent.AppendLine();  Commenting this fixed the problem with spaces between the text content and the closing tags :)*/
        //            fullContent.Append(new string(' ', depth * 4));
        //        }
        //        if (node.isSelfClosing == false)
        //        {
        //            fullContent.Append($"</{node.Tag}>");
        //        }
        //        //if (node.Children.Count != 0)
        //        //{
        //        //    fullContent.AppendLine();
        //        //}   
        //    }
        //}
    }
}
