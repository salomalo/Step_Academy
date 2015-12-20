using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Second;
using NamespacesSamp; // to have oportunity get NamespacesSamp classes in ThirdNS
using sp = Second;
using np = NamespacesSamp;
using inn = ThirdNS.Inner.InInner;

namespace NamespacesSamp
{
    class InOtherFileClass
    {
     //   Second.Program2 p2 = new Second.Program2();// without using
        Program2 p2 = new Program2();
        Program p = new Program();
        Second.Program prr = new Second.Program();
    }

    partial class Program
    {

    }
}

namespace ThirdNS
{
    class ThirdClass
    {
        public void ToDo()
        {
           // Second.Program p = new Second.Program();
            //NamespacesSamp.Program pr = new NamespacesSamp.Program();
           // Inner.InInner.InnerClass ic = new Inner.InInner.InnerClass();

            sp::Program p = new sp.Program();
            np.Program pr = new np.Program();
            inn.InnerClass ic = new inn.InnerClass();
        }

    }
    namespace Inner
    {
        namespace InInner
        {
            class InnerClass
            {
                ThirdClass third;
            }
        }
    }
}