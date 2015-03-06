using System.Runtime.InteropServices;
using Epam.NetMentoring.HashTable;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void NewHashTable_Empty_Succeed()
        {
            int nonEmptyBuckets=0;
            var list = new HashTable();
            int it = 0;
            for (int i = 0; i <= 200000; i++)
            {
                var ent = new WordEntity {Type = WordType.Noun, Word = RandomWords.GetRandomString(i%30)};
                var def=new WordDefinition { Definition = RandomWords.GetRandomString(i % 5) + " " + RandomWords.GetRandomString(i % 2)};
                list[ent]= def;
            }

            foreach (var v in list._list)
            {
                if (v != null)
                {
                    if (v.Count > 1)
                        it++;
                    nonEmptyBuckets++;
                }
            }
            var pullFactor = (double)nonEmptyBuckets/(double)list._list.Length*100;
            Assert.That((int)pullFactor, Is.GreaterThan(80));

        }


    }


}
