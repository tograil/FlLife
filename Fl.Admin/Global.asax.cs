using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Fl.Admin.Factories;

namespace Fl.Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Initialize IoC container/Unity
            Bootstrapper.Initialise();
            //Register our custom controller factory
            ControllerBuilder.Current.SetControllerFactory(typeof(ControllerFactory));
        }
    }
}
