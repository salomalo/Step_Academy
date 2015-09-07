using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace _003_StronglyTypedDataSet
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

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _sql = "select * from Students";
            _da = new SqlDataAdapter(_sql, _conn);
            _da.Fill(_ds);

            dataGridView1.DataSource = (from dr in _ds.Tables[0].AsEnumerable()
                select new Student
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = dr["Name"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    TotalMarks = Convert.ToInt32(dr["TotalMarks"])
                }).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                dataGridView1.DataSource = (from dr in _ds.Tables[0].AsEnumerable()
                    select new Student
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        TotalMarks = Convert.ToInt32(dr["TotalMarks"])
                    }).ToList();
            }
            else
            {
                dataGridView1.DataSource = (from dr in _ds.Tables[0].AsEnumerable()
                    where dr["Name"].ToString().ToLower().StartsWith(textBox1.Text.ToLower())
                    select new Student
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Gender = dr["Gender"].ToString(),
                        TotalMarks = Convert.ToInt32(dr["TotalMarks"])
                    }).ToList();
            }
        }
    }
}
