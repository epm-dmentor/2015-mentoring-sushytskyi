using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.HashTable
{
    internal class Bucket
    {
        internal ICollection<KeyValue> Items = new LinkedList<KeyValue>();

        public void SetItem(WordEntity key, WordDefinition value)
        {
            var item = GetItem(key);

            if (value == null)
            {
                Items.Remove(item);
            }
            else if (item == null)
            {
                Items.Add(new KeyValue(key, value));
            }
            else
            {
                item.Value = value;
            }
        }

        public KeyValue GetItem(WordEntity key)
        {
            //IT: re-write using LINQ
            foreach (KeyValue keyValuePair in Items)
            {
                if (keyValuePair.Key.Equals(key))
                    return keyValuePair;
            }
            return null;
        }

        public bool Contains(WordDefinition wordD)
        {
            //IT: re-write using LINQ
            foreach (KeyValue keyValuePair in Items)
            {
                if (keyValuePair.Value.Equals(wordD))
                    return keyValuePair.Value;
            }
            return null;
        }

        public int Count { get { throw new NotImplementedException();} }
    }
}
