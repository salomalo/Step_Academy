using System.Data.Entity;

namespace _002_CodeFirstApproachDemo
{
    public class EmployeeDBContext : DbContext
    {
        public DbSet<Department> Departments { set; get; }
        public DbSet<Employee> Employees { set; get; }
    }
}
