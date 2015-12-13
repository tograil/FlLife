using System;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;
using Fl.Data.DB;
using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Identity
{
    public class FlUserStore : IUserStore<FlUser>, IUserLockoutStore<FlUser, string>, IUserPasswordStore<FlUser>
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
                _repository.Users.AddOrUpdate(user.Login.User);
                _repository.Logins.AddOrUpdate(user.Login);
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

        public Task<int> GetAccessFailedCountAsync(FlUser user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task<bool> GetLockoutEnabledAsync(FlUser user)
        {
            return Task.Factory.StartNew<bool>(() => false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(FlUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(FlUser user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task ResetAccessFailedCountAsync(FlUser user)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task SetLockoutEnabledAsync(FlUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(FlUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        #region IUserPasswordStore


        public Task SetPasswordHashAsync(FlUser user, string passwordHash)
        {
            return Task.Factory.StartNew(() => string.Empty);
        }

        public Task<string> GetPasswordHashAsync(FlUser user)
        {
            return Task.Factory.StartNew(() => user.Login.Password);
        }

        public Task<bool> HasPasswordAsync(FlUser user)
        {
            return Task.Factory.StartNew(() => true);
        }

        #endregion
    }
}