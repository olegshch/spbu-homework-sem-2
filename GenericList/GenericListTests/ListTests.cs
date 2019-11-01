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
        private MyList<object> list = new MyList<object>();

        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod()]
        public void CopyToTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddTest()
        {
            list.Add("lol");
            Assert.AreEqual(1,list.Count);
        }

        [TestMethod()]
        public void GetDataTest()
        {
            list.Add("kek");
            Assert.AreEqual("kek",list[0]);
        }

        [TestMethod()]
        public void RemoveAtTest()
        {
            list.Add(1);
            list.Add("str");
            list.Add(2);
            list.RemoveAt(1);
            Assert.AreEqual("str", list[1]);
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ContainsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexOfTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteByDataTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }
    }
}