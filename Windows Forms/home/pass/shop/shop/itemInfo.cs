using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shop
{
    public partial class itemInfo : Form
    {
        Item tmp ;
        public itemInfo()
        {
            InitializeComponent();
            tmp = new Item();
        }

        public itemInfo(Item i)
        {
            InitializeComponent();
            tmp = i;
            txTitle.Text = i.Title;
            txPrice.Text = i.Price.ToString();
        }

        private void itemInfo_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            tmp.Title = txTitle.Text;
            tmp.Price = Convert.ToDouble(txPrice.Text);

        }

        public Item CreateItem()
        {
            return tmp;
        }


        public Item EditItem(Item i)
        {
            //i.Title = txTitle.Text;
            //i.Price = Convert.ToDouble(txPrice.Text);
            
            return i;
        }




    }
}