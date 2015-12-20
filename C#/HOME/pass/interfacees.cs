using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Chocolate_cake one = new Chocolate_cake("Chocolate_cake", 500, 35.5);
            one.Print();
            one.termCondition();

            Console.WriteLine(" ");

            Milk second = new Milk("Milk", 100, 5.6);
            second.Print();
            second.termCondition();

            Glas gl = new Glas("CoolGlass", 123);
            gl.Print();
            gl.HoldCondition();


            Champagne ch = new Champagne("Champ", 67.8);
            ch.Print();
        }
    }

    public class Product
    {
        protected String title;
        protected double price;
        public Product(String title, double price)
        {
            this.title = title;
            this.price = price;
        }
    }

    public class NotFood : Product
    {
        public NotFood(String title, double price)
            : base(title, price)
        { }
        public void Print()
        {
            Console.WriteLine("Not food");
        }
    }

    public class GlassItems : NotFood, IBreakable
    {
        public GlassItems(String title, double price)
            : base(title, price)
        { }
        public void HoldCondition()
        {
            Console.WriteLine("Do not beat!!!!!");
        }
    }
    public class Glas : GlassItems
    {
        public Glas(String title, double price)
            : base(title, price)
        { }
    }


    public class Food : Product
    {
        protected double massa;
        public Food(double massa, String title, double price)
            : base(title, price)
        {
            this.massa = massa;
        }
        public void Print()
        {
            Console.WriteLine("title - {0} massa - {1} price - {2}", this.title, this.massa, this.price);
        }
    }

    public class Milk : Food, IPerishables, IPrinteble
    {
        public Milk(String title, double massa, double price)
            : base(massa, title, price)
        { }
        public void termCondition()
        {
            Console.WriteLine("hold in refrigerator");
        }
    }

    public class Chocolate_cake : Food, IPerishables, IPrinteble
    {
        public Chocolate_cake(String title, double massa, double price)
            : base(massa, title, price)
        { }
        public void termCondition()
        {
            Console.WriteLine("hold in refrigerator");
        }
        public void Print()
        {
            Console.WriteLine("title - {0} massa - {1} price - {2}", this.title, this.massa, this.price);
        }
    }

    public class Alckohol : NotFood, Ilicense
    {
        public Alckohol(String title, double price)
            : base(title, price)
        { }

        public void infoIlicense()
        {
            Console.WriteLine("license from....");
        }



    }

    public class Champagne : Alckohol
    {
        public Champagne(String title, double price)
            : base(title, price)
        { }

    }





    interface Ilicense
    {
        void infoIlicense();
    }
    interface IFirable
    {
        void infoIFireble();
    }
    interface IPerishables
    {
        void termCondition();
    }
    interface IBreakable
    {
        void HoldCondition();
    }

    interface IPrinteble
    {
        void Print();
    }



}