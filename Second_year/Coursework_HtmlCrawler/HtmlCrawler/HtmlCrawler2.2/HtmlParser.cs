using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawler2._2
{
    class HTMLParser
    {
        private List<Node>?  nodes;
        private Node? root;

        public void ParseHTML(string htmlContent)
        {
            root = new Node("html");
            nodes = new List<Node>();
            nodes.Add(root);

            int position = 0;
            int length = htmlContent.Length;

            while (position < length)
            {
                if (htmlContent[position] == '<')
                {
                    if (htmlContent[position + 1] == '/')
                    {
                        int endTagIndex = position + 2;
                        while (endTagIndex < length && htmlContent[endTagIndex] != '>')
                        {
                            endTagIndex++;
                        }

                        string tagName = htmlContent.CustomSubstring(position + 2, endTagIndex - position - 2);

                        if (nodes.Count > 1 && nodes[nodes.Count - 1].Tag == tagName)
                        {
                            nodes.RemoveAt(nodes.Count - 1);
                        }
                    }
                    else
                    {
                        int endTagIndex = position + 1;
                        while (endTagIndex < length && htmlContent[endTagIndex] != '>')
                        {
                            endTagIndex++;
                        }

                        string tagContent = htmlContent.CustomSubstring(position + 1, endTagIndex - position - 1);


                        string tagName = GetTagName(tagContent);
                        if (tagName != null)
                        {
                            Node newNode = new Node(tagName);
                            Node current = nodes[nodes.Count - 1];
                            current.Children.Add(newNode);
                            nodes.Add(newNode);

                            ParseAttributes(tagContent, newNode);

                            if (htmlContent[endTagIndex] == '/')
                            {
                                nodes.RemoveAt(nodes.Count - 1);
                            }
                        }
                    }

                    int closingBracket = htmlContent.CustomIndexOf(">", position);
                    position = closingBracket + 1;
                }
                else
                {
                    int nextTagIndex = htmlContent.CustomIndexOf("<", position);
                    string text = nextTagIndex != -1 ? htmlContent.CustomSubstring(position, nextTagIndex - position) : htmlContent.CustomSubstring(position);

                    if (!IsWhitespace(text)) 
                    {
                        Node current = nodes[nodes.Count - 1];
                        current.Content += text;
                    }

                    if (nextTagIndex == -1) break;
                    position = nextTagIndex;
                }
            }

        }
        public Node GetRootNode()
        {
            if (root == null)
            {
                throw new Exception("Root node is null!");
            }
            return root.Children[0];
        }
        private string GetTagName(string tagContent)
        {
            int index = 0;
            while (index < tagContent.Length && !char.IsWhiteSpace(tagContent[index]) && tagContent[index] != '>')
            {
                index++;
            }

            if (index == 0) 
            {
                return null;
            }

            return tagContent.CustomSubstring(0, index);
        }

        private bool IsWhitespace(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsWhiteSpace(c) && c != '\0')
                {
                    return false;
                }
            }
            return true;
        }

        private void ParseAttributes(string tagContent, Node node)
        {
            int index = 0;
            int tagNameEnd = tagContent.CustomIndexOf(" ");
            if (tagNameEnd == -1)
            {
                tagNameEnd = tagContent.CustomIndexOf(">");
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

                int equalIndex = tagContent.CustomIndexOf("=", index);
                if (equalIndex == -1)
                {
                    break;
                }

                string attributeName = tagContent.CustomSubstring(index, equalIndex - index).CustomTrim();
                int valueStartIndex = equalIndex + 1;

                if (valueStartIndex >= tagContent.Length)
                {
                    break;
                }

                char quote = tagContent[valueStartIndex];
                int valueEndIndex = tagContent.CustomIndexOf(quote.ToString(), valueStartIndex + 1);

                if (valueEndIndex == -1)
                {
                    break;
                }

                string attributeValue = tagContent.CustomSubstring(valueStartIndex + 1, valueEndIndex - valueStartIndex - 1);

                node.Attributes.Add(new Attribute { Key = attributeName, Value = attributeValue });

                index = valueEndIndex + 1;
            }
        }
        public string GetFullHtmlContent(Node node)
        {
            StringBuilder fullContent = new StringBuilder();
            TraverseAndConcatenate(node, fullContent);
            return fullContent.ToString();
        }
        private void TraverseAndConcatenate(Node node, StringBuilder fullContent, int depth = 0)
        {
            if (node != null)
            {
                fullContent.Append(new string(' ', depth * 4));

                fullContent.Append($"<{node.Tag}");

                foreach (Attribute attribute in node.Attributes)
                {
                    fullContent.Append($" {attribute.Key}='{attribute.Value}'");
                }

                fullContent.Append(">");

                if (!string.IsNullOrEmpty(node.Content))
                {
                    fullContent.Append(node.Content.CustomTrim());
                }

                if (node.Children.Count > 0)
                {
                    fullContent.AppendLine();
                }

                foreach (Node child in node.Children)
                {
                    TraverseAndConcatenate(child, fullContent, depth + 1);
                }

                if (node.Children.Count > 0)
                {
                    fullContent.AppendLine();
                    fullContent.Append(new string(' ', depth * 4));
                }

                fullContent.Append($"</{node.Tag}>");
                fullContent.AppendLine();
            }
        }
    }    
}

