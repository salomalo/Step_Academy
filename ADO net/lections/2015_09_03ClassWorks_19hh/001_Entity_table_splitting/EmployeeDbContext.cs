using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_Entity_table_splitting
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Employee>()
                .Map(map =>
                {
                    map.Properties(p => new
                    {
                        p.Id,
                        p.Name,
                        p.Gender,
                        p.JobTitle
                    });

                    map.ToTable("Employees");
                })
                .Map(map =>
                {
                    map.Properties(p => new
                        {
                            p.Id,
                            p.Email,
                            p.Phone,
                            p.Salary
                        });
                    map.ToTable("EmployeeDetails");
                });

            base.OnModelCreating(modelBuilder);
        }
         */
    }
}
