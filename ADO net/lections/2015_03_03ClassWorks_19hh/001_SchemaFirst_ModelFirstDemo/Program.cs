using System;

namespace _001_SchemaFirst_ModelFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EFdemoEntities())
            {
                ctx.Database.Log = Console.WriteLine;

                foreach (var e in ctx.Employees)
                {

                    Console.WriteLine(e);
                }
            }

        }
    }
}
