using Nancy;
using Nancy.Cookies;
using Nancy.Responses;

namespace Fl.Web.Public.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = Index;
            Get["/language/{language}/backurl/{backurl}"] = ChangeLanguage;
            Get["/language/{language}/backurl/"] = ChangeLanguage;
        }

        private dynamic Index(dynamic o)
        {
            return View["Index"];
        }

        private static dynamic ChangeLanguage(dynamic parameters)
        {
            var response = new RedirectResponse("/" + parameters.backurl);

            response.Cookies.Add(new NancyCookie("language", parameters.language));

            return response;
        }
    }
}