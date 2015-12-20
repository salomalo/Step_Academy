using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris_points
{
    class Program
    {
        static void Main(string[] args)
        {
         ///   Glass _glas = new Glass();
        //    _glas.Print();




            int[,]  Arr = new int[10, 10];
           

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Arr[i, j] = i;
                }
            }




            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(Arr[i, j]+ " ");
                }
             Console.WriteLine(" ");   
            }






        }
    }


    public class Point
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


        public Point()
        {
            X = 0;
            Y = 0;
        }
        //public Point(int x,int y)
        //{
        //    X = x;
        //    Y = y;
        //}
    } // Point

    public class Pixel : Point
    {
        //protected Point _pos; //  
        //public Point Pos
        //{
        //    set
        //    {
        //        _pos = value;
        //    }
        //    get
        //    {
        //        return _pos;
        //    }
        //}


        protected bool _value;
        public bool Value
        {
            set
            {
                _value = value;
            }
            get
            {
                return _value;
            }
        }


        //public Pixel(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //    Value = false;
        //}

        public Pixel()
        {
            X = 0;
            Y = 0;
            Value = false;
        }


        public void CoordSet(int x, int y)
        {
            X = x;
            Y = y;
        }


    } // Pixel


    public class Figure_Dot : Point
    {
        protected Point[,] _arr;
        public Point[,] Arr
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
        
        public Figure_Dot(int x, int y)
        {
            //Arr = new Point[0,0];
            X = x;
            Y = y; 
        }

        //public Figure_Dot()
        //{
            //Arr = new Point[0,0];
            //X = 0; 
            //Y = 0;
       // }



        //public void Grow(int x, int y)
        //{
        // 
        //
        //}



    } // Figure


    public class Glass
    {
        protected Pixel[,] _arr;
        public Pixel[,] Arr
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

        public Glass()
        {
            Arr = new Pixel[20, 20];
            Pixel[,] tmp = new Pixel[20, 20];

            for (int i = 0; i < Arr.GetLength(0); i++)
            {
                for (int j = 0; j < Arr.GetLength(0); j++)
                {
                    //Arr[i, j].CoordSet(i, j);
                    Arr[i, j].X = i;
                    Arr[i, j].Y = j;
                    Arr[i, j].Value = false;
                }
            }

            //Arr = tmp;

        } // Glass


        public void Print()
        {
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                   // Arr[i, j].CoordSet(i, j);
                    Console.WriteLine("X {0} Y {1}", Arr[i, j].X, Arr[i, j].Y);
                }
            }
        
        }


    } // Glass




}
