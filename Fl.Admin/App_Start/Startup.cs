using Fl.Admin;
using Fl.Data.Core.Identity;
using Fl.Data.DB;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace Fl.Admin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUnitOfWork>(UnitOfWork.Create);
            app.CreatePerOwinContext<FlUserManager>(CreateUserManager);
            app.CreatePerOwinContext<FlSignInManager>(CreateSignInManager);
            

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
        }

        public static FlUserManager CreateUserManager(IdentityFactoryOptions<FlUserManager> options,
            IOwinContext context)
        {
            var userManager = new FlUserManager(new FlUserStore(context.Get<IUnitOfWork>()));

            return userManager;

        }

        public static FlSignInManager CreateSignInManager(IdentityFactoryOptions<FlSignInManager> options, IOwinContext context)
        {
            return new FlSignInManager(context.GetUserManager<FlUserManager>(), context.Authentication);
        }
    }
}
