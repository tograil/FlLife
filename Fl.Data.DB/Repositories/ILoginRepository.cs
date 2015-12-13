using Fl.Data.Core.Domain.UserManagement;

namespace Fl.Data.DB.Repositories
{
    public interface ILoginRepository : IRepository<Login>
    {
        Login GetLoginByName(string name);
    }
}
