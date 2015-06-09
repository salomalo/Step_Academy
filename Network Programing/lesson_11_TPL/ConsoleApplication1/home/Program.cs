using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace home
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0;
            int b = 0;
            //var tuple=0;

            Task<int> _task = Task<int>.Factory.StartNew(() => { a = Convert.ToInt32(Console.ReadLine()); return a; });
            Task<int> _task2 = Task<int>.Factory.StartNew(() => { b = Convert.ToInt32(Console.ReadLine()); return b;});

            Task <int>_task3 = _task2.ContinueWith((res) => {
                var sum = a + b;
                return Tuple.Create<int>(sum);
            })
            .ContinueWith((res) =>
            {
                var sum = res.Result.Item1;
                var min = a > b ? a : b;
                return Tuple.Create<int,int>(sum, min);
            })
            .ContinueWith((res) =>
            {
                var sum = res.Result.Item1;
                var min = res.Result.Item2;
                var mid = (a + b) / 2;
                return Tuple.Create<int,int,int>(sum, min, mid);
            })
            .ContinueWith((res) => {
                Console.WriteLine("a {0} b {1} sum{2} min{3} mid {4}", a, b, res.Result.Item1, res.Result.Item2, res.Result.Item3);
            })
            ;

   
            //  Task _task2 = _task.ContinueWith((continuation) => b = Convert.ToInt32(Console.ReadLine()));



            _task3.Wait();



        }
    }
}
