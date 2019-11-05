using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    /// <summary>
    /// Класс, проводящий вычисления
    /// </summary>
    public class Calculations
    {
        /// <summary>
        /// Символ последней примененной операции
        /// </summary>
        public string OperSymbol { get; set; } = "";
        
        /// <summary>
        /// Результат вычислений
        /// </summary>
        public double Result { get; set; } = 0;
        
        /// <summary>
        /// Операнд
        /// </summary>
        public double Operand { get; set; } = 0;

       /// <summary>
       /// Вычисление по заданному числу. Операция и операнд уже определены
       /// </summary>
       /// <param name="current">заданное число</param>
       /// <returns>результат вычислений</returns>
        public double Calculate(double current)
        {
            switch (OperSymbol)
            {
                case "+":
                    Result = Operand + current;
                    break;

                case "-":
                    Result = Operand - current; 
                    break;

                case "*":
                    Result = Operand * current;
                    break;

                case "/":
                    Result = Operand / current;
                    break;
                case "=":
                    Result = Operand;
                    Operand = 0;
                    break;
            }
            Operand = Result;
            return Result;
        }
    }
}
