using System;

namespace TreeCalculator
{
    /// <summary>
    /// узел операции с заданной самопечатью и типом операции
    /// </summary>
    public abstract class OperationNode : Node
    {
        public abstract string Operation { get; }

        public override void Print()
        {
            Console.Write($"{Operation} ");
            Left.Print();
            Right.Print();
        }
    }
}
