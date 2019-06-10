using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hashtable;
using System;

namespace Hashtable.Tests
{
    [TestClass()]
    public class HashtableTests
    {
        private Hashtable hashtable;

        [TestInitialize]
        public void Initialize()
        {
            hashtable = new Hashtable();
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
        public void CorrectSize()
        {
            for(int i = 0; i < 25; i++)
            {
                hashtable.Add(i);
                Assert.IsTrue(hashtable.Exists(i));
            }
            for(int i = 0; i < 25; i++)
            {
                hashtable.Delete(i);
                Assert.IsFalse(hashtable.Exists(i));
            }
            
        }
    }
}