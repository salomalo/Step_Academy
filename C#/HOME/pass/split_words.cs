using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a="Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum ";
            string a = "a a b r b g g l";

            char[] arr = { ' ', ',', '.', ' ' };
            String[] res = a.Split(arr);

            int count = 0;
            int un = 0;
            int tmp = 0;
            
            foreach (var el in res)
            {
                Console.WriteLine(el);
                count++;
            }

            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res.Length; j++)
                {
                    if (res[i] == res[j])
                    {
                        tmp++;
                    }
                }
                if (tmp == 1)
                {
                    un++;
                }
                tmp = 0;
            }

            Console.WriteLine("count of words - " + count);
            Console.WriteLine("count of un - " + un);
        }
    }
}
