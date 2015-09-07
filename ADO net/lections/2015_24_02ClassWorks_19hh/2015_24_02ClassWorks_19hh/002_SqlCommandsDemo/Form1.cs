using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _002_SqlCommandsDemo
{
    public partial class Form1 : Form
    {
        private string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            using ( SqlConnection conn = new SqlConnection(_cs) )
            {
                // // --== ExecuteNonQUery ==--
                // // Insert, Update, Delete
                // string sql = @"insert into Workers values ('Test2', '(050)550-50-50', 27)";
                // SqlCommand cmd = new SqlCommand(sql, conn);
                // 
                // conn.Open();
                // //int totalRowAffected = cmd.ExecuteNonQuery();
                // cmd.ExecuteNonQuery();
                // //MessageBox.Show(@"Total rows " + totalRowAffected);


                // --== ExecuteScalar ==--
                string sql = @"select count(id) from Workers";
                SqlCommand cmd = new SqlCommand(sql, conn);

                conn.Open();
                var res = (int) cmd.ExecuteScalar();
                Text = @"Total rows " + res;
            }
        }
    }
}
