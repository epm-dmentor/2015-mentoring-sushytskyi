using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.HashTable
{
    internal class Bucket
    {
        internal ICollection<KeyValue> Items = new LinkedList<KeyValue>();

        public void SetItem(WordEntity key, WordDefinition value)
        {
            var item = GetItem(key);

            if (item!=null && value == null)
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
            return Items.FirstOrDefault(keyValuePair => keyValuePair.Key.Equals(key));
        }

        public int Count { get { return Items.Count; } }
    }
}
