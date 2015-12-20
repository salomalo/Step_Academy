using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexsator
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person();
            Person person2 = new Person();
            Person person3 = new Person();
            Person person4 = new Person();
            Person person5 = new Person();
            //person5.Name = "NEMO";
            
            People ukrainian = new People();
            
            ukrainian.PersonsArr = new Person[] { person1, person2, person3, person4,person5};
          

            for (int i = 0; i < ukrainian.Length; i++)
            {
                ukrainian[i].Name = "person" + i;
                Console.WriteLine(ukrainian[i].Name);
            }

            Console.WriteLine();
            foreach (var el in ukrainian)
            {
                Console.WriteLine(((Person)el).Name);
            }
        }
    }

    class People :IEnumerable  //для використання foreach
    {
        public String Name { set; get; } // всерівно що  - public String name;
        public Person[] PersonsArr { set; get; }
        public int[] Arr {set; get;}

      

        public int Length
        {
            get { return PersonsArr.Length; }
        }

        public Person this[int index]                    //для проходження по обєкту як по масиву
        {
            set
            {
                if (index > PersonsArr.Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                PersonsArr[index] = value;
            }

            get
            {
                if (index > PersonsArr.Length - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return PersonsArr[index];
            }
        }

        public IEnumerator GetEnumerator()
        {
            return PersonsArr.GetEnumerator();
        }
      
    }

    class Person
    {
        public String Name { set; get; }

    }
}
