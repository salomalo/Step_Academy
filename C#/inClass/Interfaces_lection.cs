using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSample
{
    class Program
    {
        static void Main(string[] args)
        {
         //   Pen pen = new Pen(ConsoleColor.DarkBlue);
         //   Pencile pencile = new Pencile(ConsoleColor.Cyan);
         //   Rubber rubber = new Rubber();
         //   pen.Do();
         //   (pencile as IWritable).Do();
         //   (pencile as ICleanable).Do();
         //   rubber.Do();
         ///*   pen.Write();
         //   pencile.Write();
         //   pencile.Cleane();
         //   rubber.Cleane();*/
         //   IWritable[] arr = new IWritable[] { pen, pencile };
         //   foreach (IWritable el in arr)   //приведення до інтерфейсу IWritable
         //   {
         //       el.Write();
             
         //   }

         //   ICleanable[] arr2 = new ICleanable[] { rubber, pencile };
         //   foreach (ICleanable el in arr2)
         //   {
         //       el.Cleane();
         //   }

         //   IWritable wr = new Pencile(ConsoleColor.Red);
         //   wr.Write();

         //   if (wr is ICleanable)
         //   {
         //       (wr as ICleanable).Cleane();
         //   }


            //-----------------------------------------------


            Academy a = new Academy();
            Student s = new Student();
            Teacher t = new Teacher();
            Group g = new Group();
            MainInterface.PrintInfoAbout(a);
            MainInterface.PrintInfoAbout(s); 
            MainInterface.PrintInfoAbout(t);
            MainInterface.PrintInfoAbout(g);
        }
    }

  
    class Pen : IWritable
    {
        public ConsoleColor Color { set; get; }
        public Pen(ConsoleColor color)
        {
            Color = color;
        }

        public void Write()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("I am PEN and I can WRITE");
            Console.ResetColor();
        }

        public void Do()
        {
            Console.WriteLine("I am PEN - DO");
        }
    }

    class Pencile : IWritable, ICleanable
    {
        private ConsoleColor _color;
        public ConsoleColor Color 
        { 
            set
            {
                if (value != ConsoleColor.Black)
                {
                    _color = value;
                }
            }
            get
            {
                return _color;
            }
        }
        public Pencile(ConsoleColor color)
        {
            Color = color;
        }

        public void Write()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine("I am PENCILE and I can WRITE");
            Console.ResetColor();
        }

        public void Cleane()
        {
            Console.WriteLine("I am PENCILE and I can CLEANE");
        }

        void IWritable.Do()
        {
            Console.WriteLine("I am IWritable PENCILE - DO");
        }

        void ICleanable.Do()
        {
            Console.WriteLine("I am ICleanable PENCILE - DO");
        }
    }

    class Rubber : ICleanable
    {
        public void Cleane()
        {
            Console.WriteLine("I am RUBBER and I can CLEANE");
        }
        public void Do()
        {
            Console.WriteLine("I am RUBBER - DO");
        }
    }

    interface IWritable
    {
        ConsoleColor Color { set; get; }
        void Write();
        void Do();
    }

    interface ICleanable
    {
        void Cleane();
        void Do();
    }
    //----------------------------------------------------------
    class Student : IPrintable
    {
        public void PrintInfo()
        {
            Console.WriteLine("S");
        }
    }
    class Group : IPrintable
    {
        public void PrintInfo()
        {
            Console.WriteLine("G");
        }
    }
    class Teacher : IPrintable
    {
        public void PrintInfo()
        {
            Console.WriteLine("T");
        }
    }
    class Academy : IPrintable
    {
        public void PrintInfo()
        {
            Console.WriteLine("A");
        }
    }

    interface IPrintable
    {
        void PrintInfo();
    }

    class MainInterface
    {
      
       /* public void PrintInfoAbout(int id)
        {
            switch (id)
            {
                case 1: a.PrintInfo();
                    break;
                case 2:
                    s.PrintInfo();
                    break;
                //and so on
            }
        }
        */

        public static void PrintInfoAbout(IPrintable printer)
        {
            printer.PrintInfo();
        }

    }
}
