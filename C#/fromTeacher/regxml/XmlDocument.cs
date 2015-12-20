using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                List<Book> catalog = new List<Book>();
                XmlDocument doc = new XmlDocument();
                doc.Load("../../book.xml");
                XmlNodeList list = doc.GetElementsByTagName("book");
                foreach (XmlNode node in list)
                {
                  //  Console.WriteLine("{0}, author {1} - price {2}", node["title"].InnerText, node["author"].InnerText, node["price"].InnerText);
                   
                    catalog.Add(new Book() { Author = node["author"].InnerText, Title = node["title"].InnerText, Price = node["price"].InnerText });
                    node["author"].InnerText = "Shild";
                }
                doc.Save("new.xml");
                foreach (Book book in catalog)
                {
                  //  Console.WriteLine(book.Author + " " + book.Price);
                }

                NodePrint(doc.DocumentElement);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public static void NodePrint(XmlNode node)
        {
            Console.WriteLine("{0,7} - {1, -10}, {2}", node.NodeType, node.Name, node.Value);
            if (node.Attributes != null)
            {
                foreach (XmlAttribute att in node.Attributes)
                {
                    Console.WriteLine("{0,7} - {1, -10}, {2}", att.NodeType, att.Name, att.Value);
                }
            }
            foreach (XmlNode el in node.ChildNodes)
            {
                NodePrint(el);
            }
        }

    }


    class Book
    {
        public string Title { set; get; }
        public string Author { set; get; }
        public string Price { set; get; } //треба зробити double і розпасити

    }
}
