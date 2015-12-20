using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;
//http://frolov-lib.ru/programming/javasamples/vol1/vol1_14/index.html
namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            String str = "hello world hello g hello";

            Dictionary <String, int> dict = new Dictionary <String, int>();

            char[] arr = { ' ', ',', '.', ' ' };
            String[] res = str.Split(arr);

            ArrayList a = new ArrayList();
            for (int i = 0; i < res.Length; i++)
            {
                a.Add(res[i]);
            }

            int k = 0;
            for (int i = 0; i < a.Count; i++)
            {
                for (int j = 1; j < a.Count - 1; j++)
                {
                    if (a[i] == a[j])
                    {
                        k++;
                        dict.Add(a[i].ToString(), k);
                    }

                }

                //k = 0;
            }

            //Console.WriteLine(k);
            foreach (KeyValuePair<string, int> d in dict)
            {
                Console.WriteLine("{0} - {1}",d.Key,d.Value);
            }
        }
    }
}