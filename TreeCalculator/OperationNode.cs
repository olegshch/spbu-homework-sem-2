using System;

namespace TreeCalculator
{
    /// <summary>
    /// узел операции с заданной самопечатью и типом операции
    /// </summary>
    public abstract class OperationNode : Node
    {
        /// <summary>
        /// тип операции
        /// </summary>
        public abstract string Operation { get; }

        /// <summary>
        /// печать поддерева
        /// </summary>
        /// <returns>строка - выражение поддерева</returns>
        public override string Print() => $"{Operation} " + Left.Print() + Right.Print();       
    }
}
