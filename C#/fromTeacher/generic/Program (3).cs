using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    class Program
    {
        static void Main(string[] args)
        {
           // Dictionary<String, String> dic = new Dictionary<string, String>();
            //Point<int, double> point = new Point<int, double>(2, 2.0);
           // Test<Point<int, int>> test = new Test<Point<int, int>>();

            List<Point<int, int>> points = new List<Point<int, int>>();
            points.Add(new Point<int, int>(2, 2));
            points.Add(new Point<int, int>(3, 4));
            points.Add(new Point<int, int>(7, 3));
            points.Add(new Point<int, int>(0, 8));
            points.Add(new Point<int, int>(6, 2));
            points.Add(new Point<int, int>(2, 3));

         /*   List<Point<int, int>> tmp = new List<Point<int, int>>();
            for (int i = 0; i < points.Count; i++)
            {
                Point<int, int> p = points[i];
                if ( p.X % 2 == 0)
                {
                    tmp.Add(points[i]);
                }
            }
            */
         /*   foreach (var el in tmp)
            {
                Console.WriteLine(el);
            }*/

            //LINQ
           /* var query = from p in points
                        where p.X % 2 == 0
                        orderby p.Y
                        select p;*/

           /* var query = from p in points
                        where p.X % 2 == 0
                        orderby p.Y, p.X
                        select new Point<int,int> (p.Y, p.X);*/

            var query = from p in points
                        orderby p.Y, p.X
                        select p;
            foreach (var el in query)
            {
                Console.WriteLine(el);
            }

            //Lamda
            Console.WriteLine("-------------------------------------------------------");
           // var res = points.Where(p => p.X % 2 == 0 && p.X != 0).Select(p => p.Y);
          /*  var res = points.Select(p => new Point<int, int>(p.Y, p.X));
            var res2 = points.Select(p => new String((p.Y.ToString()+"string").ToCharArray()));
            foreach (String el in res2)
            {
                Console.WriteLine(el);
            }

            if (points.All(p => p.X % 2 >= 0))
            {
                Console.WriteLine("all");
            }

            if (points.Any(p => p.X == 0))
            {
                Console.WriteLine("any");
            }*/
          
            points.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("-------------------------------------------------------");
            var point = points.Last(p => p.Y % 2 == 0);           
            Console.WriteLine(point);

            Console.WriteLine("-------------------------------------------------------");
            var point2 = points.LastOrDefault(p => p.Y == 10);
            Console.WriteLine(point2);

            var ordered = points.OrderBy(p => p.Y );
            Console.WriteLine("-------------------------------------------------------");
            foreach (var el in ordered)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine("-------------------------------------------------------");
            var r = points.SingleOrDefault(p => p.X == 0);
            Console.WriteLine(r);
           
        }
    }


    class Point<T, U> where T : new () //class, IInterface (тип повинен наслідуватися від даного інтерфейса), BaseClass, new()
    {
        public T X { set; get; }
        public U Y { set; get; }

        public Point(T x, U y)
        {
            X = x;
            Y = y;
        }
        
        public T GetX()
        {
            return X;
        }

        public void DoSmth(T v)
        {
            X = v;
        }

        public override string ToString()
        {
            return String.Format("..............{0} - {1}", X, Y);
        }
    }

    class Test<T> where T : new()
    {

    }
}
