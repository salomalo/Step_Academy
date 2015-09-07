using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TableToClass
{
    public partial class Form2 : Form
    {
        public static string StrConnect;
        public Form2()
        {
            InitializeComponent();
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            StrConnect = "Data Source=" + Server.Text +
                ";User Id=" + User.Text +
                ";Password=" + Password.Text +
                ";Initial Catalog=" + DataBase.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
