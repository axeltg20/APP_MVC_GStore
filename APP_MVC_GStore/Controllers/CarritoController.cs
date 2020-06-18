using APP_MVC_Datos.Model;
using APP_MVC_GStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;


namespace APP_MVC_GStore.Controllers
{
    public class CarritoController : Controller
    {
        GameStoreEntities db = new GameStoreEntities();
        Modelos modelo = new Modelos();
        public ActionResult ListaProductos()
        {
            return View(db.TB_Producto.ToList().OrderBy(x => x.nomProd));
        }

        public int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if(compras[i].producto.idProd == id)
                {
                    return i;
                }
            }
            return -1;
        }
        public ActionResult AgregaCarrito()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AgregaCarrito(int id, int cantidad)
        {
            if (Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.TB_Producto.Find(id), cantidad));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int indexExistente = getIndex(id);
                if (indexExistente == -1)
                {
                    compras.Add(new CarritoItem(db.TB_Producto.Find(id), cantidad));
                }
                else
                {
                    compras[indexExistente].cantidad += cantidad;
                }
                Session["carrito"] = compras;
            }
            return Json(new { response = true }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregaCarrito");
        }


        public List<TB_Tarjetas> ListarTarjetas(Modelos tarjetas)
        {
            List<TB_Tarjetas> lista = new List<TB_Tarjetas>();
            lista = tarjetas.ModelTarjetas.ToList();
            return lista;
        }


        public ActionResult Pagar(double total)
        {
            int idTarjeta;
            idTarjeta = 1;
            int totals = Convert.ToInt32(total);
            return View(db.usp_Pagar(idTarjeta, totals));
        }

    }
}