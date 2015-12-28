using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Fl.Data.DB;
using Microsoft.Practices.Unity;

namespace Fl.Web.Public.Startup
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                name: "AllNews",
                routeTemplate: "news",
                defaults: new { controller = "News", action = "Get" }
                );

            config.Routes.MapHttpRoute(
                name: "AllContent",
                routeTemplate: "content",
                defaults: new { controller = "Content", action = "Get" }
                );
        }
    }
}