using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        Random r;
        List<Button> but;
        public Form1()
        {
            InitializeComponent();
            r = new Random();
            but = new List<Button>();
            but.Add(button1);
            but.Add(button2);
            but.Add(button3);
            but.Add(button4);
            but.Add(button5);
            but.Add(button6);
            but.Add(button7);
            but.Add(button8);
            but.Add(button9);
            but.Add(button10);
            but.Add(button11);
            but.Add(button12);

            foreach (Button b in but)
            {
                b.Text = "0";
            }
           
        }

        private void button17_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            numTimer.Value = numTimer.Maximum;

            timer1.Start();
            foreach (Button b in but)
            {
                b.Text = r.Next(10,30).ToString();
                b.Enabled = true;
            }    
            listBox1.Items.Clear();
        }


        public void Check(Button b)
        {
            if (listBox1.Items.Count == 0)
            {
                listBox1.Items.Add(b.Text);
                b.Enabled = false;
            }
            else
            {
                int last = listBox1.Items.Count;

                int btnDig;
                Int32.TryParse(b.Text, out btnDig);
                int listLast;
                Int32.TryParse(listBox1.Items[last - 1].ToString(), out listLast);
                if (listLast <= btnDig)
                {
                    listBox1.Items.Add(b.Text);
                    b.Enabled = false;
                }
                else if (listLast>btnDig)
                {
                    trackBar1.Value = (trackBar1.Maximum * listBox1.Items.Count) / 12;
                    MessageBox.Show("...GamEOveR...");
                   
                    int res = listBox1.Items.Count;
                    MessageBox.Show("bad: " + res.ToString());

                    timer1.Stop();
                    foreach (Button ba in but)
                    {
                        ba.Enabled = false;
                    }
                }
                if (listBox1.Items.Count == 12)
                {
                    trackBar1.Value = trackBar1.Maximum;
                    MessageBox.Show("..WIN...");
                }
            }
        }


        private void button12_MouseClick(object sender, MouseEventArgs e)
        {        
          
        }

        private void button11_MouseClick(object sender, MouseEventArgs e)
        {   
            
        }

        private void button10_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button9_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void button8_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
        
        }

        private void button6_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button5_MouseClick(object sender, MouseEventArgs e)
        {
          
        }

        private void button4_MouseClick(object sender, MouseEventArgs e)
        {
         
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
   
        }

        private void button2_MouseClick(object sender, MouseEventArgs e)
        {
   
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
      
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            numTimer.Value-=1;

            if (numTimer.Value == 0)
            {
                timer1.Stop();

                if (listBox1.Items.Count == 12)
                {
                    trackBar1.Value = trackBar1.Maximum;
                    MessageBox.Show("..WIN...");
                }
                else {
                    trackBar1.Value = (trackBar1.Maximum * listBox1.Items.Count) / 12;
                    MessageBox.Show("...GamEOveR...");
                    
                    int res = listBox1.Items.Count;
                    MessageBox.Show("bad"+ res.ToString());

                    timer1.Stop();
                }

                foreach (Button b in but)
                {
                    b.Text = r.Next(10, 30).ToString();
                    b.Enabled = false;
                }
            }

        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numTimer_ValueChanged(object sender, EventArgs e)
        {
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Check(sender as Button);
        }

    }
}