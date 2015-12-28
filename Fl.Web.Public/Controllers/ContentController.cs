using System.Collections;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web.Http;

namespace Fl.Web.Public.Controllers
{
    public class ContentController : ApiController
    {
        public IHttpActionResult Get()
        {
            var resourceSet = new ResourceManager("Resources.Navigation.Navigation", Assembly.GetExecutingAssembly()).GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            var resources = resourceSet.Cast<DictionaryEntry>()
                .ToDictionary(x => x.Key.ToString(),
                    x => x.Value.ToString());

            return Ok(resources);
        }
    }
}
