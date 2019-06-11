using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleCoder
{
    public static class Code
    {
        /// <summary>
        /// Кодирование строки методом MTF
        /// </summary>
        /// <param name="str">входная строка</param>
        /// <returns>последовательность чисел - кодированная строка</returns>
        public static long[] MTF(string str)
        {
            long[] result = new long[str.Length];

            //здесь будем хранить коды символов
            long[] arr = new long[str.Length];

            //считка посимвольно в массив
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = Convert.ToInt64(str[i]);
            }

            //последовательно печатаем код символа, обновляем остальные значения, текущему коду присваиваем начальный код
            for (int i = 0; i < str.Length; i++)
            {
                result[i] = arr[i];

                //запоминаем старый код элемента для "зануления" ему подобных
                long cur = arr[i];
                for (int k = 0; k < str.Length; k++)
                {
                    if (arr[k] == cur)
                    {
                        arr[k] = 32;
                    }
                }

                //делаем сдвиг предшествовавших элементов
                for (int j = 0; j < str.Length; j++)
                {
                    if (arr[j] < cur)
                    {
                        arr[j]++ ;
                    }
                    
                }               
            }
            return result;
        }

        /// <summary>
        /// Конвертация массива в строку
        /// </summary>
        /// <param name="arr">передаваемый массив</param>
        /// <returns>массив в виде одной строки</returns>
        public static string Converting(long[] arr)
        {
            string result = "";
            for (int i = 0; i < arr.Length; i++)
            {
                result = result + arr[i] + " ";
            }
            return result;
        }
        
        /// <summary>
        /// Кодирование строки методом MTF
        /// </summary>
        static void Main(string[] args)
        {
            //входная строка
            string str = Console.ReadLine();

            //вывод
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write($"{MTF(str)[i]} ");
            }
            
            Console.ReadKey();
        }
    }
}
