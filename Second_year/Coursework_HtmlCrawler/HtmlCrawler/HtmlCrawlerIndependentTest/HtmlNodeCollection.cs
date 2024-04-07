using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace HtmlCrawlerIndependentTest
{
    public class HtmlNodeCollection : IList<HtmlNode>
    {
        private readonly HtmlNode _parentNode;
        private readonly List<HtmlNode> _items = new List<HtmlNode>();

        public HtmlNodeCollection(HtmlNode parentNode) => _parentNode = parentNode;
        
        public HtmlNode ParentNode
        {
            get 
            {
                return _parentNode; 
            }
        }

        public int this[HtmlNode node]
        {
            get
            {
                int index = GetNodeIndex(node);
                if(index == -1)
                {
                    throw new ArgumentOutOfRangeException("node", "Node \" \" was not found.");
                }
                return index;
            }
        }

        public HtmlNode this[string nodeName] 
        {
            get
            {
                for(int i = 0; i < _items.Count; i++)
                {
                    if(string.Equals(_items[i].Name, nodeName, StringComparison.OrdinalIgnoreCase)) 
                        return _items[i];
                }
                return null;
            }
        }
        #region IList<HtmlNode> methods
        public int Count { get => _items.Count; }

        public bool IsReadOnly { get => false; }

        public HtmlNode this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void Add(HtmlNode item)
        {
            Add(item, true);
        }
        public void Add(HtmlNode item, bool setParent)
        {
            _items.Add(item);
            if(setParent)
            {
                item.ParentNode = _parentNode;
            }
        }

        public void Clear()
        {
            foreach(HtmlNode node in _items)
            {
                node.ParentNode = null;
                //node.NextSibling = null;
                //node.PreviousSibling = null;
            }
            _items.Clear();
        }

        public bool Contains(HtmlNode item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(HtmlNode[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<HtmlNode> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public int IndexOf(HtmlNode item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, HtmlNode item)
        {
            HtmlNode prev = null;
            HtmlNode next = null;

            if (index > 0)
                prev = _items[index - 1];
            if(index < _items.Count)
                next = _items[index];
            _items.Insert(index, item);

            if(prev != null)
            {
                if(item == prev)
                {
                    throw new InvalidProgramException("Unexpected Error");
                }

                prev._nextnode = item;
            }
            if(next != null)
            {
                next._prevnode = item;
            }
            item._prevnode = prev;
            if (item == next)
            {
                throw new InvalidProgramException("Unexpected Error");
            }
            item._nextnode = next;

        }

        public bool Remove(HtmlNode item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            HtmlNode prev = null;
            HtmlNode next = null;
            HtmlNode _oldnode = _items[index];
            HtmlNode parentNode = _parentNode ?? _oldnode.ParentNode;

            if(index > 0)
            {
                prev = _items[index - 1];
            }
            if(index == _items.Count)
            {
                next = _items[index + 1];
            }
            _items.RemoveAt(index);

            if(prev != null)
            {
                if(prev == next)
                {
                    throw new InvalidProgramException("Unexpected Error");
                }
                prev._nextnode = next;
            }
            if(next != null)
            {
                next._prevnode = prev;
            }
            _oldnode._prevnode = null;
            _oldnode._nextnode = null;
            _oldnode._parentNode = null;

            if(_parentNode != null)
            {
                parentNode.SetChanged();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        //These are the public methods
        public void Append(HtmlNode item)
        {
            HtmlNode last = null;
            if(_items.Count > 0)
            {
                last = _items[_items.Count - 1];
            }
            _items.Add(item);
            item._nextnode = null;
            item._prevnode = last;
            item.SetParent(_parentNode);
            if (last == null) return;
            if (last == item) throw new InvalidProgramException("Unexpected Error");

            last._nextnode = item;
        }

        public void Prepend(HtmlNode node)
        {
            HtmlNode first = null;
            if (_items.Count > 0)
                first = _items[0];

            _items.Insert(0, node);

            if (node == first)
                throw new InvalidProgramException("Unexpected error.");
            node._nextnode = first;
            node._prevnode = null;
            node.SetParent(_parentNode);

            if (first != null)
                first._prevnode = node;
        }

        public bool Remove(int index) 
        {
            RemoveAt(index);
            return true;
        }
        public void Replace(int index, HtmlNode node)
        {
            HtmlNode next = null;
            HtmlNode prev = null;
            HtmlNode oldnode = _items[index];

            if (index > 0)
                prev = _items[index - 1];

            if (index < (_items.Count - 1))
                next = _items[index + 1];

            _items[index] = node;

            if (prev != null)
            {
                if (node == prev)
                    throw new InvalidProgramException("Unexpected error.");
                prev._nextnode = node;
            }

            if (next != null)
                next._prevnode = node;

            node._prevnode = prev;

            if (next == node)
                throw new InvalidProgramException("Unexpected error.");

            node._nextnode = next;
            node.SetParent(_parentNode);

            oldnode._prevnode = null;
            oldnode._nextnode = null;
            oldnode._parentNode = null;
        }
        public int GetNodeIndex(HtmlNode node)
        {
            for (int i = 0; i < _items.Count; i++)
                if (_items[i] == node)
                    return i;

            return -1;
        }

        //public IEnumerable<HtmlNode> Descendants()
        //{
        //    foreach (HtmlNode item in _items)
        //        foreach (HtmlNode n in item.Descendants())
        //            yield return n;
        //}


        //public IEnumerable<HtmlNode> Descendants(string name)
        //{
        //    foreach (HtmlNode item in _items)
        //        foreach (HtmlNode n in item.Descendants(name))
        //            yield return n;
        //}

        /// <summary>
        /// Gets all first generation elements in collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HtmlNode> Elements()
        {
            foreach (HtmlNode item in _items)
                foreach (HtmlNode n in item.ChildNodes)
                    yield return n;
        }

        /// <summary>
        /// Gets all first generation elements matching name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //public IEnumerable<HtmlNode> Elements(string name)
        //{
        //    foreach (HtmlNode item in _items)
        //        foreach (HtmlNode n in item.Elements(name))
        //            yield return n;
        //}

        /// <summary>
        /// All first generation nodes in collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<HtmlNode> Nodes()
        {
            foreach (HtmlNode item in _items)
                foreach (HtmlNode n in item.ChildNodes)
                    yield return n;
        }
    }
}
#endregion