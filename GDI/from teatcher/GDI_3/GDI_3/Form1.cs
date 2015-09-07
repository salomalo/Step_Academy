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

namespace GDI_3
{
    public partial class Form1 : Form
    {
        int x, y;
        Bitmap bm;
        public Form1()
        {
            InitializeComponent();
            x = 0;
            y = 0;
            bm = new Bitmap(@"D:\d.jpg");          
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
          //  Graphics g = CreateGraphics();
          //  g.ScaleTransform(2f, 3f);
          ////  g.TranslateTransform(50, 50);
          //  g.DrawImage(bm, x, y, 20,20);
          
          //  g.DrawRectangle(Pens.Blue, 20, 20, 40, 100);
          //  g.Dispose();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
                Invalidate(); //викликає перемальовку форми
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
           
           Matrix m = new Matrix();
            m.RotateAt(-20, new PointF(0,0));
        //    m.Scale(2, 2);
         //   m.Shear(1, 2);
         //  g.Transform = m;
        //    g.FillRectangle(Brushes.Red, 10,10, 40, 100);
           

            GraphicsPath gpath = new GraphicsPath();
          /*  gpath.StartFigure();
            gpath.AddLine(50, 50, 230, 100);
            gpath.AddCurve(new Point[] { new Point(20, 20), new Point(45, 82),new Point(120,120),new Point(182,200) });
            gpath.CloseFigure();*/
            gpath.AddArc(100, 100, 100, 100, 0,180 );
            gpath.Transform(m);
            g.DrawPath(Pens.Black, gpath);
           // g.FillPath(Brushes.Red, gpath);
            
            g.Dispose();

        }
    }
}
