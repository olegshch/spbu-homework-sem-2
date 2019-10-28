namespace StackCalculator_2_3
{
    /// <summary>
    /// класс, вычисляющий выражение
    /// </summary>
    public class Calculator
    {
        private IStack stack;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="stack">stack type</param>
        public Calculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// Expression computing
        /// </summary>
        /// <param name="expression">expression</param>
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
            var result = stack.Pop();
            if (!stack.IsEmpty())
            {
                throw new System.Exception();
            }
            else return result;
        }

        /// <summary>
        /// a+b in stack
        /// </summary>
        private void Sum() => stack.Push(stack.Pop() + stack.Pop());

        /// <summary>
        /// a-b in stack
        /// </summary>
        private void Minus() => stack.Push(-stack.Pop() + stack.Pop());

        /// <summary>
        /// a*b in stack
        /// </summary>
        private void Multiply() => stack.Push(stack.Pop() * stack.Pop());

        /// <summary>
        /// a/b in stack
        /// </summary>
        private void Divide() => stack.Push(1 / stack.Pop() * stack.Pop());
    }
}
