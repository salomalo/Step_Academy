using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{

    public class LeftL : Figure//: Point  // фігурка 
    { 
        public LeftL(int x, int y)
            : base(x, y)  // конструктор
        {
            Check = "Lefv";
            Arr = new List<Point>();
            X = x;
            Y = y;
        }

        public override void NewPos(int x, int y) // присвоюю нові координати точкам фігури
        {
            Arr.Clear();
            X = x;
            Y = y;

            if (Check == "Lefv")
            {
                V_View(X, Y);
            }

            if (Check == "Lefg")
            {
                G_View(X, Y);
            }


            if (Check == "LefgII")
            {
                G_View_II(X, Y);
            }


            if (Check == "LefvII")
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
            Point tmp4 = new Point(X+1, Y + 2);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "Lefv";
        } // V_View


        public void V_View_II(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y );
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 1, Y + 2);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "LefvII";
        } // V_View


        public void G_View(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 2, Y);
            Point tmp4 = new Point(X,  Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "Lefg";
        } // G_View



        public void G_View_II(int x, int y)
        {
            Arr.Clear();
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X - 2 , Y+1);
            Point tmp3 = new Point(X - 1, Y+1);
            Point tmp4 = new Point(X, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
            Check = "LefgII";
        } // G_View


        public override void Rotate(int x, int y)
        {
            X = x;
            Y = y;

            if (Check == "Lefg")
            {
                V_View_II(X, Y);
            }
            else if (Check == "LefvII")
            {
                G_View_II(X, Y);
            }
            else if(Check == "LefgII")
            {
                V_View(X, Y);
            }
            else if (Check == "Lefv")
            {
                G_View(X, Y);
            }

        } // Rotate

    } // RightZ
}
