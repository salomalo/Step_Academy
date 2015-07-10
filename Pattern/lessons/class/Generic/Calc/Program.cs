using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{

    static class Helper
    {
        public static void Swap<TType>(ref TType a, ref TType b)
        {
            TType tmp = a;
            a = b;
            b = tmp;
        }

        public static TType MinIs<TType>(TType a, TType b) where TType :IComparable
        {
            if (a.CompareTo(b) > 0)
            {
                return b;
            }
            if (a.CompareTo(b) < 0)
            {
                return a;
            }

            return b;
        }

    }

    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string a = "first a";
            string b = "second b";
            Helper.Swap(ref a, ref b);
            Console.WriteLine("a - {0} b - {1}", a, b);


            var t=Helper.MinIs(3, 4);
            Console.WriteLine(t.ToString());

        }
    }
}
