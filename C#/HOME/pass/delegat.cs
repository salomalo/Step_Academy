using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    public delegate void Del_1(String a);
    public delegate String Del_2(String a);
    public delegate String Del_3(String a, String b);
    public delegate int Del_4(String a);

    class Program
    {
        static void Main(string[] args)
        {
            MyString mystr = new MyString();

            Del_1 del = null;
            del = mystr.mySt1;
            del("the sky is red");
            Del_1 del1 = null;
            del1 = mystr.mySt11;
            del1("the sky is red");

            Console.WriteLine("-----");

            Del_2 del2 = null;
            del2 = mystr.mySt2;
            Console.WriteLine(del2("the sky is red"));
            Del_2 del22 = null;
            del22 = mystr.mySt22;
            Console.WriteLine(del22("FLOWER"));

            Console.WriteLine("-----");

            Del_3 del3 = null;
            del3 = mystr.mySt3;
            Console.WriteLine(del3("hello ", "world"));

            Del_3 del33 = null;////////////////////////////////////////////////////////////
            del33 = mystr.mySt33;
            Console.WriteLine(del33("hello", "world"));

            Console.WriteLine("-----");

            Del_4 del4 = null;
            del4 = mystr.mySt4;
            Console.WriteLine(del4("the sky is red"));
            Del_4 del44 = null;
            del44 = mystr.mySt44;
            Console.WriteLine(del44("the sky is red"));

            Console.WriteLine("-----");


            mystr.Met("again ", del3);





        }
    }

    public class MyString
    {
        public void mySt1(String str)
        {
            Console.WriteLine(str);
        }
        public void mySt11(String str)
        {
            char[] ar = str.ToCharArray();
            Array.Reverse(ar);
            str = new String(ar);
            Console.WriteLine(str);
        }



        public String mySt2(String str)
        {
            return str.ToUpper();
        }
        public String mySt22(String str)
        {
            return str.ToLower();
        }


        public String mySt3(String str, String str2)
        {
            String tmp = string.Concat(str, str2);
            return tmp;
        }
        public String mySt33(String str, String str2)
        {
            if (str.Equals(str2))
            {
                return "eaqual";
            }
            else
            {
                    return "not eaqual";
            }
        }

        public int mySt4(String str)
        {
            return str.Length;
        }
        public int mySt44(String str)
        {
            char[] arr = { ' ', ',', '.', ' ' };
            String[] res = str.Split(arr);

            int count = 0;

            foreach (var el in res)
            {
                count++;
            }
            return count;
        }


        public void Met(String a, Del_3 del3)
        {
            Console.WriteLine(" {0} {1} ", a, del3);
        }

    }
}