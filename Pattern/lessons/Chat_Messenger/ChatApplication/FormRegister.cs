using ChatApplication.ServiceAuthNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatApplication
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }


        /// <summary>
        /// check
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReg_Click(object sender, EventArgs e)
        {
            AuthClient ac = new AuthClient();
            if (tbUserName.Text != "" && tbPass.Text != "" && tbFN.Text != "" && tbLN.Text != "")
            {
               // string res = await ac.RegisterAsync(tbUserName.Text, tbPass.Text, tbFN.Text, tbLN.Text);
                string res = "Good";
                if (res == "Good")
                {
                    ac.Register(tbUserName.Text, tbPass.Text, tbFN.Text, tbLN.Text);
                    MessageBox.Show("cool");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Login Exist");
                }
            }
            else
            {
                MessageBox.Show("not all fields");
            }
            ac.Close();         
        }
    }
}