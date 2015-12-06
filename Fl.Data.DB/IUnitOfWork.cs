using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.DB.Repositories;

namespace Fl.Data.DB
{
    public interface IUnitOfWork : IDisposable
    {
        ILanguageRepository Languages { get; set; }
        INewsPostRepository NewsPosts { get; set; }

        int Commit();
    }
}
