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

        public override double Value { get; }

        public override void Print() => Console.Write(Value);
    }
}
