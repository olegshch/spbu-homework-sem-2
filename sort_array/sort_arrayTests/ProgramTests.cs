using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void MainTest()
        {
            int number = 1;//int.Parse(Console.ReadLine());
            Assert.AreEqual(number,1);
        }
    }
}