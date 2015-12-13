using Microsoft.AspNet.Identity;

namespace Fl.Data.Core.Identity
{
    public class FlPasswordHasher : PasswordHasher
    {
        private readonly string _salt;

        public FlPasswordHasher(string salt)
        {
            _salt = salt;
        }

        public override string HashPassword(string password)
        {
            password = string.Concat(password, _salt);
            
            return base.HashPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            providedPassword = HashPassword(providedPassword);

            return hashedPassword.Equals(providedPassword) ? PasswordVerificationResult.Success : PasswordVerificationResult.Failed;
        }
    }
}