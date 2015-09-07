using System.ComponentModel.DataAnnotations.Schema;

namespace _007_TPTcodeFirst
{
    // [Table("PermanentEmployees")]
    public class PermanentEmployee : Employee
    {
        public int AnnualSalary { set; get; }
    }
}
