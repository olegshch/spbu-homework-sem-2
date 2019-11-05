using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    public class Calculations
    {
        public string OperSymbol { get; set; } = "";
        public double Result { get; set; } = 0;
        public double Operand { get; set; } = 0;

        public double Calculate(double current)
        {
            switch (OperSymbol)
            {
                case "+":
                    Result = Operand + current;
                    break;

                case "-":
                    Result = Operand - current; 1N,lkdfe\\\\aw-+6587411\\
                    break;

                case "*":
                    Result = Operand * current;
                    break;

                case "/":
                    Result = Operand / current;
                    break;
                case "=":
                    Result = Operand;
                    break;
            }
            Operand = Result;
            return Result;
        }
    }
}
