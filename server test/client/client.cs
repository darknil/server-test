using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace client
{
    class client
    {
        static void Main(string[] args)
        {
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            try
            {
                client.Connect("127.0.0.1",8080);
                Console.WriteLine("connected");
                Console.ReadLine();
                string message = "hi server";
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                client.Send(buffer);

                byte[] buffer2 = new byte[1024];
                client.Receive(buffer2);
                Console.WriteLine(Encoding.ASCII.GetString(buffer2));
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
