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
    public class DbStore: CustomerStore
    {
        private VisitCardDbContext ctx = VisitCardDbContext.Instance;


        public List<CustomerProfile> GetAll()
        {
            return Customers;
        }

        public void Delete(CustomerProfile profile)
        {
            var custToDelete = ctx.CustomerProfiles.First(c => c.Id == profile.Id);
            ctx.CustomerProfiles.Remove(custToDelete);
            ctx.SaveChanges();
        }

        public override void SaveProfile(CustomerProfile profile)
        {
            ctx.CustomerProfiles.Add(profile);
            ctx.SaveChanges();
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
