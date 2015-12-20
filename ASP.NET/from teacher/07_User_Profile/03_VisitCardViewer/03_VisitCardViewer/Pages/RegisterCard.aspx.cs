using _03_VisitCardViewer.Core.Abstract;
using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.Pages
{
    public partial class RegisterCard : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        private string GetTextBoxValue(TextBox tb)
        {
            if (tb == null)
                return string.Empty;
            return tb.Text ?? string.Empty;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //var model = new VisitCardModel
            //{
            //    Name = GetTextBoxValue(txtName),
            //    Surname = GetTextBoxValue(txtSurname),
            //    Email = GetTextBoxValue(txtEmail),
            //    Phone = GetTextBoxValue(txtPhone),
            //    Profession = GetTextBoxValue(txtProfession)
            //};

            //store.Save(model);
            //Response.Redirect("~/Pages/Home.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }
    }
}