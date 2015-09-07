using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _002_CopyTableToAnother
{
    public partial class Form1 : Form
    {
        private static string _sourceCS = ConfigurationManager.ConnectionStrings["sourceCS"].ConnectionString;
        private static string _destCS = ConfigurationManager.ConnectionStrings["destCS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            // ствоення source connection
            using ( SqlConnection sourceConn =  new SqlConnection(_sourceCS))
            {
                SqlCommand cmd = new SqlCommand("select * from Departments", sourceConn);

                sourceConn.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    // ствоення dest connection
                    using (SqlConnection destConn = new SqlConnection(_destCS))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(destConn))
                        {
                            bc.DestinationTableName = "Departments";

                            destConn.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }

                cmd = new SqlCommand("select * from Employees", sourceConn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    using (SqlConnection destConn = new SqlConnection(_destCS))
                    {
                        using (SqlBulkCopy bc = new SqlBulkCopy(destConn))
                        {
                            bc.DestinationTableName = "Employees";

                            destConn.Open();
                            bc.WriteToServer(rdr);
                        }
                    }
                }

                button1.Enabled = false;
                label1.Text = @"Done!";
            }
        }
    }
}
