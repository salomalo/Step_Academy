using System.ComponentModel.DataAnnotations.Schema;

namespace _007_TPTcodeFirst
{
    // [Table("Employees")]
    public class Employee
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Gender { set; get; }
    }
}
