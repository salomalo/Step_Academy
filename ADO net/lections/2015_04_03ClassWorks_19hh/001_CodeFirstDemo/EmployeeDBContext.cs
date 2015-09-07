using System.Collections.Generic;
using System.Data.Entity;

namespace _001_CodeFirstDemo
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
            : base("CS")
        {
            // Database.SetInitializer<EmployeeDBContext>(new DropCreateDatabaseIfModelChanges<EmployeeDBContext>());

            // Database.SetInitializer<EmployeeDBContext>(new DropCreateDatabaseAlways<EmployeeDBContext>());
            Database.SetInitializer<EmployeeDBContext>(new EmployeeDBInitializer());

        }

        public DbSet<Employee> Employees { set; get; }
        public DbSet<Department> Departments { set; get; }
    }

    public class EmployeeDBInitializer : DropCreateDatabaseIfModelChanges<EmployeeDBContext>
        //CreateDatabaseIfNotExists<EmployeeDBContext>
    {

        protected override void Seed(EmployeeDBContext context)
        {
            Department department1 = new Department()
            {
                Name = "IT",
                Location = "Rivne",
                Employees = new List<Employee>()
                {
                    new Employee () {
                        Name = "mike",
                        Gender = "male",
                        Salary = 6000,
                        JobTitle = "developer"
                    },
                    new Employee () {
                        Name = "todd",
                        Gender = "male",
                        Salary = 6500,
                        JobTitle = "developer"

                    },
                    new Employee () {
                        Name = "john",
                        Gender = "male",
                        Salary = 6900,
                        JobTitle = "developer"

                    }
                }
            };
            Department department2 = new Department()
            {
                Name = "HR",
                Location = "Lviv",
                Employees = new List<Employee>()
                {
                    new Employee () {
                        Name = "mike2",
                        Gender = "male2",
                        Salary = 7700,
                        JobTitle = "rectruiter"

                    },
                    new Employee () {
                        Name = "todd2",
                        Gender = "male2",
                        Salary = 10000,
                        JobTitle = "rectruiter"

                    }
                }
            };

            context.Departments.Add(department1);
            context.Departments.Add(department2);

            base.Seed(context);
        }
    }
}
