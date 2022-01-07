using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region TCP
            const string ip = "127.0.0.1";
            const int port = 8080;

            var tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("~ TCP Client is created");

            Console.WriteLine("~ Insert message:");
            var message = Console.ReadLine();

            var data = Encoding.UTF8.GetBytes(message);
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data);

            var dataBuffer = new byte[256];
            var bufferLength = 0;
            var answer = new StringBuilder();

            do
            {
                bufferLength = tcpSocket.Receive(dataBuffer);
                answer.Append(Encoding.UTF8.GetString(dataBuffer, 0, bufferLength));
            }
            while (tcpSocket.Available > 0);

            Console.WriteLine("~ Server respond:");
            Console.WriteLine(answer);

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadKey();
            #endregion
        }
    }
}
