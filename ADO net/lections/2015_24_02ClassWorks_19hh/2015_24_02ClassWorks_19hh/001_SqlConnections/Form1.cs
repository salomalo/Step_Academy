using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _001_SqlConnections
{
    public partial class Form1 : Form
    {
        private string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            // SqlConnection conn = new SqlConnection(_cs);
            
            // SqlCommand cmd = new SqlCommand("select * from Workers", conn);
            // 
            // conn.Open();
            // 
            // BindingSource source = new BindingSource
            // {
            //     DataSource = cmd.ExecuteReader()
            // };
            // 
            // dataGridView1.DataSource = source;
            // 
            // conn.Close();


            // - Варіант щоб краще дебажити (c)
            // try
            // {
            //     SqlCommand cmd = new SqlCommand("select * from Workers", conn);
            //     conn.Open();
            // 
            //     BindingSource source = new BindingSource
            //     {
            //         DataSource = cmd.ExecuteReader()
            //     };
            // 
            //     dataGridView1.DataSource = source;
            // }
            // catch (Exception e)
            // {
            //     MessageBox.Show(e.Message);
            // }
            // finally
            // {
            //     conn.Close();
            // }


            using (SqlConnection conn = new SqlConnection(_cs))
            {
                SqlCommand cmd = new SqlCommand("select * from Workers", conn);
                BindingSource source = new BindingSource();

                conn.Open();
                source.DataSource = cmd.ExecuteReader();
                dataGridView1.DataSource = source;
            }
        }
    }
}
