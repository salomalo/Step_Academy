using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList arr = new ArrayList();
            arr.Add(0.5);
            arr.Add(0.5);
            arr.Add(7.8);
            arr.Add(4.8);
            arr.Add(4.8);
            arr.Add(54.8);
           
			int unic = 0;
            int tmp = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    if (arr[i].Equals(arr[j]))
                    {
                        tmp++;
                    }
                }
                if (tmp == 1)
                {
                    unic++;
                    Console.WriteLine(arr[i]);
                }
                tmp = 0;
            }
            Console.WriteLine("count of un - " + unic);
        }
    }






}