//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FitnesClub.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class subscribe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public subscribe()
        {
            this.buy = new HashSet<buy>();
        }
    
        public int id_subscribe { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public Nullable<int> period_id { get; set; }
        public int type_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<buy> buy { get; set; }
        public virtual period period { get; set; }
        public virtual type_subscribe type_subscribe { get; set; }
    }
}
