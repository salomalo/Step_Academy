using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _004_ConnectionDemo
{
    public partial class Form1 : Form
    {
        string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        
        public Form1()
        {
            InitializeComponent();

            // SqlConnection conn = new SqlConnection(_cs);
            // SqlCommand cmd = new SqlCommand("select * from Workers", conn);

            // try
            // {
            //     conn.Open();
            // 
            //     BindingSource source = new BindingSource();
            //     source.DataSource = cmd.ExecuteReader();
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

                conn.Open();
                
                BindingSource source = new BindingSource();
                source.DataSource = cmd.ExecuteReader();
                dataGridView1.DataSource = source;
            }

        }
    }
}
