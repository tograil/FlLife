using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;

namespace Fl.Data.Core.Identity
{
    public class FlUserManager : UserManager<Login>
    {
        public FlUserManager(IUserStore<Login> store) : base(store)
        {

        }

        public override async Task<Login> FindAsync(string userName, string password)
        {
            var login = await Store.FindByNameAsync(userName);

            var passwordHasher = new FlPasswordHasher();

            var result = passwordHasher.VerifyHashedPassword(login.Password, password);

            return result == PasswordVerificationResult.Success ? login : null;
        }

        public override Task<bool> CheckPasswordAsync(Login login, string password)
        {
            var passwordHasher = new FlPasswordHasher();

            var result = passwordHasher.VerifyHashedPassword(login.Password, password);

            return Task.Factory.StartNew(() => result == PasswordVerificationResult.Success);
        }
    }
}