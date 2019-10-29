namespace TreeCalculator
{
    /// <summary>
    /// Класс узла, в котором либо значения либо операции
    /// </summary>
    public class Node
    {
        /// <summary>
        /// обрабатываемая позиция выражения
        /// </summary>
        public int index;

        /// <summary>
        /// обрабатываемое выражение
        /// </summary>
        public string[] expression;

        /// <summary>
        /// результат поддерева для операций или само значение для значений
        /// </summary>
        public double Data { get; set; }
        
        /// <summary>
        /// до какого места дошло вычисление левого поддерева
        /// </summary>
        private int MaxIndex { get; set; }

        /// <summary>
        /// правое поддерево
        /// </summary>
        private Node Right { get; set; }

        /// <summary>
        /// левое поддерево
        /// </summary>
        private Node Left { get; set; }

        /// <summary>
        /// конструктор узла
        /// </summary>
        /// <param name="expression">выражение</param>
        /// <param name="index">индекс символа в выражении</param>
        public Node(string[] expression, int index)
        {
            this.expression = expression;
            this.index = index;                             
        }

        /// <summary>
        /// рекурсивное построение поддеревьев
        /// - создание и вычисление левого поддерева
        /// - создание и вычисление правого поддерева
        /// - вычисление значения узла
        /// - пересчет MaxIndex
        /// </summary>
        /// <param name="operation">либо число либо операция (влияет на логику построения)</param>
        public void MakeSons(string operation)
        {
            switch (operation)
            {
                case ("+"):
                    Left = new Node(expression, index + 1);
                    Left.MakeSons(expression[index + 1]);
                    Right = new Node(expression, Left.MaxIndex + 1);
                    Right.MakeSons(expression[Left.MaxIndex + 1]);
                    Data = Left.Data + Right.Data;
                    MaxIndex = System.Math.Max(Left.MaxIndex, Right.MaxIndex);
                    break;

                case ("-"):
                    Left = new Node(expression, index + 1);
                    Left.MakeSons(expression[index + 1]);
                    Right = new Node(expression, Left.MaxIndex + 1);
                    Right.MakeSons(expression[Left.MaxIndex + 1]);
                    Data = Left.Data - Right.Data;
                    MaxIndex = System.Math.Max(Left.MaxIndex, Right.MaxIndex);
                    break;

                case ("*"):
                    Left = new Node(expression, index + 1);
                    Left.MakeSons(expression[index + 1]);
                    Right = new Node(expression, Left.MaxIndex + 1);
                    Right.MakeSons(expression[Left.MaxIndex + 1]);
                    Data = Left.Data * Right.Data;
                    MaxIndex = System.Math.Max(Left.MaxIndex, Right.MaxIndex);
                    break;

                case ("/"):
                    Left = new Node(expression, index + 1);
                    Left.MakeSons(expression[index + 1]);
                    Right = new Node(expression, Left.MaxIndex + 1);
                    Right.MakeSons(expression[Left.MaxIndex + 1]);
                    Data = Left.Data / Right.Data;
                    MaxIndex = System.Math.Max(Left.MaxIndex, Right.MaxIndex);
                    break;

                default:
                    Data = double.Parse(expression[index]);
                    MaxIndex = index;
                    break;
            }
        }
        
    }
}
