using System;
using AbstractFactory.Concrete;

namespace AbstractFactory
{
    public enum KeybordManufacture
    {
        Genius,
        Logitech
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. create factory
            //we don't need to specify concrete type to return instead of we should specify concrete factory
            var factory = CreateFactory(KeybordManufacture.Genius);

            //2. use it
            //we should think about of product here
            Print(factory.ClassicKeyboard);
            Print(factory.WireLessKeyboard);
        }

        private static IKeyboradFactory CreateFactory(KeybordManufacture k)
        {
            if (k == KeybordManufacture.Genius)
            {
                return new GeniusFactory();
            }
            return new LogitechFactory();
        }

        private static void Print(ISimpleKeyboard k)
        {
            Console.WriteLine("Simple keyboard. Model: {0}  Keys: {1}", k.Name, k.KeysCount);
        }

        private static void Print(IWireLessKeyboard k)
        {
            Console.WriteLine("Wire less keyboard. Model: {0}  Keys: {1}", k.Name, k.KeysCount);
        }
    }
}
