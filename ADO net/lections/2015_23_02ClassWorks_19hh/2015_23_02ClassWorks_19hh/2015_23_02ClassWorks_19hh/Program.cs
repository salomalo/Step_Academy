using System;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace _2015_23_02ClassWorks_19hh
{
    class Program
    {
        static void Main()
        {
            // // Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;
            // var cs = @"Server=LYNX-HOME\SQLEXPRESS;Database=db19hours;Trusted_Connection=True;";
            // var conn = new SqlConnection(cs);
            // var cmd = new SqlCommand("select * from Workers", conn);
            // 
            // 
            // conn.Open();
            // 
            // var rdr = cmd.ExecuteReader();
            // 
            // while (rdr.Read())
            // {
            //     Console.WriteLine("{0} {1} {2}", rdr["Id"], rdr["Name"], rdr["Phone"]);
            // }
            // 
            // conn.Close();

            // Server=myServerAddress;Database=myDataBase;Uid=myUsername;Pwd=myPassword;
            var cs = @"Server=localhost;database=zorinDB;Uid=root;Pwd=";
            var conn = new MySqlConnection(cs);
            var cmd = new MySqlCommand("select * from Workers", conn);

            conn.Open();

            var rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("{0} {1} {2}", rdr["Id"], rdr["Name"], rdr["Phone"]);
            }

            conn.Close();
        }
    }
}
