using System;

namespace Fibonachchi
{
    class Program
    {
        public static int Fib(int number)
        {
            int first = 1;
            int second = 1;
            int sum;
            for (int i = 0; i < number-2; i++)
            {
                sum = first + second;
                first = second;
                second = sum;
            }
            return second;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(number));
        }
    }
}
