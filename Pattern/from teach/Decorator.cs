using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            // загальний автомобіль
            HondaCity car = new HondaCity();

            Console.WriteLine("Honda City base price are : {0}", car.Price);

            // спеціальна пропозиція
            SpecialOffer offer = new SpecialOffer(car);
            offer.DiscountPercentage = 25;
            offer.Offer = "25 % discount";

            Console.WriteLine("{1} .Special offer and price are : {0} ", offer.Price, offer.Offer);

            Console.ReadKey();

        }
    }

    //Інтерфейс компонента
    public interface IVehicle
    {
        string Make { get; }
        string Model { get; }
        double Price { get; }
    }

    //конкретний компонент
    public class HondaCity : IVehicle
    {

        public string Make
        {
            get { return "HondaCity"; }
        }

        public string Model
        {
            get { return "CNG"; }
        }

        public double Price
        {
            get { return 1000000; }
        }
    }

    //абстрактний клас декоратор
    public abstract class VehicleDecorator : IVehicle
    {
        private readonly IVehicle _vehicle;

        protected VehicleDecorator(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public string Make
        {
            get { return _vehicle.Make; }
        }

        public string Model
        {
            get { return _vehicle.Model; }
        }

        public double Price
        {
            get { return _vehicle.Price; }
        }

    }

    //конкретний клас декоратор
    public class SpecialOffer : VehicleDecorator
    {
        public SpecialOffer(IVehicle vehicle) :
            base(vehicle)
        {
            
        }

        public int DiscountPercentage { get; set; }
        public string Offer { get; set; }

        public new double Price
        {
            get
            {
                double price = base.Price;
                int percentage = 100 - DiscountPercentage;
                return Math.Round((price * percentage) / 100, 2);
            }
        }

    }

    
}