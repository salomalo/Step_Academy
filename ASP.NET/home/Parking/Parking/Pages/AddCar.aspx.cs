
using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Parking.Pages
{
    public partial class AddCar : System.Web.UI.Page
    {
        public List<CarModel> CarOnParking;
        protected void Page_Load(object sender, EventArgs e)
        {
            CarOnParking = new List<CarModel>();
        }
        private string GetTextBoxValue(TextBox tb)
        {
            if (tb == null)
                return string.Empty;
            return tb.Text ?? string.Empty;
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            using (var ctx = new ParkingEntities())
            {
                var car = new Cars
                            {
                                OwnerName = GetTextBoxValue(txtName),
                                OwnerSurname = GetTextBoxValue(txtSurname),
                                CarModel = GetTextBoxValue(txtCarModel),
                                CarNumber = GetTextBoxValue(txtCarNumber)
                            };

                // ctx.Cars.InsertOnSubmit(car);
                //ctx.SaveChanges();

                ctx.Cars.Add(car);
                ctx.SaveChanges();
            }

            Response.Redirect("~/Pages/Home.aspx");
        }




        //create database Parking
        //use Parking
        //create table Cars
        //(
        //OwnerName nvarchar(50) not NULL primary key
        //,OwnerSurname nvarchar(50) not NULL
        //,CarModel nvarchar(50) not NULL
        //,CarNumber nvarchar(50) not NULL
        //)

        //select * from Cars


        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }


        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/DeleteCar.aspx");
        }
    }
}