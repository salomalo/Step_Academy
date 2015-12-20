using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public class line : Figure //: Point  // фігурка 
    {
        public line(int x, int y)
            : base(x, y)  // конструктор
        {
            Check = "lv";
            Arr = new List<Point>();
            X = x;
            Y = y;
        }

        public override void NewPos(int x, int y) // присвоюю нові координати точкам фігури
        {
            Arr.Clear();
            X = x;
            Y = y;
            if (Check == "lv")
            {
                V_View(X, Y);
            }
            if (Check == "lg")
            {
                G_View(X, Y);
            }
        }
        public void V_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X, Y + 1);
            Point tmp3 = new Point(X, Y + 2);
            Point tmp4 = new Point(X, Y + 3);
            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "lv";
        }
        public void G_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y+1);
            Point tmp2 = new Point(X - 1, Y + 1);
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 2, Y + 1);
            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "lg";
        }

        public override void Rotate(int x, int y) // присвоюю нові координати точкам фігури
        {
            X = x;
            Y = y;
            Arr.Clear();
            if (Check == "lg")
            {
                V_View(X, Y);
            }
            else if (Check == "lv")
            {
                G_View(X, Y);
            }
        } // Rotate
    } // line
}