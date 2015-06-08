using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsort
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = new int[short.MaxValue];

            
            FillArray(arr);
            
            var watch = Stopwatch.StartNew();

            int length = 10000;
            for (int i = 0; i < length; i++)
            {
                var res = arr.ToList().Sum();
            }
            
            Console.WriteLine("Simple query: {0}", watch.ElapsedMilliseconds);


            watch = Stopwatch.StartNew();
            for (int i = 0; i < length; i++)
            {
                var res = arr.ToList().AsParallel().Sum();
            }
            Console.WriteLine("AsParallel query: {0}", watch.ElapsedMilliseconds);

        }

        private static void FillArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Random().Next(100);
            }
        }

        private static void PrintArray(int[] arr)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("I = {0}", arr[i]);
            }
        }

        public static int[] bubleSort(int[] array)
        {
            int length = array.Length;
            int temp = array[0];

            for (int i = 0; i < length; i++)
            {
                for (int j = i + 1; j < length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
    }
}
