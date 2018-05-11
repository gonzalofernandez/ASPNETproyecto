using MaquetaAplicacion.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MaquetaAplicacion.Controllers
{
    public class ComponenteController : Controller
    {
        //Declaramos la colección que contiene los elementos iniciales
        private List<Elemento> elementos = new List<Elemento>();

        public ComponenteController()
        {
            //Creamos las elementos iniciales
            this.elementos.Add(new Elemento("var", "VARIVENT", "", "", "", "", "", "", "", "", "", "", "", "", ""));
            this.elementos.Add(new Elemento("eco", "ECOVENT", "", "", "", "", "", "", "", "", "", "", "", "", ""));
            this.elementos.Add(new Elemento("tsv", "TSV", "", "", "", "", "", "", "", "", "", "", "", "", ""));
            this.elementos.Add(new Elemento("mod", "MODULANTES", "", "", "", "", "", "", "", "", "", "", "", "", ""));
            this.elementos.Add(new Elemento("mar", "MARIPOSA TS", "", "", "", "", "", "", "", "", "", "", "", "", ""));
            this.elementos.Add(new Elemento("bom", "BOMBAS", "", "", "", "", "", "", "", "", "", "", "", "", ""));
        }

        // GET: /APLICACION/{appId}

        public ActionResult Show(string compId)
        {
            //Guardamos los elementos en la sesión si aún no están
            if (Session["elementos"] == null)
            {
                Session["elementos"] = elementos;
            }
            //Leemos datos de la sesión
            List<Componente> componentes = (List<Componente>)(Session["componentes"]);
            //Identificamos el componente seleccionado 
            Componente componente = componentes.Find(x => x.Id.Equals(compId));
            //Identificamos las elementos de la aplicación 
            List<Elemento> elems = elementos;
            //Si queremos buscar por alguna propiedad del objeto .FindAll(x => x.App.Equals(compId));
            //Datos para la vista
            ViewBag.Componentes = componentes;
            ViewBag.CompElems = elems;
            ViewBag.Elementos = (List<Elemento>)(Session["elementos"]);
            //Devolvemos la vista correspondiente
            return View(componente);
        }
    }
}
