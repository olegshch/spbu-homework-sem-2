using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface;

namespace ArrayStructure
{
    public class ACalc : IStack
    {
        private double[] arr = new double[10000];
        public int Size { get; set; }

        public bool Add(string symbol)
        {
            double data = double.Parse(symbol);
            arr[Size] = data;
            Size++;
            return true;
        }

        public void GetSize()
        {
            Console.WriteLine(Size);
        }

        public void Operate(string symbol)
        {
            if (Size > 1)
            {
                double result;
                if (symbol == "+")
                {
                    result = arr[Size - 1] + arr[Size - 2];
                    arr[Size - 2] = result;
                    Size--;
                }

                if (symbol == "-")
                {
                    result = arr[Size - 1] - arr[Size - 2];
                    arr[Size - 2] = result;
                    Size--;
                }

                if (symbol == "*")
                {
                    result = arr[Size - 1] * arr[Size - 2];
                    arr[Size - 2] = result;
                    Size--;
                }

                if (symbol == "/")
                {
                    if (arr[Size-1] != 0)
                    {
                        result = arr[Size - 2] / arr[Size - 1];
                        arr[Size - 2] = result;
                        Size--;
                    }

                    else
                    {
                        Console.WriteLine("divider can't be 0");
                        Size--;
                    }
                }
            }
        }

        public void Print()
        {
            if (Size > 1) Console.WriteLine("Not empty");
            if (Size == 0) Console.WriteLine("Absolutely empty");
            if (Size == 1) Console.WriteLine(arr[Size-1]);
            
        }

        public void PrintList()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"{arr[i]} ");               
            }
            Console.WriteLine("\n");
        }
    }
}
