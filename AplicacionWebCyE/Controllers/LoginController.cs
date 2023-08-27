using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using CapaDatos;
using CapaEntidad;
using CapaNegocio;

namespace AplicacionWebCyE.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string correo, string clave)
        {
            Usuario oUsuario = new Usuario();

             oUsuario = new CN_Usuario().Listar().Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefault();

            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña no correcta";
                return View();
            }

            else
            {
                FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);

                ViewBag.Error = null;

                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult CerrarSesion()
        {
            //FormsAuthentication.SignOut();
            //Session["Usuario"] = null;
            return RedirectToAction("Index", "Login");
        }





    }
}