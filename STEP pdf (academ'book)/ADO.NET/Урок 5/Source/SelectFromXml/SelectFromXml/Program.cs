using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml;

namespace SelectFromXml
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаем reader
            XmlReader reader = XmlReader.Create("albom.xml");
            //загружаем данные их документа
            XDocument doc = XDocument.Load(reader);
            
            //Формируем выборку
            var collection = from el in doc.Descendants(XName.Get("disk"))
                             where Convert.ToInt32(el.Element(XName.Get("year")).Value) >=2006
                             select el;

            //Выводим полученный результат
            foreach (var el in collection)
            {
                Console.WriteLine(el.Value);
            }
        }
       
    }
}
