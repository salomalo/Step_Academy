using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace registr
{
    class Program
    {
        static void Main(string[] args)
        {
            string user = Registry.CurrentUser.Name, 
                skey = "GetSetValue",
                skeyName =user+"\\"+skey;
 
           // додавати в автозагрузку якийсь метод
           // Registry.SetValue(skeyName,
           // Registry


        }
    }
}
