using Microsoft.VisualStudio.TestTools.UnitTesting;
using Map_Filter_Fold;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map_Filter_Fold.Tests
{
    [TestClass()]
    public class FunctionTests
    {
        private List<int> list;
        private List<int> resultlist;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();
            resultlist = new List<int>();
        }

        [TestMethod()]
        public void MapTest()
        {
            list.Add(1);
            list.Add(2);
            list.Add(3);
            resultlist = Function.Map(list, x => x * 2);
            for (int i = 0; i < resultlist.Count; i++)
            {
                Assert.AreEqual(list[i] * 2 , resultlist[i]);
            }
        }

        [TestMethod()]
        public void FilterTest()
        {
            for(int i = 0; i < 100; i++)
            {
                list.Add(i);
            }
            resultlist = Function.Filter(list, x => x % 3 == 1);
            for (int i = 0; i < resultlist.Count; i++)
            {
                Assert.IsTrue(resultlist[i] % 3 == 1);
            }
        }

        [TestMethod()]
        public void FoldTest()
        {
            int known = 1;
            for (int i = 1; i <= 10; i++)
            {
                list.Add(i);
                known *= i;
            }
            int result = Function.Fold(list, 1, (res, curr) => res * curr);
            Assert.AreEqual(result, known);
              
        }
    }
}