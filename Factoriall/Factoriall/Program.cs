using System;

namespace Factoriall
{
    class Program
    {
        public static int Fact(int number)
        {
            if (number <= 1)
            {
                return 1;
            }
            else
            {
                return number * Fact(number - 1);
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine(Fact(number));
            
        }
    }
}
