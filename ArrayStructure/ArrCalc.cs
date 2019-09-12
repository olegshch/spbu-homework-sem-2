using System;
using Interface;

namespace ArrayStructure
{
    public class ACalc : IStack
    {
        private double[] arr = new double[10000];

        //Количество элементов
        public int Size { get; set; }

        /// <summary>
        /// Добавляет число
        /// </summary>
        /// <param name="symbol">число</param>
        /// <returns>true, если добавление прошло успешно</returns>
        public bool Add(string symbol)
        {
            double data = double.Parse(symbol);
            arr[Size] = data;
            Size++;
            return true;
        }

        /// <summary>
        /// Возвращает количество чисел
        /// </summary>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// Применение соответствующей операции
        /// </summary>
        /// <param name="symbol"></param>
        public void Operate(string symbol)
        {
            //Проверка на возможность выполнения операции
            if (Size > 1)
            {
                double result;

                //Выполнение соответствующих операций
                if (symbol == "+")
                {
                    result = arr[Size - 1] + arr[Size - 2];
                    arr[Size - 2] = result;
                    Size--;
                }

                if (symbol == "-")
                {
                    result = arr[Size - 2] - arr[Size - 1];
                    arr[Size - 2] = result;
                    Size--;
                }

                if (symbol == "*")
                {
                    result = arr[Size - 1] * arr[Size - 2];
                    arr[Size - 2] = result;
                    Size--;
                }

                if (symbol == "/")
                {
                    if (arr[Size-1] != 0)
                    {
                        result = arr[Size - 2] / arr[Size - 1];
                        arr[Size - 2] = result;
                        Size--;
                    }

                    else
                    {
                        Console.WriteLine("divider can't be 0");
                        Size--;
                    }
                }
            }
        }

        /// <summary>
        /// Выводит результат вычислений, если выражение было синтаксически завершено
        /// </summary>
        public string Print()
        {
            string result="";
            if (Size > 1) result = "Not empty";
            if (Size == 0) result = "Absolutely empty";
            if (Size == 1) result = $"{arr[Size-1]}";
            return result;
        }

        /// <summary>
        /// Распечатывает все элементы, находящиеся внутри калькулятора
        /// </summary>
        public string PrintList()
        {
            string result = "";
            for (int i = 0; i < Size; i++)
            {
                result+=$"{arr[i]} ";               
            }
            return result;
        }

        public void Clear()
        {
            Size = 0;
        }
    }
}
