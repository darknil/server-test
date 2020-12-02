using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace server_test
{
    class server
    {

      
        static void Main(string[] args)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            try
            {
                server.Bind(ipPoint);
                server.Listen(5);
                Console.WriteLine("server started...");
                Socket client = server.Accept();
                byte[] buffer = new byte[1024];
                client.Receive(buffer);
                Console.WriteLine(Encoding.ASCII.GetString(buffer));
                Console.WriteLine("напиши ответ");
                string message = Console.ReadLine();
                byte[] buffer2 = Encoding.ASCII.GetBytes(message);
                client.Send(buffer2);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }

        }
    }
}
