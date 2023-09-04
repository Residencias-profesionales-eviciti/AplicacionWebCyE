using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;

namespace AplicacionWebCyE.Controllers
{
    public class Tipo_RespuestaController : Controller
    {
        // GET: Tipo_Respuesta
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTipoRespuesta()
        {
            List<Tipo_Respuesta> olista = new List<Tipo_Respuesta>();

            olista = new CN_Tipo_Respuesta().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }
    }
}