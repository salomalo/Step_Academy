using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Child
{
    public partial class Form1 : Form
    {
        ChildForm child;
        public Form1()
        {
            InitializeComponent();
            child = new ChildForm(/*textBox1.Text*/);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
         //   ChildForm child = new ChildForm(textBox1.Text);  //1 - передаємо дані в конструктор 
           // ChildForm child = new ChildForm();
           // child.UserName = textBox1.Text;    // 2 - створюємо в дочірній формі властивість або метод
          //  child.ShowDialog();
            child.ShowDialog(textBox1.Text); // 3 - перевантажити метод ShowDialog
        }
    }
}
