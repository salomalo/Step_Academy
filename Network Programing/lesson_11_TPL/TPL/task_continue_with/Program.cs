using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_continue_with
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = Task.Factory.StartNew(() =>
                {
                    return Convert.ToInt32(Console.ReadLine());
                });

            data.ContinueWith((res) =>
            {
                var r = res.Result * res.Result;
                return Tuple.Create(res.Result, r);
            })
            .ContinueWith((res) => 
            {
                var tuple = res.Result;
                Console.WriteLine("Result: {0} and r {1}", tuple.Item1, tuple.Item2);
            })
            .Wait();

            

            Console.WriteLine("bb gg");
            //Console.ReadLine();

        }
    }
}
