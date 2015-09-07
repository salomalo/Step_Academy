using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProceduresDemo
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Department> Departments { set; get; }


        public EmployeeDBContext()
            : base("CS")
        {
            Database.SetInitializer<EmployeeDBContext>(new DropCreateDatabaseAlways<EmployeeDBContext>());
        }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 1. base stage
            //modelBuilder.Entity<Employee>().MapToStoredProcedures();
            //modelBuilder.Entity<Department>().MapToStoredProcedures();
            
            // 2. Overloading stored procedures
            // modelBuilder.Entity<Employee>().MapToStoredProcedures(p => p.Insert(x => x.HasName("spInsertEmployee")));
            // modelBuilder.Entity<Employee>().MapToStoredProcedures(p => p.Delete(x => x.HasName("spDeleteEmployee")));
            // modelBuilder.Entity<Employee>().MapToStoredProcedures(p => p.Update(x => x.HasName("spUpdateEmployee")));

            // or

            modelBuilder.Entity<Employee>().MapToStoredProcedures(
                    p => p.Insert(x => x.HasName("spInsertEmployee2")
                                .Parameter(n => n.Name, "EmployeeName")
                                .Parameter(n => n.Salary, "EmployeeSalary")
                                .Parameter(n => n.Gender, "EmployeeGender"))
                          .Update(x => x.HasName("spUpdateEmployee2"))
                          .Delete(x => x.HasName("spDeleteEmployee2")
                              .Parameter(n => n.Id, "EmployeeId"))
                );


            base.OnModelCreating(modelBuilder);
        }
    }
}
