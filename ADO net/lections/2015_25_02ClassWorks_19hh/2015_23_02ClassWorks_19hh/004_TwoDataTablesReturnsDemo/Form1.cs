using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _004_TwoDataTablesReturnsDemo
{
    internal class Foo
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }

    public partial class Form1 : Form
    {
        private string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();

            SqlConnection conn = new SqlConnection(_cs);
            SqlDataAdapter da = new SqlDataAdapter("spGetData", conn);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();

            da.Fill(ds);

            // dataGridView1.DataSource = ds.Tables["Table"];
            // // dataGridView1.DataMember = ds.Tables["Table"].ToString();
            // 
            // dataGridView2.DataSource = ds.Tables["Table1"];
            // // dataGridView2.DataMember = ds.Tables["Table1"].ToString();

            ds.Tables[0].TableName = "Goods";
            ds.Tables[1].TableName = "Employee";

            List<Foo> list = new List<Foo>();

            list.Add(new Foo { Id = 101, Name = "mike" });
            list.Add(new Foo { Id = 102, Name = "todd" });
            list.Add(new Foo { Id = 103, Name = "john" });
            

            dataGridView1.DataSource = list;
            dataGridView2.DataSource = ds.Tables[1];

        }
    }
}
