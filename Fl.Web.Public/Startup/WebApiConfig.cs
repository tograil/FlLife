using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Fl.Data.DB;
using Fl.Web.Public.General;
using Microsoft.Practices.Unity;

namespace Fl.Web.Public.Startup
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());
            container.RegisterType<ILanguages, Languages>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional });
        }
    }
}