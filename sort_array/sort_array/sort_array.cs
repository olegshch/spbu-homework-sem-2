namespace SortArray
{
    using System;
    using System.Linq;

    public class Program
    {
        /// <summary>
        /// эта штука сортирует массив
        ///
        /// </summary>
        /// 
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter amount");
            int number = int.Parse(Console.ReadLine());
            int[] arr = new int[number];
            Console.WriteLine("Enter numbers");
            string String = Console.ReadLine();
            int count = 0;
            foreach (int v in String.Split(' ').Select(v => Convert.ToInt32(v)))
            {
                arr[count] = v;
                count++;
            }
            for (count = 0; count < number; count++)
            {
                for (int count2 = 0; count2 < number - 1; count2++)
                {
                    if (arr[count2] > arr[count2 + 1])
                    {
                        int t = arr[count2];
                        arr[count2] = arr[count2 + 1];
                        arr[count2 + 1] = t;
                    }
                }
            }
            for (count = 0; count < number; count++)
            {
                Console.Write($"{arr[count]} ");
            }

            Console.ReadKey();
        }
    }
}
