using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StackCalculator_2_3.Tests
{

    [TestClass()]
    public class CalculatorTests
    {
        private Calculator calcArray;
        private Calculator calcList;

        [TestInitialize()]
        public void CalculatorInitialization()
        {
            calcArray = new Calculator(new ArrayStack());
            calcList = new Calculator(new ListStack());
        }

        private void Sum(Calculator calc)
        {
            Assert.AreEqual(4, calc.Calculate("2 2 +"));
        }

        [TestMethod()]
        public void ListIf2plus2Then4() => Sum(calcList);

        [TestMethod()]
        public void ArrayIf2plus2Then4() => Sum(calcArray);

        private void Minus(Calculator calc)
        {
            Assert.AreEqual(0, calc.Calculate("2 2 -"));
        }

        [TestMethod()]
        public void ListIf2minus2Then0() => Minus(calcList);

        [TestMethod()]
        public void ArrayIf2minus2Then0() => Minus(calcArray);

        private void Divide(Calculator calc)
        {
            Assert.AreEqual(1, calcArray.Calculate("2 2 /"));
        }

        [TestMethod()]
        public void ListIf2divide2Then1() => Divide(calcList);

        [TestMethod()]
        public void ArrayIf2divide2Then1() => Divide(calcArray);

        private void Multiply(Calculator calc)
        {
            Assert.AreEqual(6, calc.Calculate("3 2 *"));
        }

        [TestMethod()]
        public void ListIf3multiply2Then6() => Multiply(calcList);

        [TestMethod()]
        public void ArrayIf3multiply2Then6() =>Multiply(calcArray);

        private void MinusDivide(Calculator calc)
        {
            Assert.AreEqual(-1, calc.Calculate("2 -2 /"));
        }

        [TestMethod()]
        public void ListIf2dividemin2Thenmin1() => MinusDivide(calcList);

        [TestMethod()]
        public void ArrayIf2dividemin2Thenmin1() => MinusDivide(calcArray);
        
        private void DoubleDivide(Calculator calc)
        {
            Assert.AreEqual(1.5, calc.Calculate("3 2 /"));
        }

        [TestMethod()]
        public void ListIf3divide2Then15() => MinusDivide(calcList);

        [TestMethod()]
        public void ArrayIf3divide2Then15() => MinusDivide(calcArray);
        
        private void DivideDouble(Calculator calc)
        {
            Assert.AreEqual(6, calc.Calculate("3 0,5 /"));
        }

        [TestMethod()]
        public void ListIf3divide05Then6() => MinusDivide(calcList);

        [TestMethod()]
        public void ArrayIf3divide05Then6() => MinusDivide(calcArray);
        
        private void MultMult(Calculator calc)
        {
            Assert.AreEqual(12, calc.Calculate("2 2 3 * *"));
        }

        [TestMethod()]
        public void ListIf2mult2mult3Then12() => MinusDivide(calcList);

        [TestMethod()]
        public void ArrayIf2mult2mult3Then12() => MinusDivide(calcArray);
        
        private void DivideMult(Calculator calc)
        {
            Assert.AreEqual(3, calc.Calculate("3 2 / 2 *"));
        }

        [TestMethod()]
        public void ListIf3divide2mult2Then3() => MinusDivide(calcList);

        [TestMethod()]
        public void ArrayIf3divide2mult2Then3() => MinusDivide(calcArray);      
        
        private void Operand(Calculator calc)
        {
            calc.Calculate("1 +");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ListIfNotEnoughOperandsThenException() => Operand(calcList);

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ArrayIfNotEnoughOperandsThenException() => Operand(calcArray);

        private void Notation(Calculator calc)
        {
            calcArray.Calculate("1 1 + 1");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void ListIfWrongNotationThenException() => Notation(calcList);

        [TestMethod()]
        [ExpectedException(typeof(System.Exception))]
        public void ArrayIfWrongNotationThenException() => Notation(calcArray);
        
    }
}