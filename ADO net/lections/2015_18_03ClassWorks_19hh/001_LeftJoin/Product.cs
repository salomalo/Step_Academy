//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _001_LeftJoin
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public Product()
        {
            this.Packages = new HashSet<Package>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> ProducerId { get; set; }
        public Nullable<int> CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual Producer Producer { get; set; }
    }
}