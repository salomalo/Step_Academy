//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class WarehouseItem
    {
        public int Id { get; set; }
        public Nullable<int> WarehousId { get; set; }
        public Nullable<int> PackegeId { get; set; }
        public Nullable<decimal> Quantity { get; set; }
    
        public virtual Packeges Packeges { get; set; }
        public virtual Warehouses Warehouses { get; set; }
    }
}
