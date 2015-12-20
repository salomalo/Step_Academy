using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


//http://www.programmer-lib.ru/csharp_page.php?id=17


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter");

            String a = Console.ReadLine();
            Equation riv = new Equation();

            String b = Console.ReadLine();
            Equation riv1 = new Equation();
            try
            {
                riv.Parse(a);
                riv1.Parse(b);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Error {0} ", e.Message);
            }
            riv.Print();
            riv1.Print();

            Urivnyanya uriv = new Urivnyanya();
            uriv.Lin(riv, riv1);
        }

        public class Urivnyanya
        {
            protected int x;
            protected int y;

            public int X
            {
                get { return x; }
                set { x = value; }
            }

            public int Y
            {
                get { return y; }
                set { y = value; }
            }

            public void Lin(Equation first, Equation second)
            {
                X = first.C * (-1) - Y * (-1);

                int r = (second.A * first.C * (-1) + second.A * Y * (-1) + Y + second.C) / second.A;
                r *= -1;

                int n = first.C * (-1) - r * (-1);

                Console.WriteLine("this.y {0} {1}", r, n);
            }

        }

        public class Equation
        {
            protected int a;
            protected int b;
            protected int c;

            public int A
            {
                get { return a; }
                set { a = value; }
            }

            public int B
            {
                get { return b; }
                set { b = value; }
            }

            public int C
            {
                get { return c; }
                set { c = value; }
            }

            public void Parse(String str)
            {
                char[] arr = { ',', ' ' };
                String[] res = str.Split(arr);

                int res1;
                int res2;
                int res3;
                if (res.Length != 3)
                {
                    throw new ArgumentException("wrong count of arguments");
                }
                else
                    if (Int32.TryParse(res[0], out res1) == false)
                    {
                        throw new ArgumentException("first not a digit");
                    }
                    else if (Int32.TryParse(res[1], out res2) == false)
                    {
                        throw new ArgumentException("second not a digit");
                    }
                    else if (Int32.TryParse(res[2], out res3) == false)
                    {
                        throw new ArgumentException("third not a digit");
                    }
                this.a = res1;
                this.b = res2;
                this.c = res3;
            }




            public void Print()
            {
                Console.WriteLine("a {0}, b {1} c {2}", A, B, C);
            }


        }



    }
}
