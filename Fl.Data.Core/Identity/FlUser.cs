using System.Security.Claims;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.UserManagement;
using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Identity
{
    public class FlUser : IUser
    {
        public string Id { get; set; }

        public string UserName
        {
            get { return string.Join(" ", Login.User.FirstName, Login.User.LastName); }
            set
            {
            }
        }

        public Login Login { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<FlUser> manager)
        {
            
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            
            return userIdentity;
        }
    }
}