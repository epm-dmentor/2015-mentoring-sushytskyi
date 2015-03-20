using System;

namespace Epam.Mentoring.LinkedList
{
    public interface ILinkedList
    {
        int Lenght { get; }
        void Add(object item);
        void RemoveAt(int position);
        Object FindElementAt(int position);
        void AddAt(object element, int position);
        void Remove(object element);
    }
}