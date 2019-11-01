namespace TreeCalculator
{
    /// <summary>
    /// узел сложения потомков
    /// </summary>
    public class NodePlus : OperationNode
    {
        /// <summary>
        /// пересчет собственного значения через поддеревья (сложение)
        /// </summary>
        public override double Value => Left.Value + Right.Value;

        /// <summary>
        /// символ операции
        /// </summary>
        public override string Operation { get; } = "+";
    }
}
