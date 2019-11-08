using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Game
{
    public class Game
    {
        public List<List<char>> Map { get; set; }
        private (int, int) position;

        public Game(string path)
        {
            var reader = new StreamReader(path);
            Map = new List<List<char>>();

            string line;
            int index = 0;
            while ((line = reader.ReadLine()) != null)
            {
                Map.Add(new List<char>());
                for (var i = 0; i < line.Length; ++i)
                {
                    Map[index].Add(line[i]);
                }
                index ++;
            }
            
        }

        private bool IsStop(int x, int y) => Map[x][y] == '+';

        private void Move(int xx, int yy)
        {
            if (!IsStop(xx, yy))
            {
                Map[position.Item1][position.Item2] = ' ';
                Map[xx][yy] = '@';
                position = (xx, yy);
            }
        }

        public void Up(object sender, EventArgs args) => Move(position.Item1 - 1, position.Item2);
        public void Down(object sender, EventArgs args) => Move(position.Item1 + 1, position.Item2);
        public void Left(object sender, EventArgs args) => Move(position.Item1, position.Item2 - 1);
        public void Right(object sender, EventArgs args) => Move(position.Item1, position.Item2 + 1);

        public void Find()
        {
            Console.Clear();
            for (int i=0; i < Map.Count; i++)
            {
                for(int j = 0; j < Map[i].Count; j++)
                {
                    if(Map[i][j] == '@')
                    {
                        position = (i, j);
                    }
                }
            }
        }


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
    }
}
