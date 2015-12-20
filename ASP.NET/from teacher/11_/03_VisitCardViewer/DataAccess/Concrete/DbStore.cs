using DataAccess.Abstract;
using DataModel;
using DataModel.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class DbStore : CustomerStore
    {
        private VisitCardDbContext ctx = VisitCardDbContext.Instance;


        public List<CustomerProfile> GetAll()
        {
            return Customers;
        }

        public CustomerProfile GetCustomerById(int id)
        {
            if (id == -1)
                return new CustomerProfile();
            return ctx.CustomerProfiles.First(c => c.Id == id);
        }

        public void EditProfile(CustomerProfile profile)
        {
            var custToEdit = ctx.CustomerProfiles.First(c => c.Id == profile.Id);
            custToEdit.Login = profile.Login;
            custToEdit.Name = profile.Name;
            custToEdit.Password = profile.Password;
            custToEdit.Phone = profile.Phone;
            custToEdit.Profession = profile.Profession;
            custToEdit.Surname = profile.Surname;
            custToEdit.Birthday = profile.Birthday;
            custToEdit.Email = profile.Email;

            ctx.Entry<CustomerProfile>(custToEdit).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

        public void Delete(CustomerProfile profile)
        {
            var custToDelete = ctx.CustomerProfiles.First(c => c.Id == profile.Id);
            ctx.CustomerProfiles.Remove(custToDelete);
            ctx.SaveChanges();
        }

        public override void SaveProfile(CustomerProfile profile)
        {
            try
            {
                ctx.CustomerProfiles.Add(profile);
                ctx.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public override void SaveVisitCard(VisitCardModel card)
        {
            ctx.VisitCards.Add(card);
            ctx.SaveChanges();
        }

        public override List<CustomerProfile> Customers
        {
            get
            {
                return ctx.CustomerProfiles.ToList();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
