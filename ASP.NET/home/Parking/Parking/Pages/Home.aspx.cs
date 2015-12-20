using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parking.Pages
{
    public partial class Home : System.Web.UI.Page
    {
        private static List<Cars> carlist = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            carlist = new List<Cars>();
            using (var ctx = new ParkingEntities())
            {
                foreach (Cars c in ctx.Cars)
                {
                    carlist.Add(c);
                }
            }

            if (!IsPostBack)
            {
                dgCustomers.DataSource = carlist;
                dgCustomers.DataBind();
            }       
        }

        protected void btnAddCar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/AddCar.aspx");
        }

        protected void btnDeleteCar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/DeleteCar.aspx");
        }
    }
}