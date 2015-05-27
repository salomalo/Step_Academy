using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Server

            IPHostEntry ipHost = Dns.GetHostEntry("localhost"); 
            IPAddress ipAddr = ipHost.AddressList[0];
            
			IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);

                while (true)
                {
                    Console.WriteLine("Waiting throug the port - {0}", ipEndPoint);
                    Socket handler = sListener.Accept();
                    string data = null;

                    // 
                    byte[] bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    Console.WriteLine("Text - " + data + "\n");


                    ///////////////
                    //Send response for client 

                    string reply = "Thanks" + data.Length.ToString() + " symbols";
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    handler.Send(msg);
                    if (data.IndexOf("<The end>") > -1)
                    {
                        Console.WriteLine("Text which was recived ");
                        break;
                    }
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.ReadLine();
            }


            ///////////////////////////////////////////////////


        }




    }
}
