using System.Collections.Generic;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.Core.Domain.News;

namespace Fl.Data.Core.Repositories
{
    public interface INewsPostRepository : IRepository<NewsPost>
    {
        IEnumerable<NewsPost> GetAllPostsByLanguage(Language language);

        IEnumerable<NewsPost> GetAllPostsByLanguageShortName(string languageShortName);
    }
}
