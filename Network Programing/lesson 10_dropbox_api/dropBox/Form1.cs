using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


//https://www.dropbox.com/developers/core/docs#metadata
//https://www.dropbox.com/developers/apps/info/fedkk89jn7el2bj


namespace dropBox
{
    public partial class Form1 : Form
    {
        string st;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            st = webBrowser1.Url.AbsoluteUri.ToString();
            textBox1.Text = st;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://api.dropbox.com/1/oauth2/authorize?response_type=code&client_id=fedkk89jn7el2bj");
            webBrowser1.Navigated += webBrowser1_Navigated;

            //x1KSOCiYEHQAAAAAAAACEEa_hugSZq_YeV0b2neurxY
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WebRequest we = WebRequest.Create("https://api.dropbox.com/1/metadata/auto/copy.txt?acsses_tocen=x1KSOCiYEHQAAAAAAAACEmpPXvWbd6fvKG4o0C4y0fE");
            var t = we.GetResponse();

            var streem = t.GetResponseStream();
            StreamReader sr = new StreamReader(streem);

            string res = sr.ReadToEnd();

            MessageBox.Show(res);
        }

    }
}
