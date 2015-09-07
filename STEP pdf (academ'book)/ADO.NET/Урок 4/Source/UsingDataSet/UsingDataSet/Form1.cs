using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UsingDataSet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Load_Click(object sender, EventArgs e)
        {
            try
            {
                
                //Загружаем данные в DataSet
                dataSet1.ReadXml("..\\..\\1.xml");
                //Привяка данных из DataSet к DataGridView
                dataGridView1.DataSource = dataSet1.Tables[0];
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
                
        }
    }
}
