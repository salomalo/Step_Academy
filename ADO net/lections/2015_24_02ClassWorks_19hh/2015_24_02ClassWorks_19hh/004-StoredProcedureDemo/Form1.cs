using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _004_StoredProcedureDemo
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
                SqlCommand cmd = new SqlCommand("spAddEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Gender", comboBox1.SelectedItem); // !!!
                cmd.Parameters.AddWithValue("@Salary", textBox2.Text);

                SqlParameter output = new SqlParameter
                {
                    ParameterName = "@EmployeeId",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(output);

                conn.Open();
                // cmd.ExecuteNonQuery();
                cmd.ExecuteReader();

                label4.Text = @"Id : " + output.Value + @" was added";
            }
        }
    }
}
