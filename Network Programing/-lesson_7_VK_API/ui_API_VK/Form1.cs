using Newtonsoft.Json;
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

namespace ui_API_VK
{
    public partial class Form1 : Form
    {
        string st;
        public Form1()
        {
            InitializeComponent();
        }

        string token = "76286ec72814e280c1869ca473ee0645ff3717b1a7baaa540df4bca8eea1d18f70cbcd052ca31aa222016";

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            st = webBrowser1.Url.AbsoluteUri.ToString();
            textBox1.Text = st;
        }

        public void GetFriend()
        {
            HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(String.Format("https://api.vk.com/method/friends.get?user_id=11137346&order=name&fields=city&name_case=nom&access_token=" + token));
            HttpWebResponse myResp = (HttpWebResponse)myReq.GetResponse();

            StreamReader myStream = new StreamReader(myResp.GetResponseStream(), Encoding.UTF8);

            string html = myStream.ReadToEnd();

            RootObject root = JsonConvert.DeserializeObject<RootObject>(html); // create my own clas from json

            webBrowser1.DocumentText = html;

            foreach (Response r in root.response)
            {
                richTextBox1.Text += r.first_name+ " "+r.last_name+Environment.NewLine;
            }            
        }

        public class Response
        {
            public int uid { get; set; }
            public string first_name { get; set; }
            public string last_name { get; set; }
            public int city { get; set; }
            public int user_id { get; set; }
        }

        public class RootObject
        {
            public List<Response> response { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetFriend();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://oauth.vk.com/authorize?client_id=4935015&scope=friends&redirect_uri=https://oauth.vk.com/blank.html&display=popup&v=5.33&response_type=token");
            webBrowser1.Navigated += webBrowser1_Navigated;
        }



    }
}
