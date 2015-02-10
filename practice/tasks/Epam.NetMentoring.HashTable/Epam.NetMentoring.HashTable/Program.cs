using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Epam.NetMentoring.HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new HashTable();
            //WordEntity en1 = new WordEntity {Type = WordType.Noun, Word = "Fuck"};
            //WordDefinition df1 = new WordDefinition {Definition = "Fucking music"};

            //WordEntity en2 = new WordEntity {Type = WordType.Noun, Word = "Snake"};
            //WordDefinition df2 = new WordDefinition {Definition = "Snaking music"};

            //WordEntity en3 = new WordEntity {Type = WordType.Noun, Word = "Givedargsfdgaerwefasdgaetwedc"};
            //WordDefinition df3 = new WordDefinition {Definition = "Given music"};


            ////list[en1] = df1;
            ////var i = list[en1];

            //list[en1] = df1;
            //var v = list[en1];


            //list[en2] = df2;
            //var z = list[en2];
            //list[en3] = df3;
            //var z1 = list[en3];

            int it = 0;
            for (int i = 0; i <= 1000; i++)
            {
                list[new WordEntity {Type = WordType.Noun, Word = RandomWords.GetRandomString(i%30)}]
                    = new WordDefinition { Definition = RandomWords.GetRandomString(i % 30) + " " + RandomWords.GetRandomString(i % 30) + " " + RandomWords.GetRandomString(i%30) };
            }

            foreach (var v in list._list)
            {
                if(v!=null)
                    if (v.Count > 1)
                        it++;
            }
        }
    }
}
