using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackCalculator;

namespace CalcWindow
{
    class Interface
    {
        static void Main(string[] args)
        {
            var calc = new SCalc();
            string s="";
            while (s != "exit")
            {
                s = Console.ReadLine();
                switch (s)
                {
                    case "+":
                        calc.Operate(s);
                        break;
                    case "-":
                        calc.Operate(s);
                        break;
                    case "*":
                        calc.Operate(s);
                        break;
                    case "/":
                        calc.Operate(s);
                        break;
                    case "size":
                        calc.GetSize();
                        break;
                    case "=":
                        calc.Print();
                        break;
                    case "print":
                        calc.PrintList();
                        break;
                    default:
                        calc.Add(s);
                        break;
                }

            }
            Console.ReadKey();
            

        }
    }
}
