namespace _003_SelfReferencesCodeFirst
{
    public class Employee
    {
        // Scalar properties
        public int Id { set; get; }
        public string Name { set; get; }
        public int? ManagerId { set; get; }

        // Navigation property
        public Employee Manager { set; get; }
    }
}
