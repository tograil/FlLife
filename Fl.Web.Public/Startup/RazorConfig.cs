using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }

        public bool AutoIncludeModelNamespace => true;
    }
}