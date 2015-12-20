using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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


            //-----------------------XmlSerializer----------------------------------------


            List <catalogOrder> orlist = new List<catalogOrder>(0);





            XmlSerializer xml = new XmlSerializer(typeof(catalog));
            catalog ctl = null;
            using (FileStream fs = new FileStream("order.xml", FileMode.Open))
            {
                ctl = (catalog)xml.Deserialize(fs);
            }

            if (ctl != null)
            {
                foreach (catalogOrder or in ctl.order)
                {
                    or.id += 10;
                  //  Console.WriteLine("title: {0,-10}  price: {1,-10}  id: {2,-10} ", or.title, or.Price, or.id);
                    orlist.Add(or);
                }
            }

           //   using (FileStream fs = new FileStream("orderNew.xml", FileMode.OpenOrCreate))
           // {
           //     xml.Serialize(fs, ctl);
           //     fs.Flush();
           //  }



            foreach (catalogOrder or in orlist)
            {
                Console.WriteLine("title: {0,-10}  price: {1,-10}  id: {2,-10} ", or.title, or.Price, or.id);
            }

            catalogOrder catalogOrder1 = new catalogOrder() {id=9, Price="8", title="9"};



            //BinaryFormatter
            //---------------------seralization записати в бінареик
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fse = new FileStream("binORDER.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fse, catalogOrder1);
                fse.Flush();
            }

            //---------------------deseralization зчитати з бінарника
            BinaryFormatter r = new BinaryFormatter();
            List<catalogOrder>






            //SoapFormatter
            //---------------------seralization записати в бінареик




            //---------------------deseralization зчитати з бінарника





        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    [Serializable]
    public partial class catalog
    {
        private catalogOrder[] orderField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("order")]
        public catalogOrder[] order
        {
            get
            {
                return this.orderField;
            }
            set
            {
                this.orderField = value;
            }
        }
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [Serializable]
    public partial class catalogOrder
    {
        private string titleField;
        private string priceField;
        private byte idField;

        /// <remarks/>
        public string title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }

        /// <remarks/>
        public string Price
        {
            get
            {
                return this.priceField;
            }
            set
            {
                this.priceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }
    }








}