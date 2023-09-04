using CapaEntidad;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWebCyE.Controllers
{
    public class EncuestaPreguntaController : Controller
    {
        // GET: EncuestaPregunta
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarTipo()
        {
            List<EncuestaPreguntaTipo> olista = new List<EncuestaPreguntaTipo>();

            olista = new CN_EncuestaPregunta().ListarPreguntaTipo(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListarEncuestaPregunta()
        {
            List<EncuestaPregunta> olista = new List<EncuestaPregunta>();

            olista = new CN_EncuestaPregunta().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarEncuestaPregunta(EncuestaPregunta objeto)
        {
            object resultado; //Debe ir solo la variable
            string Mensaje = string.Empty;

            if (objeto.IdEncuesta_pregunta == 0)
            {
                resultado = new CN_EncuestaPregunta().Registrar(objeto, out Mensaje);
            }
            else
            {
                resultado = new CN_EncuestaPregunta().Editar(objeto, out Mensaje);
            }

            return Json(new { resultado = resultado, Mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarEncuestaPregunta(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new CN_Encuesta().Eliminar(id, out mensaje);

            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

    }
}