using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("97", MTF("a"));
        }
    }
}
