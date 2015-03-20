using System;
using NUnit.Framework;
using Epam.Mentoring.LinkedList;

namespace Epam.NetMentoring.Testing
{
    [TestFixture]
    public class Test
    {

        #region ADD

        [Test]
        public void OneObjectAddedToList()
        {
            var lenght = 1;
            var list = new LinkedList();
            var item = new object();
            list.Add(item);
            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item, list.FindElementAt(0));
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void AddNull_Exception()
        {
            var list = new LinkedList();
            object item = null;
            list.Add(item);
        }

        [Test]
        public void TwoObjectsAdded_SecondReturnedSuccess()
        {
            var lenght = 2;
            var list = new LinkedList();
            object item1 = new object();
            object item2 = new object();

            list.Add(item1);
            list.Add(item2);
            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item2, list.FindElementAt(1));
        }

        [Test]
        public void TwoIdenticalObjAdded_FindAt1RetunsInserted()
        {
            var lenght = 2;
            var list = new LinkedList();
            object item = new object();

            list.Add(item);
            list.Add(item);
            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item, list.FindElementAt(1));
        }

        [Test]
        public void ListTwoItemsAddAt2ThenAdd_SequenceSaved()
        {
            var lenght = 4;
            var list = new LinkedList();
            object item1 = new object();
            object item2 = new object();
            object item3 = new object();
            object item4 = new object();

            list.Add(item1);
            list.Add(item2);
            list.AddAt(item3, 1);
            list.Add(item4);

            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item3, list.FindElementAt(1));
            Assert.AreEqual(item2, list.FindElementAt(2));
            Assert.AreEqual(item4, list.FindElementAt(3));
        }

        #endregion

        #region FindAt

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyListFindAt1_Exception()
        {
            var list = new LinkedList();
            list.FindElementAt(1);
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyListFindAtNegative1_Exception()
        {
            var list = new LinkedList();
            list.FindElementAt(-1);
        }

        [Test]
        public void ListThreeItemsFindAt1_ReturnSecond()
        {
            var lenght = 3;
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
        
            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item2, list.FindElementAt(1));
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListThreeItemsFindAt3_Exception()
        {
            var lenght = 3;
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();
            list.Add(item1);
            list.Add(item2);
            list.Add(item3);

            Assert.AreEqual(lenght, list.Lenght);
            list.FindElementAt(3);
        }

        [Test]
        public void ListTwoItemsRemoveAt1ThenFindAt0_ReturnSecond()
        {
            var lenght = 1;
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();

            list.Add(item1);
            list.Add(item2);
            list.RemoveAt(0);
            
            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item2, list.FindElementAt(0));
        }

        [Test]
        public void ListWith_N_ItemsFindAt_N_ReturnCorrectItem()
        {
            var lenght = 4;
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();
            var item4 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Add(item4);

            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item2, list.FindElementAt(1));
            Assert.AreEqual(item3, list.FindElementAt(2));
        }

        #endregion

        #region RemoveAt

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyListRemoveAt0_Exception()
        {
            var list = new LinkedList();
            list.RemoveAt(0);
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyListRemoveAtMinus1_Exception()
        {
            var list = new LinkedList();
            list.RemoveAt(-1);
        }

        [Test]
        public void ListTwoItemsRemoveAt1_RemovesSecondItem()
        {
            var lenght = 1;
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            list.Add(item1);
            list.Add(item2);
            list.RemoveAt(1);

            Assert.AreEqual(lenght, list.Lenght);
            Assert.AreEqual(item1, list.FindElementAt(0));
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListTwoItemsRemoveAt2_Exception()
        {
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            list.Add(item1);
            list.Add(item2);

            list.RemoveAt(2);
        }

        [Test]
        public void List3ItemsRemoveAt2_SavesOrder()
        {
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.RemoveAt(2);

            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item2, list.FindElementAt(1));
        }

        [Test]
        public void List3ItemsRemoveAt0_SavesOrder()
        {
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.RemoveAt(0);

            Assert.AreEqual(item2, list.FindElementAt(0));
            Assert.AreEqual(item3, list.FindElementAt(1));
        }

        public void List3ItemsRemoveAt1_SavesOrder()
        {
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);

            list.RemoveAt(1);

            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item3, list.FindElementAt(1));
        }


        #endregion

        #region AddAt

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddAtMinus1_Exception()
        {
            var list = new LinkedList();
            list.AddAt(new object(), -1);
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListWithOneItemAddAt2_Exception()
        {
            var list = new LinkedList();
            list.AddAt(new object(), 0);
            list.AddAt(new object(), 2);
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void EmptyListAddAt0_Exception()
        {
            var list = new LinkedList();
            var item = new object();
            list.AddAt(item, 0);
        }

        [Test]
        public void List2ItemsAddAt2_SavesOrder()
        {
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.AddAt(item3, 1);

            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item3, list.FindElementAt(1));
            Assert.AreEqual(item2, list.FindElementAt(2));
        }

        [Test]
        public void List2ItemsAddAt0_SavesOrder()
        {
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            var item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.AddAt(item3, 0);

            Assert.AreEqual(item3, list.FindElementAt(0));
            Assert.AreEqual(item1, list.FindElementAt(1));
            Assert.AreEqual(item2, list.FindElementAt(2));

        }


        #endregion

        #region Remove

        [Test]
        public void ListOneItemRemoveItem_Success()
        {
            var lenght = 0;
            var list = new LinkedList();
            var item = new object();
            list.Add(item);
            list.Remove(item);

            Assert.AreEqual(lenght, list.Lenght);
        }

        [Test]
        public void ListOneItemRemoveAnotherItem_NothingRemoved()
        {
            var len = 1;
            var list = new LinkedList();
            var item1 = new object();
            var item2 = new object();
            list.Add(item1);
            list.Remove(item2);

            Assert.AreEqual(len, list.Lenght);
            Assert.AreEqual(item1, list.FindElementAt(0));
        }

        [Test, ExpectedException(typeof(NullReferenceException))]
        public void ListRemoveNull_Exception()
        {
            var list = new LinkedList();
            object item = null;
            list.Remove(item);
        }

        [Test]
        public void List3ItemsRemove1st_SequenceSaved()
        {
            var list = new LinkedList();
            object item1 = new object();
            object item2 = new object();
            object item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Remove(item1);

            Assert.AreEqual(item2, list.FindElementAt(0));
            Assert.AreEqual(item3, list.FindElementAt(1));
        }

        [Test]
        public void List3ItemsRemoveLast_SequenceSaved()
        {
            var list = new LinkedList();
            object item1 = new object();
            object item2 = new object();
            object item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Remove(item3);

            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item2, list.FindElementAt(1));
        }

        [Test]
        public void List3ItemsRemove2nd_SequenceSaved()
        {
            var list = new LinkedList();
            object item1 = new object();
            object item2 = new object();
            object item3 = new object();

            list.Add(item1);
            list.Add(item2);
            list.Add(item3);
            list.Remove(item2);

            Assert.AreEqual(item1, list.FindElementAt(0));
            Assert.AreEqual(item3, list.FindElementAt(1));
        }

        #endregion

        #region ForEach

        [Test]
        public void List3ItemsForEachIterates_Success()
        {
            var list = new LinkedList();
            list.Add(new object());
            list.Add(new object());
            list.Add(new object());

            foreach (var item in list)
            {
                Assert.NotNull(item);
            }
        }

        #endregion
    }
}
