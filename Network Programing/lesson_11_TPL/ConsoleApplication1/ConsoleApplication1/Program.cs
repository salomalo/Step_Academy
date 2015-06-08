using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// TPL

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<int[]> arr = new List<int[]>()
            //{
            //new int[short.MaxValue / 2],
            //new int[short.MaxValue / 2]
            //};

            //foreach(var a in arr)
            //{
            //    fill(a);
            //}

            //var watch = Stopwatch.StartNew();
            //foreach (var a in arr)
            //{
            //    BubbleSort(a);
            //}

            //watch = Stopwatch.StartNew();
            //Parallel.ForEach(arr, a=>
            //{
            //    {
            //        BubbleSort(a);
            //    }
            //});
        //    Console.WriteLine();


            //int[] arr = new int[short.MaxValue / 2];
            //fill(arr);

            //var watch = Stopwatch.StartNew();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    var res = arr.ToList().Average();
            //}
            //Console.WriteLine("simple {0}", watch.ElapsedMilliseconds);

            //watch = Stopwatch.StartNew();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    var res = arr.ToList().AsParallel().Average();
            //}
            //Console.WriteLine("AsParallel {0}", watch.ElapsedMilliseconds);

            //arr =  BubbleSort(arr);


            int[] arr = new int[25];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(1, 100);
            }

            //foreach (var a in res)
            //{
            //    Console.WriteLine(a.ToString());
            //}


          //  var watch = Stopwatch.StartNew();
          //  Task tas = Task.Factory.StartNew(()=>{             
           // BubbleSort(arr);
           // });


           //var act = new Action<int[]>();
           
           Task<int[]> t = new Task<int[]>
               (() => {
                 BubbleSort(arr);
                 return new int[10];
                });
           var res = t.Result;
           foreach (var a in res)
           {
               Console.WriteLine(a.ToString());
           }

          //  Console.WriteLine("Task {0}", watch.ElapsedMilliseconds);



          //  Console.WriteLine("task");
          //  Console.ReadLine();




        }

    

        public static void fill(int[] arr)
        { 

        }

        public static int[] BubbleSort(int[] arr)
        {
            int tmp =arr[0];

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 1 + 1; j < arr.Length - 1; j++)
                {
                    if(arr[i] <arr[j])
                    {
                        tmp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = tmp;
                    }
                }
            }
            return arr;
        } // BubbleSort
    }
}
