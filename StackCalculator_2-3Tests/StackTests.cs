using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackCalculator_2_3;

namespace StackCalculator_2_3Tests
{
    [TestClass()]
    public class StackTests
    {
        private ArrayStack arrayStack = new ArrayStack();
        private ListStack listStack = new ListStack();

        private void DoPush(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod()]
        public void ArrayStackPush() => DoPush(arrayStack);

        [TestMethod()]
        public void ListStackPush() => DoPush(listStack);

        private void DoPop(IStack stack)
        {
            stack.Push(1);
            Assert.IsFalse(stack.IsEmpty());
        }

        [TestMethod()]
        public void ArrayPop() => DoPop(arrayStack);

        public void ListPop() => DoPop(listStack);

        private void DoIsEmpty(IStack stack)
        {
            Assert.IsTrue(stack.IsEmpty());
        }

        [TestMethod()]
        public void ArrayIsEmpty() => DoIsEmpty(arrayStack);

        [TestMethod()]
        public void ListIsEmpty() => DoIsEmpty(listStack);

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ArrayPushException()
        {
            for (int i = 0; i < 100001; i++)
            {
                arrayStack.Push(1);
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ArrayPopException()
        {
            arrayStack.Pop();
        }

        [TestMethod()]
        [ExpectedException(typeof(System.InvalidOperationException))]
        public void ListPopException()
        {
            listStack.Pop();
        }
    }
}
