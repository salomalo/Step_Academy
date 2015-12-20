using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConfirmChoice
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Child form1 = new Child();
            if (form1.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(form1.TText);
            }
        }
    }
}
