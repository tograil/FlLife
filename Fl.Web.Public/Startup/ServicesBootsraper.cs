using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fl.Data.DB;
using Fl.Web.Public.General;
using Nancy;
using Nancy.TinyIoc;

namespace Fl.Web.Public.Startup
{
    public class ServicesBootsraper : DefaultNancyBootstrapper
    {
        // ReSharper disable once ClassNeverInstantiated.Local
        private class ConcreteLanguages : Languages
        {
            public static void InitRepository(IUnitOfWork unitOfWork)
            {
                UnitOfWork = unitOfWork;
            }
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            var uow = container.Resolve<IUnitOfWork>();
            
            ConcreteLanguages.InitRepository(uow);
        }
    }
}