﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtentionMethods1
{
    class Program
    {
        static void Main()
        {
            string myString = "Hi!";
            myString.PrintMe(2); //Используем Extension Method
        }
    }
    
    // Класс в котором объявлены Extension Methods должен быть static
     public static class MyClass
    {
        // Определяем Extension Method PrintMe
        public static void PrintMe(this object obj, int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(obj.ToString());
            }
        }
    }

}
