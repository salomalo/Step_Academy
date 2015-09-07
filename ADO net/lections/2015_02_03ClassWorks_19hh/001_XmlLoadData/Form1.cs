using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _001_XmlLoadData
{

    public partial class Form1 : Form
    {
        private static string _cs = ConfigurationManager.ConnectionStrings["CS"].ConnectionString;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(_cs))
            {
                conn.Open();

                DataSet ds = new DataSet();
                ds.ReadXml("XMLData.xml");

                DataTable dtDepartments = ds.Tables["Department"];
                DataTable dtEmployees = ds.Tables["Employee"];

                using (SqlBulkCopy bc = new SqlBulkCopy(conn))
                {
                    // column mapping
                    bc.DestinationTableName = "Departments";

                    bc.ColumnMappings.Add("Id", "Id");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Location", "Location");

                    bc.WriteToServer(dtDepartments);
                }

                using (SqlBulkCopy bc = new SqlBulkCopy(conn))
                {
                    bc.DestinationTableName = "Employees";
                    bc.ColumnMappings.Add("Id", "Id");
                    bc.ColumnMappings.Add("Name", "Name");
                    bc.ColumnMappings.Add("Gender", "Gender");
                    bc.ColumnMappings.Add("DepartmentId", "DepartmentId");

                    bc.WriteToServer(dtEmployees);
                }
            }

            label1.Text = @"data has been copied";
            button1.Enabled = false;
        }
    }
}
