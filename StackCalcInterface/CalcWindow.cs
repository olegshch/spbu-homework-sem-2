using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ListStructure;
using ArrayStructure;
using Interface;

namespace CalcWindow
{
    class Window
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose the type of calculator structure: list or array");
            string flag;
            flag = Console.ReadLine();
            //IStack calc;
            IStack calc = new ACalc();
            if (flag == "list") calc = new LCalc();
            if (flag == "array") calc = new ACalc();
            
            string s;
            s = Console.ReadLine();
            while (s != "exit")
            {                
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
                    case "":                       
                        break;
                    default:
                        calc.Add(s);
                        break;
                }
                s = Console.ReadLine();
            }
        }
    }
}
