using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            return FlDataContext.NewsPosts.Include(np => np.Language).Where(np => np.LanguageId == language.Id);
        }

        public IEnumerable<NewsPost> GetAllPostsByLanguageShortName(string languageShortName)
        {
            return FlDataContext.NewsPosts.Include(np => np.Language).Where(np => np.Language.ShortName.Equals(languageShortName));
        }

        public FlDataContext FlDataContext => Context as FlDataContext;
    }
}
