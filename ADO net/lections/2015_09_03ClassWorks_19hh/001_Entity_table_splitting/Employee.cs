//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _001_Entity_table_splitting
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Jobtitle { get; set; }
    
        public virtual EmployeeDetails EmployeeDetails { get; set; }
    }
}