using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public enum PersonMaritalStatus
    {
        Merried,
        Single
    }
    [Serializable]

    public class Person
    {
        string Name;
        string LastName;
        int Age;
        PersonMaritalStatus MaritsalStatus;
        public Person(string Name, string Lastname, int Age)
        {
            this.Name = Name;
            this.LastName = Lastname;
            this.Age = Age;
            this.MaritsalStatus = PersonMaritalStatus.Single;
        }
        public void Print()
        {
            Console.WriteLine("Person:\nName: " + Name + "\nLastname: " + LastName + "\nAge: " + Age);
        }
    }

    public class Employee : Person
    {
        string Position;
        decimal Salary;
        public Employee(string Name, string Lastname, int Age, string Position, decimal Salary) :
            base(Name, Lastname, Age)
        {
            this.Position = Position;
            this.Salary = Salary;
        }
    }

}
