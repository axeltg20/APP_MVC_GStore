using APP_MVC_GStore.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace APP_MVC_GStore.Controllers
{
    public class CarritoController : Controller
    {
        GameStoreEntities db = new GameStoreEntities();

        // GET: Carrito
        public ActionResult Carrito()
        {
                var carrito = db.TB_Producto.Include(t => t.TB_Categoria);
                return View(carrito.ToList());

        }
    }
}