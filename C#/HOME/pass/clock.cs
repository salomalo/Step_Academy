using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace ConsoleApplication1
{
    class Program
    {
        static Boolean ExitFlag = false;
        static void Main(string[] args)
        {
            System.Timers.Timer tmr = new System.Timers.Timer(); //object of the class timer
            tmr.Elapsed += new ElapsedEventHandler(OnTimedEvent); // event Происходит по истечении интервала времени.
            tmr.Interval = 1000; //	Возвращает или задает интервал, по истечении которого возникает событие Elapsed.
            tmr.Enabled = true; // Возвращает или задает значение, определяющее, должен ли объект Timer вызывать событие Elapsed.

            while (ExitFlag == false) ;
        }

        public static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.Write(DateTime.Now.TimeOfDay);
            Console.ReadLine();
        }
    }
}