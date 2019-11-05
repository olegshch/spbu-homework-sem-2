using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList.Tests
{
    [TestClass()]
    public class ListTests
    {
        private MyList<int> list = new MyList<int>();

        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod()]
        public void CopyToTest()
        {
            int[] array = new int[3];
            list.Add(1);
            list.Add(2);
            list.CopyTo(array, 1);
            Assert.AreEqual(1, array[1]);
            Assert.AreEqual(2, array[2]);
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add(5);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void GetDataTest()
        {
            list.Add(21);
            Assert.AreEqual(21, list[0]);
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            list.Add(1);
            list.Add(34);
            list.Add(2);
            list.RemoveAt(1);
            Assert.AreEqual(2, list[1]);
        }

        [TestMethod()]
        public void InsertTest()
        {
            list.Add(4);
            list.Insert(0, 7);
            Assert.AreEqual(7, list[0]);
        }

        [TestMethod()]
        public void ContainsTest()
        {
            list.Add(67);
            Assert.IsTrue(list.Contains(67));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(2);
            Assert.IsTrue(list.Count == 2 && list[0].Equals(1) && list[1].Equals(3));
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            list.Add(0);
            list.Add(1);
            list.Add(2);
            list.Add(2);
            Assert.IsTrue(list.IndexOf(2).Equals(2));
        }        

        [TestMethod()]
        public void ClearTest()
        {
            list.Add(1);
            list.Add(3);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod()]
        public void GetIndexTest()
        {
            list.Add(1);
            list.Add(3);
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(3, list[1]);
        }
    }
}