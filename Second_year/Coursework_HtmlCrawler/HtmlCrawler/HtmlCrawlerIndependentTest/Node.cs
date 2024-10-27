using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HtmlCrawlerIndependentTest
{
    public class Attribute
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public Attribute() { }
        public Attribute(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
    public class Node
    {
        internal NodeCollection _childnodes;
        internal Node _prevnode;
        internal Node _nextnode;
        internal Node _parentnode;
        internal bool _changed;

        public Node(string tag)
        {
            Tag = tag;
            Attributes = new List<Attribute>();        
            Content = "";
            this.isSelfClosing = false;
        }
<<<<<<< HEAD

        public string Tag { get; set; }
        public string Content { get; set; }
        public List<Attribute> Attributes { get; set; }
        public NodeCollection ChildNodes 
        {
            get
            {
                return _childnodes ?? (_childnodes = new NodeCollection(_parentnode));
            }
        }
        public bool isSelfClosing { get; set; }

        private bool IsSingleElementNode()
        {
            int count = 0;
            var element = ChildNodes[0];

            while (element != null)
            {
                if (element.Content != "\r\n")
                    count++;

                element = element._nextnode;
            }

            return count <= 1 ? true : false;
        }
        public IEnumerable<Node> Descendants()
        {
            // DO NOT REMOVE, the empty method is required for Fizzler third party library
            return Descendants(0);
        }

        /// <summary>
        /// Gets all Descendant nodes in enumerated list
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Node> Descendants(int level)
        {

            foreach (Node node in ChildNodes)
            {
                yield return node;

                foreach (Node descendant in node.Descendants(level + 1))
                {
                    yield return descendant;
                }
            }
        }

        /// <summary>
        /// Get all descendant nodes with matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Node> Descendants(string name)
        {
            foreach (Node node in Descendants())
                if (String.Equals(node.Tag, name, StringComparison.OrdinalIgnoreCase))
                    yield return node;
        }

        public Node Element(string name)
        {
            foreach (Node node in ChildNodes)
                if (node.Tag == name)
                    return node;
            return null;
        }

        /// <summary>
        /// Gets matching first generation child nodes matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<Node> Elements(string name)
        {
            foreach (Node node in ChildNodes)
                if (node.Tag == name)
                    yield return node;
        }
=======
        

>>>>>>> a2b61791e2931babd8934849aaf9b5be242194ad
    }
}
