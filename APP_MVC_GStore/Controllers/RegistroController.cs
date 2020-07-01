using APP_MVC_GStore.Models;
using APP_MVC_Datos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
        /*Registrar Usuario, Parametros: Tabla Usuario*/
        [HttpPost]
        public ActionResult Registrar(TB_Usuario user)
        {
            /*Declarar valores de tabla como strings*/
            String nom = user.nombre;
            String ape = user.apellido;
            String ema = user.email;
            String con = user.contra;
            var emailverif = user.codigoactivacion;
            ViewBag.nombre = nom;
            ViewBag.apellido = ape;
            ViewBag.email = ema;
            ViewBag.contra = con;
            /*Registro de Usuario*/
            if (!string.IsNullOrEmpty(nom) && !string.IsNullOrEmpty(ape) && !string.IsNullOrEmpty(ema) && !string.IsNullOrEmpty(con))
            {   /*Detectar correos existentes*/
                var existe = EmailExistente(ema);
                if (existe)
                {
                    /*Crear metodo de retorno en caso encuentre correos duplicados*/
                    ModelState.AddModelError("EmailExists", "Email ya registrado");
                    return View("Registrar");
                }
                /*Creaciono de GUID (Identificador Unico Global) para el codigo de verificación*/
                emailverif = Guid.NewGuid();
                /*Cifrado de contraseña*/
                //con = APP_MVC_GStore.Models.EncriptarContra.textToEncrypt(con);
                /*Registro final*/
                var registrar = db.usp_CrearUsuario(nom, ape, ema, emailverif, con);
               /*Enviar Correo de confirmacion*/
                enviarCorreoAUsuario(ema, emailverif.ToString());
                var mensaje = "Registro Compleado. Por favor revise su correo " + ema;
                ViewBag.mensaje = mensaje;
                return View("RegistroConfirmado");

            }
            return View();
        }



        /*Ingresar usuario*/
        public ActionResult Ingresar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ingresar(LoginUsuario login)
        {
            
            //Verificar ingreso de datos
            bool Isvalid = db.TB_Usuario.Any(x => x.email == login.Correo && x.emailverficiado == true && x.contra == login.Password); ;
            if (Isvalid)
            {
                int timeout = login.Rememberme ? 60 : 5; // Timeout in minutes, 60 = 1 hour.  
                var ticket = new FormsAuthenticationTicket(login.Correo, false, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = System.DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);
                return RedirectToAction("Seguridad", "Registro");
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

        /*Detector de correos existentes*/
        public bool EmailExistente(string correo)
        {
            //var IsCheck = db.TB_Usuario.Where(x => x.email == correo).FirstOrDefault();
            var check = db.TB_Usuario.Where(x => x.email == correo).FirstOrDefault();
            return check != null;
        }

        /*Enviar Correo de validacion*/
        public void enviarCorreoAUsuario(string emailId, string codigoacti)
        {
            /*Generar link del correo de activacion*/
            var GenarateUserVerificationLink = "/Registro/VerificacionUsuario/" + codigoacti;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, GenarateUserVerificationLink);
            /*Asociar Cuenta que enviara los correos)*/
            var fromMail = new MailAddress("gamestore1220@gmail.com", "GStore Perú"); // Poner tu correo
            var fromEmailpassword = "gstore2020951"; // Poner tu contraseña
            var toEmail = new MailAddress(emailId);

            var smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(fromMail.Address, fromEmailpassword);

            var Message = new MailMessage(fromMail, toEmail);
            Message.Subject = "GStore - Registro";
            Message.Body = "<br/> Hola! Tu registro en GStore fue exitoso!" +
                           "<br/> Por favor haz click aquí para confirmar tu cuenta:" +
                           "<br/><br/><a href=" + link + ">" + link + "</a>";
            Message.IsBodyHtml = true;
            smtp.Send(Message);
        }

        /*Verificacion de Correo*/
        public ActionResult VerificacionUsuario(string id)
        {
            bool Status = false;

            db.Configuration.ValidateOnSaveEnabled = false; // Ignorar confirmacion de contraseña
            /*Captuar el id del correo validado*/
            var verificado = db.TB_Usuario.Where(u => u.codigoactivacion == new Guid(id)).FirstOrDefault();

            if (verificado != null)
            {
                verificado.emailverficiado = true;
                db.SaveChanges();
                ViewBag.Message = "Verificación de correo completa!";
                Status = true;
            }
            else
            {
                ViewBag.Message = "Request Invalido, correo no verificado.";
                ViewBag.Status = false;
            }

            return View();
        }
    }

    }
