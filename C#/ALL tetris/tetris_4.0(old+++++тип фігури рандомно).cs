using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tetris_points
{
    class Program
    {
        static void Main(string[] args)
        {
            Glass _glas = new Glass();
            //Random r = new Random(1);
            //_glas.New_Figure_Type(r);

            //for (int i = 0; i < _glas.Arr.GetLength(0)+1; i++) // умова закінчення падіння - поки не закінчеться висота стакана
            //while (_glas.IsBottom() == false) // цикл працює поки фігурка не впаде на дно
            while (true)
            {
                Thread.Sleep(250);
                Console.Clear();

                Console.WriteLine("X: {0} ; Y: {1}", _glas.CurFigure.X, _glas.CurFigure.Y); //виводжу координати стартової точки
                foreach (Point p in _glas.CurFigure.Arr)
                    p.Print(); //виводжу координати кожної точки

                _glas.Paint(); // переношу фігурку в стакан
                _glas.Print(); // малюю стакан із падаючими фігурками !!!!!!!
                _glas.Fall(); // змінюю координати фігурки для  реалізації падіння



                _glas.IsBottom();
                // _glas.IsFigureBelow();


                if (_glas.IsBottom() == true || _glas.IsFigureBelow() == true) // якщо низ стакана то почати малювати нову фігурку зверху
                {
                    _glas.NewFigure();
                }

                _glas.NewGlass(); // ініціалізую стакан новими значеннями



                Console.WriteLine(_glas.IsBottom());
                //Console.WriteLine(i);
            } // while



            //////////////////////////////////////

        } // main 
    } // Program

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

    } // Point

    public abstract class Figure : Point
    {
        protected ArrayList _arr;
        public ArrayList Arr
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

        public Figure(int x, int y)
            : base(x, y)
        {
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
        public virtual void Rotate() { }

    } // Figure


    /// //////////////////////////////////////////////

    public class RightZ : Figure  // фігурка 
    {
        public RightZ(int x, int y)
            : base(x, y)  // конструктор
        {
            Arr = new ArrayList();
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
            Point tmp1 = new Point(X, Y);
            Point tmp2 = new Point(X + 1, Y);
            Point tmp3 = new Point(X + 1, Y + 1);
            Point tmp4 = new Point(X + 2, Y + 1);

            Arr.Add(tmp1);
            Arr.Add(tmp2);
            Arr.Add(tmp3);
            Arr.Add(tmp4);
        }

        //public override void Rotate()
        //{ 


        //}

    } // RightZ
    public class Dot : Figure // фігурка точка 
    {
        public Dot(int x, int y)
            : base(x, y)
        {
            Arr = new ArrayList();
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

        //public override void Rotate_view()
        //{


        //}

    } // Dot 


    public class Glass // стакан 
    {
        protected bool[,] _arr; // масив стакана
        public bool[,] Arr
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

        protected bool[,] _buffer; // масив стакана
        public bool[,] Buffer
        {
            set
            {
                _buffer = value;
            }
            get
            {
                return _buffer;
            }
        }

        protected Dot _curFigure; // поточна фігура (яка падає в даний момент)
        public Dot CurFigure
        {
            set
            {
                _curFigure = value;
            }
            get
            {
                return _curFigure;
            }
        } // 

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

        protected int _curY; // значення основної координати У фігури (від якої перевизначатимуться координати всіх інших точок в фігурі)
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

        protected int _curX; // значення основної координати Х фігури (від якої перевизначатимуться координати всіх інших точок в фігурі)
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

        public Glass() // constructor 
        {
            CurY = -1;
            CurX = 9;
            // CurType = Figure_Type.Dot;
            CurFigure = new Dot(9, 0);
            Arr = new bool[20, 20];
            Buffer = new bool[20, 20];

            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    Arr[i, j] = false; // ініціалізую стакан 
                    Buffer[i, j] = false;
                }
            }

        } // Glass

        ///////////////////////////////           дописати          //////////////////////////////////////////////////////////////////////
        // метод має зберігати стакан із фігурками які впали на дно і робити його поточним
        public void NewGlass() // переініціалізовую стакан новими занченнями 
        {
            Copy(Buffer, Arr);
            ///////////////////////////////
        } // NewGlass


        public void Copy(bool[,] source, bool[,] destenation) // переініціалізовую стакан новими занченнями 
        {
            for (int i = 0; i < destenation.GetLength(0); i++)
            {
                for (int j = 0; j < destenation.GetLength(1); j++)
                {
                    destenation[i, j] = source[i, j]; // з сорса в дестенатіон
                }
            }
        } // Copy

        public void NewFigure()
        {
            CurY = -1;
            CurX = 9;
            CurFigure = new Dot(9, 0);
        }

        ///////////////////////////////////// дописати переміщення по Х 
        public void Fall() // змінюю координати фігурки для  реалізації падіння
        {
            CurY += 1; //
            //CurX += 1;
            CurFigure.NewPos(CurX, CurY);
        } // Fall

        public void Move(int x) // змінюю координати фігурки для  реалізації падіння
        {
            //CurY += 1; //
            CurX += x;
            CurFigure.NewPos(CurX, CurY);
        } // Move

        public void Paint() // переношу фігурку в стакан
        {
            foreach (Point p in CurFigure.Arr)
                Arr[p.Y, p.X] = true;
        } // Paint


        /// <summary>
        /// ////////////// для великих фігур переписати
        public bool IsBottom()
        {
            if (CurFigure.Y == Arr.GetLength(0))
            {
                //Buffer = Arr;
                Copy(Arr, Buffer); // копіюю з arr в buffer
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFigureBelow()
        {
            if (CurFigure.Y + 1 != Arr.GetLength(0) && Arr[CurFigure.X, CurFigure.Y + 1] == true)
            {
                //Buffer = Arr;
                Copy(Arr, Buffer); // копіюю з arr в buffer
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Print() // малюю стакан із фігурками !!!!!!!
        {
            for (int i = 0; i < Arr.GetLength(0); i++) // y row
            {
                for (int j = 0; j < Arr.GetLength(1); j++) // x col
                {
                    if (Arr[i, j] == false)
                    {
                        Console.Write(".");
                    }
                    else
                    {
                        Console.Write("#");
                    }
                }
                Console.WriteLine(" {0}", i);
            }
            Console.WriteLine();
        } //Print

        public void Clear_figure() // очищЯю значеннЯ ф?гурки щоб змінити тип падаючої фігурки
        {
            CurFigure.Arr.Clear();
        }

        public void New_Figure_Type(Random r) // присвоюю новий тип ф?гур? 
        {
            RightZ rightZ = new RightZ(9, 0);
            Dot dot = new Dot(9, 0);
            Clear_figure();

            CurType = (Figure_Type)r.Next(1);
            if (CurType == Figure_Type.RightZ)
            {
                rightZ = new RightZ(9, 0);
               // CurFigure = rightZ;
            }
            if (CurType == Figure_Type.Dot)
            {
                dot = new Dot(9, 0);
                //      CurFigure = dot;
            }

        } // New_Figure_Type

    } // Glass


    public enum Figure_Type
    {
        //line, square, rightL, leftL, pyramide 
        RightZ, Dot
    } // Figure_Type

}