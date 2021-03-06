﻿using System;
using System.Collections;

namespace Epam.Mentoring.LinkedList
{
    //implementation is based on cercular data structure, implemented as double linked list
    public class LinkedList : IEnumerable, ILinkedList
    {
        //used to determine either first or last element as we use circular data structure 
        //and our list is double linked 
        private Node _dummyNode;
        public int Lenght { get; private set; }

        public LinkedList()
        {
            //create dummy node linked on itself with dummy value
            //IT: InitiateCercularList
            InitCercularList();
        }

        private void InitCercularList()
        {
            _dummyNode = new Node { Value = "DummyValue" };
            _dummyNode.Next = _dummyNode;
            _dummyNode.Previous = _dummyNode;
        }

        public void Add(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var newNode = new Node { Value = item };
            //Note: LastItem.next always points to dummy, dummyPrevious points to lastItem
            //if first element in the linked list
            AddNodeInFront(newNode, _dummyNode);
            Lenght++;
        }

        public void RemoveAt(int position)
        {
            var node = GetNodeAt(position);

            //IT: code is duplicated
            RemoveFromLinkedList(node);
            Lenght--;
        }

        private static void RemoveFromLinkedList(Node node)
        {
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
        }

        //always return either real node or an exception. Null is not possible
        private Node GetNodeAt(int position)
        {
            if (position >= Lenght || position < 0)
                throw new ArgumentOutOfRangeException(String.Format("requested position:{0}, current lenght of a linked list: {1}", position, Lenght));

            //IS: if list empty and _dummyNode.Next returns dummy we wont get to this part of code due to Lenght=0; checked above
            var node = _dummyNode.Next;

            int i = 0;
            while (i < Lenght)
            {
                if (i == position)
                {
                    return node;
                }
                node = node.Next;
                i++;
            }

            throw new ApplicationException("Unexpected situation during finding node by a position");
        }

        public Object FindElementAt(int position)
        {
            return GetNodeAt(position).Value;
        }

        //IT: if we have 5 element, i should be able to run AddAt(..., 5)
        public void AddAt(object item, int position)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            var newNode = new Node { Value = item };

            var currentNode = Lenght == position ? _dummyNode : GetNodeAt(position);

            AddNodeInFront(newNode, currentNode);
            Lenght++;
        }

        private static void AddNodeInFront(Node newNode, Node currentNode)
        {
            newNode.Next = currentNode;
            newNode.Previous = currentNode.Previous;

            currentNode.Previous.Next = newNode;
            currentNode.Previous = newNode;
        }

        public void Remove(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int i = 0;
            while (i < Lenght)
            {
                var node = GetNodeAt(i);
                if (node.Value.Equals(item))
                {
                    RemoveFromLinkedList(node);
                    Lenght--;
                    break;
                }
                i++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i < Lenght)
            {
                yield return GetNodeAt(i);
                i++;
            }

        }
    }
}

