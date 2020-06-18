using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_MVC_GStore.Models
{
    public class Modelos
    {   
        public List<APP_MVC_Datos.Model.TB_Tarjetas> ModelTarjetas { get; set; }
        public List<APP_MVC_GStore.Models.CarritoItem> ModelCarrito { get; set; }
    }
}