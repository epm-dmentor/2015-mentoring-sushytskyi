using System;
using System.Collections.Generic;

namespace Epam.NetMentoring.HashTable
{
    public class HashTable
    {
        //default count 10;
        internal Bucket[] Items = new Bucket[10];

        public WordDefinition this[WordEntity key]
        {
            get
            {
                KeyValue result = null;
                var keyCompresed = HashCompression(key.GetHashCode());

                if (Items[keyCompresed] != null)
                    result = Items[keyCompresed].GetItem(key);

                if (result == null)
                    throw new KeyNotFoundException();
                return result.Value;
            }
            set
            {
                var keyCode = HashCompression(key.GetHashCode());

                if (GetLoadFactor() < 90)
                {
                    if (Items[keyCode] != null)
                        Items[keyCode].AddItem(key, value);
                    else
                    {
                        var bucket = new Bucket();
                        bucket.AddItem(key, value);
                        Items[keyCode] = bucket;
                    }
                }
                else
                {
                    Array.Resize(ref Items, Items.Length * 2);
                    var bucket = new Bucket();
                    bucket.AddItem(key, value);
                    Items[keyCode] = bucket;
                }
            }
        }

        private int GetLoadFactor()
        {
            double filledBuckets = 0;
            int result = 0;
            foreach (Bucket item in Items)
            {
                if (item != null)
                {
                    filledBuckets++;
                }
            }
            result = (int)(filledBuckets / Items.Length * 100);
            return result;
        }

        private int HashCompression(int hash)
        {
            var result = hash % Items.Length;
            return result;
        }

        public WordDefinition Contains(WordDefinition wordD)
        {
            foreach (Bucket bucket in Items)
            {
                if (bucket != null)
                {
                    bucket.Contains(wordD);
                }
            }
            return null;
        }


    }
}
