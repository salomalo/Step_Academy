using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Italy;
using England;
using Ukraine;

namespace ns_main
{
    class Program
    {
        static void Main(string[] args)
        {

            Rym populr = new Rym("Rym", 2753000);
            London popull = new London("London", 8308000);
            Kyiv populu = new Kyiv("Kyiv", 2868373);


            if (popull.Population > populr.Population && popull.Population > populu.Population)
            {
                Console.Write("{0} - {1} ", popull.Title, popull.Population);
            }
            else 
            {
                if (populr.Population > popull.Population && populr.Population > populu.Population)
                {
                    Console.Write("{0} - {1} ", populr.Title, populr.Population);
                }
                else
                {
                    Console.Write("{0} - {1} ", populu.Title, populu.Population);
                }
            }


        }
    }
}