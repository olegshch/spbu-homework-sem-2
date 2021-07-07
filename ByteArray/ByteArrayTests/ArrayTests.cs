using Microsoft.VisualStudio.TestTools.UnitTesting;
using ByteArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteArray.Tests
{
    [TestClass()]
    public class ArrayTests
    {
        [TestInitialize]
        public void Initialize()
        {
            myarray = new Array();
        }


        [TestMethod()]
        public void IsEmptyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddInListTest()
        {
            List<byte> array = new List<byte>();
            array.Add(1);
            array.Add(1);
            array.Add(1);

            Assert.AreEqual(3, Array[1].Count);
        }

        [TestMethod()]
        public void PrintTest()
        {
            Assert.Fail();
        }
    }
}