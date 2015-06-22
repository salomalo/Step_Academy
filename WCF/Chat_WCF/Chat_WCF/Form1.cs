using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat_WCF
{
    public partial class Form1 : Form
    {
        static int RemotePort;
        static int LocalPort;
        static IPAddress RemoteIPAddr;

        public Form1()
        {
            InitializeComponent();
        }

        public void Initial()
        {
            try
            {
                RemoteIPAddr = IPAddress.Parse(tbxRemoteIP.Text);
                RemotePort = Convert.ToInt32(tbxRemotePort.Text);
                LocalPort = Convert.ToInt32(tbxLocalPort.Text);
                //отдельный поток для чтения в методе ThreadFuncReceive
                //этот метод вызывает метод Receive() класса UdpClient,
                //который блокирует текущий поток, поэтому необходим отдельный
                //поток
                Thread thread = new Thread(
                       new ThreadStart(ThreadFuncReceive)
                );
                //создание фонового потока
                thread.IsBackground = true;
                //запуск потока
                thread.Start();
            }
            catch (FormatException formExc)
            {
                MessageBox.Show("Преобразование невозможно :" + formExc);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Ошибка:" + exc.Message);
            }
        }

        public void ThreadFuncReceive()
        {
            try
            {
                while (true)
                {
                    //подключение к локальному хосту
                    UdpClient uClient = new UdpClient(LocalPort);
                    IPEndPoint ipEnd = null;
                    //получание дейтаграммы
                    byte[] responce = uClient.Receive(ref ipEnd);
                    //преобразование в строку
                    string strResult = Encoding.Unicode.GetString(responce) + Environment.NewLine;
                    
                    //вывод на экран
                    SetText(strResult);
                    //tbxChatWindow.Text += strResult;
                   
                    uClient.Close();
                }
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета: :" + sockEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }
        }

        private void btnInitial_Click(object sender, EventArgs e)
        {
            Initial();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendData(tbxEnterMessage.Text);
        }

        public void SendData(string datagramm)
        {
            SetText(tbxClientNick.Text + ": " + datagramm);
            UdpClient uClient = new UdpClient();
            //подключение к удаленному хосту
            IPEndPoint ipEnd = new IPEndPoint(RemoteIPAddr, RemotePort);
            try
            {
                byte[] bytes = Encoding.Unicode.GetBytes(tbxClientNick.Text + ": " + datagramm + Environment.NewLine);
                uClient.Send(bytes, bytes.Length, ipEnd);
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета: :" + sockEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }
            finally
            {
                //закрытие экземпляра класса UdpClient
                uClient.Close();
            }
        } // SendData



        delegate void SetTextCallback(string text);
        private void SetText(string text)
        {
            if (this.tbxChatWindow.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.tbxChatWindow.Text += text + Environment.NewLine;
            }
        }





    }
}
