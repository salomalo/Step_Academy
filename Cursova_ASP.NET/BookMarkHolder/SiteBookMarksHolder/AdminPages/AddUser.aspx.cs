using ClassDBAccess;
using SiteBookMarksHolder.Core.Abstract;
using System;

namespace SiteBookMarksHolder.AdminPages
{
    public partial class AddUser : BasePage
    {
        private BookmarkHolder _holder = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            _holder = holder;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            CreateAndSave(txtLogin.Text, txtPassword.Text);           
            Response.Redirect("~/AdminPages/Users.aspx");
        }

        public void CreateAndSave(string log, string pass)
        {
            if (txtLogin.Text != string.Empty && txtPassword.Text != string.Empty)
            _holder.SU(txtLogin.Text, txtPassword.Text); // не працює
           // else            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AdminPages/Users.aspx");
        }

        //protected void btnDelete_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/AdminPages/DeleteUser.aspx");
        //}
    }
}