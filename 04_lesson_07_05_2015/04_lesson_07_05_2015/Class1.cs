using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _04_lesson_07_05_2015
{
    public class Class1
    {
        static public object obj1 = new object();


        public  void Method1()
        {
            lock (this)
            {

            }
        }

    }
}
