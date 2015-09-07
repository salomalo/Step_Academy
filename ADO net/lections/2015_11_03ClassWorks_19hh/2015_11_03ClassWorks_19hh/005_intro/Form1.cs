using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _005_intro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            DataClasses1DataContext ctx = new DataClasses1DataContext();

            dataGridView1.DataSource = from student in ctx.Students
                                       //where student.Gender == "female"
                                       select student;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
