using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.Script.Serialization;


using CapaEntidad;
using CapaNegocio;
using System.Net;

namespace AplicacionWebCyE.Controllers
{

    public class DepartamentoController : Controller
    {
        //string SistemaContext = ConfigurationManager.ConnectionStrings["SistemaContext"].ConnectionString.ToString();
        //private SistemaContext db = new DBSISTEMAEntitiesDBSISTEMAEntitiesDBSISTEMAEntities();

        // GET: Departamento
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListarDepartamentos()
        {
            List<departamentos> olista = new List<departamentos>();

            olista = new CN_departamentos().Listar(); //llamando a la capa de negocio

            return Json(new { data = olista }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        [HttpPost]
        public JsonResult GuardarDepartamentos(departamentos objeto)
        {
            object resultado;
            string mensaje = string.Empty;

            if (objeto.ID == 0)
            {
                resultado = new CN_departamentos().Registrar(objeto, out mensaje);
            }
            else
            {
                resultado = new CN_departamentos().Editar(objeto, out mensaje);
            }

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EliminarDepartamentos(int ID)
        {
            bool resultado = false;
            string mensaje = string.Empty;

            resultado = new CN_departamentos().Eliminar(ID, out mensaje);

            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }


    }
}