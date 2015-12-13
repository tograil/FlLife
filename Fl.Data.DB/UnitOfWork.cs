using Fl.Data.Core.Domain.UserManagement;
using Fl.Data.Core.Repositories;
using Fl.Data.DB.Repositories;

namespace Fl.Data.DB
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlDataContext _context;

        public UnitOfWork(FlDataContext context)
        {
            _context = context;

            Languages = new LanguageRepository(context);
            NewsPosts = new NewsPostRepository(context);
            Logins = new LoginRepository(context);
            Users = new Repository<User>(context);
        }

        public ILanguageRepository Languages { get; set; }

        public INewsPostRepository NewsPosts { get; set; }
        public ILoginRepository Logins { get; set; }
        public IRepository<User> Users { get; set; }

        public static UnitOfWork Create()
        {
            return new UnitOfWork(new FlDataContext());
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
