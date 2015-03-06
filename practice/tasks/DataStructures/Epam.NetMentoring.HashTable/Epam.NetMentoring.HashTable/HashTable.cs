using System;
using System.Collections.Generic;
using System.Linq;

namespace Epam.NetMentoring.HashTable
{
    public class HashTable
    {
        public LinkedList<KeyValuePair<WordEntity, WordDefinition>>[] _list = new LinkedList<KeyValuePair<WordEntity, WordDefinition>>[0];
       
        //aproximate number of words in oxford dictionary used for compresion
        private const int Compression = 700;
        public WordDefinition this[WordEntity key]
        {
            get { return GetItem(key).Value; }
            set
            {
                AddItem(key, value);
            }
        }

        private void AddItem(WordEntity key, WordDefinition value)
        {
            var keyCode = HashCompression(key.GetHashCode());

            if (_list.Length > keyCode)
            {
                if (_list[keyCode] != null)
                    _list[keyCode].AddFirst(new KeyValuePair<WordEntity, WordDefinition>(key, value));
                else
                {
                    var linkedList = new LinkedList<KeyValuePair<WordEntity, WordDefinition>>();
                    linkedList.AddFirst(new KeyValuePair<WordEntity, WordDefinition>(key, value));
                    _list[keyCode] = linkedList;
                }

            }
            else
            {
                Array.Resize(ref _list, keyCode + 1);
                var linkedList = new LinkedList<KeyValuePair<WordEntity, WordDefinition>>();
                linkedList.AddFirst(new KeyValuePair<WordEntity, WordDefinition>(key, value));
                _list[keyCode] = linkedList;

            }

        }

        private KeyValuePair<WordEntity, WordDefinition> GetItem(WordEntity key)
        {
            var keyCode = HashCompression(key.GetHashCode());

            if (_list.Length <= keyCode)
                return new KeyValuePair<WordEntity, WordDefinition>();

            var item = _list[keyCode];

            if (item != null)
            {
                if (item.Count == 1)
                    return item.First();
                foreach (KeyValuePair<WordEntity, WordDefinition> keyValuePair in item)
                {
                    if (keyValuePair.Key.Equals(key))
                        return keyValuePair;
                }
            }
            return new KeyValuePair<WordEntity, WordDefinition>();
        }

        private int HashCompression(int hash)
        {
          var result= hash % Compression;
            return result;
        }

        public WordDefinition Contains(WordDefinition wordD)
        {
            foreach (LinkedList<KeyValuePair<WordEntity, WordDefinition>> keyValuePairs in _list)
            {
                if (keyValuePairs != null)
                {
                    foreach (KeyValuePair<WordEntity, WordDefinition> keyValuePair in keyValuePairs)
                    {
                        if (keyValuePair.Value.Equals(wordD))
                            return keyValuePair.Value;
                    }
                }
            }
            return null;
        }
    }
}
