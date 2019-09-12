using Microsoft.VisualStudio.TestTools.UnitTesting;
using ListStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListStructure.Tests
{
    [TestClass()]
    public class LCalcTests
    {
        LCalc calc = new LCalc();

        [TestMethod()]
        public void GetSizeTest()
        {
            Assert.AreEqual(0, calc.GetSize());
            calc.Add("2");
            Assert.AreEqual(1, calc.GetSize());
            calc.Clear();
            Assert.AreEqual(0, calc.GetSize());
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.AreEqual(0, calc.GetSize());
            calc.Add("2");
            Assert.AreEqual(1, calc.GetSize());
            calc.Add("2");
            Assert.AreEqual(2, calc.GetSize());
        }

        [TestMethod()]
        public void OperateTest()
        {
            calc.Add("10");
            calc.Add("5");
            calc.Operate("+");
            Assert.AreEqual("15", calc.Print());

            calc.Clear();

            calc.Add("10");
            calc.Add("5");
            calc.Operate("-");
            Assert.AreEqual("5", calc.Print());

            calc.Clear();

            calc.Add("10");
            calc.Add("5");
            calc.Operate("*");
            Assert.AreEqual("50", calc.Print());

            calc.Clear();

            calc.Add("10");
            calc.Add("5");
            calc.Operate("/");
            Assert.AreEqual("2", calc.Print());
        }

        [TestMethod()]
        public void PrintTest()
        {
            Assert.AreEqual("Absolutely empty", calc.Print());
            calc.Add("2");
            calc.Add("2");
            Assert.AreEqual("Not empty", calc.Print());
            calc.Operate("+");
            Assert.AreEqual("4", calc.Print());
        }

        [TestMethod()]
        public void PrintListTest()
        {
            calc.Add("2");
            Assert.AreEqual("2 ", calc.PrintList());
            calc.Clear();
            Assert.AreEqual("", calc.PrintList());
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.AreEqual("Absolutely empty", calc.Print());
            calc.Add("2");
            calc.Add("2");
            Assert.AreEqual("Not empty", calc.Print());
            calc.Clear();
            Assert.AreEqual("Absolutely empty", calc.Print());
        }
    }
}