using System;
using System.Collections;
using System.Collections.Generic;

namespace Epam.Mentoring.LinkedList
{

    public class LinkedList : IEnumerable, ILinkedList
    {
        //IT: what the name does mean? Is't <_head> better?
        private readonly Node _sentinel;
        public int Lenght { get; private set; }

        public LinkedList()
        {
            //IT: Wrong approach, there is a risk of infinite loop. Do not use such approache any more
            //IT: initialy there should not be any nodes at all :) as we haven't added anything
            _sentinel = new Node { Value = "Sentinel" };
            _sentinel.Next = _sentinel;
            _sentinel.Previous = _sentinel;

            //IT: https://msdn.microsoft.com/en-us/library/83fhsxwc.aspx
            Lenght = 0;
        }

        public void Add(object item)
        {
            //IT: Never, never again! Do not use null reference exception, use ArgumentNullException and pass argument name into constructor
            if (item == null)
                throw new NullReferenceException();

            var newNode = new Node { Value = item };

            //IT: we need to add to the end, as your approache will be changed due to previous comment this part must be re-written at all
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
            //IT: null reference exception is possisble
            var node = GetNodeAt(position);

            //IT: due to changin an approach it will be changed, otherwise you will have null reference exception very often
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            Lenght--;
        }

        private Node GetNodeAt(int position)
        {
            if (position >= Lenght || position < 0)
                //IT: more information must be provided to help debuggin people that will use your code
                throw new ArgumentOutOfRangeException();

            var node = _sentinel.Next;

            //IT: it's better to use while loop for iterating throught linked list
            for (var i = 0; i < Lenght; i++)
            {
                if (i == position)
                {
                    return node;
                }
                node = node.Next;
            }

            //IT: null refference exception is possible in a future use
            return null;
        }

        public Object FindElementAt(int position)
        {
            //IT: currently null reference exception is possible
            return GetNodeAt(position).Value;
        }

        public void AddAt(object item, int position)
        {
            //IT: as it was mentioned it not a cceptable            
            if (item == null)
                throw new NullReferenceException();

            var newNode = new Node();
            newNode.Value = item;
            //IT: what happend if I'd like to insert to position 6 when there are 6 elements?
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

            //IT: for iterating linked list it's better to use while loop
            for (var i = 0; i < Lenght; i++)
            {
                var node = GetNodeAt(i);
                //IT: avoid using continue as much as possible
                if (!node.Value.Equals(item)) continue;
                node.Next.Previous = node.Previous;
                node.Previous.Next = node.Next;
                Lenght--;
            }
        }

        public IEnumerator GetEnumerator()
        {
            //IT: good, it event may work :) but now creating new list of object is prohibited AND 
            //IT: now it's not lazy evaluation of items. should be lazy, one by one
            var enumerableList = new List<object>();
            for (var i = 0; i < Lenght; i++)
            {
                enumerableList.Add(GetNodeAt(i));
            }
            return enumerableList.GetEnumerator();
        }

        //move this sub-class to different class, but still make it subclass of linked list
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

