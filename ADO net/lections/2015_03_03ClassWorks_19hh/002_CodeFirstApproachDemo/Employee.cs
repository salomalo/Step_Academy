namespace _002_CodeFirstApproachDemo
{
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
        public int Salary { set; get; }

        public Department Department { set; get; }
    }
}
