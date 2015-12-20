using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    public class Piramida : Figure //: Point  // фігурка 
    {
        public Piramida(int x, int y)
            : base(x, y)  // конструктор
        {
            Check = "pg";
            Arr = new List<Point>();
            X = x;
            Y = y;
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X - 1, Y + 1);
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
            if (Check == "pv")
            {
                V_View(X, Y);
            }
            if (Check == "pg")
            {
                G_View(X, Y);
            }
            if (Check == "pgII")
            {
                G_View_II(X, Y);
            }
            if (Check == "pvII")
            {
                V_View_II(X, Y);
            }
        } // NewPos

        public void V_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X, Y + 1);
            Point tmp3 = new Point(X, Y + 2);
            Point tmp4 = new Point(X + 1, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "pv";
        } // V_View

        public void G_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X - 1, Y + 1);
            Point tmp3 = new Point(X, Y + 1);
            Point tmp4 = new Point(X + 1, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "pg";
        } // G_View

        public void G_View_II(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 2, Y);
            Point tmp4 = new Point(X + 1, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "pgII";
        } // G_View_II

        public void V_View_II(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X, Y + 1);
            Point tmp3 = new Point(X, Y + 2);
            Point tmp4 = new Point(X - 1, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "pvII";
        } // V_View_II

        public override void Rotate(int x, int y)
        {
            X = x;
            Y = y;

            if (Check == "pg")
            {
                V_View(X, Y);
            }
            else if (Check == "pv")
            {
                G_View_II(X, Y);
            }
            else if (Check == "pgII")
            {
                V_View_II(X, Y);
            }
            else if (Check == "pvII")
            {
                G_View(X, Y);
            }

        } // Rotate

    } // Piramida
}
