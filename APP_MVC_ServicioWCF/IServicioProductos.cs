using APP_MVC_ServicioWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace APP_MVC_ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServicioProductos" in both code and config file together.
    [ServiceContract]
    public interface IServicioProductos
    {
        [OperationContract] List<usp_ListarProducto_Result> Productos();
        [OperationContract] void InsertaProducto(TB_Producto obj);
        [OperationContract] void ActualizaProducto(TB_Producto obj);
        [OperationContract] void EliminaProducto(int id);
    }

  
}
