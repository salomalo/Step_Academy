using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Class1
    {
        public List<int> B
        { set; get; }

        public Class1()
        { 
            B = new List<int>();
        }

        ~Class1()
        {
            //Console.ReadKey();
            Console.WriteLine("delete");
        }


        public void Do()
        {
            Console.WriteLine("hello ");
        }

    }
}
