using System;
using System.Collections;
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
        List<float> carINT;
       

        int x, y;
        //Bitmap bm;

        public Form1()
        {
            carINT = new List<float>();
            col = new List<Color>();
            InitializeComponent();
            x = 0;
            y = 0;
            // bm = new Bitmap(@"E:\d.jpg");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
          

            //Graphics g = CreateGraphics();
            //GraphicsPath gpath = new GraphicsPath();

            //foreach (int car in carINT)
            //{
            //    per *= car; // який выдсоток складають машинки одного кольору
            //    gra = (per * 360) / 100;

            //    gpath.AddPie(100, 100, 100, 100, start, gra);
            //    start += gra;

            //    g.DrawPath(Pens.Black, gpath);
            //}


            //g.Dispose();
            

            base.OnPaint(e);

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

        int allCars;
        float gra;
        float start=0;
        float per;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Refresh();
            Graphics g = CreateGraphics();
            GraphicsPath gpath = new GraphicsPath();

            per = 100 / (float)allCars;

            float l;
            l = per;

            int i = 0;

            foreach (float car in carINT)
            {
                
                per *= car; // який выдсоток складають машинки одного кольору

                gra = (per * 360) / 100;

                gpath.AddPie(100, 100, 100, 100, start, gra);
                g.FillPie(new SolidBrush(col[i]), 100, 100, 100, 100, start, gra);   
                start += gra;
                g.DrawPath(Pens.Black, gpath);
                
                i++;
                per = l;
            }

            
            g.Dispose();
        }

        List<Color> col;
        private void button1_Click_1(object sender, EventArgs e)
        {
            
            int count; // кылькысть машин одного кольору
            Int32.TryParse(txbCars.Text, out count);
            carINT.Add(count);

            allCars = 0; // всы машини
            foreach (int car in carINT)
            {
                allCars += car;
            }
            ColorPie();
        }


        public void ColorPie()
        {

            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                c = cld.Color;
                col.Add(c);
                //this.BackColor = cld.Color;
            }
        
        }

        Color c;



    }
}