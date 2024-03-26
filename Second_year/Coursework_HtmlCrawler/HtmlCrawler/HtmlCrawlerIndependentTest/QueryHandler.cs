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
        }
    }
}
 