using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.LinkedList
{

    public class LinkedList : IEnumerable, ILinkedList
    {
        private readonly Node _sentinel;
        public int Lenghts { get; private set; }

        public LinkedList()
        {
            _sentinel = new Node { Value = "Sentinel" };
            _sentinel.Next = _sentinel;
            _sentinel.Previous = _sentinel;
            Lenghts = 0;
        }
        public void Add(object item)
        {
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
            Lenghts++;
        }

        public void RemoveAt(int position)
        {
            var node = GetNodeAt(position);
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            Lenghts--;
        }

        private Node GetNodeAt(int position)
        {

            if (position >= Lenghts)
                throw new ArgumentOutOfRangeException();

            var node = _sentinel.Next;
            for (var i = 0; i < Lenghts; i++)
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

        public void AddAt(object element, int position)
        {
            var newNode = new Node();
            newNode.Value = element;
            var currentNode = GetNodeAt(position);

            newNode.Next = currentNode;
            newNode.Previous = currentNode.Previous;

            currentNode.Previous.Next = newNode;
            currentNode.Previous = newNode;

            Lenghts++;

        }

        public void Remove(object element)
        {
            for (var i = 0; i < Lenghts; i++)
            {
                var node = GetNodeAt(i);
                if (!node.Value.Equals(element)) continue;
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                Lenghts--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            var enumerableList = new List<object>();
            for (var i = 0; i < Lenghts; i++)
            {
                enumerableList.Add(GetNodeAt(i));
            }
            return enumerableList.GetEnumerator();
        }
    }
}
