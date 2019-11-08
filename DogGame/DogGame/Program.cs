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
            var eventLoop = new EventLoop.EventLoop();
            var game = new Game.Game("..\\..\\map.txt");
            game.Find();
            eventLoop.LeftHandler += game.Left;
            eventLoop.RightHandler += game.Right;
            eventLoop.UpHandler += game.Up;
            eventLoop.DownHandler += game.Down;

            eventLoop.UpHandler += game.Print;
            eventLoop.DownHandler += game.Print;
            eventLoop.LeftHandler += game.Print;
            eventLoop.RightHandler += game.Print;

            eventLoop.Run();
            
        }
    }
}
