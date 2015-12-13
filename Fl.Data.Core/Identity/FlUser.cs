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
            get { return Login.Name; }
            set
            {
                if (Login == null)
                {
                    Login = new Login
                    {
                        Name = value
                    };
                }
            }
        }

        public Login Login { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<FlUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}