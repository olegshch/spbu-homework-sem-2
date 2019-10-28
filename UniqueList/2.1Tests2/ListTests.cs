using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._1;
using System;

namespace _2._1.Tests
{
    [TestClass()]
    public class ListTests
    {
        List list;
        [TestInitialize()]
        public void Initialize()
        {
            list = new List();
        }
        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod()]
        public void GetTest()
        {
            list.Add(0, 1);
            Assert.AreEqual(1,list.Dataget(0));
        }

        [TestMethod()]
        public void DatasetTest()
        {
            list.Add(0, 1);
            list.Dataset(0, 2);
            Assert.AreEqual(2,list.Dataget(0));
        }

        [TestMethod()]
        public void DeleteTest()
        {
            list.Add(0, 1);
            list.Delete(0);
            Assert.IsTrue(list.IsEmpty());
        }

       
    }
}