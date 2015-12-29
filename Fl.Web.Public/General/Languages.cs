using System.Collections.Generic;
using System.Linq;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.DB;

namespace Fl.Web.Public.General
{
    public class Languages : ILanguages
    {
        public Languages(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private readonly IUnitOfWork _unitOfWork;

        protected ICollection<Language> LanguagesList = null;

        protected object Locker = new object();

        public Language GetLanguage(string code)
        {
            return GetAllActive().Single(language => language.ShortName.Equals(code));
        }

        public ICollection<Language> GetAllActive()
        {
            lock (Locker)
            {
                return LanguagesList ?? (LanguagesList = _unitOfWork.Languages.GetAllAciveOrdered().ToArray());
            } 
        }
    }
}