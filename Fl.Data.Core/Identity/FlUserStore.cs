using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;
using Fl.Data.DB;
using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Identity
{
    public class FlUserStore : IUserStore<FlUser>
    {
        private readonly IUnitOfWork _repository;

        public FlUserStore(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            
        }

        public Task CreateAsync(FlUser user)
        {
            return Task.Factory.StartNew(() =>
            {
                _repository.Users.Add(user.Login.User);
                _repository.Logins.Add(user.Login);
                _repository.Commit();

            });
        }

        public Task UpdateAsync(FlUser user)
        {
            return CreateAsync(user);
        }

        public Task DeleteAsync(FlUser user)
        {
            var login = GetLoginUser(user.UserName);

            return Task.Factory.StartNew(() =>
            {
                _repository.Logins.Remove(login);
                _repository.Commit();
            });
        }

        public Task<FlUser> FindByIdAsync(string userId)
        {
            return FindByNameAsync(userId);
        }

        public Task<FlUser> FindByNameAsync(string userName)
        {

            var login = GetLoginUser(userName);

            return Task<FlUser>.Factory.StartNew(() => new FlUser
            {
                Id = login.Name,
                UserName = login.Name,
                Login = login
            });
        }

        private Login GetLoginUser(string name)
        {
            return _repository.Logins.GetLoginByName(name);
        } 
    }
}