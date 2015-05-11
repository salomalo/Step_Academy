using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simafor
{
    public partial class Form1 : Form
    {
        Semaphore s = new Semaphore(3, 3, "My_SEMAPHORE"); // скільки можна заняти з початку (доступне місце ) , максимум який може доступитися
          
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                comboBox1.Items.Add(i);
            }
        }

        List<Thread> lt = new List<Thread>();

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(Method1);
            Thread t = new Thread(ts);
            t.Name = "thread";
        
            AddThread(t);
          //  listBox1.Items.Add(t.Name + number.ToString());
        }

      //  List<Thread> sli = new List<Thread>();
        public void AddThread(Thread t)
        {
            int number = 0;

            foreach (Thread s in listBox1.Items)
            {
                if (t.Name.StartsWith("thread"))
                {
                    number++;
                }
                if (number > 0)
                {
                    t.Name = "thread" + number.ToString();
                }
            }

            MessageBox.Show(t.Name);
        }

        private void Method1()
        {
            for (int i = 0; i < 10; i++)
            {
                MessageBox.Show(i.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            s = new Semaphore(comboBox1.SelectedIndex + 1, comboBox1.SelectedIndex + 1);
        }
    }
}
