using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace seraliz
{
    class Program
    {
        static void Main(string[] args)
        {
        
            HtmlWeb web = new HtmlWeb();
            HtmlDocument html = web.Load("http://kurs.com.ua/ua/rovno");
           
            //Console.WriteLine(html.DocumentNode.Descendants("div").Count());


            var block = html.DocumentNode.SelectSingleNode("//*[@id=\"content_center\"]/div[1]");
            

            Console.WriteLine(block.ChildNodes.Count());



   
        }

    }


}
