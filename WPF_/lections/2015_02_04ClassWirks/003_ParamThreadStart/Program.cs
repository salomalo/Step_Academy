using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _003_ParamThreadStart
{
    class Program
    {
        static void Main(string[] args)
        {
            object target;
            ParameterizedThreadStart pthStart = new ParameterizedThreadStart(Number.PrintNumbers);
            Thread t1 = new Thread(pthStart);

            target = 32;
            t1.Start(target);

            Thread t2 = new Thread(Number.PrintNumbers);
            t2.Start(target);
        }
    }

    class Number
    {
        public static void PrintNumbers(object target)
        {
            int number = 0;
            if (int.TryParse(target.ToString(), out number))
            {

                for (int i = 0; i < number; i++)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
