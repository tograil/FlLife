using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Identity
{
    public class FlUserManager : UserManager<FlUser>
    {
        public FlUserManager(IUserStore<FlUser> store) : base(store)
        {

        }

        public async override Task<FlUser> FindAsync(string userName, string password)
        {
            var user = await Store.FindByNameAsync(userName);

            var passwordHasher = new FlPasswordHasher(user.Login.Salt);

            var result = passwordHasher.VerifyHashedPassword(user.Login.Password, password);

            return result == PasswordVerificationResult.Success ? user : null;
        }
    }
}