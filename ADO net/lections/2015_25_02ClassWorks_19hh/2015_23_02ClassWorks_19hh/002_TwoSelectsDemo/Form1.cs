using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _002_TwoSelectsDemo
{
    public partial class Form1 : Form
    {
        private string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            using (SqlConnection conn = new SqlConnection(_cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Employee select * from Goods", conn);

                conn.Open();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = rdr;
                    dataGridView1.DataSource = source;

                    if(rdr.NextResult())
                    {
                        BindingSource source2 = new BindingSource();
                        source2.DataSource = rdr;
                        dataGridView2.DataSource = source2;
                        
                    }
                }
            }

        }
    }
}
