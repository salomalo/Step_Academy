using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace move_icon
{
    class SnakePart : coord
    {
        public Bitmap Bit { set; get; }
        public SnakePart(Bitmap bit, int x,int y):base(x,y)
        {
            Bit = bit;
        }

        public void NewPos(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
