using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(2, 3);
            Fraction b = new Fraction(3, 3);

            Console.WriteLine("a < b");
            Console.WriteLine(a < b);

            /* Console.WriteLine("a > b");
             Console.WriteLine(a > b);

             Console.WriteLine("a == b");
             Console.WriteLine(a == b);

             Console.WriteLine("a != b");
             Console.WriteLine(a != b);*/



            Console.WriteLine("a + b");
            Fraction sumF_F = a + b;
            // Console.WriteLine(sumF_F);
            sumF_F.Print();


            //Console.WriteLine("a + 1");
            //Fraction sumF_I = a + 1;
            //sumF_I.Print();

            //Console.WriteLine("1 + a");
            //Fraction sumI_F = 1 + a;
            //sumI_F.Print();

            //Console.WriteLine("a - b");
            //Fraction subtrF_F = a - b;
            //subtrF_F.Print();

            //Console.WriteLine("1 - a");
            //Fraction subtrI_F = 1 - a;
            //subtrI_F.Print();

            //Console.WriteLine("a - 1");
            //Fraction subtrF_I = a - 1;
            //subtrF_I.Print();





            double res = a;

            Console.WriteLine("F to double {0:0.00}", res);

        }

        public class Fraction
        {
            protected int numer;
            protected int denum;

            public Fraction() : this(0, 1) { }

            public Fraction(int numer, int denum)
            {
                this.denum = denum;
                this.numer = numer;
            }

            public Fraction(String tmp)
            {
                char[] arr = { ',', ' ', '.', '/' };
                String[] res = tmp.Split(arr);

                int tmp1;
                int tmp2;

                Int32.TryParse(res[0], out tmp1);
                Int32.TryParse(res[1], out tmp2);

                this.numer = tmp1;
                this.denum = tmp2;
            }

            public override string ToString()
            {
                return base.ToString();
            }
            //static Fraction Parse(String str)
            //{
            //    Fraction tmp = new Fraction();
            //    return tmp;
            //}


            //////////////////////////   ++  -- /////////////

            public static Fraction operator ++(Fraction a)
            {
                // a.numer++;
                return a + 1;
            }
            public static Fraction operator --(Fraction a)
            {
                //  a.numer--;
                return a - 1;
            }

            //////////////////////////    *   /     /////////////

            public static Fraction operator *(Fraction a, Fraction b)
            {
                return new Fraction(a.numer * b.numer, a.denum * b.denum);
            }
            public static Fraction operator /(Fraction a, Fraction b)
            {
                return new Fraction(a.numer * b.numer, a.denum * b.denum);
            }

            //////////////////////////   true  false /////////////

            public static bool operator true(Fraction a)
            {
                return a.numer > a.denum;
            }
            public static bool operator false(Fraction a)
            {
                return a.numer < a.denum;
            }

            //////////////////////////   double  int  /////////////

            public static implicit operator double(Fraction a)
            {
                double res = (double)a.numer / a.denum;
                return res;
            }
            public static implicit operator Fraction(double a)/////////////////////////////////////////////
            {
                Fraction res = new Fraction();
                //     res.numer =     ;
                //     res.denum =     ;
                return res;
            }

            public static explicit operator int(Fraction a)
            {
                return a.numer / a.denum;
            }
            public static explicit operator Fraction(int a)
            {
                Fraction tmp = new Fraction();
                tmp.numer = a;
                tmp.denum = 1;
                return tmp;
            }

            //////////////////////////   +   /////////////

            public static Fraction operator +(Fraction a, Fraction b)
            {
                Fraction tmp = new Fraction();
                tmp.numer = a.numer * b.denum + b.numer * a.denum;
                tmp.denum = a.denum * b.numer;
                return tmp;
            }
            public static Fraction operator +(Fraction a, int b)
            {
                Fraction tmp = new Fraction();
                tmp.numer = a.denum * b + a.numer;
                tmp.denum = a.denum;

                return new Fraction(tmp.numer, a.denum);
            }
            public static Fraction operator +(int a, Fraction b)
            {
                Fraction tmp = new Fraction();
                tmp.numer = b.denum * a + b.numer;
                tmp.denum = b.denum;
                return new Fraction(tmp.numer, tmp.denum);
            }


            ////////////////////////        -    ///////////////////////

            public static Fraction operator -(Fraction a, Fraction b)
            {
                Fraction tmp = new Fraction();
                tmp.numer = a.numer * b.denum - b.numer * a.denum;
                tmp.denum = a.denum * b.numer;
                return tmp;
            }

            public static Fraction operator -(Fraction a, int b)
            {
                Fraction tmp = new Fraction();
                tmp.numer = a.denum * b - a.numer;
                tmp.denum = a.denum;

                return new Fraction(tmp.numer, a.denum);

            }
            public static Fraction operator -(int a, Fraction b)
            {
                Fraction tmp = new Fraction();
                tmp.numer = b.denum * a - b.numer;
                tmp.denum = b.denum;
                return new Fraction(tmp.numer, tmp.denum);
            }

            ////////////////////////        > <    ///////////////////////

            public static bool operator >(Fraction a, Fraction b)
            {
                double aa;
                double bb;

                aa = a.numer / a.denum;
                bb = b.numer / b.denum;

                if (aa > bb)
                    return true;
                else
                    return false;
            }

            public static bool operator <(Fraction a, Fraction b)
            {
                double aa;
                double bb;

                aa = a.numer / a.denum;
                bb = b.numer / b.denum;

                if (aa < bb)
                    return true;
                else
                    return false;
            }

            /////////////////////      >= <=     ////////////////////////

            public static bool operator >=(Fraction a, Fraction b)
            {
                double aa;
                double bb;

                aa = a.numer / a.denum;
                bb = b.numer / b.denum;

                if (aa >= bb)
                    return true;
                else
                    return false;
            }
            public static bool operator <=(Fraction a, Fraction b)
            {
                double aa;
                double bb;

                aa = a.numer / a.denum;
                bb = b.numer / b.denum;

                if (aa <= bb)
                    return true;
                else
                    return false;
            }

            ///////////////           ==    !=        ///////////

            public static bool operator ==(Fraction a, Fraction b)
            {
                Fraction tmp = new Fraction();
                a.numer = a.numer * b.denum;
                b.numer = b.numer * a.denum;
                a.denum = a.denum * b.numer;

                if (a.numer == b.numer)
                    return true;
                else
                    return false;
            }

            public static bool operator !=(Fraction a, Fraction b)
            {
                Fraction tmp = new Fraction();
                a.numer = a.numer * b.denum;
                b.numer = b.numer * a.denum;
                a.denum = a.denum * b.numer;

                if (a.numer != b.numer)
                    return true;
                else
                    return false;
            }


            public void Print()
            {
                Console.WriteLine("{0}  /  {1}", this.numer, this.denum);
            }


        }

    }
}