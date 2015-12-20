using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop
{
    public class Item
    {
        public String Title { set; get; }
        public double Price { set; get; }


        public override String ToString()
        {
            return Title;
        }

    }
}
