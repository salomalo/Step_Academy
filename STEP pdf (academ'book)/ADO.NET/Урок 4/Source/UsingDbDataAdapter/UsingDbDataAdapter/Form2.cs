using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UsingDbDataAdapter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string ServerName
        {
            get
            {
                return Server.Text;
            }
        }
        public string DBName
        {
            get
            {
                return DataBase.Text;
            }
        }
        public string UserName
        {
            get
            {
                return User.Text;
            }
        }
        public string Password
        {
            get
            {
                return Pwd.Text;
            }
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

       
    }
}
