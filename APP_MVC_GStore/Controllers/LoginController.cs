using APP_MVC_GStore.Models;
using APP_MVC_Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace APP_MVC_GStore.Controllers
{
    public class LoginController : Controller
    {
        GameStoreEntities db = new GameStoreEntities();
        // GET: Login
        public ActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(LoginUsuario login)
        {
            var _passWord = APP_MVC_GStore.Models.EncriptarContra.textToEncrypt(login.Password);
            //Verificar ingreso de datos
            bool Isvalid = db.TB_Usuario.Any(x => x.email == login.Correo && x.emailverficiado == true && x.contra == _passWord ); ;
            //bool Isvalid = db.TB_Usuario.Any(x => x.email == login.Correo && x.contra == login.Password);
            if (Isvalid)
            {
                int timeout = login.Rememberme ? 60 : 5; // Timeout in minutes, 60 = 1 hour.  
                var ticket = new FormsAuthenticationTicket(login.Correo, false, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Seguridad", "Login");
            }
            else
            {
                ModelState.AddModelError("", "Los datos ingresados son incorrectos, intente nuevamente.");
            }
           return View();
        }

        public ActionResult Seguridad()
        {
            return View();
        }
    }
}