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
    
    public partial class buy
    {
        public int id_buy { get; set; }
        public int client_id { get; set; }
        public int subsribe_id { get; set; }
        public Nullable<int> discont_id { get; set; }
        public System.DateTime date_buy { get; set; }
    
        public virtual clients clients { get; set; }
        public virtual discont discont { get; set; }
        public virtual subscribe subscribe { get; set; }
    }
}