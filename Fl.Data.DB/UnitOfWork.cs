using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public ILanguageRepository Languages { get; set; }

        public INewsPostRepository NewsPosts { get; set; }

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
