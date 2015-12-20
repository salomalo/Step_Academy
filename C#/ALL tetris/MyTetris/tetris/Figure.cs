using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public abstract class Figure : Point
    {
        protected List<Point> _arr;
        public List<Point> Arr
        {
            set
            {
                _arr = value;
            }
            get
            {
                return _arr;
            }
        }

        protected String _check;
        public String Check
        {
            set
            {
                _check = value;
            }
            get
            {
                return _check;
            }
        }

        public Figure(int x, int y)
            : base(x, y)
        {
            Check = " ";
            X = x;
            Y = y;
        }

        public virtual void NewPos(int x, int y)
        {
            Arr.Clear();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Arr.Add(tmp1);
        }
        
        public virtual void Rotate(int x,int y) { }

    } // Figure
}