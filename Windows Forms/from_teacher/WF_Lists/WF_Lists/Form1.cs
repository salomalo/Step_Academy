using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Lists
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {           
            foreach (var el in Directory.GetFiles(Directory.GetCurrentDirectory()))
            {
                 listBox1.Items.Add((new FileInfo(el)).Name);
            }

            listBox1.Items.Add(new Person() { Name = "Tom", SName = "Soyer" });
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                foreach (var el in listBox1.SelectedItems)
                {
                    MessageBox.Show(el.ToString());
                }
            }
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems != null)
            {
                foreach (var el in listBox1.SelectedItems)
                {
                    checkedListBox1.Items.Add(el);
                }
              //  Thread.Sleep(2000);
                for(int i = listBox1.SelectedItems.Count-1; i >= 0; i--) 
                {
                    listBox1.Items.Remove(listBox1.SelectedItems[i]);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedText);
        }
    }

    class Person
    {
        public string Name { set; get; }
        public string SName { set; get; }

        public override string ToString()
        {
            return Name + " " + SName;
        }
    }
}
