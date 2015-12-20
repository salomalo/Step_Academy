using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace test_class
{
    class Program
    {
        static void Main(string[] args)
        {
            Dict dict = new Dict();

            dict.Add("Ukraine", "Україна");
            dict.Add("USA", "США");
            dict.Add("England", "Англія");
            dict.Add("Italy", "Італія");
            dict.Add("Poland", "Польща");

            Console.WriteLine("...Dictionary...");
            while (true)
            {
                Console.WriteLine("enter \n 1 - En - > Ukr \n 2 - Ukr - > En \n 3 - print all words");
                String str = Console.ReadLine();
                switch (str)
                {
                    case "1":
                        Console.WriteLine("enter english word:");
                        String key = Console.ReadLine();
                        dict.en_uk(key);
                        break;

                    case "2":
                        Console.WriteLine("enter ukrainian word:");
                        String value = Console.ReadLine();
                        dict.uk_en(value);
                        break;

                    case "3":
                        Console.WriteLine("all words in dictionary");
                        dict.PrintAll();
                        break;
                }
            }
        }
    }
    public class Dict
    {
        public Hashtable dictionary { set; get; }
        public Dict()
        {
            dictionary = new Hashtable();
        }
        public void Add(String a, String b)
        {
            dictionary.Add(a, b);
        }
        public void PrintAll()
        {
            object tmp;
            foreach (DictionaryEntry en in dictionary)
            {
                tmp = en.Key;
                Console.WriteLine("{0} -> {1}", dictionary[tmp], tmp);
            }
        }
        public void en_uk(String a)
        {
            if (dictionary.ContainsKey(a))
            {
                Console.WriteLine("{0} -> {1}", a, dictionary[a]);
            }
            else
                Console.WriteLine("no such word");
        }
        public void uk_en(String a)
        {
            if (dictionary.ContainsValue(a))
            {
                object tmp;
                foreach (DictionaryEntry en in dictionary)
                {
                    if (en.Value.Equals(a))
                    {
                        tmp = en.Key;
                        Console.WriteLine("{0} -> {1}", dictionary[tmp], tmp);
                    }
                }
            }
            else
                Console.WriteLine("no such word");
        }
    }
}