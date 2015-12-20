using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary2
{
    public class Class1
    {
        public  void btnSave_Click(object sender, EventArgs e)
        {
            using (var ctx = new ParkingEntities())
            {
                var car = new Cars
                            {
                                //OwnerName = GetTextBoxValue(txtName),
                                //OwnerSurname = GetTextBoxValue(txtSurname),
                                //CarModel = GetTextBoxValue(txtCarModel),
                                //CarNumber = GetTextBoxValue(txtCarNumber)
                            };

                //ctx.Cars.InsertOnSubmit(car);
                ctx.SaveChanges();

                //ctx.Cars.Add(car);
                ctx.SaveChanges();
            }  
        }
    }
}