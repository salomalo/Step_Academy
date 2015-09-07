using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace join
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new DB_Shop_bud_materEntities())
            {
                var Catalog = from pg in ctx.Packeges
                              join pr in ctx.Products
                              on pg.ProductId equals pr.Id into pgGroup
                              from pr in pgGroup.DefaultIfEmpty()

                              join prod in ctx.Producers
                              on pr.ProducerId equals prod.Id
                              into prodGroup
                              from prod in prodGroup.DefaultIfEmpty()

                              join cat in ctx.Categorys
                              on pr.CategoryId equals cat.Id
                              into catGroup
                              from cat in catGroup.DefaultIfEmpty()

                              join mes in ctx.Measures
                              on pg.MeasureID equals mes.Id
                              into mesGroup
                              from mes in mesGroup.DefaultIfEmpty()

                              join pri in ctx.Prices
                              on pg.Id equals pri.PackegeId
                              into priGroup
                              from pri in priGroup.DefaultIfEmpty()

                              //where pri.PriceTime = select(ctx.Prices
                              //var PriTime = where 

                              select new
                              {
                                  Id = pg.Id,
                                  Title = pr.Name,
                                  Producer = prod == null ? "No Producer" : prod.Name,
                                  Categorys = cat.Name,
                                  Measures = mes.Name,
                                  Volume = pg.Volume,

                                  Prices = pri.UnitCost
                                  // Prices = pg.Prices
                              };

                foreach (var p in Catalog)
                {
                    Console.WriteLine(p.Id
                        + " " +
                        p.Title
                        + " " +
                        p.Producer
                        + " " +
                        p.Categorys
                        + " " +
                        p.Measures
                        + " " +
                        p.Volume
                        + " " +
                        p.Prices);
                }

                //1. Catalog to csv
                StringBuilder sb = new StringBuilder();
                string delimeter = "|";
                foreach (var p in Catalog.ToList())
                {
                    sb.Append(p.Id
                    + delimeter +
                    p.Title
                    + delimeter +
                    p.Producer
                    + delimeter +
                    p.Categorys
                    + delimeter +
                    p.Measures
                    + delimeter +
                    p.Volume
                    + delimeter +
                    p.Prices
                + "\n");
                } // foreach (var p in res.ToList())

                StreamWriter sw = new StreamWriter("Catalog.csv");
                sw.WriteLine(sb);
                sw.Close();


                //2. Catalog to html
                XDocument catalogRES = new XDocument(
                    new XElement("table", new XAttribute("border", 1),
                        new XElement("thead",
                            new XElement("tr",
                                new XElement("th", "Id"),
                                new XElement("th", "Title"),
                                new XElement("th", "Producer"),
                                new XElement("th", "Categorys"),
                                new XElement("th", "Measures"),
                                new XElement("th", "Volume"),
                                new XElement("th", "Prices")
                                                           )),
                        new XElement("tbody",

                            from s in Catalog.ToList()
                            select new XElement("tr",
                                new XElement("td", s.Id),
                                new XElement("td", s.Title),
                                new XElement("td", s.Producer),
                                new XElement("td", s.Categorys),
                                new XElement("td", s.Measures),
                                new XElement("td", s.Volume),
                                new XElement("td", s.Prices)))));
                catalogRES.Save("Catalog.html");

            } // using (var ctx = new DB_Shop_bud_materEntities())

        } // main

    }
}
