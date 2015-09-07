using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace TableToClass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        private void Filter_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 f = new Form2();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExampleDatabase db = new ExampleDatabase(Form2.StrConnect);

                    var q = from item in db.Country
                            where item.CountryName.Contains("о")
                            select new
                            {
                                Id = item.Id,
                                CountryName = item.CountryName,
                                Square = item.Square
                            };

                    dataGridView1.DataSource = q.ToList();
                    
                   
                }
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }

        private void ShowAll_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 f = new Form2();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ExampleDatabase db = new ExampleDatabase(Form2.StrConnect);

                    var q = from item in db.Country
                            select new
                            {
                                Id = item.Id,
                                CountryName = item.CountryName,
                                Square = item.Square
                            };

                    dataGridView1.DataSource = q.ToList();
                    
                    
                }
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
    }
}
