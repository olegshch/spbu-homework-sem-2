using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreeCalculator;

namespace TreeCalcWindow
{
    class Program
    {
        static void Main(string[] args)
        {
            TreeCalculator.TreeCalculator calc = new TreeCalculator.TreeCalculator();
            Console.WriteLine(calc.Calculate("+ 1 * / 8 4 3"));
            //Console.ReadKey();
            calc.Print("+ 1 * / 8 4 3");
            Console.WriteLine();
            Console.WriteLine(calc.Index);
            Console.ReadKey();
            //calc.Calculate("+ 1 * / 8 4 3");
            //calc.Print("+ 1 * / 8 4 3");
        }
    }
}
