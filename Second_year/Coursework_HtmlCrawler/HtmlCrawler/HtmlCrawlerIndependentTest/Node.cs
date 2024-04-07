using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Tag { get; set; }
        public string Content { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<Node> Children { get; set; }
        public bool isSelfClosing { get; set; }
        public Node(string tag)
        {
            Tag = tag;
            Attributes = new List<Attribute>();
            Children = new List<Node>();
            Content = "";
            this.isSelfClosing = false;
        }
        

    }
}
