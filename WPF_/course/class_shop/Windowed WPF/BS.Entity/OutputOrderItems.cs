//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BS.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class OutputOrderItems
    {
        public int Id { get; set; }
        public int OutputOrderId { get; set; }
        public int PackageId { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitCost { get; set; }
    
        public virtual OutputOrders OutputOrders { get; set; }
        public virtual Packages Packages { get; set; }
    }
}