using System;
using System.Collections.Generic;

namespace Builder
{
    /// <summary>
    /// Надає інтерфейс для покрокового конструювання складного продукту
    /// </summary>
    public interface IVehicleBuilder
    {
        void SetModel();
        void SetEngine();
        void SetTransmission();
        void SetBody();
        void SetAccessories();
        Vehicle GetVehicle();
    }

    /// <summary>
    /// Director який, знає по яких кроках відбувається процес створення
    /// </summary>
    public class VehicleCreator
    {
        private readonly IVehicleBuilder _builder;

        public VehicleCreator(IVehicleBuilder builder)
        {
            _builder = builder;
        }

        public void CreateVehicle()
        {
            //ПОКРОКОВЕ КОНСТРУЮВАННЯ!!!!
            _builder.SetModel();
            _builder.SetEngine();
            _builder.SetBody();
            _builder.SetTransmission();
            _builder.SetAccessories();
        }

        public Vehicle GetVehicle()
        {
            return _builder.GetVehicle();
        }
    }

    /// <summary>
    /// Продукт який буде створюватися
    /// </summary>
    public class Vehicle
    {
        public string Model { get; set; }
        public string Engine { get; set; }
        public string Transmission { get; set; }
        public string Body { get; set; }
        public List<string> Accessories { get; set; }

        public Vehicle()
        {
            Accessories = new List<string>();
        }

        public void Print()
        {
            Console.WriteLine("Model: {0}", Model);
            Console.WriteLine("Engine: {0}", Engine);
            Console.WriteLine("Body: {0}", Body);
            Console.WriteLine("Transmission: {0}", Transmission);
            Console.WriteLine("Accessories:");
            foreach (var accessory in Accessories)
            {
                Console.WriteLine("\t{0}", accessory);
            }
        }
    }
}
