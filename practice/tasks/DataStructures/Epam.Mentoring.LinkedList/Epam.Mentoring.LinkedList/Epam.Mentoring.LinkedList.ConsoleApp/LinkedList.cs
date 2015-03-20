using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.LinkedList
{

    public class LinkedList : IEnumerable, ILinkedList
    {
        private readonly Node _sentinel;
        public int Lenght { get; private set; }

        public LinkedList()
        {
            _sentinel = new Node { Value = "Sentinel" };
            _sentinel.Next = _sentinel;
            _sentinel.Previous = _sentinel;
            Lenght = 0;
        }

        public void Add(object item)
        {
            if (item == null)
                throw new NullReferenceException();

            var newNode = new Node { Value = item };
            if (_sentinel.Next == _sentinel && _sentinel.Previous == _sentinel)
            {
                _sentinel.Next = newNode;
                newNode.Previous = _sentinel;

                _sentinel.Previous = newNode;
                newNode.Next = _sentinel;

            }
            else
            {
                newNode.Next = _sentinel;
                newNode.Previous = _sentinel.Previous;
                _sentinel.Previous.Next = newNode;
                _sentinel.Previous = newNode;
            }
            Lenght++;
        }

        public void RemoveAt(int position)
        {
            var node = GetNodeAt(position);
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            Lenght--;
        }

        private Node GetNodeAt(int position)
        {
            if (position >= Lenght || position < 0)
                throw new ArgumentOutOfRangeException();

            var node = _sentinel.Next;
            for (var i = 0; i < Lenght; i++)
            {
                if (i == position)
                {
                    return node;
                }
                node = node.Next;
            }
            return null;
        }

        public Object FindElementAt(int position)
        {
            return GetNodeAt(position).Value;
        }

        public void AddAt(object item, int position)
        {
            if (item == null)
                throw new NullReferenceException();

            var newNode = new Node();
            newNode.Value = item;
            var currentNode = GetNodeAt(position);

            newNode.Next = currentNode;
            newNode.Previous = currentNode.Previous;

            currentNode.Previous.Next = newNode;
            currentNode.Previous = newNode;

            Lenght++;
        }

        public void Remove(object item)
        {
            if (item == null)
                throw new NullReferenceException();

            for (var i = 0; i < Lenght; i++)
            {
                var node = GetNodeAt(i);
                if (!node.Value.Equals(item)) continue;
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                Lenght--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            var enumerableList = new List<object>();
            for (var i = 0; i < Lenght; i++)
            {
                enumerableList.Add(GetNodeAt(i));
            }
            return enumerableList.GetEnumerator();
        }

        private class Node
        {
            public object Value { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }
            public override string ToString()
            {
                return Value.ToString();
            }
        }
    }
}

