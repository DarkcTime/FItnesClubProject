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
    
    public partial class discont
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public discont()
        {
            this.buy = new HashSet<buy>();
        }
    
        public int id_discont { get; set; }
        public string name { get; set; }
        public int number { get; set; }
        public string criterion { get; set; }
        public int type_discont_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<buy> buy { get; set; }
        public virtual type_discont type_discont { get; set; }
    }
}