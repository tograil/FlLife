using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Fl.Web.Public.Startup
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "AllNews",
                routeTemplate: "news",
                defaults: new { controller = "News", action = "Get" }
                );
        }
    }
}