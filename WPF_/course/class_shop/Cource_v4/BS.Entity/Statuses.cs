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
    
    public partial class Statuses
    {
        public Statuses()
        {
            this.InputOrders = new HashSet<InputOrders>();
            this.OutputOrders = new HashSet<OutputOrders>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<InputOrders> InputOrders { get; set; }
        public virtual ICollection<OutputOrders> OutputOrders { get; set; }
    }
}
