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
    public partial class Form1 : Form
    {  
        public List <Item> listItems;
        public double Price { set; get;}


        public Form1()
        {
            InitializeComponent();
            listItems = new List<Item>();
            Price = 0;
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            itemInfo f = new itemInfo();
            if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                listItems.Add(f.CreateItem());
                cbListItems.Items.Add(f.CreateItem().Title);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int ind = cbListItems.SelectedIndex;
            itemInfo f2 = new itemInfo(listItems[ind]);

            if (f2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cbListItems.Items[ind] = listItems[ind].Title;
            }

        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            int ind = cbListItems.SelectedIndex;
            listCart.Items.Add(listItems[ind].Title);

            Price += listItems[ind].Price;
            txPrice.Text = Price.ToString();
        }

        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
           int ind = listCart.SelectedIndex;
           
            for(int i=0; i<listItems.Count; i++)
            {
                if(listCart.Items[ind] == listItems[i].Title)
                {
                    Price -= listItems[i].Price;
                    
                }
            }

            listCart.Items.RemoveAt(ind);
            txPrice.Text = Price.ToString();

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }






    }
}