using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace APP_MVC_GStore.Models
{
    public class RegistroUsuario
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Inserte su nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Inserte su apellido")]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Inserte su Email")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Ingrese una Contraseña")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Ingrese una contraseña de minimo 6 caracteres")]
        public string Contra { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirme su contraseña")]
        [DataType(DataType.Password)]
        [Compare("Contra", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }
    }
}