using _03_VisitCardViewer.Core.Abstract;
using _03_VisitCardViewer.Core.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _03_VisitCardViewer.Pages
{
    public partial class Home : BasePage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                dgCustomers.DataSource = store.Customers;
                dgCustomers.DataBind();
            }
        }

        protected void btnRegisterCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/RegisterCard.aspx");
        }
    }
}