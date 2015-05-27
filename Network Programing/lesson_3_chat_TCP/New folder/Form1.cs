using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatTcp
{
	public partial class Form1 : Form
	{
		ChatClient chatClient;
		ChatServer chatServer;
		
		IPEndPoint ipClient, ipServer;
		
		public Form1()
		{
			InitializeComponent();
			InitListeners();

		}

		public void InitListeners()
		{
			btnCreateClient.Click += btnCreateClient_Click;
			btnCreateServer.Click += btnCreateServer_Click;
			btnSend.Click +=btnSend_Click;
		}

		void btnSend_Click(object sender, EventArgs e)
		{
 			if (chatClient != null && tbxSendMsg.Text != null)
			{
				string msg = tbxSendMsg.Text;
				chatClient.SendMessage(msg);
			}
		}

		void btnCreateClient_Click(object sender, EventArgs e)
		{
			IPAddress ip; 
			int port;
			string login = tbxLogin.Text;
			if ( Int32.TryParse(tbxClientPort.Text, out port) &&
				 IPAddress.TryParse(tbxClientIp.Text, out ip))
			{
				try
				{					
					ipServer = new IPEndPoint(ip, port);			
		 			
				//	ipClient = new IPEndPoint(Dns.GetHostEntry("localhost").AddressList[0], port);
					ipClient = new IPEndPoint(IPAddress.Parse("192.168.1.50"), port);
					//---------------------------------------
					chatClient = new ChatClient(ipClient,ipServer, login);					
				}
				catch (WebException exc)
				{

				}
			}

		}

		void btnCreateServer_Click(object sender, EventArgs e)
		{
			IPAddress ip; 
			int port;
			if (IPAddress.TryParse(tbxServerIp.Text,out ip) && Int32.TryParse(tbxServerPort.Text,out port))
			{
				try
				{					
					ipServer = new IPEndPoint(ip, port);
					chatServer = new ChatServer(new IPEndPoint(ip, port));
					chatServer.OnTextRecieved += new EventHandler(TextRecieved);
				}
				catch(WebException exc)
				{
					
				}
			}
			else
			{
				MessageBox.Show("Write correct ip or port");
			}
			
		}

		public void TextRecieved(object obj, EventArgs e)
		{
			tbxRecieveMsg.Text = chatServer.message;
		}
	}
}
