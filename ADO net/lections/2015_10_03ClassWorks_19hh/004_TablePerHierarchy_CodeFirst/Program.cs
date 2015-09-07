namespace _005_TablePerHierarchy_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new EmployeeDbContext())
            {
                // ctx.Entry(new PermanentEmployee()).State =
                //     System.Data.Entity.EntityState.Unchanged;

                Employee emp1 = new PermanentEmployee() { 
                    Name = "mike",
                    Gender = "male",
                    AnnualSalary = 70000
                };

                ctx.Employees.Add(emp1);

                Employee emp2 = new ContractEmployee() { 
                    Name = "leo",
                    Gender = "female",
                    HoursWorked = 2,
                    HourlyPay = 100
                };

                ctx.Employees.Add(emp2);

                ctx.SaveChanges();
            }
        }
    }
}
