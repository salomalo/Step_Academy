using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace move_icon
{
    public partial class Form1 : Form
    {
        Bitmap img;
        int x = 0, y = 0;

        Bitmap imgApple;
        int xx = 100, yy = 100;

        public String direction;

        List<SnakePart> snakeList;

        List<coord> must;
        public Form1()
        {
            InitializeComponent();
            snakeList = new List<SnakePart>();
            must = new List<coord>();

            Bitmap bit = new Bitmap(@"H:\wall.jpg");
            pictureBox1.Image = bit;
            img = new Bitmap(@"H:\d2.jpg");

            SnakePart a = new SnakePart(img, x, y);
            snakeList.Add(a);

            timer1.Start();
        }

        public void Apple()
        {
            imgApple = new Bitmap(@"H:\ad.png");
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawImage(imgApple, xx, yy);
            g.Dispose();
        }

        public void NewApple()
        {
            Random r = new Random();
            //xx = r.Next(0, pictureBox1.Width);
            //yy = r.Next(0, pictureBox1.Height);

            xx = r.Next(0, 60);
            yy = r.Next(0, 60);
            Apple();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Right:
                    direction = "Right";
                    break;

                case Keys.Left:
                    direction = "Left";
                    break;

                case Keys.Up:
                    direction = "Up";
                    break;

                case Keys.Down:
                    direction = "Down";
                    break;
            }
        } // Form1_KeyDown


        public void Inval()
        {
            int last = snakeList.Count;
            switch (direction)
            {
                case "Right":
                    pictureBox1.Invalidate(new Rectangle(snakeList[last - 1].x, snakeList[last - 1].y, 2, img.Height));
                    break;

                case "Left":
                    pictureBox1.Invalidate(new Rectangle(snakeList[last - 1].x + img.Width - 1, snakeList[last - 1].y, 2, img.Height));
                    break;

                case "Up":
                    pictureBox1.Invalidate(new Rectangle(snakeList[last - 1].x, snakeList[last - 1].y + img.Height - 1, img.Width, 2));
                    break;

                case "Down":
                    pictureBox1.Invalidate(new Rectangle(snakeList[last - 1].x, snakeList[last - 1].y, img.Width, 2));
                    break;
            }
        } //Inval()

        public void DrewSnake()
        {
            Graphics g = pictureBox1.CreateGraphics();
            foreach (SnakePart ba in snakeList)
            {
                g.DrawImage(ba.Bit, ba.x, ba.y);
            }
            g.Dispose();
        } //DrewSnake()


        public void Update(int ix, int iy)
        {

            snakeList[0].x += ix;
            snakeList[0].y += iy;

            //int last = snakeList.Count;
            
            //snakeList.RemoveAt(last - 1);
            //snakeList.Insert(0, new SnakePart(img, snakeList[0].x+img.Width, snakeList[0].y+img.Height));

        }

        public void SnakeIncres()
        {
            int last = snakeList.Count;
            NewApple();

            SnakePart a;

            switch (direction)
            {
                case "Right":
                    a = new SnakePart(img, snakeList[last - 1].x - img.Height, snakeList[last - 1].y);
                    snakeList.Add(a);
                    break;

                case "Left":
                    a = new SnakePart(img, snakeList[last - 1].x + img.Height, snakeList[last - 1].y);
                    snakeList.Add(a);
                    break;

                case "Up":
                    a = new SnakePart(img, snakeList[last - 1].x, snakeList[last - 1].y + img.Width);
                    snakeList.Add(a);
                    break;

                case "Down":
                    a = new SnakePart(img, snakeList[last - 1].x, snakeList[last - 1].y - img.Width);
                    snakeList.Add(a);
                    break;
            }
        } // SnakeIncres()

        public void AppleChek()
        {
            switch (direction)
            {
                case "Right":
                    if (snakeList[0].x + img.Width == xx && snakeList[0].y < yy && yy < snakeList[0].y + img.Height)
                    {
                        // MessageBox.Show("x+++1");                        
                        pictureBox1.Invalidate(new Rectangle(snakeList[0].x + img.Width, snakeList[0].y, imgApple.Width + 10, img.Height));
                        SnakeIncres();
                    }
                    break;

                case "Left":
                    if (xx + imgApple.Width == snakeList[0].x && snakeList[0].y < yy && yy < snakeList[0].y + img.Height)
                    {
                        //   MessageBox.Show("x---1");
                        pictureBox1.Invalidate(new Rectangle(snakeList[0].x - imgApple.Width, snakeList[0].y, imgApple.Width, img.Height));
                        SnakeIncres();
                    }
                    break;

                case "Up":
                    if (yy + imgApple.Height == snakeList[0].y && snakeList[0].x < xx && xx < snakeList[0].x + img.Width)
                    {
                        //   MessageBox.Show("y---1");
                        pictureBox1.Invalidate(new Rectangle(snakeList[0].x, snakeList[0].y - img.Height, img.Width, img.Height));
                        SnakeIncres();
                    }
                    break;

                case "Down":
                    if (yy == snakeList[0].y + img.Height && snakeList[0].x < xx && xx < snakeList[0].x + img.Width)
                    {
                        //   MessageBox.Show("y+++1");
                        pictureBox1.Invalidate(new Rectangle(snakeList[0].x, snakeList[0].y + img.Height, img.Width, img.Height));
                        SnakeIncres();
                    }
                    break;
            }
        } // AppleChek()


        private void timer1_Tick(object sender, EventArgs e)
        {
            int last = snakeList.Count-1;

            Apple();
            Inval();
            DrewSnake();
            switch (direction)
            {
                case "Right":
                    x += img.Width;
                    Update(1, 0);
                    AppleChek();

                    if (last > 0)
                    {
                        snakeList.RemoveAt(last);
                        snakeList.Insert(0, new SnakePart(img, snakeList[0].x + img.Width, snakeList[0].y + img.Height));
                    }
                    break;

                case "Left":
                    x -= img.Width;
                    Update(-1, 0);
                    AppleChek();


                    if (last > 0)
                    {
                        snakeList.RemoveAt(last);
                        snakeList.Insert(0, new SnakePart(img, snakeList[0].x + img.Width, snakeList[0].y + img.Height));
                    }
                    break;

                case "Up":
                    y -= img.Height;
                    Update(0, -1);
                    AppleChek();

                    if (last > 0)
                    {
                        snakeList.RemoveAt(last);
                        snakeList.Insert(0, new SnakePart(img, snakeList[0].x + img.Width, snakeList[0].y + img.Height));
                    }
                    break;

                case "Down":
                    y += img.Height;
                    Update(0, +1);
                    AppleChek();

                    if (last > 0)
                    {
                        snakeList.RemoveAt(last);
                        snakeList.Insert(0, new SnakePart(img, snakeList[0].x + img.Width, snakeList[0].y + img.Height));
                    }
                    break;
            }


        } // timer1_Tick

    } // form 1
} // move icon