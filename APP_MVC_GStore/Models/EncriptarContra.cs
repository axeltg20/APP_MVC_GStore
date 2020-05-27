using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace APP_MVC_GStore.Models
{
    public static class EncriptarContra
    {
        public static string textToEncrypt(string passWord)
        {
            return Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passWord)));
        }
    }
}