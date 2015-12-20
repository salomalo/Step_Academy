using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DM = DataModel;

namespace _03_VisitCardViewer.CustomerProfile
{
    public partial class EditCustomerProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // fvEditCustomer.FindControl("txtName"); to access txtName textbox from formwview
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CustomerProfile/CustomerList.aspx");
        }

        private string GetValueFromTextbox(string id)
        {
            var tb = fvEditCustomer.FindControl(id) as TextBox;
            return (tb != null) ? tb.Text : string.Empty;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DM.CustomerProfile profile = new DM.CustomerProfile
            {
                Id = Convert.ToInt32(Request.QueryString["Id"]),
                Birthday = DateTime.Parse(GetValueFromTextbox("txtBirthday").Split(' ')[0].Replace('.', '/')),
                Email = GetValueFromTextbox("txtEmail"),
                Login = GetValueFromTextbox("txtLogin"),
                Name = GetValueFromTextbox("txtName"),
                Password = GetValueFromTextbox("txtPassword"),
                Phone = GetValueFromTextbox("txtPhone"),
                Profession = GetValueFromTextbox("txtProfession"),
                Surname = GetValueFromTextbox("txtSurname")
            };

            DbStore store = new DbStore();
            store.EditProfile(profile);
            Response.Redirect("~/CustomerProfile/CustomerList.aspx");
        }
    }

}