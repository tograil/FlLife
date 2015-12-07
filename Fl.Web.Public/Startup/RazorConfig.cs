using System.Collections.Generic;
using Nancy.ViewEngines.Razor;

namespace Fl.Web.Public.Startup
{
    public class RazorConfig : IRazorConfiguration
    {
        public IEnumerable<string> GetAssemblyNames()
        {
            yield return "Fl.Web.Public";
            yield return "Fl.Data.Core";
        }

        public IEnumerable<string> GetDefaultNamespaces()
        {
            yield return "Fl.Web.Public";
            yield return "Fl.Data.Core";
            yield return "System.Globalization";
            yield return "System.Collections.Generic";
            yield return "System.Linq";
        }

        public bool AutoIncludeModelNamespace => true;
    }
}