using System;
using System.Data.Entity.Utilities;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace Fl.Data.Core.Identity
{
    public class FlSignInManager : SignInManager<FlUser, string>
    {
        public FlSignInManager(UserManager<FlUser, string> userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(FlUser user)
        {
            return user.GenerateUserIdentityAsync((FlUserManager) UserManager);
        }

        public FlUserManager FlUserManager => UserManager as FlUserManager;

        public override async Task SignInAsync(
        FlUser user,
        bool isPersistent,
        bool rememberBrowser)
        {
            var userIdentity = await CreateUserIdentityAsync(user).WithCurrentCulture();

            // Clear any partial cookies from external or two factor partial sign ins
            AuthenticationManager.SignOut(
                DefaultAuthenticationTypes.ExternalCookie,
                DefaultAuthenticationTypes.TwoFactorCookie);

            if (rememberBrowser)
            {
                var rememberBrowserIdentity = AuthenticationManager
                    .CreateTwoFactorRememberBrowserIdentity(ConvertIdToString(user.Id));

                AuthenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    userIdentity,
                    rememberBrowserIdentity);
            }
            else
            {
                AuthenticationManager.SignIn(
                    new AuthenticationProperties { IsPersistent = isPersistent },
                    userIdentity);
            }
        }

        private async Task<SignInStatus> SignInOrTwoFactor(FlUser user, bool isPersistent)
        {
            var id = Convert.ToString(user.Id);

            if (UserManager.SupportsUserTwoFactor
                && await UserManager.GetTwoFactorEnabledAsync(user.Id)
                                    .WithCurrentCulture()
                && (await UserManager.GetValidTwoFactorProvidersAsync(user.Id)
                                     .WithCurrentCulture()).Count > 0
                    && !await AuthenticationManager.TwoFactorBrowserRememberedAsync(id)
                                                   .WithCurrentCulture())
            {
                var identity = new ClaimsIdentity(
                    DefaultAuthenticationTypes.TwoFactorCookie);

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, id));

                AuthenticationManager.SignIn(identity);

                return SignInStatus.RequiresVerification;
            }
            await SignInAsync(user, isPersistent, false).WithCurrentCulture();
            return SignInStatus.Success;
        }

        public override async Task<SignInStatus> PasswordSignInAsync(
            string userName,
            string password,
            bool isPersistent,
            bool shouldLockout)
        {
            if (UserManager == null)
            {
                return SignInStatus.Failure;
            }

            var user = await FlUserManager.FindByNameAsync(userName).WithCurrentCulture();
            if (user == null)
            {
                return SignInStatus.Failure;
            }

            if (UserManager.SupportsUserLockout
                && await FlUserManager.IsLockedOutAsync(user.Id).WithCurrentCulture())
            {
                return SignInStatus.LockedOut;
            }

            if (UserManager.SupportsUserPassword
                && await FlUserManager.CheckPasswordAsync(user, password)
                                    .WithCurrentCulture())
            {
                return await SignInOrTwoFactor(user, isPersistent).WithCurrentCulture();
            }
            if (shouldLockout && UserManager.SupportsUserLockout)
            {
                await UserManager.AccessFailedAsync(user.Id).WithCurrentCulture();
                if (await UserManager.IsLockedOutAsync(user.Id).WithCurrentCulture())
                {
                    return SignInStatus.LockedOut;
                }
            }
            return SignInStatus.Failure;
        }
    }
}
