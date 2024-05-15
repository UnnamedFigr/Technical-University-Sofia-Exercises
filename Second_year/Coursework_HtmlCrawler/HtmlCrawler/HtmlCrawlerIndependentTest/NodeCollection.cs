using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HtmlCrawlerIndependentTest
{
    public class NodeCollection : IList<Node>
    {
        private readonly Node _parentnode;
        private readonly List<Node> _items = new List<Node>();

        public NodeCollection(Node parentNode) => _parentnode = parentNode;

        public Node ParentNode
        {
            get
            {
                return _parentnode;
            }
        }

        public int this[Node node]
        {
            get
            {
                int index = GetNodeIndex(node);
                if (index == -1)
                {
                    throw new ArgumentOutOfRangeException("node", "Node \" \" was not found.");
                }
                return index;
            }
        }

        public Node this[string nodeName]
        {
            get
            {
                for (int i = 0; i < _items.Count; i++)
                {
                    if (string.Equals(_items[i].Tag, nodeName, StringComparison.OrdinalIgnoreCase))
                        return _items[i];
                }
                return null;
            }
        }
        #region IList<Node> methods
        public int Count { get => _items.Count; }

        public bool IsReadOnly { get => false; }

        public Node this[int index]
        {
            get => _items[index];
            set => _items[index] = value;
        }

        public void Add(Node item)
        {
            Add(item, true);
        }
        public void Add(Node item, bool setParent)
        {
            _items.Add(item);
            if (setParent)
            {
                item._parentnode = _parentnode;
            }
        }

        public void Clear()
        {
            foreach (Node node in _items)
            {
                node._parentnode = null;
                node._nextnode = null;
                node._prevnode= null;
            }
            _items.Clear();
        }

        public bool Contains(Node item)
        {
            return _items.Contains(item);
        }

        public void CopyTo(Node[] array, int arrayIndex)
        {
            _items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Node> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        public int IndexOf(Node item)
        {
            return _items.IndexOf(item);
        }

        public void Insert(int index, Node item)
        {
            Node prev = null;
            Node next = null;

            if (index > 0)
                prev = _items[index - 1];
            if (index < _items.Count)
                next = _items[index];
            _items.Insert(index, item);

            if (prev != null)
            {
                if (item == prev)
                {
                    throw new InvalidProgramException("Unexpected Error");
                }

                prev._nextnode = item;
            }
            if (next != null)
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

        public bool Remove(Node item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            Node prev = null;
            Node next = null;
            Node _oldnode = _items[index];
            Node parentNode = _parentnode ?? _oldnode._parentnode;

            if (index > 0)
            {
                prev = _items[index - 1];
            }
            if (index == _items.Count)
            {
                next = _items[index + 1];
            }
            _items.RemoveAt(index);

            if (prev != null)
            {
                if (prev == next)
                {
                    throw new InvalidProgramException("Unexpected Error");
                }
                prev._nextnode = next;
            }
            if (next != null)
            {
                next._prevnode = prev;
            }
            _oldnode._prevnode = null;
            _oldnode._nextnode = null;
            _oldnode._parentnode = null;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        //These are the public methods
        public void Append(Node item)
        {
            Node last = null;
            if (_items.Count > 0)
            {
                last = _items[_items.Count - 1];
            }
            _items.Add(item);
            item._nextnode = null;
            item._prevnode = last;
            item._parentnode = _parentnode;
            if (last == null) return;
            if (last == item) throw new InvalidProgramException("Unexpected Error");
            last._nextnode = item;
        }

        public void Prepend(Node node)
        {
            Node first = null;
            if (_items.Count > 0)
                first = _items[0];

            _items.Insert(0, node);

            if (node == first)
                throw new InvalidProgramException("Unexpected error.");
            node._nextnode = first;
            node._prevnode = null;
            node._parentnode = _parentnode;

            if (first != null)
                first._prevnode = node;
        }

        public bool Remove(int index)
        {
            RemoveAt(index);
            return true;
        }
        public void Replace(int index, Node node)
        {
            Node next = null;
            Node prev = null;
            Node oldnode = _items[index];

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
            node._parentnode = _parentnode;

            oldnode._prevnode = null;
            oldnode._nextnode = null;
            oldnode._parentnode = null;
        }
        public int GetNodeIndex(Node node)
        {
            for (int i = 0; i < _items.Count; i++)
                if (_items[i] == node)
                    return i;
            return -1;
        }

        public IEnumerable<Node> Descendants()
        {
            foreach (Node item in _items)
                foreach (Node n in item.Descendants())
                    yield return n;
        }

        public IEnumerable<Node> Descendants(string name)
        {
            foreach (Node item in _items)
                foreach (Node n in item.Descendants(name))
                    yield return n;
        }
        public IEnumerable<Node> Elements()
        {
            foreach (Node item in _items)
                foreach (Node n in item.ChildNodes)
                    yield return n;
        }
        public IEnumerable<Node> Elements(string name)
        {
            foreach (Node item in _items)
                foreach (Node n in item.Elements(name))
                    yield return n;
        }

        /// <summary>
        /// All first generation nodes in collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Node> Nodes()
        {
            foreach (Node item in _items)
                foreach (Node n in item.ChildNodes)
                    yield return n;
        }
    }
}
