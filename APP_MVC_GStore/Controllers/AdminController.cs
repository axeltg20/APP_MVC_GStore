using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using APP_MVC_Datos.Model;
using APP_MVC_GStore.ReferenciaProductoAdm;

namespace APP_MVC_GStore.Controllers
{
    public class AdminController : Controller
    {
        //private GameStoreEntities db = new GameStoreEntities();
        ServicioProductosClient proxy = new ServicioProductosClient();
        //Entity Model
        GameStoreEntities db = new GameStoreEntities();
        // GET: Producto
        public ActionResult Index()
        {

            //Retorna vista Productos desde el proxy
            return View(proxy.Productos().ToString());
        }

        public ActionResult Productos()
        {
            return View(proxy.Productos().ToList());
        }

        public ActionResult Agregar()
        {
            ViewBag.categorias = new SelectList(proxy.Categorias(), "idCategoria", "nomCategoria");
            return View(new Producto());
        }

        [HttpPost]
        public ActionResult Agregar(Producto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    proxy.InsertaProducto(obj);
                }
                return RedirectToAction("Productos");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Actualizar()
        {
            ViewBag.categorias = new SelectList(proxy.Categorias(), "idCategoria", "nomCategoria");
            return View();
        }

        [HttpPost]
        public ActionResult Actualizar(Producto obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    proxy.ActualizaProducto(obj);
                }
                return RedirectToAction("Productos");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Eliminar(Producto obj)
        {
            /*try
             {
                 if (ModelState.IsValid)
                 {
                     proxy.EliminaProducto(id);
                 }
                 return RedirectToAction("Productos");
             }
             catch
             {*/
            //obj = proxy.Productos().ToList();
                return View(obj);
            //}
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmed(int id)
        {
            proxy.EliminaProducto(id);
            return RedirectToAction("Productos");
        }
    }
}
