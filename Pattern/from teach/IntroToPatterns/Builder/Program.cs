using System;
using Builder.Concrete;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicleCreator = new VehicleCreator(new FordBuilder());
            vehicleCreator.CreateVehicle();
            var vehicle = vehicleCreator.GetVehicle();
            vehicle.Print();

            //todo: add some another creator

            Console.ReadKey();
        }
    }
}
