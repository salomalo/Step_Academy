using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SAXWork
{
    class Program
    {
        static void Main(string[] args)
        {
           /*    XmlTextWriter writer = null;
               try
               {
                   writer = new XmlTextWriter("new.xml", Encoding.UTF8);
                   writer.Formatting = Formatting.Indented; //для читабельного формату 
                   writer.WriteStartDocument();
                         writer.WriteStartElement("catalog");
                               writer.WriteStartElement("book");
                               writer.WriteAttributeString("id", "542");
                               writer.WriteElementString("author", "L. Kostenko");
                               writer.WriteElementString("title", "Zapysky ukrainskogo samashedshogo");
                         writer.WriteEndElement();
                   writer.WriteEndElement();
                   writer.WriteEndDocument();
               }
               catch (XmlException xe)
               {
                   Console.WriteLine(xe.Message);
               }
               catch (Exception e)
               {
                   Console.WriteLine(e.Message);
               }
               finally
               {
                   if (writer != null)
                   {
                       writer.Close();
                   }
               } 
               */
           XmlTextReader reader = null;
            try
            {
                reader = new XmlTextReader("new.xml");
                reader.WhitespaceHandling = WhitespaceHandling.None;
                while (reader.Read())
                {
                    Console.WriteLine("    Type: {0,7}, Name = {1,10}, Value = {2}", reader.NodeType, reader.Name, reader.Value);
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine("ATT Type: {0,7}, Name = {1,10}, Value = {2}", reader.NodeType, reader.Name, reader.Value);
                        }
                    }

                }
            }
            catch (XmlException xe)
            {
                Console.WriteLine(xe.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }
    }
}

