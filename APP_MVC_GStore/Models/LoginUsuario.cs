using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APP_MVC_GStore.Models
{
    public class LoginUsuario
    {
        [Display(Name = "Correo de Cliente")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Correo requerido")]
        public string Correo { get; set; }
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contraseña requerida")]
        public string Password { get; set; }

        [Display(Name = "Recuérdame")]
        public bool Rememberme { get; set; }
    }
}