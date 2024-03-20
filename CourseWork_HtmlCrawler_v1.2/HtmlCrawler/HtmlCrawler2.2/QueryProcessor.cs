using HtmlCrawler2._2.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HtmlCrawler2._2
{
    public class QueryProcessor 
    {
        private Node? root;

        public void OutputQuery(string fullQuery)
        {
            int indexOfSpace = 0;
            string actionName = "";
            string query = "";
            object? action;
            try
            {
                indexOfSpace = fullQuery.CustomIndexOf(" ");
                actionName = fullQuery.CustomSubstring(0, indexOfSpace).ToUpper();
                query = fullQuery.CustomSubstring(indexOfSpace + 1);
                
            if(!Enum.TryParse(typeof(QueryAction), actionName, out action))
                { throw new ArgumentOutOfRangeException(paramName: actionName); }
            switch(action)
            {
                case QueryAction.PRINT:
                    var result = ExecutePrintQuery(query);
                    foreach(var item in result)
                    {
                        Console.WriteLine(item);
                    }
                    break;

                default:
                    throw new InvalidQueryException("The query you provide is not in a correct format");
            }
            }
            catch (ArgumentOutOfRangeException AOREx)
            {
                Console.WriteLine("Invalid Argument.\nTry again!");
            }
            catch (InvalidQueryException IQEX)
            {
                Console.WriteLine(IQEX.Message.ToString());
            }
        }
        public void RootNodeSet(Node root)
        {
            this.root = root != null ? root : throw new Exception("Root node null error!");
        }

        private List<string> ExecutePrintQuery(string query)
        {
            List<string> result = new List<string>();
            string[] segments = SplitQuery(query);

            if(segments.Length > 0 && segments[0] != root.Tag)
            {
                Console.WriteLine("Root tag doesn't match");
                return result;
            }
            result = Traverse(root, segments, 1, 0);
            if(result == null || result.Count() == 0 ) { throw new ArgumentOutOfRangeException(); }
            return result;
        }
        private string[] SplitQuery(string query)
        {
            List<string> segments = new List<string>();

            int start = 0;
            for(int i = 0; i < query.Length; i++) 
            {
                if (query.Length < 2) return new string[0];
                if (query.CustomIndexOf("/") == -1) return new string[0];
                if (i < 2 && query[i] == '/' && 
                    query[i + 1] == '/' )
                {
                    start += 2;
                    
                    int nextSlash = query.CustomIndexOf("/", i + 2);
                    if(nextSlash != -1)
                    {
                        segments.Add(query.CustomSubstring(start, nextSlash - start));
                        i += nextSlash + 1;
                        start = i;
                    }
                    else
                    {
                        if(query.Length - start != 0)
                        {
                            segments.Add(query.CustomSubstring(start, query.Length - start));
                            i = query.Length;
                            start = i;
                            break;
                        }
                        else 
                        {
                            segments.Add((string)"html");
                            break;
                        }
                        
                    }

                }
                if (i < query.Length && ContainsSeparators(query, i))
                {
                    segments.Add(query.CustomSubstring(start, i - start));
                    i += 1;
                    start = i;
                }

            }
            
            if(start < query.Length && query.CustomIndexOf("/", start) == -1)
            {
                
                if (query[start] == '[')
                {
                    segments[segments.Count - 1] += query.CustomSubstring(start - 1);
                }
                else
                {

                    segments.Add(query.CustomSubstring(start));
                }
                
            }
            return segments.ToArray();
        }
        private bool ContainsSeparators(string query, int i)
        {
            return query[i] == '/';
        }

        private List<string> Traverse(Node node, string[] segments, int index, int depth)
        {
            if (segments.Length == 0) return null;
            List<string> matches = new List<string>();
            
            string indentation = new string(' ', depth * 2);
            if (index == segments.Length)
            {
                if (!string.IsNullOrEmpty(node.Content))
                {
                    matches.Add($"{indentation}{node.Content}");
                }
                if(node.Tag == segments[0])
                {
                    foreach (Node child in node.Children)
                    {
                        matches.AddRange(Traverse(child, segments, index, depth + 1));
                    }
                }
                return matches;
            }
            string segment = segments[index];

            if(segment.Contains("*"))
            {
                foreach(var child in node.Children)
                {
                    matches.AddRange(Traverse(child, segments, index + 1, depth + 1));
                }
            }
            else if(segment.Contains("@"))
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
                            matches.AddRange(Traverse(child, segments, index + 1, depth + 1));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid attribute format");
                }
            }
            else if(segment.Contains("["))
            {
                int indexStart = segment.CustomIndexOf("[");
                int indexEnd = segment.CustomIndexOf("]");
                if(indexStart != -1 && indexEnd != -1)
                {
                    string indexValue = segment.CustomSubstring(indexStart + 1, indexEnd - indexStart - 1);
                    if(int.TryParse(indexValue, out int indexNum))
                    {
                        if(indexNum >= 0 && indexNum < node.Children.Count)
                        {
                            matches.AddRange(Traverse(node.Children[indexNum], segments, index + 1, depth + 1));
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
                        matches.AddRange(Traverse(child, segments, index + 1, depth + 1));
                    }
                }
            }
            return matches;
        }
        //private List<string> PrintNode(Node node, int depth)
        //{
        //    List<string> output = new List<string>();
        //    string indentation = new string(' ', depth * 4);

        //    // Concatenate attributes into a single string
        //    if (node.Attributes.Count != 0)
        //    {
        //        string attributes = "";
        //        bool isFirst = true;
        //        foreach (var attr in node.Attributes)
        //        {
        //            if (isFirst)
        //            {
        //                attributes += $"{attr.Key}='{attr.Value}'";
        //                isFirst = false;
        //            }
        //            else
        //            {
        //                attributes += $" {attr.Key}='{attr.Value}'";
        //            }
        //        }

        //        output.Add($"{indentation}  <{node.Tag} {attributes}>");
        //    }
        //    else
        //    {
        //        output.Add($"{indentation}  <{node.Tag}>");
        //    }
        //    if (!string.IsNullOrEmpty(node.Content))
        //    {
        //        output.Add($"{indentation}      {node.Content}");
        //    }

        //    foreach (var child in node.Children)
        //    {
        //        output.AddRange(PrintNode(child, depth + 1));
        //    }

        //    output.Add($"{indentation}  </{node.Tag}>");

        //    return output;
        //}   
    }
}
