using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _007_Extesion_methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "hello linq";
            // string res = str.ChangeFirstLetterCase();
            string res = StringHelper.ChangeFirstLetterCase(str);

            Console.WriteLine(res);
        }
    }
}
