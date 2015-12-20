using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.Contexts
{
    public class VisitCardDbContext: DbContext
    {
        public VisitCardDbContext():base("defaultConn")
        {
            Database.SetInitializer<VisitCardDbContext>(null);
        }

        public DbSet<CustomerInfo> CustomerInfoes { get; set; }
        public DbSet<VisitCardModel> VisitCards { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
    }
}
