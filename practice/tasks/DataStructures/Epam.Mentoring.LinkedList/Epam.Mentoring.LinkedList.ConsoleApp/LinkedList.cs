using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;

namespace Epam.Mentoring.LinkedList
{

    public class LinkedList : IEnumerable, ILinkedList
    {
        //IT: what the name does mean? Is't <_head> better?
        //IS: Use dummy node to avoid NullReference check
        private readonly Node _dummyNode;
        public int Lenght { get; private set; }

        public LinkedList()
        {
            //IT: Wrong approach, there is a risk of infinite loop. Do not use such approache any more
            //IT: initialy there should not be any nodes at all :) as we haven't added anything

            //IS: create dummy node linked on itself with dummy value
            _dummyNode = new Node { Value = "DummyValue" };
            _dummyNode.Next = _dummyNode;
            _dummyNode.Previous = _dummyNode;
        }

        public void Add(object item)
        {
            //IT: Never, never again! Do not use null reference exception, use ArgumentNullException and pass argument name into constructor
            if (item == null)
                throw new ArgumentNullException("item");

            var newNode = new Node { Value = item };

            //IT: we need to add to the end, as your approache will be changed due to previous comment this part must be re-written at all
            //IS: Note: LastItem.next always points to dummy, dummyPrevious points to lastItem
            //IS: If first element in the linked list
            if (_dummyNode.Next == _dummyNode && _dummyNode.Previous == _dummyNode)
            {
                _dummyNode.Next = newNode;
                newNode.Previous = _dummyNode;

                _dummyNode.Previous = newNode;
                newNode.Next = _dummyNode;

            }
            else
            //If not the first item then added to the end. 
            {
                newNode.Next = _dummyNode;
                newNode.Previous = _dummyNode.Previous;
                _dummyNode.Previous.Next = newNode;
                _dummyNode.Previous = newNode;
            }
            Lenght++;
        }

        public void RemoveAt(int position)
        {
            //IT: null reference exception is possisble
            //IS: corrected
            var node = GetNodeAt(position);

            //IT: due to changin an approach it will be changed, otherwise you will have null reference exception very often
            //No need to check for NullRef, due to DummyNode circular referene.   
            node.Next.Previous = node.Previous;
            node.Previous.Next = node.Next;
            Lenght--;
        }

        private Node GetNodeAt(int position)
        {
            if (position >= Lenght || position < 0)
                //IT: more information must be provided to help debuggin people that will use your code
                //IS: done
                throw new ArgumentOutOfRangeException("position", "current lenght: " + Lenght);

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

            //IT: null refference exception is possible in a future use
            //IS: To avoid Null Ref
            return new Node();
        }

        public Object FindElementAt(int position)
        {
            //IT: currently null reference exception is possible
            //IS: corrected
            return GetNodeAt(position).Value;
        }

        public void AddAt(object item, int position)
        {
            //IT: as it was mentioned it not a cceptable      
            //IS: corrected
            if (item == null)
                throw new ArgumentNullException("item");

            var newNode = new Node();
            newNode.Value = item;

            //IT: what happend if I'd like to insert to position 6 when there are 6 elements?
            //IS: Get the node by position counting from 0 (6 items in list, last item position 5)
            //IS: If request 6th item when we have 6 items in list will get ArgumentOutOfRangeException
            var currentNode = GetNodeAt(position);

          //IS: put new node on position of current node, shift current node on the right  
            newNode.Next = currentNode;
            newNode.Previous = currentNode.Previous;

            currentNode.Previous.Next = newNode;
            currentNode.Previous = newNode;

            Lenght++;
        }

        public void Remove(object item)
        {
            if (item == null)
                throw new ArgumentNullException("item");

            int i = 0;
            while (i<Lenght)
            {
                var node = GetNodeAt(i);
                if (node.Value.Equals(item))
                {
                    node.Next.Previous = node.Previous;
                    node.Previous.Next = node.Next;
                    Lenght--;
                    break;
                }
                i++;
            }            
        }

        public IEnumerator GetEnumerator()
        {
            int i = 0;
            while (i<Lenght)
            {
                yield return GetNodeAt(i);
                i++;
            }
            
        }
    }
}

