using APP_MVC_ServicioWCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace APP_MVC_ServicioWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServicioProductos" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServicioProductos.svc or ServicioProductos.svc.cs at the Solution Explorer and start debugging.
    public class ServicioProductos : IServicioProductos
    {
        //Conexion BD 

        //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["GameStore"].ConnectionString);
        GameStoreEntities bd = new GameStoreEntities();
        public void ActualizaProducto(TB_Producto obj)
        {
            throw new NotImplementedException();
        }

        public void DoWork()
        {
        }

        public void EliminaProducto(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertaProducto(TB_Producto obj)
        {
            throw new NotImplementedException();
        }

        public List<usp_ListarProducto_Result> Productos()
        {
            List<usp_ListarProducto_Result> lista = bd.usp_ListarProducto().ToList(); 
/*            
 *            Lista producto con BD
 *            
 *            List<TB_Producto> lista = new List<TB_Producto>();
            SqlCommand cmd = new SqlCommand("usp_ListarProducto", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                TB_Producto prod= new TB_Producto();
                prod.idProd = Convert.ToInt32(dr["idProd"]);
                prod.nomProd = dr["nomProd"].ToString();
                prod.precio = Convert.ToInt32(dr["precio"]);
                prod.descripcion = dr["descripcion"].ToString();
                prod.foto = dr["foto"].ToString();
                prod.idCategoria = Convert.ToInt32(dr["idCategoria"]);
                prod.stock = Convert.ToInt32(dr["stock"]);
                prod.estado = Convert.ToInt32(dr["estado"]);
                lista.Add(prod);

            }
            dr.Close();
            cn.Close();*/
            return lista;
        }
    }
}
