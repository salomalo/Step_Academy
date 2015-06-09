using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WindowsFormsApplication1
{
    public class Server
    {
        private IPAddress serverIP;
        private IPEndPoint ipEndPoint; //конечная точка(IP и порт)

        private Socket sListener;
        public String message;

        byte[] buffer = new byte[1024];


        public delegate void TextRecieved(object sender, EventArgs e);
        public event EventHandler OnTextRecieved;


        public Server(string _serverIP, string serverPort)
        {
            //serverIP = IPAddress.Parse("127.0.0.1");

            serverIP = IPAddress.Parse(_serverIP);
            ipEndPoint = new IPEndPoint(serverIP, Int32.Parse(serverPort));
            message = null;

        } // constructor

        public void CreateServer()
        {
            sListener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            sListener.Bind(ipEndPoint);
            sListener.Listen(10);

            sListener.BeginAccept((new AsyncCallback(OnAccept)), sListener); // сокет починає слухатиб колбек на метод виклик коли хтось підкл
        }


        void OnAccept(IAsyncResult res) // коли хтось підкл
        {
            var lsock = res.AsyncState as Socket;

            Socket conect = lsock.EndAccept(res);
            lsock.BeginAccept((new AsyncCallback(OnAccept)), lsock);
            //sListener.BeginAccept((new AsyncCallback(OnAccept)), lsock);
            

            conect.BeginReceive(buffer, 0, 1024, SocketFlags.None, OnReceive, conect);
        }

        
        void OnReceive(IAsyncResult res)
        {
            var lsock = (res.AsyncState as Socket);
            var recievedLength = lsock.EndReceive(res); // вертає скільки ми отримали

            if (recievedLength > 0)
            {
                message = Encoding.UTF8.GetString(buffer, 0, recievedLength);
                (lsock as Socket).BeginReceive(buffer, 0, 1024, SocketFlags.None, OnReceive, (lsock as Socket));


                if (recievedLength < 1024)
                {
                    OnTextRecieved(this, EventArgs.Empty);

                }
 
            }

            else
            {
                lsock.Shutdown(SocketShutdown.Both);
                lsock.Close();
            }

        }

    }
}
