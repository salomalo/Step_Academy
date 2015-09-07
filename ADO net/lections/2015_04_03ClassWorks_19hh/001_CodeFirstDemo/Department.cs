using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_CodeFirstDemo
{
    //[Table("tblDepartment", Schema = "Admin")]
    public class Department
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Location { set; get; }

        public List<Employee> Employees { set; get; }
    }
}
