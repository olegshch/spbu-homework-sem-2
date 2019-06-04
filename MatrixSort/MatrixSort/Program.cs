using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixSort
{
    class Program
    {
        /// <summary>
        /// Сортировка матрицы на основе пузырька за O(N^3)
        /// </summary>
        /// <param name="array">Двумерный массив</param>
        /// <param name="strings">Высота матрицы, количество строк</param>
        /// <param name="columns">Ширина матрицы, количество столбцов</param>
        /// <returns></returns>
        static int[,] BubbleSort(int[,] array, int strings, int columns)
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < columns - 1; j++)
                {
                    if (array[0,j] > array[0,j + 1])
                    {
                        for (int k = 0; k < strings; k++)
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
            int count;  
            for (int i = 0; i < strings; i++)
            {
                count = 0;
                string currentstring = Console.ReadLine();
                
                foreach (int element in currentstring.Split(' ').Select(element => Convert.ToInt32(element)))
                {
                    array[i, count] = element;
                    count++;
                }
            }

            //Sorting
            array = BubbleSort(array, strings, columns);

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
