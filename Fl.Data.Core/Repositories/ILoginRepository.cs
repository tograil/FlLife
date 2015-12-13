using Fl.Data.Core.Domain.UserManagement;

namespace Fl.Data.Core.Repositories
{
    public interface ILoginRepository : IRepository<Login>
    {
        Login GetLoginByName(string name);
    }
}
