using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataTable_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTable human = dataSet1.Tables.Add("Human");

        }

        private void Save_Click(object sender, EventArgs e)
        {

        }
    }
}
