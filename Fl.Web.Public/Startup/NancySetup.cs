using System.Globalization;
using System.Linq;
using Nancy.Bootstrapper;
using Nancy.Session;
using Fl.Web.Public.General;

namespace Fl.Web.Public.Startup
{
    public class NancySetup : IApplicationStartup
    {
        public void Initialize(IPipelines pipelines)
        {
            CookieBasedSessions.Enable(pipelines);

            pipelines.AfterRequest.AddItemToStartOfPipeline(ctx =>
            {
                var language = ctx.Request.Cookies.ContainsKey("language") ? ctx.Request.Cookies["language"] : "RU";

                if (!Languages.GetAllActive().Any(lng => lng.ShortName.Equals(language)))
                {
                    language = GeneralConstants.DefaultLanguage;
                }

                GeneralConstants.CurrentLanguage = language;
                
                ctx.Culture = new CultureInfo(Languages.GetLanguage(language).CultureCode);
            });
        }
    }
}