using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Xml;

namespace tetris
{
    class Program
    {
        static void Main(string[] args)
        {
            Game gm = new Game();
            Random r = new Random(1);

            gm.R = r;
            gm.Menu();

        } // main

    } // Program


    public enum Figure_Type
    {
        LeftL, Piramida, Square, RightZ, line, Dot //, LeftL
    } // Figure_Type

}