using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        Client client;
        Server server;

        string Username;
        string msg;

        public Form1()
        {
            InitializeComponent();
        }

        private void start_server_Click(object sender, EventArgs e)
        {
            server = new Server(tbIP.Text, tbPortServer.Text);
            server.OnTextRecieved += new EventHandler(TextRecieved);
            server.CreateServer();

        } // start listen 


        private void create_user_Click(object sender, EventArgs e)
        {
            Username = tbxUsername.Text;

            //
           // server = new Server(tbIP.Text, tbPortServer.Text);
            client = new Client(tbIP.Text, tbMyPort.Text, tbPortServer.Text);
        }


        private void send_message_Click(object sender, EventArgs e)
        {
            msg = tbMessage.Text;
            client.SetMessege(msg);

            ///
            SetText(msg);
        } 


        public void TextRecieved(object obj, EventArgs e)
        {
            SetText(server.message);
        }


        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.chat.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.chat.Text = text;
            }
        }

        private void chat_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
