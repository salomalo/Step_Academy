using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car = new Car(50, ConsoleColor.Blue);
            Driver driver = new Driver();
            car.PropertyChanged += driver.PropertyChangedCheck; //PropertyChanged - подія, PropertyChangedCheck - метод який слухає і реагує
            
            car.Ride(10);
            car.Excident();
            car.BacFulling(50);
            car.NewStyle(ConsoleColor.DarkBlue);
            car.Color = ConsoleColor.Cyan;

        }
    }

    class Car : INotifyPropertyChanged
    {
       // public event EventHandler FuelValueChanged;
       // public event EventHandler ColorChanged;
        public event PropertyChangedEventHandler PropertyChanged; // подія

        private double _fuel;
        private ConsoleColor _color;

        public double Fuel 
        {
            set
            {
                if (value != _fuel)
                {
                    _fuel = value;
                    RisePropertyChanged("Fuel");                 
                }
            }
            get
            {
                return _fuel;
            }        
        }
        public ConsoleColor Color
        {
            set
            {
                if (value != _color)
                {
                    _color = value;
                    RisePropertyChanged("Color");
                }
            }
            get
            {
                return _color;
            }

        }

        public Car(double fuel, ConsoleColor color)
        {
            _color = color;
            _fuel = fuel;
        }

        public void Ride(int distance)
        {
            for (int i = 0; i < distance; i++)
            {
                if (Fuel - 0.6 <= 0)
                {
                    Fuel = 0;
                    return;
                }
                Fuel -= 0.6;
               /* if (Fuel <= 0)
                {
                    _fuel = 0;
                    return;
                }*/
               
            }
        }

        public void BacFulling(float liters)
        {
            Fuel += liters;
        }

        public void Excident()
        {
            Console.WriteLine("Babah!!!..............");
            Fuel = 0;
        }

        public void NewStyle(ConsoleColor color)
        {
            Color = color;
        }

        public void RisePropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    class Driver
    {
        public void PropertyChangedCheck(object sender, PropertyChangedEventArgs args)
        {          
            if (args.PropertyName == "Color")
            {
                Console.WriteLine("Cool!!!");
            }
            else if (args.PropertyName == "Fuel")
            {
              //  Car car = (sender as Car);
                if (sender is Car)
                {
                    if ((sender as Car).Fuel == 0)
                    {
                        Console.WriteLine("I can't ride");    //пишуть окремі методи які викликаються в залежності від того як змінилась та чи інша властивість
                    }
                    else
                    {
                        Console.WriteLine("I can ride");
                    }
                }
            }
        }

    }
}
