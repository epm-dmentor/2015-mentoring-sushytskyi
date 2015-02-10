using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.NetMentoring.HashTable
{
    public class HashTable
    {
        public LinkedList<KeyValuePair<WordEntity, WordDefinition>>[] _list = new LinkedList<KeyValuePair<WordEntity, WordDefinition>>[0];
        private const int Compression= 6500;
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
            var keyCode = GetKeyHashCode(key);

            if (_list.Length>=keyCode)
            {
                if (_list[keyCode] != null)
                    _list[keyCode].AddFirst(new KeyValuePair<WordEntity, WordDefinition>(key, value));
                else
                {
                   var linkedList= new LinkedList<KeyValuePair<WordEntity, WordDefinition>>();
                    linkedList.AddFirst(new KeyValuePair<WordEntity, WordDefinition>(key, value));
                    _list[keyCode] = linkedList;
                }
                
            }
            else
            {
               Array.Resize(ref _list,keyCode+1);
               var linkedList = new LinkedList<KeyValuePair<WordEntity, WordDefinition>>();
               linkedList.AddFirst(new KeyValuePair<WordEntity, WordDefinition>(key, value));
               _list[keyCode] = linkedList;
   
            }

        }

        private KeyValuePair<WordEntity, WordDefinition> GetItem(WordEntity key)
        {
            var keyCode = GetKeyHashCode(key);

            if (_list.Length <= keyCode)
                return new KeyValuePair<WordEntity, WordDefinition>();

            var item = _list[keyCode];

            if (item != null)
            {
                if (item.Count == 1)
                    return item.First();
                    foreach (KeyValuePair<WordEntity, WordDefinition> keyValuePair in item)
                    {
                        if (keyValuePair.Key == key)
                            return keyValuePair;
                    }
            }
            return new KeyValuePair<WordEntity, WordDefinition>();
        }

        private int GetKeyHashCode(WordEntity key)
        {
            var code = 0;
            key.Word.ToList().ForEach(s => code = (int)s + code + key.Word.Length);
            code = code * (int) key.Type;
            return HashCompression(code);
        }

        private int HashCompression(int hash)
        {
            return hash % Compression;
        }
    }
}
