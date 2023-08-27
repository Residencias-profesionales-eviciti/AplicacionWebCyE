using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace AplicacionWebCyE.Controllers
{
    public class TipoUsuarioController : Controller
    {
        // GET: TipoUsuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTipoUsuario()
        {
            List<tipo_usuario> olista = new List<tipo_usuario>();

            olista = new CN_TipoUsuario().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
    }
}