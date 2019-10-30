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
        private int Index { get; set; } = 0;

        /// <summary>
        /// массив из символов
        /// </summary>
        private string[] Expression { get; set; }

        /// <summary>
        /// корень дерева 
        /// </summary>
        private Node Head { get; } 

        /// <summary>
        /// рекурсивная функция построения дерева
        /// </summary>
        /// <returns>корень дерева</returns>
        private Node Build()
        {
            
            Node current;

            // выбор типа узла и создание поддеревьев
            switch (Expression[Index])
            {
                case ("+"):
                    current = new NodePlus();
                    Index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;

                case ("-"):
                    current = new NodeMinus();
                    Index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;

                case ("*"):
                    current = new NodeMultiply();
                    Index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;

                case ("/"):
                    current = new NodeDivide();
                    Index++;
                    current.Left = Build();
                    current.Right = Build();
                    break;
                default:
                    current = new OperandNode(Expression[Index]);
                    Index++;
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
            Index = 0;
            return head.Value;           
        }

        /// <summary>
        /// печать дерева разбора
        /// </summary>
        /// <param name="str">выражение</param>
        public void Print(string str)
        {
            Expression = str.Split(' ');
            Node head = Build();
            head.Print();
        }
    }
        
            
        
    
}
