namespace TreeCalculator
{
    /// <summary>
    /// узел сложения потомков
    /// </summary>
    public class NodePlus : OperationNode
    {
        public override double Value => Left.Value + Right.Value;

        public override string Operation { get; } = "+";
    }
}
