using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations.Tests
{
    [TestClass()]
    public class CalculationsTests
    {
        private Calculations calc = new Calculations();

        [TestMethod()]
        public void CalculatePlus()
        {
            calc.OperSymbol = "+";
            calc.Operand = 0.5;
            Assert.AreEqual(1, calc.Calculate(0.5));
        }

        [TestMethod()]
        public void CalculateMinus()
        {
            calc.OperSymbol = "-";
            calc.Operand = 0;
            Assert.AreEqual(-5, calc.Calculate(5));
        }

        [TestMethod()]
        public void CalculateMultiply()
        {
            calc.OperSymbol = "*";
            calc.Operand = 0.5;
            Assert.AreEqual(0.25, calc.Calculate(0.5));
        }

        [TestMethod()]
        public void CalculateDivide()
        {
            calc.OperSymbol = "/";
            calc.Operand = 0.5;
            Assert.AreEqual(1, calc.Calculate(0.5));
        }

        [TestMethod()]
        public void CalculateEqual()
        {
            calc.OperSymbol = "=";
            calc.Operand = 0.5;
            Assert.AreEqual(0.5, calc.Calculate(0.5));
        }


    }
}
        