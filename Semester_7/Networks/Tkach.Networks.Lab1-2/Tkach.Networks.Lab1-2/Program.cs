using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Tkach.Networks.Lab1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            // связывание, перевод сокета в режим ожидания
            tcpSocket.Bind(tcpEndPoint);
            Console.WriteLine("~ TCP Server is created");
            // очередь
            tcpSocket.Listen(5);
            Console.WriteLine("~ TCP Server listening...");

            // процесс прослушивания
            while (true)
            {
                var listener = tcpSocket.Accept();
                var dataBuffer = new byte[256];
                var bufferLength = 0;
                var data = new StringBuilder();

                do
                {
                    bufferLength = listener.Receive(dataBuffer);
                    data.Append(Encoding.UTF8.GetString(dataBuffer, 0, bufferLength));
                }
                while (listener.Available > 0);

                Console.WriteLine("~ Message from TCP Client:");
                Console.WriteLine(data);

                listener.Send(Encoding.UTF8.GetBytes("Success"));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}
