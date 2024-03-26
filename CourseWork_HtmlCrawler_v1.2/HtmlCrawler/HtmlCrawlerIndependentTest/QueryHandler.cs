using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HtmlCrawlerIndependentTest
{
    public enum TraverseOptions
    {
        FullRootTraverse,
        SpecificTraverse
    }
    public class QueryHandler
    {
        private string action;
        private Node? _root;
        private string[] queryParts;

        public QueryHandler(Node root)
        {
            if(root == null) throw new ArgumentNullException("Root node is null");
            _root = root;
        }
       
        public void HandleQuery(string fullQuery)
        {
            int _space = fullQuery.IndexOf(' ');
            action = fullQuery.Substring(0, _space).ToUpper();
            string query = fullQuery.Substring(_space + 1);
            queryParts = SplitQuery(query);
            var printQuery = ExecutePrintQuery(queryParts);
            foreach (var str in printQuery)
            {
                Console.WriteLine(str);
            }
        }
         private List<string> ExecutePrintQuery(string[] queryParts)
        {
            List<string> result = new List<string>();
            //result = Traverse(_root,queryParts);
            
            result.AddRange(Traverse(_root, queryParts, 0));
            return result;
        }
        private string[] SplitQuery(string query)
        {
            List<string> _parts = new List<string>();
            if (query.IndexOf("/") == -1) return new string[0];

            int start = 0;
            for(int i = 0; i < query.Length; i++)
            {
                int nextSlashIndex = -1;
                if(i < 2 && query[i] == '/' && query[i + 1] == '/')
                {
                    if (query.Length == 2) return new string[1] { "html" };
                    start += 2;  
                    nextSlashIndex = query.IndexOf("/", i + 2);
                    if(nextSlashIndex != -1)
                    {
                        _parts.Add(query.Substring(start, nextSlashIndex - start));

                        i += nextSlashIndex + 1;
                        start = i;
                    }
                    else
                    {
                        _parts.Add(query.Substring(start));
                        start = query.Length;
                        break;
                    }
                }
                if(i < query.Length && query[i] == '/')
                {
                    _parts.Add(query.Substring(start, i - start));
                    i += 1;
                    start = i;
                }                
            }
            if(start < query.Length && query.IndexOf('/', start) == -1)
            {
                if (query[start] == '[')
                {
                    _parts[_parts.Count - 1] += query.Substring(start - 1);
                }
                else
                {
                    _parts.Add(query.Substring(start));
                }
            }
            return _parts.ToArray();
        }
        
        private List<string> Traverse(Node node, string[] segments, int index)
        {
            
            List<string> matches = new List<string>();
            if (node == null) return matches;

            if (index + 1>= segments.Length)
            {
                if (!string.IsNullOrEmpty(node.Content))
                {
                    matches.Add(node.Content);
                }
                foreach (Node child in node.Children)
                {
                    matches.AddRange(Traverse(child, segments, index));
                }           
                return matches;
            }
            string segment = segments[index];

            if (segment.Contains("*"))
            {
                foreach (var child in node.Children)
                {
                    matches.AddRange(Traverse(child, segments, index + 1));
                }
            }
            else if (segment.Contains("@"))
            {
                int attributeStart = segment.IndexOf('@');
                int attributeEnd = segment.IndexOf('=');
                if (attributeStart != -1 && attributeEnd != -1)
                {
                    string attributeName = segment.Substring(attributeStart + 1, attributeEnd - attributeStart - 1);
                    string attributeValue = segment.Substring(attributeEnd + 2, segment.Length - attributeEnd - 4);

                    foreach (var child in node.Children)
                    {
                        if (child.Attributes.Any(attr => attr.Key == attributeName && attr.Value == attributeValue))
                        {
                            matches.AddRange(Traverse(child, segments, index + 1));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid attribute format");
                }
            }
            else if (segment.Contains("["))
            {
                int indexStart = segment.IndexOf("[");
                int indexEnd = segment.IndexOf("]");
                if (indexStart != -1 && indexEnd != -1)
                {
                    string indexValue = segment.Substring(indexStart + 1, indexEnd - indexStart - 1);
                    if (int.TryParse(indexValue, out int indexNum))
                    {
                        if (indexNum >= 0 && indexNum < node.Children.Count)
                        {
                            matches.AddRange(Traverse(node.Children[indexNum], segments, index + 1));
                        }
                        else
                        {
                            Console.WriteLine($"Invalid index: {indexNum}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Invalid index value: {indexValue}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index format");
                }
            }
            else
            {
                foreach (var child in node.Children)
                {
                    
                    if (segments[index + 1] == child.Tag)
                    {
                        matches.AddRange(Traverse(child, segments, index + 1));
                    }
                }
            }
            return matches;
        }
        
        //private NodeType DetermineType(Node root)
    }
}
 