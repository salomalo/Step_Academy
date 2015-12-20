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
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void Show_Click(object sender, EventArgs e)
        {
            Child form1 = new Child(textBox1.Text);
            form1.ShowDialog();
        }
    }
}
