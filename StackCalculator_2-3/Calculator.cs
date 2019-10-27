using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator_2_3
{
    public class Calculator
    {
        private ICalcStack stack;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stack">stack type</param>
        public Calculator(ICalcStack stack)
        {
            this.stack = stack;
        }

        /*
        /// <summary>
        /// Проверяет, является ли введенная строка числом
        /// </summary>
        /// <param name="s">проверяемая строка</param>
        /// <returns>true, если число</returns>
        private static bool IsNumber(string s)
        {
            double result;
            return double.TryParse(s, out result);
        }
        */

        /// <summary>
        /// Expression computing
        /// </summary>
        /// <param name="expression"></param>
        /// <returns>result</returns>
        public double Calculate(string expression)
        {
            // Parsing
            string[] symbols = expression.Split(' ');

            // Checking for every item: number or operation
            foreach (var symbol in symbols)
            {              
                switch (symbol)
                {
                    case "+":
                        Sum();
                        break;

                    case "-":
                        Minus();
                        break;

                    case "*":
                        Multiply();
                        break;

                    case "/":
                        Divide();
                        break;

                    default:
                        stack.Push(double.Parse(symbol));
                        break;

                }
            }
            return stack.Pop();
        }

        /// <summary>
        /// a+b in stack
        /// </summary>
        private void Sum()
        {
            stack.Push(stack.Pop() + stack.Pop());
        }

        /// <summary>
        /// a-b in stack
        /// </summary>
        private void Minus()
        {
            stack.Push((-1)*stack.Pop() + stack.Pop());
        }

        /// <summary>
        /// a*b in stack
        /// </summary>
        private void Multiply()
        {
            stack.Push(stack.Pop() * stack.Pop());
        }

        /// <summary>
        /// a/b in stack
        /// </summary>
        private void Divide()
        {
            stack.Push(1/stack.Pop() * stack.Pop());
        }
    }
}
