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
    public partial class UserForm : Form
    {
        /*List<User> _users;*/
        public UserForm(/*List<User> users*/)
        {
            InitializeComponent();
       //     this._users = users;
        }

        public User CreateUser()
        {
            return new User() { Name = tbName.Text, SName = tbSName.Text, Birthday = dtpBirth.Value };
        }

      /*  private void btnOK_Click(object sender, EventArgs e)
        {
            _users.Add(CreateUser());
        }*/
    }
}
