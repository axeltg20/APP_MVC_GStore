//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_MVC_GStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Carrito
    {
        public int idCarrito { get; set; }
        public Nullable<int> idprod { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual TB_Producto TB_Producto { get; set; }
    }
}
