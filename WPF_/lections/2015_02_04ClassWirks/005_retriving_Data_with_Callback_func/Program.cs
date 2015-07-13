using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _005_retriving_Data_with_Callback_func
{
    public delegate void SumOfNumbersCallback(int sumOfNumber);

    class Number
    {
        int _target;
        SumOfNumbersCallback _callbackMethod;

        public Number(int target, SumOfNumbersCallback callback)
        {
            _target = target;
            _callbackMethod = callback;
        }

        public void PrintSumOfNumbers()
        {
            int sum = 0;
            for (int i = 0; i < _target; ++i)
            {
                sum += i;
            }

            if (_callbackMethod != null)
            {
                _callbackMethod(sum);
            }
        }
    }

    class Program
    {
        public static void PrintSum(int sum)
        {
            Console.WriteLine("Sum = " + sum);
        }
        
        static void Main(string[] args)
        {
            int target = 1000000;

            SumOfNumbersCallback callback = new SumOfNumbersCallback(PrintSum);
            Number num = new Number(target, callback);
            Thread t1 = new Thread(new ThreadStart(num.PrintSumOfNumbers));
            t1.Start();

        }
    }
}
