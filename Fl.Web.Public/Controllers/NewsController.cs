using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using Fl.Data.Core.Domain.News;
using Fl.Data.DB;
using Fl.Web.Public.Models.News;

namespace Fl.Web.Public.Controllers
{
    [RoutePrefix("api/news")]
    [Route("{action}")]
    public class NewsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("news/{locale}")]
        public IHttpActionResult Get(string locale)
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

        public IHttpActionResult List([FromBody]NewsParams locale)
        {
            var news  = _unitOfWork.NewsPosts.GetAllPostsByLocaleAndType(locale.Locale, locale.Type).Select(newsItem => new
            {
                newsItem.Title,
                DateString = newsItem.PostDate.ToString("D", new CultureInfo(locale.Locale)),
                newsItem.Body
            });

            return Ok(news);
        }


    }
}
