//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_MVC_Datos.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class TB_Direcciones
    {
        public int idDireccion { get; set; }
        public string nomDireccion { get; set; }
        public string nomDistrito { get; set; }
        public string nomCiudad { get; set; }
        public Nullable<int> idUsuario { get; set; }
    
        public virtual TB_Usuario TB_Usuario { get; set; }
    }
}
