using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _002_xml_to_xml
{
    class Program
    {
        static void Main(string[] args)
        {
            XDocument source = XDocument.Load("dataSource.xml");

            XDocument res = new XDocument(
                new XElement("Students",
                    new XElement("USA",

                        from e in source.Descendants("Student")
                        where e.Attribute("Country").Value == "USA"
                        select new XElement("Student",
                            new XElement("Name", e.Element("Name").Value),
                            new XElement("Gender", e.Element("Gender").Value),
                            new XElement("TotalMarks", e.Element("TotalMarks").Value))),
                    new XElement("Ukraine",

                        from e in source.Descendants("Student")
                        where e.Attribute("Country").Value == "Ukraine"
                        select new XElement("Student",
                            new XElement("Name", e.Element("Name").Value),
                            new XElement("Gender", e.Element("Gender").Value),
                            new XElement("TotalMarks", e.Element("TotalMarks").Value)))));

            res.Save("dataDestination.xml");
                
        }
    }
}
