using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _003_DataAdapterDemo
{
    public partial class Form1 : Form
    {
        private string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_cs);
            // SqlDataAdapter da = new SqlDataAdapter("select * from Goods", conn);
            // DataSet ds = new DataSet();
            // 
            // da.Fill(ds, "Goods"); // замість open закидує закриває
            // 
            // dataGridView1.DataSource = ds;
            // dataGridView1.DataMember = ds.Tables["Goods"].ToString();

            
            SqlDataAdapter da = new SqlDataAdapter("spGoods", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            
            da.Fill(ds, "Goods"); // замість open закидує закриває
            
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables["Goods"].ToString();

        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            SqlConnection conn = new SqlConnection(_cs);

            SqlDataAdapter da = new SqlDataAdapter("spGoodsById", conn);
            
            
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Id", textBox1.Text);
            DataSet ds = new DataSet();

            da.Fill(ds, "Goods"); // замість open закидує закриває

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables["Goods"].ToString();
        }
    }
}
