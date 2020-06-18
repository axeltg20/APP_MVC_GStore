using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_MVC_GStore.Controllers
{
    public class PagoController : Controller
    {
        // GET: Pago
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult agregarTarjeta()
        {
            return View();
        }
    }
}