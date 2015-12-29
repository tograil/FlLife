using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fl.Data.Core;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.Core.Domain.News;
using Fl.Data.Core.Repositories;

namespace Fl.Data.DB.Repositories
{
    public class NewsPostRepository : Repository<NewsPost>, INewsPostRepository
    {
        public NewsPostRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<NewsPost> GetAllPostsByLanguage(Language language)
        {
            return FlDataContext.NewsPosts.Include(np => np.Language).Where(np => np.LanguageId == language.Id).ToArray();
        }

        public IEnumerable<NewsPost> GetAllPostsByLanguageShortName(string languageShortName)
        {
            return FlDataContext.NewsPosts.Include(np => np.Language).Where(np => np.Language.ShortName.Equals(languageShortName)).ToArray();
        }

        public IEnumerable<NewsPost> GetAllPostsByLocaleAndType(string locale, Constants.NewsType type)
        {
            return FlDataContext.NewsPosts.Include(np => np.Language).Where(np => np.Language.CultureCode.Equals(locale) && np.NewsType == type).OrderByDescending(np => np.PostDate).ToArray();
        }

        public FlDataContext FlDataContext => Context as FlDataContext;
    }
}
