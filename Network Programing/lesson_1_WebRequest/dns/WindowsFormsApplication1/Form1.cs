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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        WebResponse wres;
        public Form1()
        {
            InitializeComponent();
            WebClient w = new WebClient();
            String s = w.DownloadString("http://habrahabr.ru/");
            //richTextBox1.Text = s;
            
            WebRequest wReq = WebRequest.Create("http://habrahabr.ru/");
            using (wres = wReq.GetResponse())
            {
                //  richTextBox1.Text = wReq.Headers.ToString();
                // richTextBox1.Text = wres.ContentType.ToString(); // .Headers.ToString(); 
                string tmp;
                string res = wres.GetResponseStream().ReadAsync(tmp,200, wres.ContentLength).Result;
                string find_text = new StreamReader(wres.GetResponseStream(), Encoding.GetEncoding("windows-1251")).ReadToEnd();
                richTextBox1.Text = find_text;
            }




        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
    
        }
    }
}
