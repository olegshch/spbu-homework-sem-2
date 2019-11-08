using System;
using System.Collections.Generic;
using System.IO;

namespace Game
{
    /// <summary>
    /// описание игры
    /// </summary>
    public class Game
    {
        /// <summary>
        /// карта хранится в списке списков
        /// </summary>
        public List<List<char>> Map { get; set; }
        
        /// <summary>
        /// позиция собаки описывается парой координат
        /// </summary>
        private (int, int) position;

        /// <summary>
        /// считывание карты
        /// </summary>
        /// <param name="path">путь к файлу</param>
        public Game(string path)
        {
            var reader = new StreamReader(path);
            Map = new List<List<char>>();

            string line = reader.ReadLine();
            int index = 0;
            while (line != null)
            {
                Map.Add(new List<char>());
                for (var i = 0; i < line.Length; ++i)
                {
                    Map[index].Add(line[i]);
                }
                index ++;
                line = reader.ReadLine();
            }
            
        }

        /// <summary>
        /// стопор для персонажа
        /// </summary>
        /// <param name="x">1 координата</param>
        /// <param name="y">2 координата</param>
        /// <returns>true, если ходить нельзя</returns>
        private bool IsStop(int x, int y) => Map[x][y] == '+';

        /// <summary>
        /// смена позиции персонажа
        /// </summary>
        /// <param name="xx">новая 1 координата</param>
        /// <param name="yy">новая 2 координата</param>
        private void Move(int xx, int yy)
        {
            if (!IsStop(xx, yy))
            {
                Map[position.Item1][position.Item2] = ' ';
                Map[xx][yy] = '@';
                position = (xx, yy);
            }
        }

        /// <summary>
        /// команды контроля персонажем для передвижения на соседние клетки
        /// </summary>
        public void Up(object sender, EventArgs args) => Move(position.Item1 - 1, position.Item2);
        public void Down(object sender, EventArgs args) => Move(position.Item1 + 1, position.Item2);
        public void Left(object sender, EventArgs args) => Move(position.Item1, position.Item2 - 1);
        public void Right(object sender, EventArgs args) => Move(position.Item1, position.Item2 + 1);

        /// <summary>
        /// поиск начальной позиции персонажа
        /// </summary>
        private void Find()
        {
            Console.Clear();
            bool flag = false;
            for (int i=0; i < Map.Count; i++)
            {
                for(int j = 0; j < Map[i].Count; j++)
                {
                    if(Map[i][j] == '@')
                    {
                        if(flag == true)
                        {
                            throw new System.ArgumentException();
                        }
                        flag = true;
                        position = (i, j);
                    }
                }
            }
            if(flag == false)
            {
                throw new System.ArgumentException();
            }
        }

        /// <summary>
        /// проверка на замкнутость контура карты
        /// </summary>
        private void Check()
        {
            bool flag = false;
            for (int i = 0; i< Map[0].Count; i++)
            {
                if(Map[0][i] != '+')
                {
                    flag = true;
                }
            }
            for (int i = 0; i < Map[Map.Count - 1].Count; i++)
            {
                if (Map[Map.Count - 1][i] != '+')
                {
                    flag = true;
                }
            }
            for (int i = 1; i < Map.Count - 1; i++)
            {
                if(Map[i][0] != '+' || Map[i][Map[i].Count - 1] != '+')
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                throw new System.ArgumentException();
            }
            Find();
        }

        
        /// <summary>
        /// печать карты
        /// </summary>
        public void Print(object sender, EventArgs args)
        {
            Console.Clear();
            for (var i = 0; i < Map.Count; ++i)
            {
                for (var j = 0; j < Map[i].Count; ++j)
                {
                    Console.Write(Map[i][j]);
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// Обычная (не событийная) печать карты
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void SimplePrint()
        {
            Console.Clear();
            for (var i = 0; i < Map.Count; ++i)
            {
                for (var j = 0; j < Map[i].Count; ++j)
                {
                    Console.Write(Map[i][j]);
                }
                Console.WriteLine();
            }

        }

        /// <summary>
        /// предстартовые махинации (проверка + печать карты)
        /// </summary>
        public void Start()
        {
            Check();
            SimplePrint();
        }
    }
}
