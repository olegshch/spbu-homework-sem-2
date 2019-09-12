using System;
using Interface;

namespace ListStructure
{
    public class LCalc : IStack
    {
        /// <summary>
        /// Узел листа
        /// </summary>
        private class Node
        {
            public double Data { get; set; }
            public Node Next { get; set; }
            public Node(double data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node start;

        //Количество элементов
        public int Size { get; set; }

        /// <summary>
        /// Вспомогательная функция для функции Delete
        /// </summary>
        /// <param name="position"></param>
        /// <returns>нужный узел</returns>
        private Node Get(int position)
        {
            Node current = start;
            for (int i = 0; i < position; i++)
            {
                current = current.Next;
            }
            return current;
        }

        /// <summary>
        /// Возвращает количество чисел
        /// </summary>
        public int GetSize()
        {
            return Size;
        }

        /// <summary>
        /// Добавляет число
        /// </summary>
        /// <param name="symbol">число</param>
        /// <returns>true, если добавление прошло успешно</returns>
        public bool Add(string symbol)
        {
            //Преобразование строки в число
            double data = double.Parse(symbol);

            //Создание и размещение соответствующего узла
            Node newNode = new Node(data, null);
            if (Size == 0)
            {
                newNode.Next = start;
                start = newNode;
            }
            else
            {
                var current = Get(Size - 1);
                newNode.Next = current.Next;
                current.Next = newNode;
            }
            Size++;
            return true;
        }
       
        /// <summary>
        /// Вспомогательная функция, аналог Pop() для стека
        /// </summary>
        /// <param name="position"></param>
        /// <returns>true, если удаление прошло успешно</returns>
        private bool Delete(int position)
        {
            //Проверка на возможность удаления
            if (Size < 2) return false;
            if (position == 0) start = start.Next;
            else
            {
                Node current = Get(position - 1);
                current.Next = current.Next.Next;
            }
            Size--;
            return true;
        }

        /// <summary>
        /// Вспомогательная функция для очистки
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool ExtremeDelete(int position)
        {
            //Проверка на возможность удаления
            if (Size < 1) return false;
            if (position == 0) start = start.Next;
            else
            {
                Node current = Get(position - 1);
                current.Next = current.Next.Next;
            }
            Size--;
            return true;
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
                    result = Get(Size - 1).Data + Get(Size - 2).Data;
                    Add(result.ToString());
                    Delete(Size - 2);
                    Delete(Size - 2);
                }

                if (symbol == "-")
                {
                    result = Get(Size - 2).Data - Get(Size - 1).Data;
                    Add(result.ToString());
                    Delete(Size - 2);
                    Delete(Size - 2);
                }

                if (symbol == "*")
                {
                    result = Get(Size - 1).Data * Get(Size - 2).Data;
                    Add(result.ToString());
                    Delete(Size - 2);
                    Delete(Size - 2);
                }

                if (symbol == "/")
                {
                    if(Get(Size - 1).Data != 0)
                    {
                        result = Get(Size - 2).Data / Get(Size - 1).Data;
                        Add(result.ToString());
                        Delete(Size - 2);
                        Delete(Size - 2);
                    }

                    else
                    {
                        Console.WriteLine("divider can't be 0");
                        Delete(Size - 1);
                    }
                }
            }              
        }

        /// <summary>
        /// Выводит результат вычислений, если выражение было синтаксически завершено
        /// </summary>
        public string Print()
        {
            string result = "";
            if (Size > 1) result = "Not empty";
            if (Size == 0) result = "Absolutely empty";
            if (Size == 1)
            {
                var current = Get(Size - 1);
                result = $"{current.Data}";
            }
            return result;
        }

        /// <summary>
        /// Распечатывает все элементы, находящиеся внутри калькулятора
        /// </summary>
        public string PrintList()
        {
            string result = "";
            Node current = start;
            for (int i = 0; i < Size; i++)
            {
                result+=$"{ current.Data.ToString()} ";
                current = current.Next;
            }
            return result;
        }

        /// <summary>
        /// Очистка
        /// </summary>
        public void Clear()
        {
            while (Size > 0) ExtremeDelete(Size-1);            
        }

    }
}
