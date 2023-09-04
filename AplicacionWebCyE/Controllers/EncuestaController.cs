using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using CapaEntidad;
using CapaNegocio;
using CapaDatos;

namespace AplicacionWebCyE.Controllers
{
    public class EncuestaController : Controller
    {
        // GET: Encuesta
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarEncuesta()
        {
            List<Encuesta> olista = new List<Encuesta>();

            olista = new CN_Encuesta().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEncuesta(Encuesta objeto)
        {
            object resultado; //Debe ir solo la variable
            string Mensaje = string.Empty;

            if (objeto.IdEncuesta == 0)
            {
                resultado = new CN_Encuesta().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_Encuesta().Editar(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEncuesta(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Encuesta().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}