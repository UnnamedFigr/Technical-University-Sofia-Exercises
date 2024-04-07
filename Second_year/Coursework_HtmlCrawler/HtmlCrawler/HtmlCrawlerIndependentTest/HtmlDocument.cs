using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HtmlCrawlerIndependentTest
{
    public class HtmlDocument
    {

        private int _c;
        private HtmlAttribute _currentattribute;
        private HtmlNode _currentnode;
        private HtmlNode _documentnode;
        private HtmlNode _lastparentnode;
        private int _line;
        private int _lineposition;
        internal Dictionary<string, HtmlNode> Lastnodes = new Dictionary<string, HtmlNode>();
        internal Dictionary<int, HtmlNode> Openednodes;
        private ParseState _state;
        private ParseState _oldstate;


        public string Text;
        public HtmlDocument() { }

        //Gets the root node of the document
        public HtmlNode DocumentNode { get => _documentnode; }
        public string ParsedText { get => Text; }

        public static bool IsWhiteSpace(int c)
        {
            if ((c == 10) || (c == 13) || (c == 32) || (c == 9))
            {
                return true;
            }

            return false;
        }

        public HtmlTextNode CreateTextNode()
        {
            return (HtmlTextNode)CreateNode(HtmlNodeType.Text);
        }

        public HtmlTextNode CreateTextNode(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            HtmlTextNode t = CreateTextNode();
            t.Text = text;
            return t;
        }

        internal HtmlNode CreateNode(HtmlNodeType type)
        {
            return CreateNode(type, -1);
        }

        internal HtmlNode CreateNode(HtmlNodeType type, int index)
        {
            switch (type)
            {
                case HtmlNodeType.Text:
                    return new HtmlTextNode(this, index);

                default:
                    return new HtmlNode(type, this, index);
            }
        }
        internal void UpdateLastParentNode()
        {
            do
            {
                if (_lastparentnode.Closed)
                    _lastparentnode = _lastparentnode.ParentNode;
            } while ((_lastparentnode != null) && (_lastparentnode.Closed));

            if (_lastparentnode == null)
                _lastparentnode = _documentnode;
        }

        //private void CloseCurrentNode()
        //{
        //    if (_currentnode.Closed) // text or document are by def closed
        //        return;

        //    bool error = false;
        //    HtmlNode prev = Utilities.GetDictionaryValueOrDefault(Lastnodes, _currentnode.Name);

        //    // find last node of this kind
        //    if (prev == null)
        //    {
        //        if (HtmlNode.IsClosedElement(_currentnode.Name))
        //        {
        //            // </br> will be seen as <br>
        //            _currentnode.CloseNode(_currentnode);

        //            // add to parent node
        //            if (_lastparentnode != null)
        //            {
        //                HtmlNode foundNode = null;
        //                Stack<HtmlNode> futureChild = new Stack<HtmlNode>();

        //                if (!_currentnode.Name.Equals("br"))
        //                {
        //                    for (HtmlNode node = _lastparentnode.LastChild; node != null; node = node.PreviousSibling)
        //                    {
        //                        // br node never can contains other nodes.
        //                        if ((node.Name == _currentnode.Name) && (!node.HasChildNodes))
        //                        {
        //                            foundNode = node;
        //                            break;
        //                        }

        //                        futureChild.Push(node);
        //                    }
        //                }


        //                if (foundNode != null)
        //                {
        //                    while (futureChild.Count != 0)
        //                    {
        //                        HtmlNode node = futureChild.Pop();
        //                        _lastparentnode.RemoveChild(node);
        //                        foundNode.AppendChild(node);
        //                    }
        //                }
        //                else
        //                {
        //                    _lastparentnode.AppendChild(_currentnode);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            // node has no parent
        //            // node is not a closed node

        //            if (HtmlNode.CanOverlapElement(_currentnode.Name))
        //            {
        //                // this is a hack: add it as a text node
        //                HtmlNode closenode = CreateNode(HtmlNodeType.Text, _currentnode._outerstartindex);
        //                closenode._outerlength = _currentnode._outerlength;
        //                ((HtmlTextNode)closenode).Text = ((HtmlTextNode)closenode).Text.ToLowerInvariant();
        //                if (_lastparentnode != null)
        //                {
        //                    _lastparentnode.AppendChild(closenode);
        //                }
        //            }
        //            else
        //            {
        //                if (HtmlNode.IsEmptyElement(_currentnode.Name))
        //                {
        //                    AddError(
        //                        HtmlParseErrorCode.EndTagNotRequired,
        //                        _currentnode._line, _currentnode._lineposition,
        //                        _currentnode._streamposition, _currentnode.OuterHtml,
        //                        "End tag </" + _currentnode.Name + "> is not required");
        //                }
        //                else
        //                {
        //                    // node cannot overlap, node is not empty
        //                    AddError(
        //                        HtmlParseErrorCode.TagNotOpened,
        //                        _currentnode._line, _currentnode._lineposition,
        //                        _currentnode._streamposition, _currentnode.OuterHtml,
        //                        "Start tag <" + _currentnode.Name + "> was not found");
        //                    error = true;
        //                }
        //            }
        //        }
        //    }
        //    else
        //    {
        //        if (OptionFixNestedTags)
        //        {
        //            if (FindResetterNodes(prev, GetResetters(_currentnode.Name)))
        //            {
        //                AddError(
        //                    HtmlParseErrorCode.EndTagInvalidHere,
        //                    _currentnode._line, _currentnode._lineposition,
        //                    _currentnode._streamposition, _currentnode.OuterHtml,
        //                    "End tag </" + _currentnode.Name + "> invalid here");
        //                error = true;
        //            }
        //        }

        //        if (!error)
        //        {
        //            Lastnodes[_currentnode.Name] = prev._prevwithsamename;
        //            prev.CloseNode(_currentnode);
        //        }
        //    }


        //    // we close this node, get grandparent
        //    if (!error)
        //    {
        //        if ((_lastparentnode != null) &&
        //            ((!HtmlNode.IsClosedElement(_currentnode.Name)) ||
        //             (_currentnode._starttag)))
        //        {
        //            UpdateLastParentNode();
        //        }
        //    }
        //}
        private HtmlNode FindResetterNode(HtmlNode node, string name)
        {
            HtmlNode? resetter;
            if (!Lastnodes.TryGetValue(name, out resetter))
                resetter = default(HtmlNode);
                
            if (resetter == null)
                return null;

            if (resetter.Closed)
                return null;

            if (resetter._streamposition < node._streamposition)
            {
                return null;
            }

            return resetter;
        }

        private bool FindResetterNodes(HtmlNode node, string[] names)
        {
            if (names == null)
                return false;

            for (int i = 0; i < names.Length; i++)
            {
                if (FindResetterNode(node, names[i]) != null)
                    return true;
            }

            return false;
        }

        private string CurrentNodeName()
        {
            return Text.Substring(_currentnode._namestartindex, _currentnode._namelength);
        }

        private enum ParseState
        {
            Text,
            WhichTag,
            Tag,
            BetweenAttributes,
            EmptyTag,
            AttributeName,
            AttributeBeforeEquals,
            AttributeAfterEquals,
            AttributeValue,            
            QuotedAttributeValue,
            ServerSideCode,
            PcData
        }
    }
}
