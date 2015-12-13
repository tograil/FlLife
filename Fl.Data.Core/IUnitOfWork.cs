using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;
using Fl.Data.Core.Repositories;

namespace Fl.Data.DB
{
    public interface IUnitOfWork : IDisposable
    {
        ILanguageRepository Languages { get; set; }
        INewsPostRepository NewsPosts { get; set; }
        ILoginRepository Logins { get; set; }
        IRepository<User> Users { get; set; }

        int Commit();
    }
}
