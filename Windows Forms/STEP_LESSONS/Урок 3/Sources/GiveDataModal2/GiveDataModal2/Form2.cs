using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiveDataModal2
{
    public partial class Child : Form
    {
        public Child()
        {
            InitializeComponent();
        }
        public string TText
        {
            set
            {
                textBox1.Text=value;
            }
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public DialogResult ShowDialog(string s)
        {
            textBox1.Text = s;
            return ShowDialog();
        }
    }
}
