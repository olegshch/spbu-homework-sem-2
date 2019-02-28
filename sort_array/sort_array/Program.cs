using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sort_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string st = Console.ReadLine();
            int i = 0;
            foreach (int v in st.Split(' ').Select(v => Convert.ToInt32(v)))
            {
                arr[i++] = v;
            }
            for (i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int t = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = t;
                    }
                }
            }
            for (i = 0; i < n; i++)
            {
                Console.Write($"{arr[i]} ");
            }

            Console.ReadKey();
        }
    }
}
