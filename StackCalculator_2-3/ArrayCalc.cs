using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator_2_3
{
    /// <summary>
    /// Array stack
    /// </summary>
    public class ArrayCalc : ICalcStack
    {
        double[] array = new double[10000];
        int index = 0;

        /// <summary>
        /// Pushing element
        /// </summary>
        /// <param name="data">element</param>
        public void Push(double data)
        {
            array[index] = data;
            index++;
        }

        /// <summary>
        /// Gets and deletes top element
        /// </summary>
        /// <returns>top element</returns>
        public double Pop() 
        {
            index--;
            return array[index];
        }
        
        /// <summary>
        /// Check if empty
        /// </summary>
        /// <returns>true if empty</returns>
        public bool IsEmpty() => index == 0;
        
    }
}
