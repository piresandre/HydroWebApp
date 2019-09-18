using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hydro
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Dashboard",
                url: "Dashboard/MainDashboard/{codCliente}",
                defaults: new { controller = "Dashboard", action = "MainDashboard", codCliente = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cadastrar",
                url: "Login/Cadastrar",
                defaults: new { controller = "Login", action = "FormCadastro"}
            );
            routes.MapRoute(
                name: "Login",
                url: "Login/Login",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Introducing", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
