using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _005_CachingDemo
{
    public partial class Form1 : Form
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        private SqlDataAdapter _da;
        private DataSet _ds = new DataSet();
        SqlConnection _conn = new SqlConnection(_cs);

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (_da == null)
            {
                _da = new SqlDataAdapter("select * from Goods", _conn);
                _ds.Clear();

                _da.Fill(_ds);
                label1.Text = @"Data loaded from Database";
            }
            else
            {
                label1.Text = @"Data loaded from the Cache";
            }

            dataGridView1.DataSource = _ds.Tables[0];
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            if (_da != null)
            {
                _da = null;
                label1.Text = @"DataSet is removed from the Cache";
            }
            else
            {
                label1.Text = @"There is nothins in the Cache to be removed";
            }
        }
    }
}
