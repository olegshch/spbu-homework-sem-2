using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace GenericSet.Tests
{
    [TestClass()]
    public class SetTests
    {
        private MySet<int> set = new MySet<int>();
        private List<int> list = new List<int>();

        [TestMethod()]
        public void ContainsTest()
        {
            set.Add(1);
            set.Add(0);
            set.Add(3);
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(0));
            Assert.IsTrue(set.Contains(1));
        }

        [TestMethod()]
        public void ClearTest()
        {
            set.Add(1);
            set.Add(2);
            set.Clear();
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            set.Add(1);
            set.Add(4);
            set.Add(5);
            set.Add(3);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(3));
            Assert.IsTrue(set.Contains(4));
            Assert.IsTrue(set.Contains(5));
            Assert.AreEqual(4, set.Count);

            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod()]
        public void UnionWithTest()
        {
            set.Add(1);
            set.Add(2);
            list.Add(2);
            list.Add(3);
            set.UnionWith(list);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(3));
        }

        [TestMethod()]
        public void RemoveRightChildTest()
        {
            set.Add(1);
            set.Add(2);
            set.Remove(2);
            Assert.IsFalse(set.Contains(2));
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod()]
        public void RemoveRootWithRightChildTest()
        {
            set.Add(1);
            set.Add(2);
            set.Remove(1);
            Assert.IsFalse(set.Contains(1));
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod()]
        public void RemoveLeftChildTest()
        {
            set.Add(1);
            set.Add(0);
            set.Remove(0);
            Assert.IsFalse(set.Contains(0));
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod()]
        public void RemoveAnyNodeTest()
        {
            set.Add(16);
            set.Add(8);
            set.Add(32);
            set.Add(4);
            set.Add(10);
            set.Add(24);
            set.Add(64);
            set.Add(1);
            set.Add(5);
            set.Add(9);
            set.Add(11);
            set.Add(12);
            set.Add(30);
            set.Add(50);
            set.Add(70);
            set.Remove(32);
            Assert.IsFalse(set.Contains(32));
            Assert.IsTrue(set.Contains(16));
            Assert.IsTrue(set.Contains(8));
            Assert.IsTrue(set.Contains(4));
            Assert.IsTrue(set.Contains(10));
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(5));
            Assert.IsTrue(set.Contains(9));
            Assert.IsTrue(set.Contains(11));
            Assert.IsTrue(set.Contains(24));
            Assert.IsTrue(set.Contains(64));
            Assert.IsTrue(set.Contains(12));
            Assert.IsTrue(set.Contains(30));
            Assert.IsTrue(set.Contains(50));
            Assert.IsTrue(set.Contains(70));
        }

        [TestMethod()]
        public void RemoveRootWithChildrenTest()
        {
            set.Add(5);
            set.Add(10);
            set.Add(3);
            set.Remove(5);
            Assert.IsFalse(set.Contains(5));
            Assert.AreEqual(2, set.Count);
        }

        [TestMethod()]
        public void RemoveRootTest()
        {
            set.Add(1);
            set.Remove(1);
            Assert.IsFalse(set.Contains(1));
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod()]
        public void IsSupersetOfTest()
        {
            set.Add(1);
            set.Add(2);
            list.Add(1);
            Assert.IsTrue(set.IsSupersetOf(list));
        }

        [TestMethod()]
        public void IsSubsetOfTest()
        {
            list.Add(1);
            list.Add(2);
            set.Add(1);
            Assert.IsTrue(set.IsSubsetOf(list));
        }

        [TestMethod()]
        public void SetEqualsTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            set.Add(1);
            set.Add(2);
            Assert.IsFalse(set.SetEquals(list));
            set.Add(3);
            Assert.IsTrue(set.SetEquals(list));
        }

        [TestMethod()]
        public void ExceptWithTest()
        {
            list.Add(1);
            list.Add(2);
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.ExceptWith(list);
            Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(3));
            Assert.IsFalse(set.Contains(1));
            Assert.IsFalse(set.Contains(2));
        }

        [TestMethod()]
        public void CopyToTest()
        {
            set.Add(3);
            set.Add(1);
            set.Add(5);
            set.Add(0);
            set.Add(2);
            set.Add(4);
            set.Add(6);
            int[] array = new int[8];
            set.CopyTo(array, 1);
            Assert.AreEqual(0, array[1]);
            Assert.AreEqual(2, array[2]);
            Assert.AreEqual(1, array[3]);
            Assert.AreEqual(4, array[4]);
            Assert.AreEqual(6, array[5]);
            Assert.AreEqual(5, array[6]);
            Assert.AreEqual(3, array[7]);
        }

        [TestMethod()]
        public void IsProperSubsetOfTest()
        {
            set.Add(1);
            list.Add(1);
            Assert.IsFalse(set.IsProperSubsetOf(list));
            list.Add(2);
            Assert.IsTrue(set.IsProperSubsetOf(list));
        }

        [TestMethod()]
        public void IsProperSupersetOfTest()
        {
            set.Add(1);
            list.Add(1);
            Assert.IsFalse(set.IsProperSupersetOf(list));
            set.Add(2);
            Assert.IsTrue(set.IsProperSupersetOf(list));
        }

        [TestMethod()]
        public void IntersectWithTest()
        {
            set.Add(1);
            set.Add(2);
            list.Add(2);
            list.Add(3);
            set.IntersectWith(list);
            Assert.IsFalse(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsFalse(set.Contains(3));
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            list.Add(1);
            list.Add(2);
            set.Add(3);
            set.Add(2);
            Assert.IsTrue(set.Overlaps(list));
        }
    }
}