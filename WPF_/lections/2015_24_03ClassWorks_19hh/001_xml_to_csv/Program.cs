using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _001_xml_to_csv
{
    class Program
    {
        static void Main(string[] args)
        {
            // xml to html
            XDocument res = new XDocument(
                new XElement("table", new XAttribute("border", 1),
                    new XElement("thead",
                        new XElement("tr",
                            new XElement("th", "--== Id ==--"),
                            new XElement("th", "--== Name ==--"),
                            new XElement("th", "--== Gender ==--"),
                            new XElement("th", "--== TotalMarks ==--"))),
                    new XElement("tbody",

                        from s in XDocument.Load("Students.xml").Descendants("Student")
                        select new XElement("tr",
                            new XElement("td", s.Attribute("Id").Value),
                            new XElement("td", s.Element("Name").Value),
                            new XElement("td", s.Element("Gender").Value),
                            new XElement("td", s.Element("TotalMarks").Value)))));


            res.Save("Students.html");


            // xml to csv

            // StringBuilder sb = new StringBuilder();
            // string delimeter = "|";
            // 
            // XDocument.Load("Students.xml").Descendants("Student")
            //     .ToList()
            //     .ForEach(
            //         e => sb.Append(
            //             e.Attribute("Id").Value + delimeter +
            //             e.Element("Name").Value + delimeter +
            //             e.Element("Gender").Value + delimeter +
            //             e.Element("TotalMarks").Value + "\n"));
            // 
            // StreamWriter sw = new StreamWriter("Students.csv");
            // sw.WriteLine(sb);
            // sw.Close();
        }
    }
}
