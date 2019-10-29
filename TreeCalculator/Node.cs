namespace TreeCalculator
{
    /// <summary>
    /// абстрактный класс узла с 2 потомками, значением и самопечатью
    /// </summary>
    public abstract class Node
    {
        public Node Left { get; set; }

        public Node Right { get; set; }

        public abstract double Value { get; }

        public abstract void Print();
    }
}
