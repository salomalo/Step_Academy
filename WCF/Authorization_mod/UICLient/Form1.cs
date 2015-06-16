using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UICLient.ServiceReference1;

namespace UICLient
{
    public class User
    {
        public string Name;
        public string LoginName;

        //public List<string> Surname;
        //public List<string> Pasword;
        public string Token;
        //public DateTime ExpDate;
    }

    public partial class Form1 : Form
    {
        User _us = new User();
        GetUserInfoClient user = new GetUserInfoClient();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            var token = user.Authorize(usLogin.Text, usPass.Text);
        
            var obj = JsonConvert.DeserializeObject<User>(token);

            MessageBox.Show(obj.Token.ToString());

          //  textBox1.Text = user.Authorize(usLogin.Text, usPass.Text);


        }

    }








}
