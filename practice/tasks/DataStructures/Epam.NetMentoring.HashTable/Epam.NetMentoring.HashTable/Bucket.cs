using System.Collections.Generic;

namespace Epam.NetMentoring.HashTable
{
    public class Bucket
    {
        internal LinkedList<KeyValue> Items = new LinkedList<KeyValue>();

        public void AddItem(WordEntity key, WordDefinition value)
        {
            var item = GetItem(key);

            if (item != null)
            {
                if (value == null)
                {
                    Items.Remove(item);
                    return;
                }

                item.Value = value;
                return;
            }

            Items.AddFirst(new KeyValue(key, value));
        }

        public KeyValue GetItem(WordEntity key)
        {
            foreach (KeyValue keyValuePair in Items)
            {
                if (keyValuePair.Key.Equals(key))
                    return keyValuePair;
            }
            return null;
        }

        public WordDefinition Contains(WordDefinition wordD)
        {
            foreach (KeyValue keyValuePair in Items)
            {
                if (keyValuePair.Value.Equals(wordD))
                    return keyValuePair.Value;
            }
            return null;
        }
    }
}
