using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stuctures
{
    class Program
    {
        static void Main(string[] args)
        {

           /* PersonStr[] arr = new PersonStr[1000];
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                arr[i] = new PersonStr();
            }
            sw.Stop();
            Console.WriteLine(sw.Elapsed);*/
            PersonStr person = new PersonStr("Tom", "Cat",5, Nationalities.Polish);
         //   Console.WriteLine(person.nat + 1);

           var arr = Enum.GetValues(typeof(Nationalities));
           foreach (var el in arr)
           {
               Console.WriteLine(el);
           }
            Nationalities marker = Nationalities.USA;
            switch (marker)
            {
                case Nationalities.English:
                    break;
                case Nationalities.Polish:
                    break;
                case Nationalities.USA:
                    break;
                case Nationalities.Ukrainian:
                    break;
            }
         //   person.Name = "tom";
         /*   Console.WriteLine(person.Name);
            Rename(ref person);
            PersonStr personCreate = PersonCreation();
            PersonCreation(out personCreate);
            Console.WriteLine(person.Name);*/
        }

        public static void Rename(ref PersonStr p)
        {
         //   p = new PersonStr();
            p.Name = "NewName";
            Console.WriteLine(p.Name);
        }

        public static void PersonCreation(out PersonStr p)
        {
            p = new PersonStr();
            p.Name = "New Person";
            Console.WriteLine(p.Name);
        }

        public static PersonStr PersonCreation()
        {
            PersonStr p = new PersonStr();
            p.Name = "New Person";
            Console.WriteLine(p.Name);
            return p;
        }
    }

    class Person
    {
        public String Name { set; get; }
        public String LastName { set; get; }
        public int Age { set; get; }
    }

    struct PersonStr
    {
        public Nationalities nat;

        private String _name;
        public String Name 
        {
            set
            { 
                _name = value; 
            }
            get
            {
                return _name;
            }
        }
        private String _lastName;
        public String LastName
        {
            set
            {
                _lastName = value;
            }
            get
            {
                return _lastName;
            }
        }
        private int _age;
        public int Age
        {
            set
            {
                _age = value;
            }
            get
            {
                return _age;
            }
        }

        public PersonStr(String name, String lastName, int age, Nationalities nation)
        {
            _name = name;
            _lastName = lastName;
            _age = age;
            nat = nation;
        }
    }

    enum Nationalities : ulong
    {
        Ukrainian=100000000000000, Polish, English=50, USA=0
    }

}
