using System.Data.Entity;

namespace _007_TPTcodeFirst
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }

        public EmployeeDbContext() : base("CS") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractEmployee>().ToTable("ContractEmployees");
            modelBuilder.Entity<PermanentEmployee>().ToTable("PermanentEmployees");
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
