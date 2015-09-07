using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = this.CreateGraphics();
         //   g.DrawEllipse(Pens.Red, 20, 20, 20, 20);

            Rectangle rect1 = new Rectangle(200,250,300,120);
            Rectangle rect2 = new Rectangle(150,300,140,320);

            Region reg1 = new Region(rect1);
            Region reg2 = new Region(rect2);

            g.DrawRectangle(new Pen(Brushes.Red, 5), rect1);
            g.DrawRectangle(new Pen(Brushes.Blue, 5), rect2);
            reg1.Complement(reg2);
            g.FillRegion(Brushes.Brown, reg1);
            g.Dispose();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            //g.DrawArc(Pens.Plum, new Rectangle(20, 20, 40, 70), 40, 90);
          //  ToDraw();
        }

        private void ToDraw()
        {
            Graphics g = this.CreateGraphics();
            Pen pen = new Pen(Color.Red, 5);
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            g.DrawLine(pen, new Point(100, 100), new Point(50, 50));
            g.DrawLine(Pens.Blue, new Point(120, 120), new Point(170, 200));

            LinearGradientBrush grad = new LinearGradientBrush(new Point(0, 0), new Point(10, 10), Color.Blue, Color.Yellow);
            g.FillRectangle(grad, new Rectangle(100, 100, 70, 70));
            HatchBrush hatch = new HatchBrush(HatchStyle.ZigZag, Color.Red);
            g.FillRectangle(hatch, new Rectangle(200, 200, 70, 70));

            TextureBrush texture = new TextureBrush(new Bitmap("logo.bmp"));
            g.FillEllipse(texture, new Rectangle(new Point(40, 150), new Size(300, 150)));
            g.Dispose();
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
        //    Graphics g = e.Graphics;
        //    g.DrawArc(Pens.Plum, new Rectangle(0, 0, 40, 70), 40, 90);
        }
    }
}
