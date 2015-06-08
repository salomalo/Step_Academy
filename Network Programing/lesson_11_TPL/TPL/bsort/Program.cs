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

            List<int[]> arr = new List<int[]>
            {
                new int[short.MaxValue / 2],
                new int[short.MaxValue / 2]

            };
 
            foreach(var a in arr)
            {
                FillArray(a);
            }

            var watch = Stopwatch.StartNew();
            foreach (var a in arr)
            {
                bubleSort(a);
            }
            Console.WriteLine("Simple foreach: {0}",watch.ElapsedMilliseconds);


            watch = Stopwatch.StartNew();
            Parallel.ForEach(arr, a =>
            {
                {
                    bubleSort(a);
                }
            });
            Console.WriteLine("ForEach foreach: {0}", watch.ElapsedMilliseconds);
           
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
