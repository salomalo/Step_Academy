using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _004_Transactions
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

        private void GetData()
        {
            _ds.Clear();
            _sql = "select * from Accounts";
            _da = new SqlDataAdapter(_sql, _conn);
            _da.Fill(_ds);
            dataGridView1.DataSource = _ds.Tables[0];
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            GetData();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            _conn.Open();
            SqlTransaction transaction = _conn.BeginTransaction();

            try
            {
                
                _sql = "update Accounts set Balance -= 10 where AccountNumber = 'acc101'";
                SqlCommand cmd = new SqlCommand(_sql, _conn, transaction);
                cmd.ExecuteNonQuery();

                _sql = "update Accounts1 set Balance += 10 where AccountNumber = 'acc102'";
                cmd = new SqlCommand(_sql, _conn, transaction);
                cmd.ExecuteNonQuery();

                transaction.Commit();
                label1.Font = new Font(label1.Font, FontStyle.Bold);
                label1.ForeColor = Color.Green;
                label1.Text = @"Transaction Successful";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                label1.ForeColor = Color.Red;
                label1.Text = @"Transaction Failed";

                MessageBox.Show(ex.Message);
            }
            finally
            {
                _conn.Close();
            }

            GetData();
        }

    }
}
