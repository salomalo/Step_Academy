using _03_VisitCardViewer.Core.Abstract;
using System;

namespace _03_VisitCardViewer.Pages
{
    public partial class Home : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgCustomers.DataSource = store.Cars;
                dgCustomers.DataBind();
            }            
        }

        protected void btnRegisterCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/RegisterCard.aspx");
        }


        protected void btnDeleteCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/DeleteCarPage.aspx");
        }



    }
}