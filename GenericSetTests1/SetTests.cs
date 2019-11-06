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
            Assert.IsTrue(set.Add(1));
            Assert.AreEqual(1, set.Count);
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
            Assert.IsTrue(set.Remove(1));
        }

        [TestMethod()]
        public void IsSupersetOfTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IsSubsetOfTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetEqualsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void OverlapsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ExceptWithTest()
        {
            Assert.Fail();
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
            Assert.Fail();
        }

        [TestMethod()]
        public void IsProperSupersetOfTest()
        {
            Assert.Fail();
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