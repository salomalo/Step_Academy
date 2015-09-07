using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Install-Package EntityFramework -Version 6.1.2
namespace add_categories
{
    public partial class Form1 : Form
    {
        List<String> mainCategories;
        List<String> tmpCategories;
        List<String> allCat;

        public Form1()
        {
            InitializeComponent();
            mainCategories = new List<string>();
            tmpCategories = new List<string>();
            allCat = new List<string>();
            LoadCategories();
        }

        public void LoadCategories()
        {
            using (var ctx = new DB_Shop_bud_materEntities())
            {
                var res = ctx.Categorys.Select(cat => new
                {
                    CategoryName = cat.Name,
                    CategoryId = cat.Id,
                    CategoryParentId = cat.ParentId
                });

                foreach (var e in res)
                {
                    allCat.Add(e.CategoryName);
                    if (e.CategoryParentId == null)
                    {
                        mainCategories.Add(e.CategoryName);
                        comboBox1.Items.Add(e.CategoryName);
                    }
                }
            }
            Refresh();
        } // LoadCategories

        private void button1_Click(object sender, EventArgs e)
        {
            mainCategories.Clear();
            comboBox1.Items.Clear();
            using (var ctx = new DB_Shop_bud_materEntities())
            {
                Categorys newMainCat = new Categorys()
                {
                    Name = textBox1.Text,
                    Id = allCat.Count + 1,
                    ParentId = null
                };
                ctx.Categorys.Add(newMainCat);
                ctx.SaveChanges();
            }
            LoadCategories();
            Refresh();
        } // add main Category

		
        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadSubCat();
        } // displayed the subcat


        public void LoadSubCat()
        {
            tmpCategories.Clear();
            comboBox2.Items.Clear();

            string selectCat = comboBox1.SelectedItem.ToString();
            int checkID = 0;

            using (var ctx = new DB_Shop_bud_materEntities())
            {
                var res = ctx.Categorys.Select(cat => new
                {
                    CategoryName = cat.Name,
                    CategoryId = cat.Id,
                    CategoryParentId = cat.ParentId
                });

                foreach (var st in res)
                {
                    if (st.CategoryName == selectCat)
                    {
                        checkID = st.CategoryId;
                    }
                    if (st.CategoryParentId == checkID)
                    {
                        comboBox2.Items.Add(st.CategoryName);
                        tmpCategories.Add(st.CategoryName);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainCategories.Clear();
            comboBox2.Items.Clear();

            string selectCat = comboBox1.SelectedItem.ToString();
            int checkID = 0;

            using (var ctx = new DB_Shop_bud_materEntities())
            {
                var res = ctx.Categorys.Select(cat => new
                {
                    CategoryName = cat.Name,
                    CategoryId = cat.Id,
                    CategoryParentId = cat.ParentId
                });

                foreach (var st in res)
                {
                    if (st.CategoryName == selectCat)
                    {
                        checkID = st.CategoryId;
                    }
                }

                Categorys newSubCat = new Categorys()
                          {
                              Name = textBox2.Text,
                              Id = allCat.Count + 1,
                              ParentId = checkID
                          };

                ctx.Categorys.Add(newSubCat);
                ctx.SaveChanges();
            }

            LoadSubCat();
        } // add sub cat


        public void Refresh()
        {
            using (var ctx = new DB_Shop_bud_materEntities())
            {
                var res = ctx.Categorys.Where(x=>x.ParentId != null).Select(cat => new
                {
                    CategoryName = cat.Name,
                });
                dataGridView1.DataSource = res.ToList();
            }
        }
    }
}
