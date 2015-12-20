using ClassDBAccess;
using ClassDBModel;
using SiteBookMarksHolder.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteBookMarksHolder.AdminPages
{
    public partial class UsersPage : BasePage
    {
        private static BookmarkHolder staticHolder = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            staticHolder = holder;
            if (!IsPostBack)
            {
                dgUsers.DataSource = holder.UsersList;
                dgUsers.DataBind();
            }
        }

        protected void btnAddUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddUser.aspx");
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteUser.aspx");
        }
    }
}