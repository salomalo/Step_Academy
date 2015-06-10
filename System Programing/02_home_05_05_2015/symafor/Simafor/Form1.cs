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
        int count = 0;

        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                comboBox1.Items.Add(i);
            }

           
       
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadStart ts = new ThreadStart(Method1);
            Thread t = new Thread(ts);
            t.Name = "thread";

            AddThread(t);


            MessageBox.Show(listBox1.Items.Count.ToString());

            ////
            //for (int i = 0; i < listBox1.Items.Count; ++i)
            //   ThreadPool.QueueUserWorkItem(Method2, s);
        
        }

        public void AddThread(Thread t)
        {
           listBox1.Items.Add(t.Name + " " + t.ManagedThreadId);      
        }

        private void Method1()
        {
            count++;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count=comboBox1.SelectedIndex + 1;
            s = new Semaphore(count, count, "My_SEMAPHORE");
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        public void Method2(object obj)
        {
            Semaphore s = obj as Semaphore;
            bool stop = false;

            while (!stop)
            {
                if (s.WaitOne())
                {
                    try
                    {
                        //  Console.WriteLine("Поток {0} блокировку получил", Thread.CurrentThread.ManagedThreadId);
                        //  Thread.Sleep(2000);
                        Method1();
                    }
                    finally
                    {
                        stop = true;//коли завершиться пеший потік
                        s.Release();
                        //  Console.WriteLine("Поток {0} блокировку снял", Thread.CurrentThread.ManagedThreadId);
                    }
                }
                else
                {
                    //  Console.WriteLine("Таймаут для потока {0} истек. Повторное ожидание", Thread.CurrentThread.ManagedThreadId);
                }

            }
        }

        private void listBox3_MouseClick(object sender, MouseEventArgs e)
        {

            listBox2.Items.Remove(listBox1.SelectedItem);


        }



    }
}
