using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace home_UI
{
    public partial class Form1 : Form
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;
        private SqlDataAdapter _da;
        private DataSet _ds = new DataSet();
        private SqlConnection _conn = new SqlConnection(_cs);
        private string _sql;

        public Form1()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e) // load all OutputOrders
        {
            _ds.Clear();
            _sql = "select * from OutputOrders";
            _da = new SqlDataAdapter(_sql, _conn);
            
            _conn.Open();
            
            _da.Fill(_ds, "OutputOrders");
            

            dataGridView1.DataSource = _ds;
            dataGridView1.DataMember = _ds.Tables[0].ToString();

        }

        private void button2_Click(object sender, EventArgs e) // check status for all orders
        {
            //_ds.Clear();
            //_sql = "select * from OutputOrders";
            //_da = new SqlDataAdapter(_sql, _conn);

            //_conn.Open();

            //_da.Fill(_ds, "OutputOrders");


            //dataGridView1.DataSource = _ds;
            //dataGridView1.DataMember = _ds.Tables[0].ToString();




        }




    }
}
