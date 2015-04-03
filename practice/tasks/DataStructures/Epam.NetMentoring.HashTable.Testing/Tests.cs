using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Epam.NetMentoring.HashTable.Testing
{
    [TestFixture]
    public class Tests
    {

        #region AddingItems

        [Test]
        public void EmptyList_AddItem_Succes()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var def = new WordDefinition() { Definition = "Defenition one" };

            list[key] = def;
            Assert.AreEqual(def, list[key]);
        }

        [Test]
        public void EmptyList_AddItemsWithDupHash_ReturnsCorrectItem()
        {
            var list = new HashTable();
            var key = new FakeWordEntity { Type = WordType.Noun, Word = "TestKey" };
            var key1 = new FakeWordEntity { Type = WordType.Noun, Word = "TestKey1" };

            var def = new WordDefinition() { Definition = "Defenition one" };
            var def1 = new WordDefinition() { Definition = "Defenition two" };

            list[key] = def;
            list[key1] = def1;

            Assert.AreEqual(def1, list[key1]);
            Assert.AreEqual(def, list[key]);

        }

        [Test]
        public void EmptyList_TwoItemsAdded_Succes()
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
        public void EmptyList_NullValueItemsAdded_Succes()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var def = new WordDefinition() { Definition = null };

            list[key] = def;

            Assert.AreEqual(def, list[key]);
        }

        [Test]
        public void EmptyList_NullItemAdded_Succes()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            WordDefinition def = null;

            list[key] = def;
            WordDefinition res = list[key];
            Assert.AreEqual(def, res);
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void EmptyList_TwoNullValueItemsAdded_RemoveBoth()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            WordDefinition def = null;
            var key1 = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            WordDefinition def1 = null;


            list[key] = def;
            list[key1] = def1;
            var t = list[key];
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void EmptyList_NullKeyAdded_NullReferenceExc()
        {
            var list = new HashTable();
            WordEntity key = null;
            var def = new WordDefinition() { Definition = "Defenition one1" };

            list[key] = def;
        }

        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void ListTwoItems_AddNullToKey_RemovesItem()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var key1 = new WordEntity { Type = WordType.Noun, Word = "TestKey1" };

            var def = new WordDefinition() { Definition = "Defenition one" };
            var def1 = new WordDefinition() { Definition = "Defenition two" };

            list[key] = def;
            list[key1] = def1;

            list[key1] = null;

            Assert.AreEqual(def1, list[key1]);

        }
        #endregion

        #region loadFactor check
       // [Test]
       // public void LoadFactorEqulasMoreThan80percents()
       // {
       //     int nonEmptyBuckets = 0;
       //     var hash = new HashTable();
       //     int wordItems = 10000;

       //     var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
       //     var random = new Random();

       //     for (int i = 0; i < wordItems; i++)
       //     {
       //         var result = new string(
       //             Enumerable.Repeat(chars, random.Next() % 14)
       //                 .Select(s => s[random.Next(s.Length)])
       //                 .ToArray());

       //         var result1 = new string(
       //Enumerable.Repeat(chars, 36)
       //    .Select(s => s[random.Next(s.Length)])
       //    .ToArray());
       //         hash[new WordEntity { Type = WordType.Noun, Word = result }] = new WordDefinition() { Definition = result1 };

       //     }

       //     foreach (var v in hash.Items)
       //     {
       //         if (v != null)
       //         {
       //             nonEmptyBuckets++;
       //         }
       //     }

       //     var pullFactor = (double)nonEmptyBuckets / (double)hash.Items.Length * 100;
       //     Assert.That((int)pullFactor, Is.GreaterThanOrEqualTo(80));
       // }

        #endregion

        #region Getting Items

        [Test, ExpectedException(typeof(KeyNotFoundException))]
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
            var t = list[key3];

        }

        [Test]
        public void ListTwoDuplicateItems_GetItem_ReturnSecond()
        {
            var list = new HashTable();
            var key = new WordEntity { Type = WordType.Noun, Word = "TestKey" };
            var def = new WordDefinition() { Definition = "Defenition one" };
            var def2 = new WordDefinition() { Definition = "Defenition two" };

            list[key] = def;
            list[key] = def2;

            Assert.AreEqual(def2, list[key]);
        }
        #endregion
        #region remove items
        [Test, ExpectedException(typeof(KeyNotFoundException))]
        public void ListTwoItemsWithDupHash_RemoveOne_RemovesCorrect()
        {
            var list = new HashTable();
            var key = new FakeWordEntity { Type = WordType.Noun, Word = "TestKey" };
            var key1 = new FakeWordEntity { Type = WordType.Noun, Word = "TestKey1" };

            var def = new WordDefinition() { Definition = "Defenition one" };
            var def1 = new WordDefinition() { Definition = "Defenition two" };

            list[key] = def;
            list[key1] = def1;
            list[key] = null;

            Assert.AreEqual(def, list[key]);
            Assert.AreEqual(def1, list[key1]);
        }

    }
        #endregion

    internal class FakeWordEntity : WordEntity
    {
        public override int GetHashCode()
        {
            return 100;
        }
    }

}
