#define TRIAL
#define PRODUCTION

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SerialAtributesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Person per = new Person() { Name = "Tom", SName = "Soyer", Age = 18 };
            per.Print();
            per.Printer();

            Type attType = typeof(DebuggerDisplayAttribute);
            Type classType = per.GetType();

            DebuggerDisplayAttribute att = (DebuggerDisplayAttribute)Attribute.GetCustomAttribute(classType, attType);
            ObsoleteAttribute attObs = (ObsoleteAttribute)Attribute.GetCustomAttribute(classType, typeof(ObsoleteAttribute));
            if (att != null)
            {
                Console.WriteLine("It will be easier to debug");
                Console.WriteLine(att.Value);
            }
            if (attObs != null)
            {
                Console.WriteLine("Not use it");
            }
        }
    }

    [DebuggerDisplayAttribute("name={Name}, lastName={SName}, years={Age}")]
    class Person
    {
        public string Name { set; get; }
        public string SName { set; get; }
        public int Age { set; get; }

      
//#if TRIAL
        [Conditional("TRIAL")]
        public void Print()
        {
            Console.WriteLine("{0} {1} - {2}", Name, SName, Age);
        }
//#endif

//#if PRODUCTION
        [Conditional("PRODUCTION")]
        public void Printer()
        {
            Console.WriteLine("{0}", Name);
        }
//#endif
    }
}
