﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace XMLSerial
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer xmlSer = new XmlSerializer(typeof(catalog));
            catalog ctl = null;
            using (FileStream fs = new FileStream("book.xml", FileMode.Open))
            {
                ctl = (catalog)xmlSer.Deserialize(fs);
            }

            if (ctl != null)
            {
                foreach (catalogBook book in ctl.book)
                {
                    book.price += 999;
                    Console.WriteLine(book.title + " - " + book.description);
                }
            }

            using (FileStream fs = new FileStream("bookNew.xml", FileMode.OpenOrCreate))
            {
                xmlSer.Serialize(fs, ctl);
                fs.Flush();
            }
        }
    }



    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class catalog
    {

        private catalogBook[] bookField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("book")]
        public catalogBook[] book
        {
            get
            {
                return this.bookField;
            }
            set
            {
                this.bookField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class catalogBook
    {

        private string authorField;

        private string titleField;

        private string genreField;

        private decimal priceField;

        private System.DateTime publish_dateField;

        private string descriptionField;

        private string idField;

        /// <remarks/>
        public string author
        {
            get
            {
                return this.authorField;
            }
            set
            {
                this.authorField = value;
            }
        }

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
        public string genre
        {
            get
            {
                return this.genreField;
            }
            set
            {
                this.genreField = value;
            }
        }

        /// <remarks/>
        public decimal price
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
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime publish_date
        {
            get
            {
                return this.publish_dateField;
            }
            set
            {
                this.publish_dateField = value;
            }
        }

        /// <remarks/>
        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
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
