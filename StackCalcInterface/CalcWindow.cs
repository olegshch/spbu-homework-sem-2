using System;
using System.Collections.Generic;
using ListStructure;
using ArrayStructure;
using Interface;

namespace CalcWindow
{
    class Window
    {
        /// <summary>
        /// Проверяет, является ли введенная строка числом
        /// </summary>
        /// <param name="s">проверяемая строка</param>
        /// <returns>true, если число</returns>
        public static bool IsNumber(string s)
        {
            double result;
            return double.TryParse(s, out result);
        }

        static void Main(string[] args)
        {
            //Выбор типа калькулятора
            Console.WriteLine("Choose the type of calculator structure: list or array");
            string flag;
            flag = Console.ReadLine();
            IStack calc = new ACalc();
            if (flag == "list") calc = new LCalc();
            if (flag == "array") calc = new ACalc();

            //Множество операторов
            SortedSet<string> myset = new SortedSet<string>()
            {
                "+","-","*","/"
            };
            
            //Начало работы. Стоп-слово - "exit"
            string s;
            s = Console.ReadLine();            
            while (s != "exit")
            {
                //Проверка на оператор
                if (myset.Contains(s)) calc.Operate(s);
                else
                {
                    //Проверка на число
                    if (IsNumber(s)) calc.Add(s);
                    else
                    {
                        switch (s)
                        {
                            //возможность запросить текущий размер "стека" по команде
                            case "size":
                                Console.WriteLine(calc.GetSize());
                                break;

                            //вывод результата
                            case "=":
                                Console.WriteLine(calc.Print());
                                break;

                            //можно вывести все содержимое "стека" на данный момент
                            case "print":
                                calc.PrintList();
                                break;
                            //очистка
                            case "clear":
                                calc.Clear();
                                break;
                            //Для остального мусора
                            default:                                
                                break;
                        }
                    }
                    
                }               
                s = Console.ReadLine();
            }
        }
    }
}
