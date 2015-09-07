using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPLIT_Entity
{
    public class Context: DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customers>()
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Phone
                    });
                    map.ToTable("Customers");
                })
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.Id,
                        p.Address,
                        p.Mobile,
                        p.Email,
                        p.JurAddress
                    });
                    map.ToTable("CustomerDetail");
                });

            base.OnModelCreating(modelBuilder);
        }

    }
}
