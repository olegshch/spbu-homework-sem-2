using System;

namespace ConsoleWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new TreeCalculator.TreeCalculator();
            string str = "+ - * / 2 3 4 5";
            var result = calc.Calculate(str);
            Console.WriteLine(result);
            calc.Print(str);
        }
    }
}
