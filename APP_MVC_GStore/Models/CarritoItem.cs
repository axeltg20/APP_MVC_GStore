using APP_MVC_Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP_MVC_GStore.Models
{
    public class CarritoItem
    {
        private TB_Producto _producto;
        public TB_Producto producto
        {
            get { return _producto; }
            set { _producto = value; }
        }
        private int _cantidad;
        public int cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; }
        }
        public CarritoItem()
        {

        }
        public CarritoItem(TB_Producto producto, int cantidad)
        {
            this._producto = producto;
            this._cantidad = cantidad;
        }
    }
}