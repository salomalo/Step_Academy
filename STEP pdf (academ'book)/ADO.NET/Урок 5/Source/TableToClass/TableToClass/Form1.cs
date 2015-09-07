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
                            select item;

                    listView1.Clear();
                    
                    listView1.View = View.Details;
                    listView1.Columns.Add("Number");
                    listView1.Columns.Add("Country_Name");
                    listView1.Columns.Add("Square");
                    foreach (var item in q)
                    {
                        ListViewItem it = listView1.Items.Add(item.Id.ToString());
                        it.SubItems.Add(item.CountryName);
                        it.SubItems.Add(item.Square.ToString());
                      
                    }
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
                            select item;

                    listView1.Clear();

                    listView1.View = View.Details;
                    listView1.Columns.Add("Number");
                    listView1.Columns.Add("Country_Name");
                    listView1.Columns.Add("Square");
                    foreach (var item in q)
                    {
                        ListViewItem it = listView1.Items.Add(item.Id.ToString());
                        it.SubItems.Add(item.CountryName);
                        it.SubItems.Add(item.Square.ToString());

                    }
                }
            }
            catch (System.Exception e1)
            {
                MessageBox.Show(e1.Message);
            }

        }
    }
}
