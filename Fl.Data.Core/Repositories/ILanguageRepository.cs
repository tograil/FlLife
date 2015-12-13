using System.Collections.Generic;
using Fl.Data.Core.Domain.Localization;

namespace Fl.Data.Core.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Language GetLanguage(string shortName);
        IEnumerable<Language> GetAllAciveOrdered();
    }
}
