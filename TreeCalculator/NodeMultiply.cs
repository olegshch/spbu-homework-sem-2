namespace TreeCalculator
{
    /// <summary>
    /// узел умножения потомков
    /// </summary>
    public class NodeMultiply : OperationNode
    {
        /// <summary>
        /// пересчет собственного значения через поддеревья (умножение)
        /// </summary>
        public override double Value => Left.Value * Right.Value;

        /// <summary>
        /// символ операции
        /// </summary>
        public override string Operation { get; } = "*";
    }
}
