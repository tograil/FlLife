using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.Localization;

namespace Fl.Data.DB.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Language GetLanguage(string shortName);
        IEnumerable<Language> GetAllAciveOrdered();
    }
}
