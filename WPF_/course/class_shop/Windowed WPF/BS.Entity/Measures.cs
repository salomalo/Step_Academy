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
    
    public partial class Measures
    {
        public Measures()
        {
            this.Packages = new HashSet<Packages>();
            this.Packages1 = new HashSet<Packages>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    
        public virtual ICollection<Packages> Packages { get; set; }
        public virtual ICollection<Packages> Packages1 { get; set; }
    }
}
