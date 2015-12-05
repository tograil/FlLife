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

                if (!GeneralConstants.Languages.ContainsKey(language))
                {
                    language = GeneralConstants.DefaultLanguage;
                }

                GeneralConstants.CurrentLanguage = language;
                
                ctx.Culture = GeneralConstants.Languages[language];
            });
        }
    }
}