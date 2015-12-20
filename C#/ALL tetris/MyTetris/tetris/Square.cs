using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    public class Square : Figure//: Point  // фігурка 
    {
        public Square(int x, int y)
            : base(x, y)  // конструктор
        {
            Check = "s";
            Arr = new List<Point>();
            X = x;
            Y = y;

            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X, Y + 1);
            Point tmp4 = new Point(X + 1, Y + 1);
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

            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X, Y + 1);
            Point tmp4 = new Point(X + 1, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);

        } // NewPos

        public override void Rotate(int x, int y)
        { } // Rotate

    } // RightZ
}
