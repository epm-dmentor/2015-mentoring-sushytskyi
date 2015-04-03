using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.HashTable
{
    //IT: should be interface
    public class HashTable : IHashTable
    {
        private const int InitialBuketSize = 10;
        private const int MaxLoadFactor = 90;

        //IT: should be private . If you'd like it to expose internal it's better to use property
        private Bucket[] _items = new Bucket[InitialBuketSize];

        public WordDefinition this[WordEntity key]
        {
            get
            {
                KeyValue result = null;
                var itemIndex = GetItemIndex(key);

                if (_items[itemIndex] != null)
                    result = _items[itemIndex].GetItem(key);

                if (result == null)
                    throw new KeyNotFoundException();
                return result.Value;
            }
            set
            {
                ResizeIfNeeded();
                var itemIndex = GetItemIndex(key);

                if (_items[itemIndex] != null)
                    _items[itemIndex].SetItem(key, value);
                else
                {
                    var bucket = new Bucket();
                    bucket.SetItem(key, value);
                    _items[itemIndex] = bucket;
                }
            }

        }

        private void ResizeIfNeeded()
        {
            if (GetLoadFactor() > MaxLoadFactor)
            {
                Array.Resize(ref _items, _items.Length*2);
            }
        }

        private int GetItemIndex(WordEntity key)
        {
            return Compress(key.GetHashCode());
        }

        private int GetLoadFactor()
        {
            double filledBuckets = 
                _items.Count(i => i != null && i.Count > 0);

            var result = (int)(filledBuckets / _items.Length * 100);
            return result;
        }

        private int Compress(int hashCode)
        {
            var result = hashCode % _items.Length;
            return result;
        }
    }
}
