using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8081;

            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);
            Console.WriteLine("~ UDP Server is created");

            while (true)
            {
                var dataBuffer = new byte[256];
                var bufferLength = 0;
                var data = new StringBuilder();
                // содержит адрес клиента
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Console.WriteLine("~ UDP Server listening...");
                do
                {
                    bufferLength = udpSocket.ReceiveFrom(dataBuffer, ref senderEndPoint);
                    data.Append(Encoding.UTF8.GetString(dataBuffer));
                } while (udpSocket.Available > 0);

                udpSocket.SendTo(Encoding.UTF8.GetBytes("Message recieved by UDP Server!"), senderEndPoint);
                Console.WriteLine("~ Message from UDP Client:");
                Console.WriteLine(data);
            }

            udpSocket.Shutdown(SocketShutdown.Both);
        }
    }
}
