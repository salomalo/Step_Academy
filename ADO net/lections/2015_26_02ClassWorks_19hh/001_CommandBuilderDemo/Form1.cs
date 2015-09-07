using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _001_CommandBuilderDemo
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

        private void button1_Click(object sender, System.EventArgs e)
        {
            _ds.Clear();
            _sql = "select * from Students where id = " + textBox1.Text;
            _da = new SqlDataAdapter(_sql, _conn);
            _da.Fill(_ds, "Students");

            if (_ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = _ds.Tables["Students"].Rows[0];

                textBox2.Text = dr["Name"].ToString();
                textBox3.Text = dr["TotalMarks"].ToString();
                comboBox1.Text = dr["Gender"].ToString().ToLower();

                label5.Text = "";
                label5.ForeColor = Color.Green;
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";

                label5.Text = @"No student with id = " + textBox1.Text;
                label5.ForeColor = Color.Red;
            }
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            SqlCommandBuilder builder = new SqlCommandBuilder();
            builder.DataAdapter = _da; // !!!!!!!!

            label6.Text = builder.GetInsertCommand().CommandText;
            label7.Text = builder.GetUpdateCommand().CommandText;
            label8.Text = builder.GetDeleteCommand().CommandText;


            if (_ds.Tables["Students"].Rows.Count > 0)
            {
                DataRow dr = _ds.Tables["Students"].Rows[0];

                dr["Name"] = textBox2.Text;
                dr["Gender"] = comboBox1.SelectedItem;
                dr["TotalMarks"] = textBox3.Text;
            }

            int rowUpdated = _da.Update(_ds, "Students");

            if (rowUpdated > 0)
            {
                label5.Text = rowUpdated + @" row(s) updated";
                label5.ForeColor = Color.Green;
            }
            else
            {
                label5.Text = @" No row(s) updated";
                label5.ForeColor = Color.Red;
            }
        }
    }
}
