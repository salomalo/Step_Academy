using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random(1);
            Table t = new Table();
            //t.A.Print();
            t.New_Shape(r);



          //  for (int i = 0; i < 6; i++)
          //  {
            //    t.SetPos(2, 2);
                t.A.Print(0, 0);
               
            //Console.Clear();
        //    }


                System.Timers.Timer aTimer = new System.Timers.Timer(1000);
                aTimer.Elapsed += new ElapsedEventHandler(t.A.OnTimedEvent);



                aTimer.Interval = 1000;
                aTimer.Enabled = true;
                Console.ReadLine();

        } // Main



        //private static void OnTimedEvent(object source, ElapsedEventArgs e)
        //{

        //    Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);

        //}

    }



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




        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {

            //Console.WriteLine("The Elapsed event was raised at {0}", e.SignalTime);
            Print(0,0);
        }



        public void Print(int x, int y)
        {

            Table t = new Table();
            t.SetPos(10, 0);

            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                t.SetPos(0, 1);
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
            bool[,] btmp = { {false, false, false, false},
                             {false, true,  false, false}, 
                             {true,  true,  false, false},
                             {true,  false, false, false}};
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
        protected int _curX;
        public int CurX
        {
            set
            {
                _curX = value;
            }
            get
            {
                return _curX;
            }
        }
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

        public void SetPos(int x, int y)
        {
            Console.SetCursorPosition(x, y);


            CurX += x;
            CurY += y;

            Console.SetCursorPosition(CurX, CurY);

            Console.CursorLeft = CurX;
            Console.CursorTop = CurY;

            // Console.WriteLine("test");

        }




        protected Figure _a;
        public Figure A
        {
            set
            {
                _a = value;
            }
            get
            {
                return _a;
            }
        }
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
        }

        protected int[,] _size;
        public int[,] Size
        {
            set
            {
                _size = value;
            }
            get
            {
                return _size;
            }
        } // Size

        public Table()
        {
            int[,] tmp = new int[10, 20];
            Size = tmp;
            A = new LeftZ();

            CurY = Console.CursorTop;
            CurX = Console.CursorLeft;
        } // Table


        public void Drop_figure()
        {


        }



        public void Clear() // очищџю значеннџ ф?гурки
        {
            bool[,] tmp = { {false, false, false, false},
                             {false, false,  false, false}, 
                             {false,  false,  false, false},
                             {false,  false, false, false}};
            A.Shape = tmp;
        }



        // додати вс? типи ф?гур
        public void New_Shape(Random r) // присвоюю новий тип ф?гур? 
        {
            RightZ rightZ = new RightZ();
            Clear();
            CurType = (Figure_Type)r.Next(1);
            if (CurType == Figure_Type.RightZ)
                rightZ = new RightZ();
            A = rightZ;


        } // New_Shape

        public void Rotate_Figure() // повертаю ф?гуру
        {
            A.Rotate_view();

        } // Rotate_Figure


    } // Table

    public class Point
    {
        protected int _curx;
        public int CurX
        {
            set
            {
                _curx = value;
            }
            get
            {
                return _curx;
            }
        }

        protected int _cury;
        public int CurY
        {
            set
            {
                _cury = value;
            }
            get
            {
                return _cury;
            }
        }


    }


    public enum Figure_Type
    {
        //line, square, rightL, leftL, pyramide, leftZ, rightZ
        RightZ = 1, LeftZ
    } // Figure_Type

}