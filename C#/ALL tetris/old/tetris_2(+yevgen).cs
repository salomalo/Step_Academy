using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading;


namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(1);
            Table t = new Table();

            // t.Figura.Print();
            // t.New_Figure_Type(r);
            // t.Figura.Print();
            // t.Figura.Rotate_view();
            // t.Figura.Print();

            // t.Drop_figure();
            // t.Print();




            // timer
            // System.Timers.Timer aTimer = new System.Timers.Timer(1000);
            // aTimer.Elapsed += new ElapsedEventHandler(t.OnTimedEvent);

            // aTimer.Interval = 1000;
            // aTimer.Enabled = true;
            // Console.ReadLine();




            // sleep
            for (int i = 0; i < t.Glass.GetLength(0) - 1; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                t.Print();
                t.NewGlass();
                t.Drop_figure(1);
                Console.WriteLine(i);
            }




        } // Main
    } // Program



    public abstract class Figure
    {
        protected bool[,] _shape;
        public bool[,] Shape
        {
            set
            {
                _shape = value;
            }
            get
            {
                return _shape;
            }
        } //Shape

        public void Print()
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    if (Shape[i, j] == true)
                    {
                        Console.Write('#'); // 9
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        } //Print

        public virtual void Rotate_view()
        { }

    } // Figure

    public class LeftZ : Figure
    {
        public LeftZ()
        {
            bool[,] btmp = { {false, false, false, false},
                             {true, false,  false, false}, 
                             {true,  true,  false, false},
                             {false,  true, false, false}};
            Shape = btmp;
        } // LeftZ

        public override void Rotate_view()
        {
            bool[,] btmp1 = { {false, false, false, false},
                             {false, false,  false, false}, 
                             {false,  true,  true, false},
                             {true,  true, false, false}};
            Shape = btmp1;
        } // Rotate_view
    } // LeftZ

    public class RightZ : Figure
    {
        public RightZ()
        {
            bool[,] btmp = { {false,false,false,false},
                             {false, true,  false,false}, 
                             {true,  true,  false,false},
                             {true,  false, false,false}};
            Shape = btmp;
        } // RightZ

        public override void Rotate_view()
        {

            bool[,] btmp1 = { {false, false, false, false},
                             {false, false,  false, false}, 
                             {true,  true,  false, false},
                             {false,  true, true, false}};
            Shape = btmp1;
        } // Rotate_view


    } // RightZ

    public class Table
    {
        protected Figure _figura;
        public Figure Figura
        {
            set
            {
                _figura = value;
            }
            get
            {
                return _figura;
            }
        } // Figura


        protected Figure_Type _curType;
        public Figure_Type CurType
        {
            set
            {
                _curType = value;
            }
            get
            {
                return _curType;
            }
        } // CurType


        protected bool[,] _glass;
        public bool[,] Glass
        {
            set
            {
                _glass = value;
            }
            get
            {
                return _glass;
            }
        } // Glass


        protected int _curY;
        public int CurY
        {
            set
            {
                _curY = value;
            }
            get
            {
                return _curY;
            }
        }


        public Table() // constructor
        {
            Figura = new RightZ();
            CurY = 0;
            Glass = new bool[20, 20];
            for (int i = 0; i < Glass.GetLength(0); i++)
            {
                for (int j = 0; j < Glass.GetLength(1); j++)
                {
                    Glass[i, j] = false;
                }
            }

        } // Table

        public void NewGlass() // 
        {
            for (int i = 0; i < Glass.GetLength(0); i++)
            {
                for (int j = 0; j < Glass.GetLength(1); j++)
                {
                    Glass[i, j] = false;
                }
            }
        } // NewGlass

        public void Print()
        {
            for (int i = 0; i < Glass.GetLength(0); i++) // y row
            {
                for (int j = 0; j < Glass.GetLength(1); j++) // x col
                {
                    if (Glass[i, j] == false)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        } //Print

        public void Drop_figure(int newY)
        {
            int s = 0;
            CurY += newY;

            //for (int yS = YSt; yS < A.Shape.GetLength(0); yS++) // y row
            //{

            //    for (int yF = 0; yF < A.Shape.GetLength(0); yF++)
            //    {
            //        int xF = 0;
            //        for (int xS = s; xS < A.Shape.GetLength(0) + s; xS++) // x col
            //        {
            //            if (A.Shape[yF, xF] == true)
            //            {
            //                Size[yS, xS] = true;
            //            }
            //            xF++;

            //        }
            //        yS++;
            //    }
            //}

            int yS = CurY;
            do
            {
                for (int yF = 0; yF < Figura.Shape.GetLength(0); yF++)
                {
                    int xF = 0;
                    for (int xS = s; xS < Figura.Shape.GetLength(0) + s; xS++) // x col
                    {
                        if (Figura.Shape[yF, xF] == true && Glass[yS, xS] != true && yS <= Glass.GetLength(0) )       ////////////////////////////////
                        {
                            Glass[yS, xS] = true;
                         //   return true;
                        }
                        
                        xF++;
                    }
                    yS++;
                }
            }
            while (yS == (Glass.GetLength(0) - Figura.Shape.GetLength(0)));

        } // Drop_figure()

        public void Clear_figure() // очищЯю значеннЯ ф?гурки
        {
            bool[,] tmp = { {false, false, false, false},
                             {false, false,  false, false}, 
                             {false,  false,  false, false},
                             {false,  false, false, false}};
            Figura.Shape = tmp;
        }


        // додати вс? типи ф?гур
        public void New_Figure_Type(Random r) // присвоюю новий тип ф?гур? 
        {
            RightZ rightZ = new RightZ();
            LeftZ leftZ = new LeftZ();
            Clear_figure();

            CurType = (Figure_Type)r.Next(1);
            if (CurType == Figure_Type.RightZ)
            {
                rightZ = new RightZ();
                Figura = rightZ;
            }

            if (CurType == Figure_Type.LeftZ)
            {
                leftZ = new LeftZ();
                Figura = leftZ;
            }

        } // New_Shape

        public void Rotate_Figure() // повертаю ф?гуру
        {
            Figura.Rotate_view();
        } // Rotate_Figure

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Print();
            NewGlass();
            Drop_figure(1);
        }
    } // Table


    public enum Figure_Type
    {
        //line, square, rightL, leftL, pyramide 
        //
        LeftZ, RightZ
    } // Figure_Type

}