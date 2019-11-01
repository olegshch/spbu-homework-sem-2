namespace TreeCalculator
{
    /// <summary>
    /// класс калькулятора с деревом разбора
    /// </summary>
    public class TreeCalculator
    {
        /// <summary>
        /// счетчик для распределения символов по узлам
        /// </summary>
        int index = 0;

        /// <summary>
        /// массив из символов
        /// </summary>
        string[] Expression;

        /// <summary>
        /// корень дерева 
        /// </summary>
        Node Head; 

        /// <summary>
        /// рекурсивная функция построения дерева
        /// </summary>
        /// <returns>корень дерева</returns>
        private Node Build()
        {
            
            Node current;

            // выбор типа узла и создание поддеревьев
            switch (Expression[index])
            {
                case "+":
                    current = new NodePlus();
                    index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;

                case "-":
                    current = new NodeMinus();
                    index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;

                case "*":
                    current = new NodeMultiply();
                    index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;

                case "/":
                    current = new NodeDivide();
                    index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;
                default:
                    current = new OperandNode(Expression[index]);
                    index++;
                    break;
            }           
            return current;
        }

        /// <summary>
        /// вычисление выражения 
        /// </summary>
        /// <param name="str">выражение</param>
        /// <returns>результат вычисления</returns>
        public double Calculate(string str)
        {            
            Expression = str.Split(' ');
            Node head = Build();
            index = 0;
            return head.Value;           
        }

        /// <summary>
        /// печать дерева разбора
        /// </summary>
        /// <param name="str">выражение</param>
        public string Print(string str)
        {
            Expression = str.Split(' ');
            Node head = Build();
            return head.Print();
        }
    }
        
            
        
    
}
