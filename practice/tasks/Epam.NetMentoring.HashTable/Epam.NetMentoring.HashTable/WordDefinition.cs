using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.NetMentoring.HashTable
{
   public class WordDefinition
    {
       public string Definition { get; set; }

       public override bool Equals(object obj)
       {
           if (obj == null)
           {
               return false;
           }
           var d = obj as WordDefinition;
           if (d == null)
           {
               return false;
           }

           return d.Definition == Definition;
       }

       public override int GetHashCode()
       {
           int code = 0;
           Definition.ToList().ForEach(s => code = (int)s + code + Definition.Length);
           return code;
       }
    }
}
