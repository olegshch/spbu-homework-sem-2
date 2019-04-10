using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray

{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter amount");
            int Number = int.Parse(Console.ReadLine());
            int[] Arr = new int[Number];
            Console.WriteLine("Enter numbers");
            string String = Console.ReadLine();
            int Count = 0;
            foreach (int v in String.Split(' ').Select(v => Convert.ToInt32(v)))
            {
                Arr[Count++] = v;
            }
            for (Count = 0; Count < Number; Count++)
            {
                for (int Count2 = 0; Count2 < Number - 1; Count2++)
                {
                    if (Arr[Count2] > Arr[Count2 + 1])
                    {
                        int t = Arr[Count2];
                        Arr[Count2] = Arr[Count2 + 1];
                        Arr[Count2 + 1] = t;
                    }
                }
            }
            for (Count = 0; Count < Number; Count++)
            {
                Console.Write($"{Arr[Count]} ");
            }

            //Console.ReadKey();
        }
    }
}
