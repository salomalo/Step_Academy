using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    public class RightZ : Figure//: Point  // фігурка 
    { 
        public RightZ(int x, int y)
            : base(x, y)  // конструктор
        {
            Check = "zg";
            Arr = new List<Point>();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 2, Y + 1);
            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
        }

        public override void NewPos(int x, int y) // присвоюю нові координати точкам фігури
        {
            Arr.Clear();
            X = x;
            Y = y;
            if (Check == "zv")
            {
                V_View(X, Y);
            }
            if (Check == "zg")
            {
                G_View(X, Y);
            }
        } // NewPos

        public void V_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X - 1, Y + 1);
            Point tmp3 = new Point(X, Y + 1);
            Point tmp4 = new Point(X - 1, Y + 2);
            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "zv";
        } // V_View

        public void G_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 2, Y + 1);
            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "zg";
        } // G_View

        public override void Rotate(int x, int y)
        {
            X = x;
            Y = y;
            if (Check == "zg")
            {
                V_View(X, Y);
            }
            else if (Check == "zv")
            {
                G_View(X, Y);
            }
        } // Rotate
    } // RightZ
}
