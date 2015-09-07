using System.ComponentModel.DataAnnotations.Schema;

namespace _007_TPTcodeFirst
{
    // [Table("ContractEmployees")]
    public class ContractEmployee : Employee
    {
        public int HoursWorked { set; get; }
        public int HourlyPay { set; get; }
    }
}
