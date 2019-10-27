using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator_2_3
{
    /// <summary>
    /// List stack
    /// </summary>
    public class ListCalc : ICalcStack
    {
        List<double> list = new List<double>();

        /// <summary>
        /// Pushing element
        /// </summary>
        /// <param name="data">element</param>
        public void Push(double data) => list.Add(data);

        /// <summary>
        /// Gets and deletes top element
        /// </summary>
        /// <returns>top element</returns>
        public double Pop()
        {
            int size = list.Count();
            double result = list.ElementAt(size-1);
            list.RemoveRange(size-1, 1);
            return result;
        }

        /// <summary>
        /// Check if empty
        /// </summary>
        /// <returns>true if empty</returns>
        public bool IsEmpty() => list.Count == 0;
    }
}
