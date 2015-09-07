using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace _002_DisconnectedDataAccessDemo
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
            // --== update ==--
            _sql = "update Students set Name = @Name, Gender = @Gender, TotalMarks = @TotalMarks where id = @Id";
            SqlCommand updateCmd = new SqlCommand(_sql, _conn);
            updateCmd.Parameters.Add("@Name", SqlDbType.NVarChar, 64, "Name");
            updateCmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 16, "Gender");
            updateCmd.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            updateCmd.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
            
            // --== insert ==--
            _sql = "insert into Students values (@Name, @Gender, @TotalMarks)";
            SqlCommand insertCmd = new SqlCommand(_sql, _conn);
            insertCmd.Parameters.Add("@Name", SqlDbType.NVarChar, 64, "Name");
            insertCmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 16, "Gender");
            insertCmd.Parameters.Add("@TotalMarks", SqlDbType.Int, 0, "TotalMarks");
            
            // --== delete ==--
            _sql = "delete from Students where Id = @Id";
            SqlCommand deleteCmd = new SqlCommand(_sql, _conn);
            deleteCmd.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");

            _da.UpdateCommand = updateCmd;
            _da.InsertCommand = insertCmd;
            _da.DeleteCommand = deleteCmd;

            _da.Update(_ds, "Students");

            lblMessage.Text = @"Database Updated";
            lblMessage.ForeColor = Color.Green;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _sql = "select * from Students";
            _da = new SqlDataAdapter(_sql, _conn);
            _da.Fill(_ds, "Students");
            dataGridView1.DataSource = _ds.Tables["Students"];
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            textBox1.Clear();

            foreach (DataRow dr in _ds.Tables["Students"].Rows)
            {
                // textBox1.Text += dr["Id"] + @" - " + dr.RowState; //  + "\r\n"
                // textBox1.Text += Environment.NewLine;

                //if (dr.RowState == DataRowState.Deleted)
                //{
                    textBox1.Text += dr["Id", DataRowVersion.Original] + @" - " + dr.RowState; //  + "\r\n"
                    textBox1.Text += Environment.NewLine;
                // }
                // else
                // {
                //     textBox1.Text += dr["Id"] + @" - " + dr.RowState; //  + "\r\n"
                //     textBox1.Text += Environment.NewLine;
                // }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           //  MessageBox.Show("!!");
            if (_ds.HasChanges())
            {
                _ds.RejectChanges();

                lblMessage.Text = @"Changes Undone";
                lblMessage.ForeColor = Color.Green;
                dataGridView1.DataSource = _ds.Tables[0];
            }
            else
            {
                lblMessage.Text = @"No Changes to Undo";
                lblMessage.ForeColor = Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            _ds.AcceptChanges();
            lblMessage.Text = @"Changes were accepted";
            lblMessage.ForeColor = Color.Green;
        }
    }
}
