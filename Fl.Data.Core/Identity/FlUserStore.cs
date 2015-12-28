using System;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;
using Fl.Data.DB;
using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Identity
{
    public class FlUserStore : IUserStore<Login>, IUserLockoutStore<Login, string>, IUserPasswordStore<Login>
    {
        private readonly IUnitOfWork _repository;

        public FlUserStore(IUnitOfWork repository)
        {
            _repository = repository;
        }

        public void Dispose()
        {
            
        }

        public Task CreateAsync(Login login)
        {
            return Task.Factory.StartNew(() =>
            {
                _repository.Users.AddOrUpdate(login.User);
                _repository.Logins.AddOrUpdate(login);
                _repository.Commit();

            });
        }

        public Task UpdateAsync(Login login)
        {
            return CreateAsync(login);
        }

        public Task DeleteAsync(Login login)
        {
            return Task.Factory.StartNew(() =>
            {
                _repository.Logins.Remove(login);
                _repository.Commit();
            });
        }

        public Task<Login> FindByIdAsync(string userId)
        {
            return FindByNameAsync(userId);
        }

        public Task<Login> FindByNameAsync(string userName)
        {

            var login = GetLoginUser(userName);

            return Task<Login>.Factory.StartNew(() => login);
        }

        private Login GetLoginUser(string name)
        {
            return _repository.Logins.GetLoginByName(name);
        }

        public Task<int> GetAccessFailedCountAsync(Login login)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task<bool> GetLockoutEnabledAsync(Login login)
        {
            return Task.Factory.StartNew(() => false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(Login login)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(Login login)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task ResetAccessFailedCountAsync(Login login)
        {
            return Task.Factory.StartNew(() => 0);
        }

        public Task SetLockoutEnabledAsync(Login login, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEndDateAsync(Login login, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        #region IUserPasswordStore


        public Task SetPasswordHashAsync(Login login, string passwordHash)
        {
            return Task.Factory.StartNew(() => string.Empty);
        }

        public Task<string> GetPasswordHashAsync(Login login)
        {
            return Task.Factory.StartNew(() => login.Password);
        }

        public Task<bool> HasPasswordAsync(Login login)
        {
            return Task.Factory.StartNew(() => true);
        }

        #endregion
    }
}