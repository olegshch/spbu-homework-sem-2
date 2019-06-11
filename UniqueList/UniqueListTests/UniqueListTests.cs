using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UniqueList;


namespace UniqueList.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        UniqueList list;
        [TestInitialize()]
        public void UInitialize()
        {
            list = new UniqueList();
        }
        [TestMethod()]
        public void UIsEmptyTest()
        {
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod()]
        public void UGetTest()
        {
            list.Add(0, 1);
            Assert.AreEqual(1, list.Dataget(0));
        }

        [TestMethod()]
        public void UDatasetTest()
        {
            list.Add(0, 1);
            list.Dataset(0, 2);
            Assert.AreEqual(2, list.Dataget(0));
        }

        [TestMethod()]
        public void UDeleteTest()
        {
            list.Add(0, 1);
            list.Delete(0);
            Assert.IsTrue(list.IsEmpty());
        }

        [TestMethod]
        [ExpectedException(typeof(UniqueElementException))]
        public void USameElements()
        {
            list.Add(0, 1);
            list.Add(1,1);
        }

        [TestMethod]
        [ExpectedException(typeof(_2._1.UnexistingElementException))]
        public void UNoCurrentElement()
        {
            list.Add(0, 1);
            list.Add(1, 2);
            list.DeleteByData(3);         
        }
    }
}