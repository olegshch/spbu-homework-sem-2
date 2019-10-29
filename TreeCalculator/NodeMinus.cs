namespace TreeCalculator
{
    /// <summary>
    /// узел вычитания потомков
    /// </summary>
    public class NodeMinus : OperationNode
    {
        public override double Value => Left.Value - Right.Value;

        public override string Operation { get; } = "-";
    }
}
