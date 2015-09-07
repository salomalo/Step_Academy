using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _003_SqlInjectionDemo
{
    public partial class Form1 : Form
    {
        private string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            {

                BindingSource source = new BindingSource();
                SqlCommand cmd = new SqlCommand("spGetGoodsByName", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@search", textBox1.Text + "%");

                conn.Open();
                
                source.DataSource = cmd.ExecuteReader();
                dataGridView1.DataSource = source;


                // // @searchStr буде переведено в параметр  (c)
                // string sql = @"select * from Goods where title like @searchStr";
                // BindingSource source = new BindingSource();
                // SqlCommand cmd = new SqlCommand(sql, conn);
                // cmd.Parameters.AddWithValue("@searchStr", textBox1.Text + "%"); // доданий параметр ))))
                // 
                // conn.Open();
                // 
                // source.DataSource = cmd.ExecuteReader();
                // dataGridView1.DataSource = source;


                // bad variant (((
                // string sql = @"select * from Goods where title like '" + textBox1.Text + "%'";
                // //string sql = @"select * from Goods";
                // BindingSource source = new BindingSource();
                // SqlCommand cmd = new SqlCommand(sql, conn);
                // 
                // conn.Open();
                // 
                // source.DataSource = cmd.ExecuteReader();
                // dataGridView1.DataSource = source;
            }
        }
    }
}
