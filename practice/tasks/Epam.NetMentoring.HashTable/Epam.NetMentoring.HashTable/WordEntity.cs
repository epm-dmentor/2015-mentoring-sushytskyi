using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.NetMentoring.HashTable
{
   public enum WordType
    {
       Verb,
       Adverb,
       Noun
    }

   public class WordEntity
    {
        public string Word { get; set; }
        public WordType Type { get; set; }
    }
}
