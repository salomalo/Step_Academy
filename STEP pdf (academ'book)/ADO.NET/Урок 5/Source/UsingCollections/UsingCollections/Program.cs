using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsingCollections
{
    class Program
    {
        class Tovar
        {//Новая возможность C#3.0 автоматические свойства
            public string Name { set; get; }
            public float Price { set; get; }
        }
        static void Main(string[] args)
        {
            //создаем список
            var Mas = new List<Tovar>();
            //заполняем список тремя позициями
            Mas.Add( new Tovar() { Name = "картошка", Price = 2.04f });
            Mas.Add(new Tovar() { Name = "огурцы", Price = 7.20f });
            Mas.Add(new Tovar() { Name = "помидоры", Price = 11.30f });
            //Выбираем все товары с ценой от 7 до 20
            var Tovars = from t in Mas
                             where t.Price>=7 && t.Price<=20 
                             select t;
            foreach (var t in Tovars)
                Console.WriteLine("{0} - {1}", t.Name, t.Price);


        }
    }
}
