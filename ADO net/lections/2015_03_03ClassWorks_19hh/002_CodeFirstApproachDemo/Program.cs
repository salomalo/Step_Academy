namespace _002_CodeFirstApproachDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var  ctx = new EmployeeDBContext())
            {
                var newDepartment = new Department()
                {
                    Id = 1,
                    Name = "IT",
                    Location = "Rivne"
                };

                ctx.Departments.Add(newDepartment);
                ctx.SaveChanges();
            }
        }
    }
}
