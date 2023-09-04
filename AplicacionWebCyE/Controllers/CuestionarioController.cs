using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AplicacionWebCyE.Controllers
{
    public class CuestionarioController : Controller
    {
        // GET: Cuestionario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cuestionario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cuestionario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cuestionario/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuestionario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Cuestionario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cuestionario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cuestionario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
