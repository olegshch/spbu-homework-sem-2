using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spiral
{
    class Program
    {
        static void Move (int i, int j, int edge, int value,  int [,] array)
        {
            if (i >= 0 && j >= 0)
            {
                for (int k = 0; k < edge - 1; k++)
                {
                    array[i + k, j] = value;
                    value++;
                }
                for (int k = 0; k < edge - 1; k++)
                {
                    array[i + edge - 1, j + k] = value;
                    value++;
                }
                for (int k = 0; k < edge - 1; k++)
                {
                    array[i + edge - 1 - k, j + edge - 1] = value;
                    value++;
                }
                for (int k = 0; k < edge - 1; k++)
                {
                    array[i, j + edge - 1 - k] = value;
                    value++;
                }
                Move(i - 1, j - 1, edge + 2, value, array);
            }
        }

        static void Print(int [,] arr, int n)
        {
            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i, j]} ");
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter odd positive number");
            odd: 
            positive: 
            int n = int.Parse(Console.ReadLine());
            if (n % 2 == 0)
            {
                Console.WriteLine("Number must be odd");
                goto odd;
            }
            if (n<1)
            {
                Console.WriteLine("Number must be positive");
                goto positive;
            }
            int [,] arr = new int[n,n];
            arr[n / 2, n / 2] = 1;
            Move(n / 2-1, n / 2-1, 3, 2, arr);
            Print(arr, n);
            Console.ReadKey();
        }
    }
}
