using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int interval = 0;

        public Form1()
        {
            InitializeComponent();

        }

        private void shut_down_Click(object sender, EventArgs e)
        {
            interval = int.Parse(numericUpDown3.Value.ToString());
            System.Threading.Thread MyThread1 =
                   new System.Threading.Thread(delegate() { Shutdown(interval); });
            MyThread1.Start();

        }

        Process proc;
        private void Shutdown(int p)
        {
            //MessageBox.Show("через " + p.ToString()+" комп виключиться");
            for (int i = 0; i < p; i++)
            {
                System.Threading.Thread.Sleep(1000);
            }
            //System.Diagnostics.Process.Start("shutdown.exe", "/s /f /t 0");
            //Process.Start("Notepad.exe");
              proc = Process.Start("Notepad.exe");

            //MessageBox.Show("off");
        }

        private void cancel_Click(object sender, EventArgs e)
        {


        }


    }
}
