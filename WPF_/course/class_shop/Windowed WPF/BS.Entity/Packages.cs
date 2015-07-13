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
    
    public partial class Packages
    {
        public Packages()
        {
            this.InputOrderItems = new HashSet<InputOrderItems>();
            this.OutputOrderItems = new HashSet<OutputOrderItems>();
            this.Prices = new HashSet<Prices>();
            this.WareHouseItems = new HashSet<WareHouseItems>();
        }
    
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal Volume { get; set; }
        public int VolumeMeasureId { get; set; }
        public int MeasureId { get; set; }
    
        public virtual ICollection<InputOrderItems> InputOrderItems { get; set; }
        public virtual Measures Measures { get; set; }
        public virtual Measures Measures1 { get; set; }
        public virtual ICollection<OutputOrderItems> OutputOrderItems { get; set; }
        public virtual Products Products { get; set; }
        public virtual ICollection<Prices> Prices { get; set; }
        public virtual ICollection<WareHouseItems> WareHouseItems { get; set; }
    }
}