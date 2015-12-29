using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.Localization;

namespace Fl.Web.Public.General
{
    public interface ILanguages
    {
        ICollection<Language> GetAllActive();
    }
}
