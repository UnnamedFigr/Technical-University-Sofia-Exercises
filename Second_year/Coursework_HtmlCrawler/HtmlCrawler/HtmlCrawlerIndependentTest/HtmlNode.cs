using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HtmlCrawlerIndependentTest
{
    public class HtmlNode
    {
        //internal HtmlAttributeCollection _attributes;
        internal HtmlNodeCollection _childnodes;
        internal HtmlNode _endnode;

        private bool _changed;
        internal string _innerhtml;
        internal int _innerlength;
        internal int _innerstartindex;
        private string _name;
        internal int _namelength;
        internal int _namestartindex;
        internal HtmlNode _nextnode;
        internal HtmlNodeType _nodetype;
        internal string _outerhtml;
        internal int _outerstartindex;
        internal int _outerlength;
        private string _optimizedName;
        internal HtmlDocument _ownerdocument;
        internal HtmlNode _parentnode;
        internal HtmlNode _prevnode;
        internal HtmlNode _prevwithsamename;
        internal bool _starttag;
        internal int _streamposition;

        /// <summary>
        /// Gets a collection of flags that define specific behaviors for specific element nodes.
        /// The table contains a DictionaryEntry list with the lowercase tag name as the Key, and a combination of HtmlElementFlags as the Value.
        /// </summary>
        static Dictionary<string, ElementFlag> ElementsFlags;

        /// <summary>
        /// Gets the name of the document node. It is actually defined as '#document'.
        /// </summary>
        public static readonly string HtmlNodeTypeNameDocument = "#document";

        /// <summary>
        /// Gets the name of a text node. It is actually defined as '#text'.
        /// </summary>
        public static readonly string HtmlNodeTypeNameText = "#text";


        static HtmlNode()
        {
            // tags whose content may be anything
            ElementsFlags = new Dictionary<string, ElementFlag>(StringComparer.OrdinalIgnoreCase);
            ElementsFlags.Add("script", ElementFlag.CData);
            ElementsFlags.Add("style", ElementFlag.CData);
            ElementsFlags.Add("noxhtml", ElementFlag.CData); // can't found.
            ElementsFlags.Add("textarea", ElementFlag.CData);
            ElementsFlags.Add("title", ElementFlag.CData);

            // tags that can not contain other tags
            ElementsFlags.Add("base", ElementFlag.Empty);
            ElementsFlags.Add("link", ElementFlag.Empty);
            ElementsFlags.Add("meta", ElementFlag.Empty);
            ElementsFlags.Add("isindex", ElementFlag.Empty);
            ElementsFlags.Add("hr", ElementFlag.Empty);
            ElementsFlags.Add("col", ElementFlag.Empty);
            ElementsFlags.Add("img", ElementFlag.Empty);
            ElementsFlags.Add("param", ElementFlag.Empty);
            ElementsFlags.Add("embed", ElementFlag.Empty);
            ElementsFlags.Add("frame", ElementFlag.Empty);
            ElementsFlags.Add("wbr", ElementFlag.Empty);
            ElementsFlags.Add("bgsound", ElementFlag.Empty);
            ElementsFlags.Add("spacer", ElementFlag.Empty);
            ElementsFlags.Add("keygen", ElementFlag.Empty);
            ElementsFlags.Add("area", ElementFlag.Empty);
            ElementsFlags.Add("input", ElementFlag.Empty);
            ElementsFlags.Add("basefont", ElementFlag.Empty);
            ElementsFlags.Add("source", ElementFlag.Empty);
            ElementsFlags.Add("form", ElementFlag.CanOverlap);

            //// they sometimes contain, and sometimes they don 't...
            //ElementsFlags.Add("option", ElementsFlag.Empty);

            // tag whose closing tag is equivalent to open tag:
            // <p>bla</p>bla will be transformed into <p>bla</p>bla
            // <p>bla<p>bla will be transformed into <p>bla<p>bla and not <p>bla></p><p>bla</p> or <p>bla<p>bla</p></p>
            //<br> see above
            ElementsFlags.Add("br", ElementFlag.Empty | ElementFlag.Closed);

        }
        public HtmlNode(HtmlNodeType nodeType, HtmlDocument ownerDocument, int index)
        {
            _nodetype = nodeType;
            _ownerdocument = ownerDocument;
            _outerstartindex = index;

            switch(nodeType)
            {
                case HtmlNodeType.Document:
                    SetName(HtmlNodeTypeNameDocument);
                    _endnode = this;
                    break;
                case HtmlNodeType.Text:
                    SetName(HtmlNodeTypeNameText);
                    _endnode = this;
                    break;

            }
        }
        public HtmlNodeCollection ChildNodes
        {
            get { return _childnodes ?? (_childnodes = new HtmlNodeCollection(this)); }
            set { _childnodes = value; }
        }
        public bool Closed { get { return _endnode != null; } }

        public HtmlNode EndNode
        {
            get => _endnode;
        }

        public HtmlNode FirstChild { get => !HasChildNodes ? null : _childnodes[0]; }

        public HtmlNode LastChild { get => !HasChildNodes ? null : _childnodes[_childnodes.Count - 1]; }
        public virtual string InnerHtml
        {
            get
            {
                if (_changed)
                {
                    UpdateHtml();
                    return _innerhtml;
                }

                if (_innerhtml != null)
                    return _innerhtml;

                if (_innerstartindex < 0 || _innerlength < 0)
                    return string.Empty;

                return _ownerdocument.Text.Substring(_innerstartindex, _innerlength);
            }
            set
            {
                //HtmlDocument doc = new HtmlDocument();
                //doc.LoadHtml(value);

                //RemoveAllChildren();
                //AppendChildren(doc.DocumentNode.ChildNodes);
            }
        }
        public virtual string InnerText
        {
            get
            {
                var sb = new StringBuilder();
                string name = this.Name;

                if (name != null)
                {
                    name = name.ToLowerInvariant();

                    bool isDisplayScriptingText = (name == "head" || name == "script" || name == "style");

                    InternalInnerText(sb, isDisplayScriptingText);
                }
                else
                {
                    InternalInnerText(sb, false);
                }

                return sb.ToString();
            }
        }

        internal void AppendDirectInnerText(StringBuilder sb)
        {
            if (_nodetype == HtmlNodeType.Text)
            {
                sb.Append(GetCurrentNodeText());
            }

            if (!HasChildNodes) return;

            foreach (HtmlNode node in ChildNodes)
            {
                sb.Append(node.GetCurrentNodeText());
            }
            return;
        }

        internal void AppendInnerText(StringBuilder sb, bool isShowHideInnerText)
        {
            if (_nodetype == HtmlNodeType.Text)
            {
                sb.Append(GetCurrentNodeText());
            }

            if (!HasChildNodes || (!isShowHideInnerText)) return;

            foreach (HtmlNode node in ChildNodes)
            {
                node.AppendInnerText(sb, isShowHideInnerText);
            }
        }

        public virtual string GetDirectInnerText()
        {
                if (HasChildNodes)
                {
                    StringBuilder sb = new StringBuilder();
                    AppendDirectInnerText(sb);
                    return sb.ToString();
                }

            if (_nodetype == HtmlNodeType.Text)
                return ((HtmlTextNode)this).Text;

            // Don't display comment or comment child nodes
            if (_nodetype == HtmlNodeType.Comment)
                return "";

            if (!HasChildNodes)
                return string.Empty;

            var s = new StringBuilder();
            foreach (HtmlNode node in ChildNodes)
            {
                if (node._nodetype == HtmlNodeType.Text)
                {
                    s.Append(((HtmlTextNode)node).Text);
                }
            }

            return s.ToString();

        }

        internal string GetCurrentNodeText()
        {
            if (_nodetype == HtmlNodeType.Text)
            {
                HtmlNode nd = new HtmlTextNode(this.OwnerDocument, _outerstartindex);
                
                string s = ((HtmlTextNode)nd).Text;

                if (ParentNode.Name != "pre")
                {
                    s = s.Replace("\n", "").Replace("\r", "").Replace("\t", "");
                }

                return s;
            }

            return "";
        }

        public static bool CanOverlapElement(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            ElementFlag flag;
            if (!ElementsFlags.TryGetValue(name, out flag))
            {
                return false;
            }

            return (flag & ElementFlag.CanOverlap) != 0;
        }

        internal virtual void InternalInnerText(StringBuilder sb, bool isDisplayScriptingText)
        {
            if (HasChildNodes)
            {
                AppendInnerText(sb, isDisplayScriptingText);
                return;
            }

            sb.Append(GetCurrentNodeText());


            if (_nodetype == HtmlNodeType.Text)
            {
                sb.Append(((HtmlTextNode)this).Text);
                return;
            }

            // Don't display comment or comment child nodes
            if (_nodetype == HtmlNodeType.Comment)
            {
                return;
            }

            if (!HasChildNodes || (!isDisplayScriptingText))
            {
                return;
            }

            foreach (HtmlNode node in ChildNodes)
                node.InternalInnerText(sb, isDisplayScriptingText);

        }
        public static bool IsCDataElement(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            ElementFlag flag;
            if (!ElementsFlags.TryGetValue(name, out flag))
            {
                return false;
            }

            return (flag & ElementFlag.CData) != 0;
        }

        public static bool IsClosedElement(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            ElementFlag flag;
            if (!ElementsFlags.TryGetValue(name, out flag))
                return false;
            return (flag & ElementFlag.Closed) != 0;
        }
        public static bool IsEmptyElement(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (name.Length == 0)
            {
                return true;
            }
            // <!DOCTYPE ...
            if ('!' == name[0])
            {
                return true;
            }
            ElementFlag flag;
            if (!ElementsFlags.TryGetValue(name, out flag))
            {
                return false;
            }

            return (flag & ElementFlag.Empty) != 0;
        }

        //TextLengths
        public int OuterStartIndex
        {
            get { return _outerstartindex; }
        }
        public int InnerLength
        {
            get { return InnerHtml.Length; }
        }
        public int OuterLength
        {
            get { return OuterHtml.Length; }
        }

        public bool HasChildNodes
        {
            get 
            {
                if (ChildNodes.Count > 0) return true;
                return false;
            }
        }
        public string Name
        {
            get
            {
                if(_optimizedName == null)
                {
                    if(_name == null)
                    {
                        SetName(_ownerdocument.Text.Substring(_namestartindex, _namelength));
                    }
                    if (_name == null)
                        _name = string.Empty;
                    else
                        _optimizedName = _name.ToLowerInvariant();
                }
                return _optimizedName;
            }

            set 
            {
                SetName(value);
                SetChanged();
            }
        }

        public HtmlNodeType NodeType { get => _nodetype; internal set => _nodetype = value; }

        public string OriginalName { get => _name; }
        
        public virtual string OuterHtml
        {
            get
            {
                if (_changed)
                {
                    UpdateHtml();
                    return _outerhtml;
                }

                if (_outerhtml != null)
                {
                    return _outerhtml;
                }

                if (_outerstartindex < 0 || _outerlength < 0)
                {
                    return string.Empty;
                }

                return _ownerdocument.Text.Substring(_outerstartindex, _outerlength);
            }
        }

        /// <summary>
        /// Gets the <see cref="HtmlDocument"/> to which this node belongs.
        /// </summary>
        public HtmlDocument OwnerDocument {get => _ownerdocument; internal set => _ownerdocument = value; }

        public HtmlNode ParentNode { get => _parentnode; internal set => _parentnode = value; }
        public HtmlNode PreviousSibling { get => _prevnode; internal set => _prevnode = value; }

        public string XPath
        {
            get
            {
                string basePath = (ParentNode.XPath == null || ParentNode.NodeType == HtmlNodeType.Document) 
                                    ? "/" 
                                    : ParentNode.XPath + "/";
                return basePath + GetRelativeXpath();
                
            }
        }

        //public int Depth { get; set; }
        public void SetName(string name)
        {
            _name = name;
            _optimizedName = null;
        }

        internal void SetChanged()
        {
            _changed = true;
            if(ParentNode != null)
            {
                ParentNode.SetChanged();
            }
        }
        public void SetParent(HtmlNode node)
        {
            if (node == null)
                return;
            ParentNode = node;
        }

        internal void CloseNode(HtmlNode endnode, int level = 0)
        {
            if (_childnodes != null)
            {
                foreach (HtmlNode child in _childnodes)
                {
                    if (child.Closed)
                        continue;

                    // create a fake closer node
                    HtmlNode close = new HtmlNode(NodeType, _ownerdocument, -1);
                    close._endnode = close;
                    child.CloseNode(close, level + 1);
                }
            }
            if (!Closed)
            {
                _endnode = endnode;

                if (_ownerdocument.Openednodes != null)
                    _ownerdocument.Openednodes.Remove(_outerstartindex);

                HtmlNode self = null;// = Utilities.GetDictionaryValueOrDefault(_ownerdocument.Lastnodes, Name);
                if (self == this)
                {
                    _ownerdocument.Lastnodes.Remove(Name);
                    _ownerdocument.UpdateLastParentNode();


                    if (_starttag && !String.IsNullOrEmpty(Name))
                    {
                        //UpdateLastNode();
                    }
                }

                if (endnode == this)
                    return;

                // create an inner section
                _innerstartindex = _outerstartindex + _outerlength;
                _innerlength = endnode._outerstartindex - _innerstartindex;

                // update full length
                _outerlength = (endnode._outerstartindex + endnode._outerlength) - _outerstartindex;
            }
        }

        //Private Methods
        private string GetRelativeXpath()
        {
            if (ParentNode == null)
                return Name;
            if (NodeType == HtmlNodeType.Document)
                return string.Empty;

            int i = 1;
            foreach (HtmlNode node in ParentNode.ChildNodes)
            {
                if (node.Name != Name) continue;

                if (node == this)
                    break;

                i++;
            }

            return Name + "[" + i + "]";
        }
        
        public void WriteContentTo(TextWriter outText, int level = 0)
        {
            if (_childnodes == null)
            {
                return;
            }

            foreach (HtmlNode node in _childnodes)
            {
                node.WriteTo(outText, level + 1);
            }
        }
        public string WriteContentTo()
        {
            StringWriter sw = new StringWriter();
            WriteContentTo(sw);
            sw.Flush();
            return sw.ToString();
        }

        public virtual void WriteTo(TextWriter outText, int level = 0)
        {
            string html;
            switch(_nodetype)
            {
                case HtmlNodeType.Document:
                    if (_ownerdocument.DocumentNode.HasChildNodes)
                    {
                        int rootnodes =_ownerdocument.DocumentNode._childnodes.Count;
                        if(rootnodes > 1)
                        {
                            outText.Write("<span>");
                            WriteContentTo(outText, level);
                            outText.Write("</span>");
                            
                            break;
                        }
                    }
                    WriteContentTo(outText, level);
                    break;
                case HtmlNodeType.Text:
                    
                    break;
            }
        }
        public string WriteTo()
        {
            using (StringWriter sw = new StringWriter())
            {
                WriteTo(sw);
                sw.Flush();
                return sw.ToString();
            }
        }

        private void UpdateHtml()
        {
            _innerhtml = WriteContentTo();
            _outerhtml = WriteTo();
            _changed = false;
        }

        public IEnumerable<HtmlNode> Ancestors(string name)
        {
            for (HtmlNode n = ParentNode; n != null; n = n.ParentNode)
                if (n.Name == name)
                    yield return n;
        }

        public IEnumerable<HtmlNode> AncestorsAndSelf()
        {
            for (HtmlNode n = this; n != null; n = n.ParentNode)
                yield return n;
        }
        public IEnumerable<HtmlNode> AncestorsAndSelf(string name)
        {
            for (HtmlNode n = this; n != null; n = n.ParentNode)
                if (n.Name == name)
                    yield return n;
        }
        public HtmlNode AppendChild(HtmlNode newChild)
        {
            if (newChild == null)
            {
                throw new ArgumentNullException("newChild");
            }

            ChildNodes.Append(newChild);

            var parentnode = _parentnode;
            HtmlDocument lastOwnerDocument = null;
            while (parentnode != null)
            {
                if (parentnode.OwnerDocument != lastOwnerDocument)
                {
                    parentnode.OwnerDocument.SetIdForNode(newChild, newChild.GetId());
                    parentnode.SetChildNodesId(newChild);
                    lastOwnerDocument = parentnode.OwnerDocument;
                }

                parentnode = parentnode._parentnode;
            }


            SetChanged();
            return newChild;
        }
    }
}
