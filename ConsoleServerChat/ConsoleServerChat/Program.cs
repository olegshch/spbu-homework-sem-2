using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConsoleServerChat
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int port = int.Parse(args[0]);
            
            //Указакие порта и адреса
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(args[1]);
            var server = new TcpListener(ip, port);
            server.Start();
            
            // TCP клиент
            using (var client = new TcpClient("host", port))
            {
                //клиент пишет и очищает буфер
                var stream = client.GetStream();
                var writer = new StreamWriter(stream);
                writer.WriteLine(Console.ReadLine());
                writer.Flush();

                //клиент читает
                var reader = new StreamReader(stream);
                var data = reader.ReadToEnd();
                Console.WriteLine(data);
            }
            
            
            string text;
            string sentText;

            //TCP сервер
            using (var socket = await server.AcceptSocketAsync())
            {
                //сервер читает
                var stream = new NetworkStream(socket);
                var serverReader = new StreamReader(stream);
                text = await serverReader.ReadLineAsync();
                if (text == "exit")
                {
                    server.Stop();
                }

                //сервер пишет
                var serverWriter = new StreamWriter(stream);
                sentText = Console.ReadLine();
                await serverWriter.WriteAsync(sentText);
                if (sentText == "exit")
                {
                    server.Stop();
                }
            }
        }
    }
}
