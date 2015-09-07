using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_2
{
    public partial class Form1 : Form
    {
        Bitmap bm;
        Rectangle rect;

        public Form1()
        {
            InitializeComponent();
            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bm;
            rect = new Rectangle(200, 200, 40, 50);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Graphics gr_img = Graphics.FromImage(bm);

            Graphics gr_pb = pictureBox1.CreateGraphics();
            gr_img.DrawEllipse(Pens.Red, 100, 100, 100, 100);
            gr_img.Dispose();

            gr_pb.DrawEllipse(Pens.Red, 100, 100, 100, 100);
            gr_pb.Dispose();
            pictureBox1.Image.Save("test.png");
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Graphics gr_pb = pictureBox1.CreateGraphics();
            gr_pb.DrawRectangle(Pens.Pink, rect);
            gr_pb.Dispose();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            rect.Inflate(5, 10);
            Graphics gr_pb = pictureBox1.CreateGraphics();
            Pen pen = new Pen(Color.FromArgb(200, 210, 10), 7);
            pen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
       //     pen.DashOffset = 2;
            pen.DashCap = System.Drawing.Drawing2D.DashCap.Triangle;
            gr_pb.DrawLine(pen, 150, 200, 50, 75);

            gr_pb.DrawString("Hello", new Font("Arial Black", 24), Brushes.Red, new Point(300, 300));
          //  gr_pb.DrawRectangle(pen, rect);
            gr_pb.Dispose();
        }
    }
}
