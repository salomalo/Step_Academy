using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_1
{
    public partial class MyForm : Form
    {
        public MyForm()
        {            
            InitializeComponent();
            btnClick.Text = "Hello";
            TextBox tb = new TextBox();
            this.Controls.Add(tb);
         //   this.Click += MyForm_Click;
        }

        private void MyForm_Load(object sender, EventArgs e)
        {
           // DialogResult res = MessageBox.Show("Load", "Message", 
           //     MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

         //   if (res == System.Windows.Forms.DialogResult.Cancel || res == System.Windows.Forms.DialogResult.No)
         //   {
              //  this.Close();  //закриває поточну форму
        //        Application.Exit(); // закриває програму
        //    }
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked");
        }

        private void MyForm_Click(object sender, EventArgs e)
        {

        }

        private void btnClick_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("Button clicked by left mouse btn");
            }
            else
            {
                MessageBox.Show("Button clicked by right mouse btn");
            }
        }

        private void MyForm_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("Form clicked by left mouse btn");
            }
            else
            {
                MessageBox.Show("Form clicked by right mouse btn");
            }*/
            tbMessage.Text += "mclick ";
            
            this.Text = String.Format("X-{0}, Y-{1}", e.Location.X, e.Y);
        }

        private void MyForm_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show(String.Format("Clicks {0}", e.Clicks));
        }

        private void MyForm_MouseDown(object sender, MouseEventArgs e)
        {
            tbMessage.Text += "mdown ";
        }

        private void MyForm_MouseUp(object sender, MouseEventArgs e)
        {
            tbMessage.Text += "mup ";
        }

        private void MyForm_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Pink;
        }

        private void MyForm_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }

        private void MyForm_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

        private void MyForm_MouseMove(object sender, MouseEventArgs e)
        {
            this.BackColor = Color.Green;
        }

        /*private void MyForm_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }*/


    }
}
