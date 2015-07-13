using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _004_safe_manner
{
    class Program
    {
        static void Main(string[] args)
        {
            Number num = new Number(64);
            Thread t1 = new Thread(num.PrintNumbers);
            t1.Start();
        }
    }

    class Number
    {
        private int _target;

        public Number(int target)
        {
            _target = target;
        }

        public void PrintNumbers()
        {
            for (int i = 0; i < _target; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
