using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Fl.Admin.Identity
{
    public class FlUserStore : IUserStore<FlUser>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(FlUser user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FlUser user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(FlUser user)
        {
            throw new NotImplementedException();
        }

        public Task<FlUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<FlUser> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}