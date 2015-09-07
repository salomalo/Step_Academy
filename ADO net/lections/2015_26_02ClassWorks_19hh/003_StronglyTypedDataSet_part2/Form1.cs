using System.Windows.Forms;
using System.Linq;
using _003_StronglyTypedDataSet_part2.StudentDataSetTableAdapters;

namespace _003_StronglyTypedDataSet_part2
{
    public partial class Form1 : Form
    {
        StudentDataSetTableAdapters.StudentsTableAdapter _sta =
            new StudentsTableAdapter();
        StudentDataSet.StudentsDataTable _sdt = 
            new StudentDataSet.StudentsDataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            _sta.Fill(_sdt);
            dataGridView1.DataSource = (from s in _sdt
                select new {s.Id, s.Name, s.Gender, s.TotalMarks}).ToList();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                _sta.Fill(_sdt);
                dataGridView1.DataSource = (from s in _sdt
                    select new {s.Id, s.Name, s.Gender, s.TotalMarks}).ToList();

            }
            else
            {
                _sta.Fill(_sdt);
                dataGridView1.DataSource = (from s in _sdt
                    where s.Name.ToLower().StartsWith(textBox1.Text.ToLower())
                    select new {s.Id, s.Name, s.Gender, s.TotalMarks}).ToList();

            }
        }
    }
}
