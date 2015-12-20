using System;

namespace Facade
{    
    class Program
    {
        static void Main(string[] args)
        {
            //доступаємося до нашого фасаду
            CarFacade facade = new CarFacade();

            facade.CreateCompleteCar();
            Console.ReadKey();
        }
    }

    //Підсистема А
    class CarModel
    {
        public void SetModel()
        {
            Console.WriteLine(" CarModel - SetModel");
        }
    }
    //Підсистема Б
    class CarEngine
    {
        public void SetEngine()
        {
            Console.WriteLine(" CarEngine - SetEngine");
        }
    }
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    public class CarFacade
    {
        readonly CarModel _model;
        readonly CarEngine _engine;

        public CarFacade()
        {
            _model = new CarModel();
            _engine = new CarEngine();
        }

        public void SetEngine()
        {
            _engine.SetEngine();
        }

        public void CreateCompleteCar()
        {
            Console.WriteLine("Creating car...");
            _engine.SetEngine();
            _model.SetModel();
            
            Console.WriteLine("Car was created");
        }
    }
}