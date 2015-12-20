using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public class Point // точка екрану з координатами Х У
    {
        protected int _x;
        public int X
        {
            set
            {
                _x = value;
            }
            get
            {
                return _x;
            }
        }

        protected int _y;
        public int Y
        {
            set
            {
                _y = value;
            }
            get
            {
                return _y;
            }
        }

        public Point(int x, int y) // конструктор
        {
            X = x;
            Y = y;
        }

        public void Print()
        {
            Console.WriteLine("X: {0} ; Y: {1}", X, Y);
        }
        public int compare(Point o1, Point o2)
        {
            return o1.Y.CompareTo(o2.Y);
        }
    } // Point
}