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

       public override bool Equals(object obj)
       {
           if (obj == null)
           {
               return false;
           }
           var e = obj as WordEntity;
           if (e == null)
           {
               return false;
           }

           return e.Word == Word && e.Type == Type;
       }

       public override int GetHashCode()
       {
           var code = Word.Length;
           Word.ToList().ForEach(s => code = s+code);
           code = code * (int)Type * Word.Length;
           return code;

       }
    }
}
