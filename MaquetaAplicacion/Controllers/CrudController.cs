using MaquetaAplicacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaquetaAplicacion.Controllers
{
    public class CrudController : Controller
    {
        //Declaramos la colección de referncias
        private List<Referencia> referencias = new List<Referencia>();

        public CrudController()
        {
            this.referencias.Add(new Referencia("Ejemplo_Ref", "Descripción de la referencia de ejemplo"));
            this.referencias.Add(new Referencia("Ejemplo_Ref", "Descripción de la referencia de ejemplo 2"));
            this.referencias.Add(new Referencia("Ejemplo_Ref", "Descripción de la referencia de ejemplo 3"));
        }

        // GET: Crud
        public ActionResult Index()
        {
            ViewBag.Componentes = (List<Componente>)(Session["componentes"]);
            ViewBag.Referencias = referencias;
            return View();
        }

        // GET: Crud/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Crud/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crud/Create
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

        // GET: Crud/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Crud/Edit/5
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

        // GET: Crud/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Crud/Delete/5
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
