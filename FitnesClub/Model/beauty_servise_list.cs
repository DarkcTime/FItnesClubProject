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
    
    public partial class beauty_servise_list
    {
        public int id_service { get; set; }
        public int client_id { get; set; }
        public int service_beaty_id { get; set; }
        public decimal price { get; set; }
    
        public virtual beauty_services beauty_services { get; set; }
        public virtual clients clients { get; set; }
    }
}