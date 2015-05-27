using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {

        static void Main(string[] args)
        {
            AppDomain dom = AppDomain.CreateDomain("demo");
            Assembly asm = dom.Load(AssemblyName.GetAssemblyName("ClassLibrary1.dll"));
            Module mod = asm.GetModule("ClassLibrary1.dll");
            Type typ = mod.GetType("ClassLibrary1.Class1");
            MethodInfo met = typ.GetMethod("DoSome");
            met.Invoke(null,null);
            asm.GetModule("ClassLibrary1.dll").GetType("ClassLibrary1.Class1").GetMethod("DoSome").Invoke(null,null);

            AppDomain.Unload(dom);
        }

    }
}
