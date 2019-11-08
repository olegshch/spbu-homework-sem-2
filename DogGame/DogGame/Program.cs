using System;

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
            game.Start();
         
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
