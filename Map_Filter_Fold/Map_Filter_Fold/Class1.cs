using System;
using System.Collections.Generic;

namespace Map_Filter_Fold
{
    public class Function
    {
        /// <summary>
        /// Меняет каждый элемент списка (как аргумент функции) на соответствующее значение
        /// </summary>
        /// <param name="inlist"> Входной список</param>
        /// <param name="function"> Функция, меняющая элементы</param>
        public static List<int> Map(List<int> inlist, Func<int, int> function)
        {
            var outlist = new List<int>();
            foreach(int element in inlist)
            {
                outlist.Add(function(element));
            }
            return outlist;
        }

        /// <summary>
        /// Принимает список элементов и возвращает список из элементов, которые прошли через фильтр, заданный функцией
        /// </summary>
        /// <param name="inlist">Входной список</param>
        /// <param name="function"> Булева функция, являющая собой фильтр</param>
        public static List<int> Filter(List<int> inlist, Func<int, bool> function)
        {
            var outlist = new List<int>();
            foreach (int element in inlist)
            {
                if (function(element))
                {
                    outlist.Add(element);
                }
                
            }
            return outlist;
        }

        /// <summary>
        /// Меняет начальное значение функции, последовательно применяя к нему заданную функцию с каждым из элементов списка
        /// </summary>
        /// <param name="inlist">Входной список</param>
        /// <param name="start">Начальное значение функции</param>
        /// <param name="function">функция обоновления результата</param>
        /// <returns></returns>
        public static int Fold(List<int> inlist, int start, Func<int, int, int> function)
        {
            var final = start;
            foreach (int element in inlist)
            {
                final = function(final, element);
            }
            return final;
        }
    }
}
