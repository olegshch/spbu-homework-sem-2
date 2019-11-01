namespace TreeCalculator
{
    /// <summary>
    /// абстрактный класс узла с 2 потомками, значением и самопечатью
    /// </summary>
    public abstract class Node
    {
        /// <summary>
        /// левый сын
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// правый сын
        /// </summary>
        public Node Right { get; set; }

        /// <summary>
        /// значение
        /// </summary>
        public abstract double Value { get; }

        /// <summary>
        /// печать
        /// </summary>
        public abstract string Print();
    }
}
