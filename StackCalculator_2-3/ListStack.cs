using System.Collections.Generic;
using System.Linq;
using _2._1;
namespace StackCalculator_2_3
{
    /// <summary>
    /// List stack
    /// </summary>
    public class ListStack : IStack
    {
        private MyList list = new MyList();

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
            if (IsEmpty())
            {
                throw new System.InvalidOperationException();
            }
            else
            {
                double result = list.DataGet(list.Size - 1);
                list.Delete(list.Size - 1);                
                return result;               
            }
        }

        /// <summary>
        /// Check if empty
        /// </summary>
        /// <returns>true if empty</returns>
        public bool IsEmpty() => list.Size == 0;
    }
}
