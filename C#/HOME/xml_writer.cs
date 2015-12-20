using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.IO;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            //Order ord1 = new Order(1, "flower", 3.5);
            //Order ord2 = new Order(2, "book", 6.8);
            //Order ord3 = new Order(3, "notebook", 12.5);

            //List<Order> orders = new List<Order>(3);
            //orders.Add(ord1);
            //orders.Add(ord2);
            //orders.Add(ord3);

            //XmlTextWriter writer = null;
            //try
            //{
            //    writer = new XmlTextWriter("order.xml", Encoding.UTF8);
            //    writer.Formatting = Formatting.Indented; //для читабельного формату 
            //    writer.WriteStartDocument();
            //    writer.WriteStartElement("catalog");
            //    foreach (Order or in orders)
            //    {
            //        //Console.WriteLine("{0}. {1} {2}",or.Id,or.Title,or.Price);
            //        Creat(or, writer);
            //    }
            //    writer.WriteEndElement();
            //    writer.WriteEndDocument();
            //}
            //catch (XmlException xe)
            //{
            //    Console.WriteLine(xe.Message);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //finally
            //{
            //    if (writer != null)
            //    {
            //        writer.Close();
            //    }
            //}



        //    XmlTextReader reader = null;
        //    try
        //    {
        //        reader = new XmlTextReader("order.xml");
        //        reader.WhitespaceHandling = WhitespaceHandling.None;
        //        while (reader.Read())
        //        {
        //            if (reader.Value != "")
        //            {
        //                if (reader.Name != "")
        //                {
        //                    Console.WriteLine("Type = {0}, Name = {1} value = {2}", reader.NodeType, reader.Name, reader.Value);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Type = {0}, value = {1}", reader.NodeType, reader.Value);
        //                }
        //            }

        //            if (reader.HasAttributes)
        //            {
        //                while (reader.MoveToNextAttribute())
        //                {
        //                    Console.WriteLine("Id: {0}", reader.Value);
        //                }
        //            }
        //        }
        //    }
        //    catch (XmlException xe)
        //    {
        //        Console.WriteLine(xe.Message);
        //    }
        //    finally
        //    {
        //        if (reader != null)
        //        {
        //            reader.Close();
        //        }
        //    }







            try
            {
                List<Order> catalog = new List<Order>();
                XmlDocument doc = new XmlDocument();
                doc.Load("order.xml");
                XmlNodeList list = doc.GetElementsByTagName("order");
                foreach (XmlNode node in list)
                {

                }
                doc.Save("new.xml");
                foreach (Order order in catalog)
                {
                    //  Console.WriteLine(book.Author + " " + book.Price);
                    catalog.Add(new Order() { Id = node["id"].InnerText, Title = node["title"].InnerText, Price = node["price"].InnerText });
                    node["Title"].InnerText = "Shild";
                }

                NodePrint(doc.DocumentElement);

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }


        }

        //public static void Creat(Order ord, XmlTextWriter writer)
        //{
        //    writer.WriteStartElement("order");

        //    writer.WriteAttributeString("id", ord.Id.ToString());
        //    writer.WriteElementString("title", ord.Title);
        //    writer.WriteElementString("Price", ord.Price.ToString());

        //    writer.WriteEndElement();
        //}

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

    public class Order
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public double Price { set; get; }

        public Order(int id, string title, double price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}