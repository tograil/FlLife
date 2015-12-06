using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fl.Data.Core.Domain.Localization;

namespace Fl.Data.DB.Repositories
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext context) : base(context)
        {
        }

        public Language GetLanguage(string shortName)
        {
            return FlDataContext.Languages.Single(l => l.ShortName.Equals(shortName));
        }

        public IEnumerable<Language> GetAllAciveOrdered()
        {
            return FlDataContext.Languages.Where(l => l.IsActive).OrderBy(l => l.Order);
        }

        public FlDataContext FlDataContext => Context as FlDataContext;
    }
}
