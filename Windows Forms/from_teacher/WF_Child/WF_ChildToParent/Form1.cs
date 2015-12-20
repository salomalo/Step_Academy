using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_ChildToParent
{
    public partial class Form1 : Form
    {
        private List<User> users;
      //  private UserForm child;
        public Form1()
        {
            InitializeComponent();
            users = new List<User>();            
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            UserForm child = new UserForm(/*users*/);
            if (child.ShowDialog() == DialogResult.OK)
            {
                users.Add(child.CreateUser());
                tbLastUser.Text = users.Last().ToString();
            }
            else
            {
                MessageBox.Show("No user");
            }
         /*   if (users.Count > 0)
            {
                tbLastUser.Text = users.Last().ToString();
            }*/
          //  MessageBox.Show("Alert");
        }
    }
}
