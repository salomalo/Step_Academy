using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    public interface IPizzaBuilder
    {
        void MakeDough();
        void AddTomatoPasta();
        void AddCheese();
       // void BakePizza();

        Pizza GetPizza();
    }

    public class PizzaDirector
    {
        public IPizzaBuilder PizzaBuilder{set;get;}

        public void CreatePizza()
        {
            PizzaBuilder.MakeDough();
            PizzaBuilder.AddTomatoPasta();
            PizzaBuilder.AddCheese();
          //  PizzaBuilder.BakePizza();
        }
    }

    public class MargaritaPizzaBuilder : IPizzaBuilder
    {
        public Pizza pizza = new Pizza();

        public void MakeDough()
        {
            pizza.Dough= "Dough was made";
        }

        public void AddTomatoPasta()
        {
            pizza.TomatoPasta= "TomatoPasta was added";
        }

        public void AddCheese()
        {
            pizza.Cheese= "Cheese was added";
        }

        //public void BakePizza()
        //{
        //    pizza. "Pizza was baked";
        //}

        public  Pizza GetPizza()
        {
            //pizza.Dough = MakeDough();
            //margarita.TomatoPasta = AddTomatoPasta();
            //margarita.Cheese = AddCheese();

            //Console.WriteLine("Dough:{0}\n TomatoPasta{1}\n Cheese{2}\n ", margarita.Dough, margarita.TomatoPasta, margarita.Cheese);

            return pizza;
        }
    }

    public class Pizza
    {
       public  string Dough { set; get; }
       public string TomatoPasta { set; get; }
       public string Cheese { set; get; }

         public Pizza()
        {
            Dough = "not ready";
            TomatoPasta = " no tomatoPasta";
            Cheese = " no cheese";
        }
        public Pizza(string dough,string tomatoPasta,string cheese)
        { 
            Dough = dough;
            TomatoPasta = tomatoPasta;
            Cheese = cheese;
        }

    }

    //public class MargaritaPizza : IPizza
    //{
    //    public string Dough { set; get;}
    //    public string TomatoPasta { set; get; }
    //    public string Cheese { set; get; }

    //    public MargaritaPizza()
    //    {
    //        Dough = "not ready";
    //        TomatoPasta = " no tomatoPasta";
    //        Cheese = " no cheese";
    //    }
    //    public MargaritaPizza(string dough,string tomatoPasta,string cheese)
    //    { 
    //        Dough = dough;
    //        TomatoPasta = tomatoPasta;
    //        Cheese = cheese;
    //    }
    //}

    class Program
    {
        static void Main(string[] args)
        {

            PizzaDirector pizzaDir = new PizzaDirector();
            IPizzaBuilder pizzaBuilder = new MargaritaPizzaBuilder();

            pizzaDir.PizzaBuilder = pizzaBuilder;
            pizzaDir.CreatePizza();

            Pizza MargaritaPizza = pizzaBuilder.GetPizza();
            Console.WriteLine(" Dough: {0}\n TomatoPasta: {1}\n Cheese: {2}\n ", MargaritaPizza.Dough, MargaritaPizza.TomatoPasta, MargaritaPizza.Cheese);


            
        }
    }
}
