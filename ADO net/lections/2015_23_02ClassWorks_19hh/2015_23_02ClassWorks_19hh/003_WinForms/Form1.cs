using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace _003_WinForms
{
    public partial class Form1 : Form
    {
        List<string> _names = new List<string>();
        List<double[]> _dataArray = new List<double[]>();

        public Form1()
        {
            InitializeComponent();

            _names.Add("mike");

            _dataArray.Add(new double[]
            {
                1.1,
                1.2,
                1.3
            });

            _names.Add("todd");

            _dataArray.Add(new double[]
            {
                2.2,
                2.4,
                2.5,
                2.9
            });

            object obj = null as object;
            

            dataGridView1.DataSource = GetResultTable();
        }

        public DataTable GetResultTable()
        {
            DataTable t = new DataTable();

            for (int i = 0; i < _names.Count; ++i)
            {
                string name = _names[i];

                t.Columns.Add(name);

                List<object> objectNumbers = _dataArray[i].Cast<object>().ToList();

                while (t.Rows.Count < objectNumbers.Count)
                {
                    t.Rows.Add();
                }

                for (int j = 0; j < objectNumbers.Count; ++j)
                {
                    t.Rows[j][i] = objectNumbers[j];
                }
            }

            return t;
        }
    }
}
