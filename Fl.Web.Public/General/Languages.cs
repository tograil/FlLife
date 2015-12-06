using System.Collections.Generic;
using System.Linq;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.DB;

namespace Fl.Web.Public.General
{
    public abstract class Languages
    {
        protected static IUnitOfWork UnitOfWork { get; set; }

        protected static ICollection<Language> LanguagesList = null;

        protected static object Locker = new object();

        public static Language GetLanguage(string code)
        {
            return GetAllActive().Single(language => language.ShortName.Equals(code));
        }

        public static ICollection<Language> GetAllActive()
        {
            lock (Locker)
            {
                return LanguagesList ?? (LanguagesList = UnitOfWork.Languages.GetAllAciveOrdered().ToArray());
            } 
        }
    }
}