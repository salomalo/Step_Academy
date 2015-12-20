using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms_2_19_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            for( int i = 0; i < tabControl1.Controls.Count; i++)
            {
                tabControl1.Controls[i].Text = (i + 1) + " page";
            }
            foreach (Control c in tpFirst.Controls)
            {
              //  MessageBox.Show(c.Name);
            }

            dateTimePicker1.Value = DateTime.UtcNow; 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c is CheckBox)
                {
                    if (((CheckBox)c).Checked)
                    {
                        MessageBox.Show(((CheckBox)c).Text);
                    }
                }
            }

            MessageBox.Show(dateTimePicker1.Value.ToString());
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                textBox1.BackColor = Color.Red;
                textBox1.Text = "Red";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                textBox1.BackColor = Color.Blue;
                textBox1.Text = "Blue";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                textBox1.BackColor = Color.Pink;
                textBox1.Text = "Pink";
            }
        }

        private void tpForth_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String str = ((TextBox)sender).Text;
            if (str.Length > 20)
            {
                ((TextBox)sender).Text = str.Substring(0,19);
            }
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                btnPress.Enabled = true;
            }
            else
            {
                btnPress.Enabled = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox3.Text;
           
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.SelectAll();
        }

    }
}
