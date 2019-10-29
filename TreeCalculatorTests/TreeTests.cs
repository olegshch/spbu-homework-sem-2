using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeCalculator.Tests
{
    [TestClass()]
    public class TreeTests
    {
        private Tree calc = new Tree();

        [TestMethod()]       
        public void If1plus1Then2()
        {
            Assert.AreEqual(2, calc.Calculate("+ 1 1"));
        }

        [TestMethod()]
        public void If2minus2Then0()
        {
            Assert.AreEqual(0, calc.Calculate("- 2 2"));
        }

        [TestMethod()]
        public void If2mult2Then4()
        {
            Assert.AreEqual(4, calc.Calculate("* 2 2"));
        }

        [TestMethod()]
        public void If2div2Then1()
        {
            Assert.AreEqual(1, calc.Calculate("/ 2 2"));
        }

        [TestMethod()]
        public void If2mult6div3Then4()
        {
            Assert.AreEqual(4, calc.Calculate("* 2 / 6 3"));
        }

        [TestMethod()]
        public void If1plus1plus1AnotherWayThen3()
        {
            Assert.AreEqual(3, calc.Calculate("+ 1 + 1 1"));
        }

        [TestMethod()]
        public void If1plus1plus1Then3()
        {
            Assert.AreEqual(3, calc.Calculate("+ + 1 1 1"));
        }

        [TestMethod()]
        public void If8div2div2Then2()
        {
            Assert.AreEqual(2, calc.Calculate("/ / 8 2 2"));
        }

        [TestMethod()]
        public void Ifplusminusmultdiv21212Then5()
        {
            Assert.AreEqual(5, calc.Calculate("+ - * / 2 1 2 1 2"));
        }
    }
}