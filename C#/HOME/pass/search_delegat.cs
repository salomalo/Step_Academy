using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    public delegate bool Del(Object a, Object b);

    class Program
    {
        static void Main()
        {
            MyCl str = new MyCl();
            Del del = str.Met;

            Object[] arr = { "hello", "world", "hi",4 };

            str.Search(arr, del);
        }
    }

    public class MyCl
    {
        public void Search(Object[] arr, Del del)
        {
            bool a = false;
            int ind = 0;
            for (int i = 0; i < arr.Length; i++)
            {

                if (del(arr[i], 4) == true)
                {
                    a = true;
                    ind = i;
                }
            }
            if (a == true)
            {
                Console.WriteLine("index of element is {0}", ind);
            }

            if (a == false)
            {
                Console.WriteLine("there is no such element");
            }


        }


        public bool Met(Object a, Object b)
        {
            if (a.Equals(b))
                return true;
            else
                return false;
        }


    }
}