using System;
using System.Configuration;
using System.Data.SqlClient;

namespace _003_SqlBulkCopy_notifyAfter__
{
    class Program
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        
        static void Main(string[] args)
        {
            using ( SqlConnection sourceConn = new SqlConnection(_cs) )
            {
                SqlCommand cmd = new SqlCommand("select * from GoodsSource", sourceConn);

                sourceConn.Open();

                using ( SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection destConn = new SqlConnection(_cs))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(destConn))
                        {
                            bc.BatchSize = 10000; // розмір пакета передачі в рфдках
                            bc.NotifyAfter = 5000; // кіль рядків для генерації події SqlRowsCopied

                            bc.SqlRowsCopied += (s, evArgs) => Console.WriteLine(evArgs.RowsCopied + " loaded");

                            bc.DestinationTableName = @"GoodsDest";

                            destConn.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }

            }
        }
    }
}
