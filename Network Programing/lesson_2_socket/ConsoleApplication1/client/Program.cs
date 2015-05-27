using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SendMesssageFrom(11000);
            }
            catch (Exception e)
            { 
            Console.WriteLine(e.ToString());

            }
            finally
            {
            Console.ReadLine();
            }
        }

        static void SendMesssageFrom(int port)
        {
            byte[] bytes = new byte[1024];

            // IPAddress ipAddr = IPAddress.Parse("10.7.");
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sender.Connect(ipEndPoint);

            Console.WriteLine("Enter message ");
            string message = Console.ReadLine();

            Console.WriteLine("Socket connect to {0}", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);

            int bytesSent = sender.Send(msg);

            int bytesRec = sender.Receive(bytes);

            Console.WriteLine("server responce {0}",Encoding.UTF8.GetString(bytes,0,bytesRec));
            if (message.IndexOf("<The end>") == -1)
                SendMesssageFrom(port);


            sender.Shutdown(SocketShutdown.Both);
            sender.Close();



            
        }

    }
}
