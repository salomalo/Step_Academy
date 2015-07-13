using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _003_validation
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            schema.Add("", "data.xsd");

            XDocument doc = XDocument.Load("data.xml");

            bool validError = false;

            doc.Validate(schema, (s, e) =>
                {
                    Console.WriteLine(e.Message);
                    validError = true;
                });

            if (validError)
            {
                Console.WriteLine("Validation failed");
            }
            else
            {
                Console.WriteLine("Validation succeeded");
            }
        }
    }
}
