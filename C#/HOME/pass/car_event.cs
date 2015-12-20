using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test_class
{
    public delegate void EventCar(object sender, EventArgs args);  //делегат


    class Program
    {
        static void Main(string[] args)
        {
            Driver dr = new Driver();

            Car car = new Car(dr, 50, 150, 100);

            // car.AddFuel(100);
            // car.Print();
            //car.sub_Fuel(150);
            //car.Print();

            while (true)
            {
                Console.WriteLine("enter \n 1 - start \n 2 - stop \n 3 - addfuel \n 4 - ride");
                String str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        car.OnStart();
                        break;

                    case "2":
                        car.OnStop();
                        break;

                    case "3":
                        car.AddFuel(100);
                        break;

                    case "4":
                        car.Ride(100);
                        break;
                }
            }
        }
    }

    public class Car //send en event
    {
        public event EventCar Stop;
        public event EventCar Start;
        public event EventCar EmptyBak;
        public event EventCar FullBak; // подія

        public int fuel;
        public int Fuel
        {
            get { return fuel; }
            set { fuel = value; }
        }

        public int speed;
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public int fuelMax;
        public int FuelMax
        {
            get { return fuelMax; }
            set { fuelMax = value; }
        }
        //public int SpeedMax { set; get; }

        public Car(Driver driver, int fuel, int fuelmax, int speed)
        {
            Fuel = fuel;
            Speed = speed;
            FuelMax = fuelmax;

            FullBak += driver.PrintFuelBak;  // підписуюсь на подію
            EmptyBak += driver.PrintEmptyBak;
            Start += driver.PrintStart;
            Stop += driver.PrintStop;
        }

        public void Print()
        {
            Console.WriteLine("fuel in bak {0}", Fuel);
        }

        public void AddFuel(int fuel)
        {
            Fuel += fuel;

            if (Fuel == FuelMax)
            {
                OnEventFullBak();
            }

            if (Fuel > FuelMax)
            {
                Fuel = FuelMax;
            }
        }

        public void Ride(int dist)
        {
            int km = 0;
            for (int i = 0; i < dist; i++)
            {
                km++;
                sub_Fuel(5);
                
                if(fuel>0){
                Console.WriteLine("km is {0}", km);
                }

                if (Fuel <= 0)
                {
                    break;
                }
            }

        }

        public void sub_Fuel(int fuel)
        {
            Fuel -= fuel;
            if (Fuel == 0)
            {
                OnEventEmptyBak();
                OnStop();
            }

            if (Fuel < 0)
            {
                Fuel = 0;
            }
        }

        public void OnEventFullBak()
        {
            if (FullBak != null)  //перевірка чи хтось підписався на подію
            {
                FullBak(this, EventArgs.Empty);
            }
        }

        public void OnEventEmptyBak()
        {
            if (EmptyBak != null)  //перевірка чи хтось підписався на подію
            {
                EmptyBak(this, EventArgs.Empty);
            }
        }

        public void OnStart()
        {
            if (Start != null)  //перевірка чи хтось підписався на подію
            {
                Start(this, EventArgs.Empty);
            }
        }

        public void OnStop()
        {
            if (Stop != null)  //перевірка чи хтось підписався на подію
            {
                Stop(this, EventArgs.Empty);
            }
        }

    }


    public class Driver
    {

        public void PrintFuelBak(object sender, EventArgs args)
        {
            Console.WriteLine("!!! Bak is full now !!!");
        }

        public void PrintEmptyBak(object sender, EventArgs args)
        {
            Console.WriteLine("---- Bak is empty now ----");
        }

        public void PrintStart(object sender, EventArgs args)
        {
            Console.WriteLine("1..2...3....Start");
        }

        public void PrintStop(object sender, EventArgs args)
        {
            Console.WriteLine("......stop");
        }

    }


}