using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_ChildToParent
{
    public class User
    {
        public String Name { set; get; }
        public String SName { set; get; }
        public DateTime Birthday { set; get; }

        public override string ToString()
        {
            return Name + " " + SName + " " + Birthday.ToLongDateString();
        }
    }
}
