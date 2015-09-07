using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
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
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("select Id, Name, Gender, Salary from Employee", conn);
                //SqlCommand cmd = new SqlCommand("select Id, Name, Gender, Salary, (Salary * 0.1) as 'Tax' from Employee", conn);
                BindingSource source = new BindingSource();

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    SqlDataReader rdr3 = new SqlDataReader();

                    DataTable table = new DataTable();
                    
                    table.Columns.Add("Id");
                    table.Columns.Add("Name");
                    table.Columns.Add("Gender");
                    table.Columns.Add("Salary");
                    table.Columns.Add("Tax");
                    
                    while (rdr.Read())
                    {
                        DataRow dataRow = table.NewRow();
                        double tax = Convert.ToDouble(rdr["Salary"]) * 0.1;
                    
                        dataRow["Id"] = rdr["Id"];
                        dataRow["Name"] = rdr["Name"];
                        dataRow["Gender"] = rdr["Gender"];
                        dataRow["Salary"] = rdr["Salary"];
                        dataRow["Tax"] = tax;
                    
                        table.Rows.Add(dataRow);
                    }
                    source.DataSource = table;
                    dataGridView1.DataSource = source;

                    // source.DataSource = rdr;
                    // dataGridView1.DataSource = source;
                }
            }
        }
    }
}
