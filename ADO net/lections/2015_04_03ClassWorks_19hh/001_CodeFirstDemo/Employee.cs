using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _001_CodeFirstDemo
{
    //[Table("tblEmployees", Schema = "Admin")]
    public class Employee
    {
        //[Key]
        //[Column("anotherId")]
        public int Id { set; get; }
        
        [Required] // not null
        [MaxLength(64)]
        public string Name { set; get; }

        [MaxLength(8)]
        public string Gender { set; get; }

        [Column("Salary", Order=1, TypeName="SmallMoney")]
        public int Salary { set; get; }

        public int DepartmentId { set; get; } // Дивний syntax
        [ForeignKey("DepartmentId")]
        [Required] // not null
        public Department Department { set; get; }

        // [NotMapped]
        public string JobTitle { set; get; }
    }
}
