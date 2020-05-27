using APP_MVC_GStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APP_MVC_GStore.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Registrar()
        {
            return View();
        }
        /*Registrar Usuario*/
        [HttpPost]
        public ActionResult Registrar(TB_Usuario user)
        {
            /*Email not verified on registration time*/
            user.emailverficiado = false;
            /*It Generar unique code*/
            return View();
        }
    }
}