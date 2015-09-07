using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoredProceduresDemo
{
    public class Employee
    {
        public int Id { set; get; }

        // [Column("FullName")]
        [MaxLength(64)]
        [Required]
        public string Name { set; get; }

        [MaxLength(16)]
        public string Gender { set; get; }
        public int? Salary { set; get; }

        public int DepartmentId { set; get; }
        [ForeignKey("DepartmentId")]
        public Department Department { set; get; }

    }
}
