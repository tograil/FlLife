using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Domain.UserManagement
{
    public class Login : IUser
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }

        public string Id => Name;

        public string UserName
        {
            get
            {
              return Name;  
            }

            set { }
        }
    }
}
