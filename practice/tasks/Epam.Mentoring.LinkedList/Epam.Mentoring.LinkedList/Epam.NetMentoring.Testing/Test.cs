using System;
using System.Collections;
using NUnit.Framework;
using Epam.Mentoring.LinkedList;

namespace Epam.NetMentoring.Testing
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void ImplementsIEnumerable()
        {
            var linkedList = new LinkedList();
            Assert.IsNotNull(linkedList as IEnumerable);
        }

        [Test]
        public void lenghts_0_ListCreated()
        {
            var list = new LinkedList();
            Assert.That(list.Lenghts, Is.EqualTo(0));
        }
        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FindElementAt_0_OutOfRangeException_ForEmptyList()
        {
            var list = new LinkedList();
            list.FindElementAt(0);
        }
        [Test]
        public void FindElementAt_0_For_List_with_one_element()
        {
            var list = new LinkedList();
            list.Add("test");
            var res = list.FindElementAt(0);
            Assert.That(res, Is.EqualTo("test"));

        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Item_Removed()
        {
            var list = new LinkedList();
            list.Add("Test");
            list.Remove("Test");
            list.FindElementAt(0);
        }

        [Test]
        public void Item_Added()
        {
            var list = new LinkedList();
            list.Add("Item");
            var res = list.FindElementAt(0);
            Assert.That(res,Is.EqualTo("Item"));
        }
    }
}
