using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalculator_2_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator_2_3.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        private Calculator calc1;
        private Calculator calc2;

        [TestInitialize()]
        public void CalculatorInitialization()
        {
             calc1 = new Calculator(new ArrayCalc());
             calc2 = new Calculator(new ListCalc());
        }

        [TestMethod()]
        public void If2plus2Then4()
        {
            Assert.AreEqual(4,calc1.Calculate("2 2 +"));
            Assert.AreEqual(4,calc2.Calculate("2 2 +"));
        }

        [TestMethod()]
        public void If2minus2Then0()
        {
            Assert.AreEqual(0, calc1.Calculate("2 2 -"));
            Assert.AreEqual(0, calc2.Calculate("2 2 -"));
        }

        [TestMethod()]
        public void If2divide2Then1()
        {
            Assert.AreEqual(1, calc1.Calculate("2 2 /"));
            Assert.AreEqual(1, calc2.Calculate("2 2 /"));
        }

        [TestMethod()]
        public void If2dividemin2Thenmin1()
        {
            Assert.AreEqual(-1, calc1.Calculate("2 -2 /"));
            Assert.AreEqual(-1, calc2.Calculate("2 -2 /"));
        }

        [TestMethod()]
        public void If3divide2Then15()
        {
            Assert.AreEqual(1.5, calc1.Calculate("3 2 /"));
            Assert.AreEqual(1.5, calc2.Calculate("3 2 /"));
        }

        [TestMethod()]
        public void If3divide05Then6()
        {
            Assert.AreEqual(6, calc1.Calculate("3 0,5 /"));
            Assert.AreEqual(6, calc2.Calculate("3 0,5 /"));
        }

        [TestMethod()]
        public void If2mult2mult3Then12()
        {
            Assert.AreEqual(12, calc1.Calculate("2 2 3 * *"));
            Assert.AreEqual(12, calc2.Calculate("2 2 3 * *"));
        }

        [TestMethod()]
        public void If3divide2mult2Then3()
        {
            Assert.AreEqual(3, calc1.Calculate("3 2 / 2 *"));
            Assert.AreEqual(3, calc2.Calculate("3 2 / 2 *"));
        }
    }
}