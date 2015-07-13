//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BS.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Package
    {
        public Package()
        {
            this.Prices = new HashSet<Price>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Volume { get; set; }
        public int VolumeMeasureId { get; set; }
        public int MeasureId { get; set; }
    
        public virtual Measure Measure { get; set; }
        public virtual Measure Measure1 { get; set; }
        public virtual Product Product { get; set; }
        public virtual ICollection<Price> Prices { get; set; }
    }
}
