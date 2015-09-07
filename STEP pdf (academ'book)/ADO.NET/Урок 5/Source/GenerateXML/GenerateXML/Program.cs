using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace GenerateXML
{
    class Program
    {
        static void Main(string[] args)
        {
            XElement node = new XElement ( "Контакты",
            new XElement ( "Контакт",
            new XElement ( "Имя", "Патрик Хайнс"),
            new XElement ( "Телефон", "206-555-0144"),
            new XElement ( "Адрес",
            new XElement ( "Улица", "123 Main St"),
            new XElement ( "Город", "Mercer Island"),
            new XElement ( "Государство", "WA"),
            new XElement ( "Индекс", "68042") ) ) );
            XmlWriter w = XmlWriter.Create("1.xml");
            node.WriteTo(w);
            w.Close();
            Console.WriteLine("файл 1.xml создан");


        }
    }
}
