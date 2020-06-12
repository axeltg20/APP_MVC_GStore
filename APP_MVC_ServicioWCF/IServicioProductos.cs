using APP_MVC_Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Profile;

namespace APP_MVC_ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioProductos" in both code and config file together.
    [ServiceContract]
    public interface IServicioProductos
    {
        [OperationContract] List<usp_Admin_ListarProducto_Result> Productos();
        [OperationContract] void InsertaProducto(Producto obj);
        [OperationContract] void ActualizaProducto(Producto obj);
        [OperationContract] void EliminaProducto(int id);
        [OperationContract] List<usp_ListarCategoria_Result> Categorias();
    }
    [DataContract]
    public class Producto
    {
        [DataMember] public int idProd { get; set; }
        [DataMember] public string nomProd { get; set; }
        [DataMember] public string precio { get; set; }
        [DataMember] public string descripcion { get; set; }
        [DataMember] public string foto { get; set; }
        [DataMember] public int idCategoria { get; set; }
        [DataMember] public int stock { get; set; }
    }
    
    [DataContract]
    public class Categoria
    {
        [DataMember] public int idCategoria { get; set; }
        [DataMember] public string nomCategoria { get; set; }
    }
}
