using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;




namespace wonders
{
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            int[] tmp = new int[2];

            for (int i = 0; i < 2; i++)
            {
                tmp[i] = r.Next(1, 12);
            }

            Wonder_1 wond = new Wonder_1("Great Pyramid of Giza");
            wond.Print();
            Wonder_2 wond2 = new Wonder_2("Hanging Gardens of Babylon");
            wond2.Print();
            Wonder_3 wond3 = new Wonder_3("Colossus of Rhodes");
            wond3.Print();
            Wonder_4 wond4 = new Wonder_4("Temple of Artemis at Ephesus");
            wond4.Print();
            Wonder_5 wond5 = new Wonder_5("Lighthouse of Alexandria");
            wond5.Print();
            Wonder_6 wond6 = new Wonder_6("Zeus at Olympia");
            wond6.Print();
            Wonder_7 wond7 = new Wonder_7("Mausoleum at Halicarnassus");
            wond7.Print();

            Wonders wonds = new Wonders();
            
            wonds.Print();

        }
    }
}