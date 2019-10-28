namespace StackCalculator_2_3
{
    /// <summary>
    /// Array stack
    /// </summary>
    public class ArrayStack : IStack
    {
        private double[] array = new double[10000];
        private int index = 0;

        /// <summary>
        /// Pushing element
        /// </summary>
        /// <param name="data">element</param>
        public void Push(double data)
        {
            if (index > array.Length - 1)
            {
                throw new System.InvalidOperationException();
            }
            array[index] = data;
            index++;
        }

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
                index--;
                return array[index];
            }           
        }
        
        /// <summary>
        /// Check if empty
        /// </summary>
        /// <returns>true if empty</returns>
        public bool IsEmpty() => index == 0;
        
    }
}
