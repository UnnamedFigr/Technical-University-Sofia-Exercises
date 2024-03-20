using HtmlCrawler2._2;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Attribute = HtmlCrawler2._2.Attribute;

namespace HtmlCrawlerTest
{
    public class DocParser
    {
        private int position;
        private string htmlContent;
        private Node? rootNode;
        private int len;

        public DocParser(string htmlContent)
        {
            this.htmlContent = htmlContent;
            position = 0;
            rootNode = new Node("root");
            
        }

        public Node ParseHtmlFile()
        {
            len = htmlContent.Length;
            while(position < len)
            {
                char currentChar = htmlContent[position];
                if(currentChar == '<')
                {
                    if (currentChar != '/')
                    {
                        ParseOpeningTag(rootNode);
                    }
                    else
                    {
                        ParseClosingTag(rootNode);
                    }
                }
                else
                {
                    ParseContent(rootNode);
                }
                position++;
            }
            return rootNode.Children[0];
        }

        private void ParseClosingTag(Node? parentNode)
        {
            position += 2;
            int tagNameStart = position;
            if(position < len && htmlContent[position] != '>')
            {
                position++;
            }
            string tagName = htmlContent.Substring(tagNameStart, position - tagNameStart);
            int childrenCount = parentNode.Children.Count;
            //See if opening and  closing tags match
            if (childrenCount > 0 && parentNode.Children[childrenCount - 1].Tag == tagName) 
            {
                parentNode.Children.RemoveAt(childrenCount - 1);
            }
            else
            {
                throw new Exception("Missmatched tag exception");
            }
        }

        private void ParseOpeningTag(Node parentNode)
        {
            position++; // Move past '<'
            int tagNameStart = position;
            while (position < htmlContent.Length && htmlContent[position] != ' ' && htmlContent[position] != '>' && htmlContent[position] != '/')
            {
                position++;
            }
            string tagName = htmlContent.Substring(tagNameStart, position - tagNameStart);

            Node currentNode = new Node(tagName);

            // Parse attributes
            while (htmlContent[position] != '>' && htmlContent[position] != '/')
            {
                while (htmlContent[position] == ' ')
                {
                    position++; // Move past whitespace
                }

                if (htmlContent[position] == '>' || htmlContent[position] == '/')
                {
                    break;
                }

                int attributeNameStart = position;
                while (htmlContent[position] != '=' && htmlContent[position] != ' ')
                {
                    position++;
                }
                string attributeName = htmlContent.Substring(attributeNameStart, position - attributeNameStart);

                // Skip whitespace and '='
                while (htmlContent[position] == ' ' || htmlContent[position] == '=')
                {
                    position++;
                }

                // Skip quote if present
                if (htmlContent[position] == '"' || htmlContent[position] == '\'')
                {
                    position++;
                }

                int attributeValueStart = position;
                while (htmlContent[position] != '"' && htmlContent[position] != '\'')
                {
                    position++;
                }
                string attributeValue = htmlContent.Substring(attributeValueStart, position - attributeValueStart);

                currentNode.Attributes.Add(new Attribute(attributeName, attributeValue));

                // Skip quote
                position++;
            }

            if (htmlContent[position] == '/')
            {
                // Self-closing tag
                position++;
                if (htmlContent[position] == '>')
                {
                    position++;
                    parentNode.Children.Add(currentNode);
                }
                else
                {
                    Console.WriteLine($"Error: Unexpected character after '/' in opening tag '{tagName}'");
                }
            }
            else
            {
                if (htmlContent[position] == '>')
                {
                    position++;
                }
                parentNode.Children.Add(currentNode);
            }
        }
        private void ParseContent(Node parentNode)
        {
            int textStart = position;
            while(position < len && htmlContent[position] != '<')
            {
                position++;
            }
            string content = htmlContent.Substring(textStart, position - textStart).Trim();
            if(!string.IsNullOrEmpty(content) )
            {
                parentNode.Content = content;
            }
            position--;
        }

    }

}
