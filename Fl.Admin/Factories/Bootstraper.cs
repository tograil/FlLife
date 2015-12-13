using System.Web.Mvc;
using Fl.Admin.Controllers;
using Fl.Data.DB;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;

namespace Fl.Admin.Factories
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            return container;
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUnitOfWork, UnitOfWork>();

            container.RegisterType<AccountController>(new InjectionConstructor(new ResolvedParameter(typeof(IUnitOfWork))));
            container.RegisterType<HomeController>(new InjectionConstructor(new ResolvedParameter(typeof(IUnitOfWork))));
            MvcUnityContainer.Container = container;
            return container;
        }
    }
}