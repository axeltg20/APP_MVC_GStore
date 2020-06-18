using APP_MVC_Datos.Model;
using APP_MVC_GStore.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_MVC_GStore.Controllers
{
    public class PagosController : Controller
    {
        GameStoreEntities db = new GameStoreEntities();
       
        // GET: Pagos
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AgregarTarjeta()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgregarTarjeta(TB_Tarjetas tarjetas)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tarjetas.idTarjeta = tarjetas.idTarjeta;
                    db.usp_AgregarTarjeta(tarjetas.idUsuario, tarjetas.nombreTitular, tarjetas.apellidoTitular, tarjetas.nroTarjeta, tarjetas.fechaExpiracion, tarjetas.ccv);
                    return RedirectToAction("Pagar", "Pagos");
                }
                return RedirectToAction("Pagar", "Pagos");
            }
            catch
            {
                return View();
            }
        }


    }
}