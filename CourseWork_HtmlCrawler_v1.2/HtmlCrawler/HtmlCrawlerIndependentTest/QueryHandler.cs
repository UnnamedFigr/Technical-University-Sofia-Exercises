using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HtmlCrawlerIndependentTest
{
    public enum NodeType
    {
        Tag, 
        Content
    }
    public class QueryHandler
    {
        private string action;
        private Node? _root;

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
            string[] _queryParts = SplitQuery(query);
            foreach (var str in ExecutePrintQuery(_queryParts))
            {
                Console.WriteLine(str);
            }
        }
         private List<string> ExecutePrintQuery(string[] queryParts)
        {
            List<string> result = new List<string>();
            //result = Traverse(_root,queryParts);
            DFS(_root, queryParts, result);
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
        private void DFS(Node node, string[] _query, List<string> results)
        {
            if (node == null) return;

            if (node.Content != null && _query[_query.Length - 1] == node.Tag)
            {
                results.Add(node.Content);
            }
            for (int c = 0; c < node.Children.Count; c++)
            {
                DFS(node.Children[c], _query, results);
            }
            return;
            /*
            if (_query.Length == 0) return;
            
            if (index == _query.Length)
            {
                if (!string.IsNullOrEmpty(node.Content))
                {
                    results.Add(node.Content);
                }
                if (node.Tag == _query[0])
                {
                    foreach (Node child in node.Children)
                    {
                        results.AddRange(Traverse(child, _query, index, depth + 1));
                    }
                }
                return;
            }
            string segment = _query[index];

            if (segment.Contains("*"))
            {
                foreach (var child in node.Children)
                {
                    results.AddRange(Traverse(child, _query, index + 1, depth + 1));
                }
            }
            else if (segment.Contains("@"))
            {
                int attributeStart = segment.IndexOf('@');
                int attributeEnd = segment.IndexOf('=');
                if (attributeStart != -1 && attributeEnd != -1)
                {
                    string attributeName = segment.CustomSubstring(attributeStart + 1, attributeEnd - attributeStart - 1);
                    string attributeValue = segment.CustomSubstring(attributeEnd + 2, segment.Length - attributeEnd - 4);

                    foreach (var child in node.Children)
                    {
                        if (child.Attributes.Any(attr => attr.Key == attributeName && attr.Value == attributeValue))
                        {
                            results.AddRange(Traverse(child, _query, index + 1, depth + 1));
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
                int indexStart = segment.CustomIndexOf("[");
                int indexEnd = segment.CustomIndexOf("]");
                if (indexStart != -1 && indexEnd != -1)
                {
                    string indexValue = segment.CustomSubstring(indexStart + 1, indexEnd - indexStart - 1);
                    if (int.TryParse(indexValue, out int indexNum))
                    {
                        if (indexNum >= 0 && indexNum < node.Children.Count)
                        {
                            results.AddRange(Traverse(node.Children[indexNum], _query, index + 1, depth + 1));
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
                    if (child.Tag == segment)
                    {
                        results.AddRange(Traverse(child, _query, index + 1, depth + 1));
                    }
                }
            }
            return results;
            */
        }

        //private List<string> Traverse(Node node, string[] queryParts)
        //{
        //    List<string> result = new List<string>();
            
        //    if (queryParts[0] == _root.Tag &&
        //        queryParts.Count() == 1) 
        //    {
        //        queryParts = Array.Empty<string>();
        //    }
        //    TraverseNode(node, queryParts,result);
        //    return result;
        //}
        //private void TraverseNode(Node node, string[] queryParts, List<string> result)
        //{
        //    if(node == null)
        //    {
        //        return;
        //    }

        //    if(MatchesQuery(node, queryParts))
        //    {
        //        result.Add(node.Content);
        //    }
        //    foreach(Node child in node.Children)
        //    {
        //        TraverseNode(child, queryParts, result);
        //    }
        
        //private static bool MatchesQuery(Node node, string[] queryParts)
        //{
        //    if (queryParts.Count() == 0)
        //    {
        //        return true; // No query provided, match everything
        //    }

        //    // Split the query into _query
        //    string[] _query = queryParts;

        //    // Process each segment of the query
        //    foreach (string segment in _query)
        //    {
        //        if (segment == "*")
        //        {
        //            continue; // Wildcard: Match any tag
        //        }
        //        else if (segment.StartsWith("@"))
        //        {
        //            // Attribute query
        //            string[] attributeParts = segment.Substring(1).Split('=');
        //            if (attributeParts.Length == 2)
        //            {
        //                // Attribute name and value provided
        //                string attributeName = attributeParts[0];
        //                string attributeValue = attributeParts[1].Trim('\"', '\'');
        //                if (node.Attributes.Any(attr => attr.Key == attributeName && attr.Value == attributeValue))
        //                {
        //                    continue; // Match found
        //                }
        //                else
        //                {
        //                    return false; // No match found
        //                }
        //            }
        //            else if (attributeParts.Length == 1)
        //            {
        //                // Only attribute name provided
        //                string attributeName = attributeParts[0];
        //                if (node.Attributes.Any(attr => attr.Key == attributeName))
        //                {
        //                    continue; // Match found
        //                }
        //                else
        //                {
        //                    return false; // No match found
        //                }
        //            }
        //            else
        //            {
        //                // Invalid attribute query
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            // Tag name query
        //            if (node.Tag != segment)
        //            {
        //                return false; // Tag name does not match
        //            }
        //        }
        //    }
        //    return true; // All _query matched
        //}
    }
}
 