using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventLoop;

namespace DogGame
{
    class Program
    {
        static void Main(string[] args)
        {
            //чтоб курсор не мешал
            Console.CursorVisible = false;

            //запуск eventloop и игры
            var eventLoop = new EventLoop.EventLoop();
            var game = new Game.Game("..\\..\\map.txt");
            //Console.WriteLine("Press 'Enter'");
            game.Find();
         
            eventLoop.LeftHandler += game.Left;
            eventLoop.RightHandler += game.Right;
            eventLoop.UpHandler += game.Up;
            eventLoop.DownHandler += game.Down;

            eventLoop.UpHandler += game.Print;
            eventLoop.DownHandler += game.Print;
            eventLoop.LeftHandler += game.Print;
            eventLoop.RightHandler += game.Print;
            eventLoop.EnterHandler += game.Print;

            eventLoop.Run();
            
        }
    }
}
