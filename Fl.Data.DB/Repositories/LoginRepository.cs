using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;

namespace Fl.Data.DB.Repositories
{
    public class LoginRepository : Repository<Login>, ILoginRepository
    {
        public LoginRepository(FlDataContext context) : base(context)
        {
        }

        public Login GetLoginByName(string name)
        {
            return FlDataContext.Logins.Include(l => l.User).Single(l => l.Name.Equals(name));
        }

        public FlDataContext FlDataContext => Context as FlDataContext;
    }
}
