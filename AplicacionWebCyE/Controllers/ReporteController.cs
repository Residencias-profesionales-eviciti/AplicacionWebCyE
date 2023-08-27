using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using CapaEntidad;
using CapaNegocio;

namespace AplicacionWebCyE.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult VistaDashboard()
        {
            Dashboard objeto = new CN_Reporte().VerDashboard();

            return Json(new { resultado = objeto }, JsonRequestBehavior.AllowGet);

        }

    }
}