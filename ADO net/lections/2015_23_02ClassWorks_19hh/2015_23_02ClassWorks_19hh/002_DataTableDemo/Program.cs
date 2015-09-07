using System;
using System.Data;

namespace _002_DataTableDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable table = new DataTable();

            // table.Columns.Add("Id", typeof(int));
            // table.Columns.Add("Name", typeof(string));
            // table.Columns.Add("Position", typeof(string));
            // table.Columns.Add("DateOfWork", typeof(DateTime));
            // 
            // table.Rows.Add(101, "Pupkin", "boss", DateTime.Now);
            // table.Rows.Add(102, "Bupkin", "manager", DateTime.Now);
            // table.Rows.Add(103, "Zupkin", "manager", DateTime.Now);
            // table.Rows.Add(104, "Bulkin", "manager", DateTime.Now);
            // table.Rows.Add(105, "Poljuhovych", "designer", DateTime.Now);
            // 
            // foreach (DataRow row in table.Rows)
            // {
            //     Console.WriteLine(
            //         row.Field<int>(0)
            //         + " " +
            //         row.Field<string>(1)
            //         + " " +
            //         row.Field<string>(2)
            //         + " " +
            //         row.Field<DateTime>(3).ToShortDateString()
            //          );
            // }

            using (table = new DataTable())
            {
                table.Columns.Add("Name", typeof(string));
                table.Columns.Add("Date", typeof(DateTime));

                table.Rows.Add("mike", DateTime.Now);
                table.Rows.Add("todd", DateTime.Now);

                Console.WriteLine("-------------------------");
                Console.WriteLine(table.Rows[0].Field<string>(0));
                Console.WriteLine(table.Rows[0].Field<DateTime>(1));

                Console.WriteLine("-------------------------");
                Console.WriteLine(table.Rows[1].Field<string>(0));
                Console.WriteLine(table.Rows[1].Field<DateTime>(1));
            }
        }
    }
}
