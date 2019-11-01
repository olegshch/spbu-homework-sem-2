namespace TreeCalculator
{
    /// <summary>
    /// узел деления потомков
    /// </summary>
    public class NodeDivide : OperationNode
    {
        /// <summary>
        /// пересчет собственного значения через поддеревья (деление)
        /// </summary>
        public override double Value => Left.Value / Right.Value;

        /// <summary>
        /// символ операции
        /// </summary>
        public override string Operation { get; } = "/";        
    }
}
