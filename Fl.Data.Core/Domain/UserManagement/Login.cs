namespace Fl.Data.Core.Domain.UserManagement
{
    public class Login
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string Salt { get; set; }

        public int UserId { get; set; }
        public UserManagement.User User { get; set; }
    }
}
