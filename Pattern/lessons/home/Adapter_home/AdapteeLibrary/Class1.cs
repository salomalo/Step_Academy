using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapteeLibrary
{
    public class AdapteeLCDDisplay
    {
        public Byte[] ByteArr()
        {
            Byte[] barr = Encoding.Default.GetBytes("Hello");
            return barr;
        }
    }
}
