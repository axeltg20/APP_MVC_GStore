﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GameStoreEntities : DbContext
    {
        public GameStoreEntities()
            : base("name=GameStoreEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TB_Carrito> TB_Carrito { get; set; }
        public virtual DbSet<TB_Categoria> TB_Categoria { get; set; }
        public virtual DbSet<TB_ComprobantePago> TB_ComprobantePago { get; set; }
        public virtual DbSet<TB_DetalleComprobante> TB_DetalleComprobante { get; set; }
        public virtual DbSet<TB_Direcciones> TB_Direcciones { get; set; }
        public virtual DbSet<TB_Producto> TB_Producto { get; set; }
        public virtual DbSet<TB_Usuario> TB_Usuario { get; set; }
        public virtual DbSet<TB_Tarjetas> TB_Tarjetas { get; set; }
    
        public virtual int usp_AgregarCarrito(Nullable<int> idProd, Nullable<int> cantidad)
        {
            var idProdParameter = idProd.HasValue ?
                new ObjectParameter("idProd", idProd) :
                new ObjectParameter("idProd", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("cantidad", cantidad) :
                new ObjectParameter("cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AgregarCarrito", idProdParameter, cantidadParameter);
        }
    
        public virtual int usp_CrearUsuario(string nombre, string apellido, string email, Nullable<System.Guid> emailverif, string contra)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            var apellidoParameter = apellido != null ?
                new ObjectParameter("apellido", apellido) :
                new ObjectParameter("apellido", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var emailverifParameter = emailverif.HasValue ?
                new ObjectParameter("emailverif", emailverif) :
                new ObjectParameter("emailverif", typeof(System.Guid));
    
            var contraParameter = contra != null ?
                new ObjectParameter("contra", contra) :
                new ObjectParameter("contra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_CrearUsuario", nombreParameter, apellidoParameter, emailParameter, emailverifParameter, contraParameter);
        }
    
        public virtual int usp_InsertaProducto(string nomProd, Nullable<decimal> precio, Nullable<int> idCategoria, Nullable<int> stock)
        {
            var nomProdParameter = nomProd != null ?
                new ObjectParameter("nomProd", nomProd) :
                new ObjectParameter("nomProd", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("stock", stock) :
                new ObjectParameter("stock", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_InsertaProducto", nomProdParameter, precioParameter, idCategoriaParameter, stockParameter);
        }
    
        public virtual int usp_InsertarCategoria(string nomCategoria)
        {
            var nomCategoriaParameter = nomCategoria != null ?
                new ObjectParameter("nomCategoria", nomCategoria) :
                new ObjectParameter("nomCategoria", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_InsertarCategoria", nomCategoriaParameter);
        }
    
        public virtual ObjectResult<usp_ListarProducto_Result> usp_ListarProducto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ListarProducto_Result>("usp_ListarProducto");
        }
    
        public virtual ObjectResult<usp_Logueo_Result> usp_Logueo(string email, string contra)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var contraParameter = contra != null ?
                new ObjectParameter("contra", contra) :
                new ObjectParameter("contra", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_Logueo_Result>("usp_Logueo", emailParameter, contraParameter);
        }
    
        public virtual int usp_ActualizaProducto(Nullable<int> id, string nomProd, Nullable<decimal> precio, string desc, Nullable<int> idCategoria, Nullable<int> stock)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nomProdParameter = nomProd != null ?
                new ObjectParameter("nomProd", nomProd) :
                new ObjectParameter("nomProd", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("stock", stock) :
                new ObjectParameter("stock", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_ActualizaProducto", idParameter, nomProdParameter, precioParameter, descParameter, idCategoriaParameter, stockParameter);
        }
    
        public virtual int usp_Admin_ActualizaProducto(Nullable<int> id, string nomProd, Nullable<decimal> precio, string desc, Nullable<int> idCategoria, Nullable<int> stock)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var nomProdParameter = nomProd != null ?
                new ObjectParameter("nomProd", nomProd) :
                new ObjectParameter("nomProd", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("stock", stock) :
                new ObjectParameter("stock", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Admin_ActualizaProducto", idParameter, nomProdParameter, precioParameter, descParameter, idCategoriaParameter, stockParameter);
        }
    
        public virtual int usp_Admin_EliminarProducto(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Admin_EliminarProducto", idParameter);
        }
    
        public virtual int usp_Admin_InsertaProducto(string nomProd, Nullable<decimal> precio, string desc, Nullable<int> idCategoria, Nullable<int> stock)
        {
            var nomProdParameter = nomProd != null ?
                new ObjectParameter("nomProd", nomProd) :
                new ObjectParameter("nomProd", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("precio", precio) :
                new ObjectParameter("precio", typeof(decimal));
    
            var descParameter = desc != null ?
                new ObjectParameter("desc", desc) :
                new ObjectParameter("desc", typeof(string));
    
            var idCategoriaParameter = idCategoria.HasValue ?
                new ObjectParameter("idCategoria", idCategoria) :
                new ObjectParameter("idCategoria", typeof(int));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("stock", stock) :
                new ObjectParameter("stock", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Admin_InsertaProducto", nomProdParameter, precioParameter, descParameter, idCategoriaParameter, stockParameter);
        }
    
        public virtual ObjectResult<usp_Admin_ListarProducto_Result> usp_Admin_ListarProducto()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_Admin_ListarProducto_Result>("usp_Admin_ListarProducto");
        }
    
        public virtual ObjectResult<usp_ListarCategoria_Result> usp_ListarCategoria()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_ListarCategoria_Result>("usp_ListarCategoria");
        }
    
        public virtual int usp_AgregarTarjeta(Nullable<int> idUsuario, string nombreTitular, string apellidoTitular, string nroTarjeta, Nullable<System.DateTime> fechaExpiracion, string ccv)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            var nombreTitularParameter = nombreTitular != null ?
                new ObjectParameter("nombreTitular", nombreTitular) :
                new ObjectParameter("nombreTitular", typeof(string));
    
            var apellidoTitularParameter = apellidoTitular != null ?
                new ObjectParameter("apellidoTitular", apellidoTitular) :
                new ObjectParameter("apellidoTitular", typeof(string));
    
            var nroTarjetaParameter = nroTarjeta != null ?
                new ObjectParameter("nroTarjeta", nroTarjeta) :
                new ObjectParameter("nroTarjeta", typeof(string));
    
            var fechaExpiracionParameter = fechaExpiracion.HasValue ?
                new ObjectParameter("fechaExpiracion", fechaExpiracion) :
                new ObjectParameter("fechaExpiracion", typeof(System.DateTime));
    
            var ccvParameter = ccv != null ?
                new ObjectParameter("ccv", ccv) :
                new ObjectParameter("ccv", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_AgregarTarjeta", idUsuarioParameter, nombreTitularParameter, apellidoTitularParameter, nroTarjetaParameter, fechaExpiracionParameter, ccvParameter);
        }
    
        public virtual ObjectResult<usp_listarTarjetas_Result> usp_listarTarjetas(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("idUsuario", idUsuario) :
                new ObjectParameter("idUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_listarTarjetas_Result>("usp_listarTarjetas", idUsuarioParameter);
        }
    
        public virtual int usp_Pagar(Nullable<int> idTarjeta, Nullable<int> total)
        {
            var idTarjetaParameter = idTarjeta.HasValue ?
                new ObjectParameter("idTarjeta", idTarjeta) :
                new ObjectParameter("idTarjeta", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("total", total) :
                new ObjectParameter("total", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Pagar", idTarjetaParameter, totalParameter);
        }
    
        public virtual int usp_Admin_ActualizaCategoria(Nullable<int> idcat, string nombre)
        {
            var idcatParameter = idcat.HasValue ?
                new ObjectParameter("idcat", idcat) :
                new ObjectParameter("idcat", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Admin_ActualizaCategoria", idcatParameter, nombreParameter);
        }
    
        public virtual int usp_Admin_CrearCategoria(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("nombre", nombre) :
                new ObjectParameter("nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Admin_CrearCategoria", nombreParameter);
        }
    
        public virtual int usp_Admin_EliminaCategoria(Nullable<int> idcat)
        {
            var idcatParameter = idcat.HasValue ?
                new ObjectParameter("idcat", idcat) :
                new ObjectParameter("idcat", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_Admin_EliminaCategoria", idcatParameter);
        }
    }
}
