using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        unsafe static void Main(string[] args)
        {

            int param = 2;
            Method(&param, 2);

            Console.WriteLine(param);



        }

        unsafe public static void Method(int *x, int y )
        {
            //int z = *x;
            //for (int i = 0; i < y; i++)
            //{
            //    *x *= z;
            //}


            *x += y;


        }



    



    }
}
