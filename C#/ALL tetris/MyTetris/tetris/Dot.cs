using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    public class Dot : Figure//: Point // фігурка точка 
    {
        public Dot(int x, int y)
            : base(x, y)  // 
        {
            Check = "d";
            Arr = new List<Point>();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Arr.Add(tmp1);
        }

        public override void NewPos(int x, int y)
        {
            Arr.Clear();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Arr.Add(tmp1);
        }

        public override void Rotate(int x, int y) { }

    } // Dot 
}