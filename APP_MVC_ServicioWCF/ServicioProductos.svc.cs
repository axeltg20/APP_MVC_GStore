using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using APP_MVC_Datos.Model;
using System.Web.ModelBinding;

namespace APP_MVC_ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioProductos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioProductos.svc or ServicioProductos.svc.cs at the Solution Explorer and start debugging.
    public class ServicioProductos : IServicioProductos
    {
        //Conexion BD 
        GameStoreEntities db = new GameStoreEntities();

        void IServicioProductos.ActualizaProducto(Producto obj)
        {
            db.Database.ExecuteSqlCommand("EXEC usp_Admin_ActualizaProducto @id,@nomProd,@precio,@desc,@idCategoria,@stock",
                new SqlParameter("@id", obj.idProd),
                new SqlParameter("@nomProd", obj.nomProd),
                new SqlParameter("@precio", obj.precio),
                new SqlParameter("@desc", obj.descripcion),
                new SqlParameter("@idCategoria", obj.idCategoria),
                new SqlParameter("@stock", obj.stock)
                );
        }

        void IServicioProductos.EliminaProducto(int id)
        {
            db.Database.ExecuteSqlCommand("EXEC usp_Admin_EliminarProducto @id",
                new SqlParameter("@id",id)
                );
        }

        void IServicioProductos.InsertaProducto(Producto obj)
        {
            db.Database.ExecuteSqlCommand("EXEC usp_Admin_InsertaProducto @nomProd,@precio,@desc,@idCategoria,@stock",
                new SqlParameter("@nomProd",obj.nomProd),
                new SqlParameter("@precio",obj.precio),
                new SqlParameter("@desc",obj.descripcion),
                new SqlParameter("@idCategoria",obj.idCategoria),
                new SqlParameter("@stock",obj.stock)
                );
        }

        List<usp_Admin_ListarProducto_Result> IServicioProductos.Productos()
        {
            return db.usp_Admin_ListarProducto().ToList();
        }

        List<usp_ListarCategoria_Result> IServicioProductos.Categorias()
        {
            return db.usp_ListarCategoria().ToList();
        }

        void IServicioProductos.InsertaCategoria(Categoria obj)
        {
            db.Database.ExecuteSqlCommand("EXEC usp_Admin_CrearCategoria @nombre",
                new SqlParameter("@nombre", obj.nomCategoria)
                );
        }

        void IServicioProductos.ActualizaCategoria(Categoria obj)
        {
            db.Database.ExecuteSqlCommand("EXEC usp_Admin_ActualizaCategoria @idcat,@nombre",
                new SqlParameter("@idcat", obj.idCategoria),
                new SqlParameter("@nombre", obj.nomCategoria)
                );
        }

        void IServicioProductos.EliminaCategoria(int id)
        {
            db.Database.ExecuteSqlCommand("EXEC usp_Admin_EliminaCategoria @idcat",
                new SqlParameter("@idcat", id)
                );
        }
    }
}
