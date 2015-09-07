using System.Data.Entity;

namespace _003_SelfReferencesCodeFirst
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> Employees { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasOptional(e => e.Manager)
                .WithMany()
                .HasForeignKey(m => m.ManagerId);
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
