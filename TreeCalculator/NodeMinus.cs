namespace TreeCalculator
{
    /// <summary>
    /// узел вычитания потомков
    /// </summary>
    public class NodeMinus : OperationNode
    {
        /// <summary>
        /// пересчет собственного значения через поддеревья (вычитание)
        /// </summary>
        public override double Value => Left.Value - Right.Value;

        /// <summary>
        /// символ операции
        /// </summary>
        public override string Operation { get; } = "-";
    }
}
