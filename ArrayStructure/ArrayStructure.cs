using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayStructure
{
    public class ACalc
    {
        private double[] arr = new double[10000];
        private int Position { get; set; }

        public bool Add(string symbol)
        {
            double data = double.Parse(symbol);
            arr[Position] = data;
            Position++;
            return true;
        }

        public void GetSize()
        {
            Console.WriteLine(Position);
        }

        public void Operate(string symbol)
        {
            if (Position > 1)
            {
                double result;
                if (symbol == "+")
                {
                    result = arr[Position - 1] + arr[Position - 2];
                    arr[Position - 2] = result;
                    Position--;
                }

                if (symbol == "-")
                {
                    result = arr[Position - 1] - arr[Position - 2];
                    arr[Position - 2] = result;
                    Position--;
                }

                if (symbol == "*")
                {
                    result = arr[Position - 1] * arr[Position - 2];
                    arr[Position - 2] = result;
                    Position--;
                }

                if (symbol == "/")
                {
                    if (arr[Position-1] != 0)
                    {
                        result = arr[Position - 2] + arr[Position - 1];
                        arr[Position - 2] = result;
                        Position--;
                    }

                    else
                    {
                        Console.WriteLine("divider can't be 0");
                        Position--;
                    }
                }
            }
        }

        public void Print()
        {
            if (Position > 1) Console.WriteLine("Not empty");
            if (Position == 0) Console.WriteLine("Absolutely empty");
            if (Position == 1) Console.WriteLine(arr[Position-1]);
            
        }

        public void PrintList()
        {
            for (int i = 0; i < Position; i++)
            {
                Console.Write($"{arr[i]} ");               
            }
            Console.WriteLine("\n");
        }
    }
}
