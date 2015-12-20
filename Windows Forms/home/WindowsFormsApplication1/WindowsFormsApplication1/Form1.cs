using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("out");
            }
        }

        private void rectangleShape1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                MessageBox.Show("in");
            }
        }


        private void rectangleShape1_Click(object sender, EventArgs e)
        {

           


        }

        private void rectangleShape1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                Text = "Height: " + Form1.ActiveForm.Size.Height.ToString() + " Width: " + Form1.ActiveForm.Size.Width.ToString();
            }
        }

        private void rectangleShape1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "X: " + e.X.ToString() + " Y: " + e.Y.ToString();
        }




    }
}
