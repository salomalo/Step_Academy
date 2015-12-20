using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Cntr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = DateTime.Now.Day;
            domainUpDown1.SelectedIndex = DateTime.Now.Month - 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value++;
            }
            else
            {
                progressBar1.Value = progressBar1.Minimum;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void notToDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not To Do");
        }

        private void toDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To Do");
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
               
                this.ShowInTaskbar = false;
            }
            else
            {
               
                this.ShowInTaskbar = true;
            }
        }


        public int ToDo()
        {
            int sum = 0;
            for (int i = 0; i < 1010101100; i++)
            {
                sum++;
            }
            return sum;

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // textBox2.Text = ToDo().ToString();
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = ToDo().ToString();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            textBox2.Text = e.Result.ToString();
        }

       
    }
}
