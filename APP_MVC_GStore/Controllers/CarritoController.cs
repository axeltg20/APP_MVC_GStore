using APP_MVC_Datos.Model;
using APP_MVC_GStore.Models;
using APP_MVC_GStore.ReferenciaProductoAdm;
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

       
        public ActionResult ComprarYa(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TB_Producto productos = db.TB_Producto.Find(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
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

        public ActionResult Pagar(double total)
        {
            int idTarjeta = 1;
            int totals = Convert.ToInt32(total);
            db.usp_Pagar(idTarjeta, totals);
            return View();
        }


        public ActionResult ListaProductos(string nombre)
        {
            if (nombre == null) { nombre = string.Empty; }
            ViewBag.nombre = nombre;
            var lista = from p in db.TB_Producto where p.nomProd.Contains(nombre) select p;
            return View(lista.ToList());
        }


    }
}