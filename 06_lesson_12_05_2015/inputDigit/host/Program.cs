using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace host
{
    class Program
    {
        static AppDomain domein;
        static AppDomain domein2;
        static Assembly asm;
        static Assembly asm2;
        static Form inputF;
        static Form outputF;


        static void Main(string[] args)
        {
            domein = AppDomain.CreateDomain("demo_domein");
            asm = domein.Load(AssemblyName.GetAssemblyName("inputDigit.exe"));

            domein2 = AppDomain.CreateDomain("demo_domein2");
            asm2 = domein.Load(AssemblyName.GetAssemblyName("outputDigit.exe"));

            //inputF = Activator.CreateInstance(asm.GetType("inputDigit.Form1")) as Form;

            inputF = Activator.CreateInstance(asm.GetType("inputDigit.Form1"), 
                new object[] 
                { asm2.GetModule("outputDigit.exe"), outputF 
                })as Form;


            outputF = Activator.CreateInstance(asm2.GetType("outputDigit.Form1"))as Form;
            



            


            inputF.ShowDialog();

            //Module module = asm.GetModule("inputDigit.exe");
            //Type typ = module.GetType("ClassLibrary1.Form1");
 
            //MethodInfo method = typ.GetMethod("Method");
            //method.Invoke(null, null);

           // asm.GetModule("inputDigit.exe").GetType("ClassLibrary1.Form1").GetMethod("Method").Invoke(null, null);



        }


    }
}
