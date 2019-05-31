using Microsoft.VisualStudio.TestTools.UnitTesting;
using _2._1.List;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.Tests
{
    [TestClass()]
    public class ListTests
    {
        [TestInitialize]
        public void Initialize()
        {
            list = new List();
        }

        [TestMethod()]
        public void IsEmptyTest()
        {
            List.Add(0, 1);
            Assert.IsFalse(List.IsEmpty());
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DatagetTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DatasetTest()
        {
            Assert.Fail();
        }
    }
}