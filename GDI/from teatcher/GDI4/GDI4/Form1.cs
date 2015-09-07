using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI4
{
    public partial class Form1 : Form
    {
        int x = 1;
        int y = 1;
        public Form1()
        {
            InitializeComponent();
            //Bitmap bmp = new Bitmap(@"D:\creativity.jpg");
            //pictureBox1.Image = bmp;
            //timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             Graphics g = this.CreateGraphics();
             Bitmap bmp = new Bitmap(@"D:\creativity.jpg");          
             g.DrawImage(bmp, 0, 0);
             g.Dispose();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
           // this.Invalidate();
            g.FillRectangle(Brushes.Red, new Rectangle(x, y, 20, 40));
            this.Invalidate(new Rectangle(x, y - 1, 20, 1));
            
            g.Dispose();

            //Graphics g = pictureBox1.CreateGraphics();
            //g.FillRectangle(Brushes.Red, new Rectangle(x, y, 20, 40));
            //pictureBox1.Invalidate(new Rectangle(x, y - 1, 20, 1));
            //g.Dispose();
         //   x++;
            y++;
         
        }
    }
}
