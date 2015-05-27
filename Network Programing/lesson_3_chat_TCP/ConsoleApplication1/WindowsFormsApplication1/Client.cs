using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Client
    {
        IPAddress ipAddr;

        IPEndPoint ipEPServer;
        IPEndPoint ipEPClient;

        Socket sSender;
        String message;

        byte[] buffer;
        int offset;

        public Client()
        {
            ipAddr = IPAddress.Parse("127.0.0.1");

            ipEPServer = new IPEndPoint(ipAddr, 50000);
            ipEPClient = new IPEndPoint(ipAddr, 50001);
        } // constructor

        public void CreateUseer()
        {
            sSender = new Socket(ipEPClient.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sSender.BeginConnect(ipEPServer, new AsyncCallback(OnConnect), sSender);
        }

        public void OnConnect(IAsyncResult ar)
        {
            (ar.AsyncState as Socket).EndConnect(ar);
            byte[] buffers = Encoding.UTF8.GetBytes(message);
            sSender.BeginSend(buffers, offset, Math.Min(1024, buffers.Length), SocketFlags.None, onSend, sSender);
        }

        public void SetMessege(string st)
        {
            offset = 0;
            message = st + Environment.NewLine;
            buffer = new byte[1024];
            buffer = Encoding.UTF8.GetBytes(message);

            CreateUseer();
        }

        void onSend(IAsyncResult res)
        {
            var t = (res.AsyncState as Socket);

            if (offset < Encoding.UTF8.GetBytes(message).Length)
            {
                int bytesRet = sSender.EndSend(res);
                offset += bytesRet;

                sSender.BeginSend(buffer, offset, Math.Min(1024, buffer.Length - offset), SocketFlags.None, (new AsyncCallback(onSend)), t);

            }

            //  sSender.Shutdown(SocketShutdown.Both);
            //  sSender.Close();

        } 


    }
}
