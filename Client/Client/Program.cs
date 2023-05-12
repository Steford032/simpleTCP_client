using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {

        static async Task Main(string[] args)
        {
            using Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                await client.ConnectAsync("127.0.0.1", 8888);
                Console.WriteLine($"Подключение к {client.RemoteEndPoint} успешно установлено");
            }
            catch(SocketException exc)
            {
                Console.WriteLine($"Не удалось подключиться к {client.RemoteEndPoint} ");
                Console.WriteLine(exc);
            }



        }
    }
}
