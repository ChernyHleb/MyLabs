using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8082;

            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);
            Console.WriteLine("~ UDP Client is created");

            while(true)
            {
                Console.WriteLine("~ Insert message:");
                var message = Console.ReadLine();

                var serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8081);
                udpSocket.SendTo(Encoding.UTF8.GetBytes(message), serverEndPoint);

                // получение ответа от сервера
                var dataBuffer = new byte[256];
                var bufferLength = 0;
                var data = new StringBuilder();
                // содержит адрес клиента
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    bufferLength = udpSocket.ReceiveFrom(dataBuffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(dataBuffer));
                } while (udpSocket.Available > 0);

                Console.WriteLine("~ Server respond:");
                Console.WriteLine(data);
                Console.ReadLine();
            }
        }
    }
}
