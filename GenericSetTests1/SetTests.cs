using Microsoft.VisualStudio.TestTools.UnitTesting;
using GenericSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            set.Add(3);
            set.Add(2);
            Assert.IsTrue(set.Contains(1));
            Assert.IsTrue(set.Contains(2));
            Assert.IsTrue(set.Contains(3));
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
        public void RemoveTest()
        {
            set.Add(1);
            set.Remove(1);
            Assert.IsFalse(set.Contains(1));
        }

        [TestMethod()]
        public void IsSupersetOfTest()
        {
            set.Add(1);
            set.Add(2);
            list.Add(1);
            Assert.IsTrue(set.IsSubsetOf(list));
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
            Assert.Fail();
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            list.Add(1);
            list.Add(2);
            set.Add(6);
            set.Add(8);
            set.Add(6);
            set.Add(2);
            Assert.IsTrue(set.Overlaps(list));
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
            //Assert.AreEqual(1, set.Count);
            Assert.IsTrue(set.Contains(3));
            //Assert.IsFalse(set.Contains(1));
            //Assert.IsFalse(set.Contains(2));
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Assert.Fail();
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
        public void SymmetricExceptWithTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IntersectWithTest()
        {
            Assert.Fail();
        }
    }
}