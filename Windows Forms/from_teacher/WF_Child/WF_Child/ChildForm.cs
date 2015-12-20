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
    public partial class ChildForm : Form
    {
        public String UserName
        {
            set
            {
                label2.Text = value;
            }
        }
        public ChildForm(/*String name*/)
        {
            InitializeComponent();
           // label2.Text = name;
        }

        public DialogResult ShowDialog(String name)
        {
            label2.Text = name;
            return ShowDialog();
        }
    }
}
