namespace TreeCalculator
{
    public class Tree
    {
        public double Calculate(string expression)
        {
            string[] symbols = expression.Split(' ');
            Node Boss = new Node(symbols, 0);
            Boss.MakeSons(symbols[0]);
            return Boss.Data;
        }
    }
}
