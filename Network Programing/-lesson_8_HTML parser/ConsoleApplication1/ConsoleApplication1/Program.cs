using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart thst = new ThreadStart(Scanner);
            Thread th = new Thread(thst);
            th.Start();
        }

        public static void Scanner()
        {
            IPAddress ipAddr = IPAddress.Parse("127.0.0.1");
            List<int> portList = new List<int>();
            for (int port = 0; port < 10000; port++)
            {
                try
                {
                    TcpListener server = new TcpListener(ipAddr, port);
                    server.Start();
                    server.Stop();
                }
                catch (Exception x)
                {
                    portList.Add(port);
                    //Console.WriteLine("err");
                }
            }

            foreach (int i in portList)
            {
                Console.WriteLine(i.ToString());
            }
        }

    }
}
