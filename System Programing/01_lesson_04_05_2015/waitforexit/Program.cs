using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace waitforexit
{
    class Program
    {

        static void Main(string[] args)
        {
            //Process myPr = new Process();
            //myPr.StartInfo.FileName = "calc.exe";
            //myPr.Start();
            //Console.WriteLine("Open process - " + myPr.ProcessName);
            //myPr.WaitForExit();
            //Console.WriteLine("ExitCode - " + myPr.ExitCode);

            //Console.WriteLine("Current process - " + Process.GetCurrentProcess().ProcessName);
            
            
            //////////////////////////////////////////////////////////////////////////////////////////


            //Process[] _process = Process.GetProcesses();

            ////foreach (Process p in _process)
            ////{
            ////   Console.WriteLine(p.ProcessName + " " + p.Id);
            ////}

            //try
            //{
            //    foreach (Process p in _process)
            //    {
            //        if(p.ProcessName=="calc")
            //          p.Kill();
            //    }
            //}
            //catch (Exception e)
            //{
            //  //  Console.WriteLine(e.Message);
            //}

            //Console.WriteLine("------------------------");
            //foreach (Process p in _process)
            //{
            //    Console.WriteLine(p.ProcessName + " " + p.Id);
            //}




            ////////////////////////////there is not nececery to recompile project

            Assembly asym = Assembly.Load(AssemblyName.GetAssemblyName("ClassLibrary1.dll"));
            Module mod = asym.GetModule("ClassLibrary1.dll");

            foreach(Type t in mod.GetTypes())
                Console.WriteLine(t.FullName);

            Type Person = mod.GetType("ClassLibrary1.Person") as Type;

            object person = Activator.CreateInstance(Person, new object [] {"name","surname",23});

            Person.GetMethod("Print").Invoke(person, null); //GetMethod() - take the information about mathod, Invoke() - execute method with our informations





        }

    }
}
