using Microsoft.VisualStudio.TestTools.UnitTesting;
using RareVector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RareVector.Tests
{
    [TestClass()]
    public class VectorTests
    {
        private Vector vector;

        [TestInitialize]
        public void Initialize()
        {
             vector = new Vector();
        }


        [TestMethod]
        public void TrueWhenEmptyTest()
        {
            Assert.IsTrue(vector.IsEmpty());
        }
        [TestMethod]
        public void TrueWhenNotEmptyTest()
        {
            vector.Add(2, 5);
            Assert.IsFalse(vector.IsEmpty());
        }


        [TestMethod()]
        public void CloneTest()
        {
            Assert.Fail();
        }
    }
}