﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace APP_MVC_GStore.ReferenciaProductoAdm {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Producto", Namespace="http://schemas.datacontract.org/2004/07/APP_MVC_ServicioWCF")]
    [System.SerializableAttribute()]
    public partial class Producto : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string descripcionField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string fotoField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idCategoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idProdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomProdField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string precioField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int stockField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                if ((object.ReferenceEquals(this.descripcionField, value) != true)) {
                    this.descripcionField = value;
                    this.RaisePropertyChanged("descripcion");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string foto {
            get {
                return this.fotoField;
            }
            set {
                if ((object.ReferenceEquals(this.fotoField, value) != true)) {
                    this.fotoField = value;
                    this.RaisePropertyChanged("foto");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idCategoria {
            get {
                return this.idCategoriaField;
            }
            set {
                if ((this.idCategoriaField.Equals(value) != true)) {
                    this.idCategoriaField = value;
                    this.RaisePropertyChanged("idCategoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idProd {
            get {
                return this.idProdField;
            }
            set {
                if ((this.idProdField.Equals(value) != true)) {
                    this.idProdField = value;
                    this.RaisePropertyChanged("idProd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomProd {
            get {
                return this.nomProdField;
            }
            set {
                if ((object.ReferenceEquals(this.nomProdField, value) != true)) {
                    this.nomProdField = value;
                    this.RaisePropertyChanged("nomProd");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string precio {
            get {
                return this.precioField;
            }
            set {
                if ((object.ReferenceEquals(this.precioField, value) != true)) {
                    this.precioField = value;
                    this.RaisePropertyChanged("precio");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int stock {
            get {
                return this.stockField;
            }
            set {
                if ((this.stockField.Equals(value) != true)) {
                    this.stockField = value;
                    this.RaisePropertyChanged("stock");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Categoria", Namespace="http://schemas.datacontract.org/2004/07/APP_MVC_ServicioWCF")]
    [System.SerializableAttribute()]
    public partial class Categoria : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int idCategoriaField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string nomCategoriaField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idCategoria {
            get {
                return this.idCategoriaField;
            }
            set {
                if ((this.idCategoriaField.Equals(value) != true)) {
                    this.idCategoriaField = value;
                    this.RaisePropertyChanged("idCategoria");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nomCategoria {
            get {
                return this.nomCategoriaField;
            }
            set {
                if ((object.ReferenceEquals(this.nomCategoriaField, value) != true)) {
                    this.nomCategoriaField = value;
                    this.RaisePropertyChanged("nomCategoria");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ReferenciaProductoAdm.IServicioProductos")]
    public interface IServicioProductos {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/Productos", ReplyAction="http://tempuri.org/IServicioProductos/ProductosResponse")]
        APP_MVC_Datos.Model.usp_Admin_ListarProducto_Result[] Productos();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/Productos", ReplyAction="http://tempuri.org/IServicioProductos/ProductosResponse")]
        System.Threading.Tasks.Task<APP_MVC_Datos.Model.usp_Admin_ListarProducto_Result[]> ProductosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/InsertaProducto", ReplyAction="http://tempuri.org/IServicioProductos/InsertaProductoResponse")]
        void InsertaProducto(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/InsertaProducto", ReplyAction="http://tempuri.org/IServicioProductos/InsertaProductoResponse")]
        System.Threading.Tasks.Task InsertaProductoAsync(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/ActualizaProducto", ReplyAction="http://tempuri.org/IServicioProductos/ActualizaProductoResponse")]
        void ActualizaProducto(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/ActualizaProducto", ReplyAction="http://tempuri.org/IServicioProductos/ActualizaProductoResponse")]
        System.Threading.Tasks.Task ActualizaProductoAsync(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/EliminaProducto", ReplyAction="http://tempuri.org/IServicioProductos/EliminaProductoResponse")]
        void EliminaProducto(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/EliminaProducto", ReplyAction="http://tempuri.org/IServicioProductos/EliminaProductoResponse")]
        System.Threading.Tasks.Task EliminaProductoAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/Categorias", ReplyAction="http://tempuri.org/IServicioProductos/CategoriasResponse")]
        APP_MVC_Datos.Model.usp_ListarCategoria_Result[] Categorias();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/Categorias", ReplyAction="http://tempuri.org/IServicioProductos/CategoriasResponse")]
        System.Threading.Tasks.Task<APP_MVC_Datos.Model.usp_ListarCategoria_Result[]> CategoriasAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/InsertaCategoria", ReplyAction="http://tempuri.org/IServicioProductos/InsertaCategoriaResponse")]
        void InsertaCategoria(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/InsertaCategoria", ReplyAction="http://tempuri.org/IServicioProductos/InsertaCategoriaResponse")]
        System.Threading.Tasks.Task InsertaCategoriaAsync(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/ActualizaCategoria", ReplyAction="http://tempuri.org/IServicioProductos/ActualizaCategoriaResponse")]
        void ActualizaCategoria(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/ActualizaCategoria", ReplyAction="http://tempuri.org/IServicioProductos/ActualizaCategoriaResponse")]
        System.Threading.Tasks.Task ActualizaCategoriaAsync(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/EliminaCategoria", ReplyAction="http://tempuri.org/IServicioProductos/EliminaCategoriaResponse")]
        void EliminaCategoria(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServicioProductos/EliminaCategoria", ReplyAction="http://tempuri.org/IServicioProductos/EliminaCategoriaResponse")]
        System.Threading.Tasks.Task EliminaCategoriaAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServicioProductosChannel : APP_MVC_GStore.ReferenciaProductoAdm.IServicioProductos, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServicioProductosClient : System.ServiceModel.ClientBase<APP_MVC_GStore.ReferenciaProductoAdm.IServicioProductos>, APP_MVC_GStore.ReferenciaProductoAdm.IServicioProductos {
        
        public ServicioProductosClient() {
        }
        
        public ServicioProductosClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServicioProductosClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioProductosClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServicioProductosClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public APP_MVC_Datos.Model.usp_Admin_ListarProducto_Result[] Productos() {
            return base.Channel.Productos();
        }
        
        public System.Threading.Tasks.Task<APP_MVC_Datos.Model.usp_Admin_ListarProducto_Result[]> ProductosAsync() {
            return base.Channel.ProductosAsync();
        }
        
        public void InsertaProducto(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj) {
            base.Channel.InsertaProducto(obj);
        }
        
        public System.Threading.Tasks.Task InsertaProductoAsync(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj) {
            return base.Channel.InsertaProductoAsync(obj);
        }
        
        public void ActualizaProducto(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj) {
            base.Channel.ActualizaProducto(obj);
        }
        
        public System.Threading.Tasks.Task ActualizaProductoAsync(APP_MVC_GStore.ReferenciaProductoAdm.Producto obj) {
            return base.Channel.ActualizaProductoAsync(obj);
        }
        
        public void EliminaProducto(int id) {
            base.Channel.EliminaProducto(id);
        }
        
        public System.Threading.Tasks.Task EliminaProductoAsync(int id) {
            return base.Channel.EliminaProductoAsync(id);
        }
        
        public APP_MVC_Datos.Model.usp_ListarCategoria_Result[] Categorias() {
            return base.Channel.Categorias();
        }
        
        public System.Threading.Tasks.Task<APP_MVC_Datos.Model.usp_ListarCategoria_Result[]> CategoriasAsync() {
            return base.Channel.CategoriasAsync();
        }
        
        public void InsertaCategoria(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj) {
            base.Channel.InsertaCategoria(obj);
        }
        
        public System.Threading.Tasks.Task InsertaCategoriaAsync(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj) {
            return base.Channel.InsertaCategoriaAsync(obj);
        }
        
        public void ActualizaCategoria(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj) {
            base.Channel.ActualizaCategoria(obj);
        }
        
        public System.Threading.Tasks.Task ActualizaCategoriaAsync(APP_MVC_GStore.ReferenciaProductoAdm.Categoria obj) {
            return base.Channel.ActualizaCategoriaAsync(obj);
        }
        
        public void EliminaCategoria(int id) {
            base.Channel.EliminaCategoria(id);
        }
        
        public System.Threading.Tasks.Task EliminaCategoriaAsync(int id) {
            return base.Channel.EliminaCategoriaAsync(id);
        }
    }
}
