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
        public int X;
        public int Y;

        public String type = null;
        public int size = 0;

        Color a;
        DashStyle dash;

        Bitmap bm;
        Rectangle rect;

        public Form1()
        {
            InitializeComponent();

            bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = bm;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            rect = new Rectangle(200, 200, 40, 50);

            dash = System.Drawing.Drawing2D.DashStyle.Solid;
            a = Color.Black;

            toolStripComboBox1.Items.Add("Solid");
            toolStripComboBox1.Items.Add("Dot");
            toolStripComboBox1.Items.Add("Dash");
        }

        private void ToDraw(int xlast, int ylast, Graphics g)
        {
            pictureBox1.Refresh();
         //   Graphics gr_img = Graphics.FromImage(bm);
            Pen pen = new Pen(a, 1);
            pen.DashStyle = dash;

            switch (type)
            {
                case "Elipse":
                    g.DrawEllipse(pen, X, Y, xlast - X, ylast - Y);
                    break;

                case "Rectangle":
                    if (X < xlast && Y < ylast)
                    {
                        g.DrawRectangle(pen, X, Y, xlast - X, ylast - Y);
                    }
                    else if (X > xlast && Y > ylast)
                        {
                            g.DrawRectangle(pen, xlast, ylast, X - xlast, Y - ylast);
                        }
                    else if (X < xlast && Y > ylast)
                    {
                        g.DrawRectangle(pen, X, ylast, xlast - X, Y - ylast);
                    }
                    else
                    {
                        g.DrawRectangle(pen, xlast, Y, X - xlast ,  ylast-Y);
                    }

                    break;

                case "Line":
                    g.DrawLine(pen, X, Y, xlast, ylast);
                    break;

                case "Dot":

                    break;

                case "Square":
                    if (X < xlast && Y < ylast)
                    {
                        g.DrawRectangle(pen, X, Y, xlast - X, xlast - X);
                    }
                    else 
                    if (X > xlast && Y > ylast)////////////////////////////////////////////////////////////////////////////////
                    {
                        g.DrawRectangle(pen, xlast, ylast, Y - ylast, Y - ylast);
                    }
                    else
                        if (X < xlast && Y > ylast)
                        {
                            g.DrawRectangle(pen, X, ylast, Y - ylast, Y - ylast);
                        }
                        else
                        {
                            g.DrawRectangle(pen, xlast, Y, X - xlast, X - xlast);
                        }
                    break;
           
            }
            g.Dispose();     
        }


        private void btnElipse_Click(object sender, EventArgs e)
        {
            type = "Elipse";
        }

        private void btnSquare_Click(object sender, EventArgs e)
        {
            type = "Square";
        }

        private void btnLine_Click(object sender, EventArgs e)
        {
            type = "Line";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
              //  pictureBox1.Refresh();
                X = e.X;
                Y = e.Y;  
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Graphics gr_img = Graphics.FromImage(bm);
                ToDraw(e.X, e.Y, gr_img);
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedItem.ToString() == "Dot")
            {
                dash = DashStyle.Dot;
            }
            if (toolStripComboBox1.SelectedItem.ToString() == "Solid")
            {
                dash = DashStyle.Solid;
            }
            if (toolStripComboBox1.SelectedItem.ToString() == "Dash")
            {
                dash = DashStyle.Dash;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            ColorDialog cld = new ColorDialog();
            if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                a = cld.Color;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) ////////////////////////////////////////////////////////////
        {
            pictureBox1.Refresh();            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Graphics g = pictureBox1.CreateGraphics();
                ToDraw(e.X, e.Y, g);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            pictureBox1.Image.Save("test.png");
        }

        private void btnPrintText_Click(object sender, EventArgs e)
        {
           Graphics gr = pictureBox1.CreateGraphics();
           // Graphics gr = Graphics.FromImage(bm);

           Graphics gr_img = Graphics.FromImage(bm);

           // gr.DrawString(tbxText.Text, new Font("Arial Black", 12,FontStyle.Regular), new SolidBrush(a), new Point(X, Y));
            gr_img.DrawString(tbxText.Text, new Font("Arial Black", 12, FontStyle.Regular), new SolidBrush(a), new Point(X, Y)); 
            gr.Dispose();
           
            //pictureBox1.Invalidate();
        }

        private void btnRectangle_Click(object sender, EventArgs e)
        {
            type = "Rectangle";
        }



    }
}