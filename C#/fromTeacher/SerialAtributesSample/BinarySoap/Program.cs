using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace BinarySoap
{
    class Program
    {
        static void Main(string[] args)
        {
            #region BinaryFormatter
            //-----------------------------------Serialization-----------------------------
            Person p1 = new Person() { Name = "Tom", SName = "Soyer", Age = new MyDate(1, 1, 1990) };
            Person p2 = new Person() { Name = "Tom1", SName = "Soyer1", Age = new MyDate(11, 1, 1990) };
            Person p3 = new Person() { Name = "Tom2", SName = "Soyer2", Age = new MyDate(21, 1, 1990) };
            Person p4 = new Person() { Name = "Tom3", SName = "Soyer4", Age = new MyDate(31, 1, 1990) };

            List<Person> list = new List<Person>();
            list.Add(p1);
            list.Add(p2);
            list.Add(p3);
            list.Add(p4);

            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream("bin.dat", FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, list);
                fs.Flush();
            }

            //-----------------------------------Deserialization-----------------------------
            //TODO add try - catch
            BinaryFormatter bf1 = new BinaryFormatter();
            List<Person> persons = null;
            using (FileStream fs = new FileStream("bin.dat", FileMode.Open))
            {
                persons = (List<Person>)bf1.Deserialize(fs);
            }
            if (persons != null)
            {
                foreach (Person pr in persons)
                {
                  //  pr.Print();
                }
            }
            #endregion

			
			
            #region SoapFormatter
            //-----------------------------------Serialization-----------------------------
            Person p = new Person() { Name = "Ket", SName = "Bring", Age = new MyDate(1, 1, 1990) };
            SoapFormatter soap = new SoapFormatter();
            using (FileStream fs = new FileStream("soap.xml", FileMode.OpenOrCreate))
            {
                soap.Serialize(fs, p);
                fs.Flush();
            }
            //-----------------------------------Deserialization-----------------------------
            Person deserPer = null;
            using (FileStream fs = new FileStream("soap.xml", FileMode.Open))
            {
                deserPer = (Person)soap.Deserialize(fs);
            }
            if (deserPer != null)
            {
                deserPer.Print();
            }
            #endregion
        }
    }

    [Serializable]
    class Person
    {
        public string Name { set; get; }
        public string SName { set; get; }      
        public MyDate Age { set; get; }

        public void Print()
        {
            Console.WriteLine("{0} {1} ", Name, SName);
        }
    }

    [Serializable]
    class MyDate
    {
        private int _day;
        private int _month;
        private int _year;

        public MyDate(int d, int m, int y)
        {
            _day = d;
            _month = m;
            _year = y;
        }
    }

      
}
