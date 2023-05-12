using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IPAddress localIp = new IPAddress(new byte[] { 127, 0, 0, 1 });
            IPEndPoint point = new IPEndPoint(new IPAddress(new byte[] {127,0,0,1}), 8888);
            using Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Bind(point);

            Console.WriteLine($"Сокет был создан (SocketInfo: {socket.LocalEndPoint})");
            socket.Listen();
            Console.WriteLine("Ожидание входящих подключений...");
            using Socket client = await socket.AcceptAsync();

            if (client.Connected)
            {
                Console.WriteLine($"Новый клиент {client.RemoteEndPoint} был подключен к серверу");
            }   
        }
    }
}
