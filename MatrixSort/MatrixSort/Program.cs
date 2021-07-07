using System;
using System.Linq;

namespace MatrixSort
{
    class Program
    {
        /// <summary>
        /// Сортировка матрицы на основе пузырька за O(N^3)
        /// </summary>
        /// <param name="array">Двумерный массив</param>
        private static int[,] BubbleSort(int[,] array)
        {
            for (int i = 0; i < array.GetLongLength(1); i++)
            {
                for (int j = 0; j < array.GetLongLength(1) - 1; j++)
                {
                    if (array[0, j] > array[0, j + 1])
                    {
                        for (int k = 0; k < array.GetLongLength(0); k++)
                        {
                            var t = array[k, j];
                            array[k, j] = array[k, j + 1];
                            array[k, j + 1] = t;
                        }
                    }
                }
            }

            return array;
        }

        /// <summary>
        /// Считка параметров матрицы и самой матрицы, вывод отсортированной матрицы
        /// </summary>
        static void Main(string[] args)
        {
            //Getting parametres
            Console.WriteLine("Ведите количество строк");
            int strings = int.Parse(Console.ReadLine());
            Console.WriteLine("Ведите количество столбцов");
            int columns = int.Parse(Console.ReadLine());
            int[,] array = new int[strings, columns];
            Console.WriteLine("Вводите матрицу");

            //Reading matrix
            for (int i = 0; i < strings; i++)
            {
                int count = 0;
                string currentstring = Console.ReadLine();
                
                foreach (int element in currentstring.Split(' ').Select(element => Convert.ToInt32(element)))
                {
                    array[i, count] = element;
                    count++;
                }
            }

            //Sorting
            array = BubbleSort(array);

            //Printing
            Console.Write("result:");
            Console.Write("\n");
            for (int i = 0; i < strings; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{array[i,j]} ");
                }
                Console.Write("\n");
            }
        }
    }
}
