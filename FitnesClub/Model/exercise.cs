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
    
    public partial class exercise
    {
        public int id_exercise { get; set; }
        public int service_id { get; set; }
        public int client_id { get; set; }
        public System.DateTime date_write { get; set; }
    
        public virtual amenities amenities { get; set; }
        public virtual clients clients { get; set; }
    }
}