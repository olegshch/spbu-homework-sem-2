using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCoder;

namespace ConsoleCoder.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void a()
        {
            string result = Code.Converting(Code.MTF("a"));
            Assert.AreEqual("97 ",result);

        }

        [TestMethod()]
        public void aa()
        {
            string result = Code.Converting(Code.MTF("aa"));
            Assert.AreEqual("97 33 ", result);

        }

        [TestMethod()]
        public void abc()
        {
            string result = Code.Converting(Code.MTF("abc"));
            Assert.AreEqual("97 98 99 ", result);

        }

        [TestMethod()]
        public void abcabc()
        {
            string result = Code.Converting(Code.MTF("abcabc"));
            Assert.AreEqual("97 98 99 35 35 35 ", result);

        }

        [TestMethod()]
        public void abccba()
        {
            string result = Code.Converting(Code.MTF("abccba"));
            Assert.AreEqual("97 98 99 33 34 35 ", result);

        }
    }
}