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
            var hash = new HashTable();
            int it = 10000;

            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var random = new Random();

            for (int i = 0; i < 10000; i++)
            {                
                var result = new string(
                    Enumerable.Repeat(chars, random.Next()%8)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());

                             var result1 = new string(
                    Enumerable.Repeat(chars, 36)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                hash[new WordEntity {Type = WordType.Noun, Word = result}] = new WordDefinition() {Definition = result1};

            }

            foreach (var v in hash._items)
            {
                if (v != null)
                {
                    if (v._items.Count > 1)
                    {
                        it--;
                        //foreach (var i in v._items)
                        //{
                        //    var c = i.Key.GetHashCode();    
                        //}
                        
                    }
                    nonEmptyBuckets++;
                }
            }

            var pullFactor = (double)it/(double)nonEmptyBuckets*100;
            Assert.That((int)pullFactor, Is.GreaterThan(80));

        }

        [Test]
        public void EmptyListItemAdded()
        {
           var list = new HashTable();
            var key = new WordEntity {Type = WordType.Noun, Word = "TestKey"};
            var def=new WordDefinition() { Definition = "Defenition one" };

            list[key] = def;
            Assert.AreEqual(def,list[key]);
        }

        [Test]
        public void EmptyListTwoItemsAdded()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var def = new WordDefinition() { Definition = "Defenition one" };

            var key1 = new WordEntity { Type = WordType.Noun, Word = "TestKey1" };
            var def1 = new WordDefinition() { Definition = "Defenition one1" };

            list[key] = def;
            list[key1] = def1;

            Assert.AreEqual(def, list[key]);
            Assert.AreEqual(def1, list[key1]);
        }

        [Test]
        public void ShouldThrowIfGetUnknownKey()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var def = new WordDefinition() { Definition = "Defenition one" };

            var key1 = new WordEntity { Type = WordType.Noun, Word = "TestKey1" };
            var def1 = new WordDefinition() { Definition = "Defenition one1" };

            var key3 = new WordEntity { Type = WordType.Noun, Word = "IncorrectKey" };


            list[key] = def;
            list[key1] = def1;

            Assert.AreEqual(new WordDefinition().Definition,list[key3].Definition);
        }

        [Test]
        public void ListTwoDuplicateItems_ReturnsDefinition()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var def = new WordDefinition() { Definition = "Defenition one11" };
            var def2 = new WordDefinition() { Definition = "Defenition one 2" };

            list[key] = def;
            list[key] = def2;

            Assert.AreEqual(def2, list[key]);
        }



    }


}
