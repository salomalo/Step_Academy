using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract
{
    public interface IPrinteble
    {
        void Print();
    }
    public interface IAbstractRaceAF
    {
        ISportCar CreateSportCar();
        IFamilyCar CreateFamilyCar();  
    }
    public interface ISportCar : IPrinteble
    {
        string Name { set; get; }
        string Color { set; get; }
        string Shild { set; get; }
        void Motor();      
    }
    public interface IFamilyCar : IPrinteble
    {
        string Name { set; get; }
        string Color { set; get; }
        string Shild { set; get; }
        void Motor();
    }

    public class MustangFamilyCar : IFamilyCar
    {
        public string Name { set; get; }
        public string Color { set; get; }
        public string Shild { set; get; }
        public MustangFamilyCar(string name, string color, string shild)
        {
            Name = name;
            Color = color;
            Shild = shild;
        }
        public void Motor()
        {         
        }
        public void Print()
        {
            Console.WriteLine(" Car Name: {0}\n Car color: {1}\n Car shild: {2}\n",
             Name, Color, Shild);
        }
    }

    public class MustangSportCar : ISportCar
    {
        public string Name { set; get; }
        public string Color { set; get; }
        public string Shild { set; get; }
        public MustangSportCar(string name, string color, string shild)
        {
            Name = name;
            Color = color;
            Shild = shild;
        }
        public void Motor()
        {

        }
        public void Print()
        {
            Console.WriteLine(" Car Name: {0}\n Car color: {1}\n Car shild: {2}\n",
             Name, Color, Shild);
        }
    }

    public class Mustang : IAbstractRaceAF
    {
        public ISportCar CreateSportCar()
        {
            return new MustangSportCar("Sport Mustang", "blue", "velvet");
        }
        public IFamilyCar CreateFamilyCar()
        {
            return new MustangFamilyCar("Family Mustang", "yellow", "plastic"); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IAbstractRaceAF must = new Mustang();
            must.CreateFamilyCar().Print();
            must.CreateSportCar().Print();
        }
    }


}
