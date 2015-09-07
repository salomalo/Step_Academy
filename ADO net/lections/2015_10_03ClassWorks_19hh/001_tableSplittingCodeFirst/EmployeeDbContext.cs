using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_tableSplittingCodeFirst
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }
        public DbSet<EmployeeDetails> EmployeeDetails { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(pk => pk.Id)
                .ToTable("Employees");

            modelBuilder.Entity<EmployeeDetails>()
                .HasKey(pk => pk.Id)
                .ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasRequired(p => p.EmployeeDetails)
                .WithRequiredPrincipal(c => c.Employee);


            base.OnModelCreating(modelBuilder);
        }
    }
}
