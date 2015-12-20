using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GiveDataModal1
{
    public partial class Child : Form
    {
        public Child(string s)
        {
            InitializeComponent();
            textBox1.Text = s;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
