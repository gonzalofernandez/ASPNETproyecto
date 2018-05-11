using System.Collections.Generic;
using System.Web.Mvc;
using MaquetaAplicacion.Models;

namespace MaquetaAplicacion.Controllers
{

    public class HomeController : Controller
    {
        //Declaramos la colección que contiene los componentes iniciales
        private List<Componente> componentes = new List<Componente>();
        
        public HomeController()
        {
            //Creamos las componentes iniciales
            this.componentes.Add(new Componente("mec", "MEC"));
            this.componentes.Add(new Componente("tuc", "Tuchengen Comp."));
            this.componentes.Add(new Componente("aut", "AUT"));
            this.componentes.Add(new Componente("rep", "REP"));
            this.componentes.Add(new Componente("ele", "ELE"));
            this.componentes.Add(new Componente("esp", "Elemento Especial"));
        }

        // GET: /HOME/{metodo}

        public ActionResult Index()
        {
            //Guardamos las componentes en la sesión
            if (Session["componentes"] == null)
            {
                Session["componentes"] = componentes;
            }
            //Datos para la vista
            ViewBag.Titulo = "Gestor de Referencias";
            ViewBag.Descripcion = "asp.net";
            ViewBag.Componentes = (List<Componente>)(Session["componentes"]);
            return View();
        }

        public ActionResult About()
        {
            //Datos para la vista
            ViewBag.Componentes = (List<Componente>)(Session["componentes"]);
            return View();
        }

        public ActionResult Contact()
        {
            //Datos para la vista
            ViewBag.Componentes = (List<Componente>)(Session["componentes"]);
            return View();
        }

        /*public ActionResult Profile()
        {
            //Datos para la vista
            ViewBag.Message = "Descripción de la página";
            ViewBag.Componentes = (List<Componente>)(Session["componentes"]);
            return View();
        }*/
    }
}
