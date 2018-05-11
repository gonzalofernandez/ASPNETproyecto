using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MaquetaAplicacion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Crud",
                url: "Crud/{action}/{id}",
                defaults: new { controller = "Crud", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Elemento",
                url: "Componente/{compId}/elemento/{elemId}",
                defaults: new { controller = "Elemento", action = "Show", compId = UrlParameter.Optional, elemId = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Componente",
                url: "Componente/{compId}",
                defaults: new { controller = "Componente", action = "Show", compId = UrlParameter.Optional } 
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
