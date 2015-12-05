using System.Collections.Generic;
using System.Web.Http;
using Fl.Data.Core.Domain.News;

namespace Fl.Web.Public.Controllers
{
    public class NewsController : ApiController
    {
        public IHttpActionResult Get()
        {
            var news = new List<NewsPost>
            {
                new NewsPost
                {
                    Title = "New Title",
                    Body = "Lorem Ipsum Dolor"
                }
            };

            return Ok(news);
        }
    }
}
