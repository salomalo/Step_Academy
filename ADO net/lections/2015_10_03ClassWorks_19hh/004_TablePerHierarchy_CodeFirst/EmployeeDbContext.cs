using System.Data.Entity;

namespace _005_TablePerHierarchy_CodeFirst
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }

        public EmployeeDbContext() : base("CS") { }
    }
}
