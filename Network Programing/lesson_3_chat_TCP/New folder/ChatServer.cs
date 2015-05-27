using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTcp
{
	public class ChatServer
	{
		private IPEndPoint _ipServer;
		private Socket sListener;
		public string message;
		byte[] bytes;
		public delegate void TextRecieved(object sender, EventArgs e);
		public event EventHandler OnTextRecieved;

		public ChatServer(IPEndPoint ipServer)
		{
			_ipServer = ipServer;
			SetNewServer();
			MessageBox.Show("Server " + _ipServer + " created");
		}

		public void SetNewServer()
		{
			sListener = new Socket(_ipServer.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			sListener.Bind(_ipServer);			
			sListener.Listen(10);
			
			AsyncCallback callback = new AsyncCallback(OnAccept);
			sListener.BeginAccept(callback, null);
		}

		public void OnAccept(IAsyncResult ar)
		{
			Socket sListenerConnected = sListener.EndAccept(ar);
			sListener.BeginAccept(OnAccept, null);
			bytes = new byte[1024];
			sListenerConnected.BeginReceive(bytes, 0, 1024, SocketFlags.None, OnRecieve, sListenerConnected);			
		}

		public void OnRecieve(IAsyncResult ar)
		{
			Socket sListenerConnected = (ar.AsyncState as Socket);
			int bytesRead = (ar.AsyncState as Socket).EndReceive(ar);
			
			if (bytesRead > 0)
			{				
				message += Encoding.UTF8.GetString(bytes, 0, bytesRead);
				sListenerConnected.BeginReceive(bytes, 0, 1024, SocketFlags.None, OnRecieve, sListenerConnected);
				if (bytesRead < 1024)
				{					
					OnTextRecieved(this, EventArgs.Empty);
				}
			}
			else
			{				
				sListenerConnected.Shutdown(SocketShutdown.Both);
				sListenerConnected.Close();
			}
		}


		
	}
}
