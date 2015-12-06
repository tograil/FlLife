using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.Core.Domain.News;

namespace Fl.Data.DB.Repositories
{
    public interface INewsPostRepository : IRepository<NewsPost>
    {
        IEnumerable<NewsPost> GetAllPostsByLanguage(Language language);

        IEnumerable<NewsPost> GetAllPostsByLanguageShortName(string languageShortName);
    }
}
