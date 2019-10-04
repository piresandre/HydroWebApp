using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Hydro
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Consumo",
                routeTemplate: "api/{Consumo}/{id}",
                defaults: new { controller = "Consumo", id = RouteParameter.Optional }
            );
        }
    }
}
