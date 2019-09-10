using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackCalculator
{
    public class SCalc
    {
        private class Node
        {
            public double Data { get; set; }
            public Node Next { get; set; }
            public Node(double data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node start;
        public int Size { get; set; }
        public bool IsEmpty() => start == null;

        private Node Get(int position)
        {
            Node current = start;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public void GetSize()
        {
            Console.WriteLine(Size);
        }

        public bool Add(string symbol)
        {
            
            if (symbol == "+" || symbol == "-" || symbol == "*" || symbol == "/") Operate(symbol);
            else
            {
                double data = double.Parse(symbol);
                Node newNode = new Node(data, null);
                if (Size == 0)
                {
                    newNode.Next = start;
                    start = newNode;
                }
                else
                {
                    var current = Get(Size - 1);
                    newNode.Next = current.Next;
                    current.Next = newNode;
                }
                Size++;

            }
                return true;
        }
       
        private bool Delete(int position)
        {
            if (Size < 2) return false;
            if (position == 0) start = start.Next;
            else
            {
                Node current = Get(position - 1);
                current.Next = current.Next.Next;
            }
            Size--;
            return true;
        }

        public void Operate(string symbol)
        {
            if (Size > 1)
            {
                double result;
                if (symbol == "+")
                {
                    result = Get(Size - 1).Data + Get(Size - 2).Data;
                    Add(result.ToString());
                    Delete(Size - 2);
                    Delete(Size - 2);
                }
                if (symbol == "-")
                {
                    result = Get(Size - 1).Data - Get(Size - 2).Data;
                    Add(result.ToString());
                    Delete(Size - 2);
                    Delete(Size - 2);
                }
                if (symbol == "*")
                {
                    result = Get(Size - 1).Data * Get(Size - 2).Data;
                    Add(result.ToString());
                    Delete(Size - 2);
                    Delete(Size - 2);
                }
                if (symbol == "/")
                {
                    if(Get(Size - 1).Data != 0)
                    {
                        result = Get(Size - 2).Data / Get(Size - 1).Data;
                        Add(result.ToString());
                        Delete(Size - 2);
                        Delete(Size - 2);
                    }
                    if (Get(Size - 1).Data == 0)
                    {
                        Console.WriteLine("divider can't be 0");
                        Delete(Size - 1);
                    }


                }
            }
              
        }
       
        public void Print()
        {
            if (Size > 1) Console.WriteLine("Not empty");
            if (Size == 0) Console.WriteLine("Absolutely empty");
            if (Size == 1)
            {
                var current = Get(Size - 1);
                Console.WriteLine(current.Data);
            }
        }

        public void PrintList()
        {
            Node current = start;
            for (int i = 0; i < Size; i++)
            {
                Console.Write($"{ current.Data.ToString()} ");
                current = current.Next;
            }
            Console.WriteLine("\n");
        }

    }
}
