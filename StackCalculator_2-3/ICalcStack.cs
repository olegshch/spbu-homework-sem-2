using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator_2_3
{
    /// <summary>
    /// Stack Interface
    /// </summary>
    public interface ICalcStack 
    {
        /// <summary>
        /// Add element
        /// </summary>
        /// <param name="data">element</param>
        void Push(double data);

        /// <summary>
        /// Delete element
        /// </summary>
        /// <param name="data">element</param>
        double Pop();

        /// <summary>
        /// Check if stack is empty
        /// </summary>
        /// <returns>true if empty</returns>
        bool IsEmpty();
    }
}
