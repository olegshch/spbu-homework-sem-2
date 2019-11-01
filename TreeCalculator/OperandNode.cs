using System;

namespace TreeCalculator
{
    /// <summary>
    /// узел операнда с заданной самопечатью и значением из строки
    /// </summary>
    public class OperandNode : Node
    {
        public OperandNode(string value)
        {
            Value = double.Parse(value);
        }

        /// <summary>
        /// значение
        /// </summary>
        public override double Value { get; }

        /// <summary>
        /// печать
        /// </summary>
        public override string Print() => $"{Value} ";
    }
}
