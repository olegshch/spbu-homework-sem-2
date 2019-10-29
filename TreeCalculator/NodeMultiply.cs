namespace TreeCalculator
{
    /// <summary>
    /// узел умножения потомков
    /// </summary>
    public class NodeMultiply : OperationNode
    {
        public override double Value => Left.Value * Right.Value;

        public override string Operation { get; } = "*";
    }
}
