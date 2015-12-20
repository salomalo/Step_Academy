using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateSample
{
    delegate double Calculator (double a, double b);
    delegate void Calc(double a, double b);
    delegate int Test (String str);
    delegate void Test2(String str);
    class Program
    {
        static void Main(string[] args)
        {
            //готові класи делегатів

            // для методів без параметрів, які нічого не повертають
            //Action action = MyMethod;
            //action();

            //// для методів з параметрами, які нічого не повертають
            //Action<String> action2 = MyMethod2;
            //action2("hello");

            //Action<String, int> action3 = MyMethod3;
            //action3("Bye", 5);

            //// для методів без параметрів, які повертають
            //Func<int> f = MyMethodReturn;
            //Console.WriteLine(f());
          
            //// для методів з параметрами, які повертають
            //Func<int,int> f2 = MyMethodReturn2;
            //Console.WriteLine(f2(5));

            //Func<int,double, double> f3 = MyMethodReturn3;
            //Console.WriteLine(f3(5, 7.8));


            //------------------------------------------------------------------------------------
            Calculator calc = null;
            Calc c = null;
            MathLib ml = new MathLib();
          /*  Console.WriteLine("Enter the action: +, -, /, *");
            String act = Console.ReadLine();

            switch (act)
            {
                case "+":
                    calc = new Calculator(ml.Add);
                    break;
                case "-":
                    calc = ml.Min;
                    break;
                case "/":
                    calc = ml.Div;
                    break;
                case "*":
                    calc = ml.Mult;
                    break;
                case "t":
                    calc = Test;
                    break;
                case "p":
                    calc = Math.Pow;
                    break;
                default:
                    c = ml.Add2;
                    c += ml.Div2;
                    c += ml.Min2;
                    c += ml.Mult2;
                    break;
            }

            if (calc != null) //перевіряєм чи є підписаний метод
            {
                Console.WriteLine(calc(2, 10));
            }
            if (c != null)
            {
                c(2, 10);
            }*/


            //анонімні методи
            Calculator anonim2 = delegate(double x, double y)
            {
                return x * y + x / y - y / x;
            };

            Console.WriteLine(anonim2(5, 2));
            anonim2 = ml.Div;            //втрачаю ссилку на анонімний метод
            Console.WriteLine(anonim2(5, 2));


            //лямда вирази
            Calculator anonimL = (x, y) => x * y + x / y - y / x;
            Console.WriteLine(anonimL(5, 2));
            Test strLength = (str) => str.Length;
            Test2 print = (str) =>
                {
                    Console.WriteLine();
                    Console.WriteLine(str);
                    Console.WriteLine();
                };
            print("Hello");

        }

        public static double Test(double a, double b)
        {
            return b;
        }

        public static void MyMethod()
        {
            Console.WriteLine("MyMethod()");
        }

        public static void MyMethod2(String str )
        {
            Console.WriteLine("MyMethod() {0}", str);
        }

        public static void MyMethod3(String str, int i)
        {
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("MyMethod() {0}", str);
            }
        }

        public static int MyMethodReturn()
        {
            return 1;
        }

        public static int MyMethodReturn2(int a)
        {
            return a*a;
        }

        public static double MyMethodReturn3(int a, double b)
        {
            return a + b;
        }
    }

    class MathLib
    {
        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Min(double a, double b)
        {
            return a - b;
        }

        public double Div(double a, double b)
        {
            return a / b;
        }

        public double Mult(double a, double b)
        {
            return a * b;
        }

        public void Add2(double a, double b)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine(a + b);
            }
        }

        public void Min2(double a, double b)
        {
            Console.WriteLine(a - b);
        }

        public void Div2(double a, double b)
        {
            Console.WriteLine(a / b);
        }

        public void Mult2(double a, double b)
        {
            Console.WriteLine(a * b);
        }
    }
}
