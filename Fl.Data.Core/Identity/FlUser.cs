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
    }
}