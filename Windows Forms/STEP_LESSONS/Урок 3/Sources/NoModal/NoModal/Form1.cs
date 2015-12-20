using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NoModal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 form=null;
        private void button1_Click(object sender, EventArgs e)
        {
            /*если одна форма уже открыта, сначала закроем ее, 
            прежде чем открывать следующую*/
            if (form != null) form.Close();  
            form = new Form2();
            form.Show();
        }
    }
}
