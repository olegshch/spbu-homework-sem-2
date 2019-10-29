namespace TreeCalculator
{
    /// <summary>
    /// узел деления потомков
    /// </summary>
    public class NodeDivide : OperationNode
    {
        public override double Value => Left.Value / Right.Value;

        public override string Operation { get; } = "/";
        
    }
}
