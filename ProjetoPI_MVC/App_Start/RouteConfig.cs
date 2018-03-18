using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoPI_MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Voluntariar",
                url: "Ong/Voluntariar/{id}",
                defaults: new { controller = "Ong", action = "Voluntariar", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Ong",
                url: "Ong/{id}",
                defaults: new { controller = "Ong", action = "Index" }
            );
                      
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
