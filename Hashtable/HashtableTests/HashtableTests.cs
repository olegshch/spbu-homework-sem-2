using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hashtable.Tests
{
    [TestClass()]
    public class HashtableTests
    {
        private Hashtable hashtable;

        [TestInitialize()]
        public void InitializeHashSymbol()
        {
            hashtable = new Hashtable(new HashSymbol(), 10);
        }

        [TestMethod()]
        public void GetFromEmpty()
        {
            Assert.IsFalse(hashtable.Exists(0));           
        }

        [TestMethod()]
        public void SuccessDelete()
        {
            hashtable.Add(19);
            hashtable.Delete(19);
            Assert.IsFalse(hashtable.Exists(19));
        }

        [TestMethod()]
        public void SuccessAdd()
        {
            hashtable.Add(0);
            Assert.IsTrue(hashtable.Exists(0));
            hashtable.Add(10);
            Assert.IsTrue(hashtable.Exists(10));
        }

        [TestMethod()]
        public void CorrectSizeChange()
        {
            for (int i = 0; i < 25; i++)
            {
                hashtable.Add(i);
                Assert.IsTrue(hashtable.Exists(i));
            }
            for (int i = 0; i < 25; i++)
            {
                hashtable.Delete(i);
                Assert.IsFalse(hashtable.Exists(i));
            }
            
        }

        [TestMethod()]
        public void SameElements()
        {
            hashtable.Add(2);
            hashtable.Add(2);
            Assert.IsTrue(hashtable.Exists(2));
        }

        [TestMethod]
        public void MinusElements()
        {
            hashtable.Add(-2);
            Assert.IsTrue(hashtable.Exists(-2));
        }

        [TestMethod()]
        public void ManyMinusElements()
        {
            for(int i = -100; i < 0; i++)
            {
                hashtable.Add(i);
            }
            for (int i = -100; i < 0; i++)
            {
                Assert.IsTrue(hashtable.Exists(i));
            }
        }

        [TestMethod()]
        public void HashSymbol()
        {
            IHashInterface hash = new HashSymbol();
            Assert.AreEqual(hash.Transform(123), 6);
        }

        [TestMethod()]
        public void HashLength()
        {
            IHashInterface hash = new HashLength();
            Assert.AreEqual(hash.Transform(123), 3);
        }

        [TestMethod()]
        public void Existing()
        {
            hashtable.Add(123);
            Assert.IsTrue(hashtable.Exists(123));            
        }

        [TestMethod()]
        public void ExistsInHash()
        {
            hashtable.Add(123);
            Assert.IsTrue(hashtable.ExistsInHash(123));
        }

        [TestMethod()]
        public void Resize()
        {
            for(int i = 0; i < 150; i++)
            {
                hashtable.Add(i);
            }
            Assert.AreEqual(20, hashtable.Height());
        }
    }
}