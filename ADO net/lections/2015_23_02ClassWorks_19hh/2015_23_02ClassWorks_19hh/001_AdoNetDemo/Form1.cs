// http://www.connectionstrings.com/mysql/
// https://www.jetbrains.com/resharper/

using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _001_AdoNetDemo
{
    public partial class Form1 : Form
    {
        string _cs = @"Server=localhost;database=zorinDB;Uid=root;Pwd=";

        public Form1()
        {
            InitializeComponent();

            var conn = new MySqlConnection(_cs);
            var cmd = new MySqlCommand("select * from Workers", conn);

            conn.Open();

            DataSet ds = new DataSet();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();

            conn.Close();
        }
    }
}
