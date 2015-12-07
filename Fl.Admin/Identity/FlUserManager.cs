using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Fl.Admin.Identity
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