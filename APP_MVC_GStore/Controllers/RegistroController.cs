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
        /*Conectar BD*/
        GameStoreEntities db = new GameStoreEntities();
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
        public ActionResult Registrar(string nombre, string apellido, string email, string contra)
        {
            
            /*It Generar unique code
            user.codigoactivacion = Guid.NewGuid();
            db.TB_Usuario.Add(user);
            db.SaveChanges();
            return View();*/

            ViewBag.nombre = nombre;
            ViewBag.apellido = apellido;
            ViewBag.email = email;
            ViewBag.contra = contra;
            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellido) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(contra))
            {   /*Detectar correos existentes*/
                var existe = EmailExistente(email);
                if (existe)
                {
                    /*Crear metodo de retorno en caso encuentre correos registrados*/
                    ModelState.AddModelError("EmailExists", "Email ya registrado");
                    return View("Registrar");
                }
                /*Cifrado de contraseña*/
                contra = APP_MVC_GStore.Models.EncriptarContra.textToEncrypt(contra);
                var registrar = db.usp_CrearUsuario(nombre, apellido, email, contra);
                return RedirectToAction("Ingresar", "Registro");

            }
            return View();
        }
      


        /*Ingresar usuario*/
        public ActionResult Ingresar(string email, string contra)
        {
            ViewBag.email = email;
            ViewBag.contra = contra;
            if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(contra))
            {
                var logueo = db.usp_Logueo(email, contra);
                return RedirectToAction("Index", "Producto");

            }

            return View();
        }

        /*Detector de correos existentes*/
        public bool EmailExistente(string correo)
        {
            var IsCheck = db.TB_Usuario.Where(x => x.email == correo).FirstOrDefault();
            return IsCheck != null;
        }
    }

    }
