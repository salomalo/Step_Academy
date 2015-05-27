using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatTcp
{
	class ChatClient
	{
		private IPEndPoint _ipClient;
		private IPEndPoint _ipServer;
		
		int offset;
		string _login;

		private Socket sSender;
		string message;

		public ChatClient(IPEndPoint ipClient, IPEndPoint ipServer, string login)
		{
			_ipClient = ipClient;
			_ipServer = ipServer;
			_login = login;
			
		}

		
		public void SetClient()
		{
			sSender = new Socket(_ipClient.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			sSender.BeginConnect(_ipServer, new AsyncCallback(OnConnect), sSender);
			//sSender.Connect(_ipServer);
		}

		public void OnConnect(IAsyncResult ar)
		{
			(ar.AsyncState as Socket).EndConnect(ar);
			byte[] buffers = Encoding.UTF8.GetBytes(message);
			sSender.BeginSend(buffers, offset, Math.Min(1024, buffers.Length), SocketFlags.None, OnSend, sSender);
		}

		public void SendMessage(string msg)
		{
			offset = 0;
			message = _login + " " + DateTime.Now.ToShortTimeString() + ": " + msg + Environment.NewLine ;			
			SetClient();
			
		}

		public void OnSend(IAsyncResult ar)
		{
			if (message != null)
			{
				Socket senderSocket = (ar.AsyncState as Socket);
				byte[] buffers = Encoding.UTF8.GetBytes(message);

				if (offset < Encoding.UTF8.GetBytes(message).Length)
				{
					int bytesSent = senderSocket.EndSend(ar);
					offset += bytesSent;
					sSender.BeginSend(buffers, offset, Math.Min(1024, buffers.Length - offset), SocketFlags.None, OnSend, sSender);
				}
				else
				{
					sSender.Shutdown(SocketShutdown.Both);
					sSender.Close();
				}
			}
		}

	}
}
