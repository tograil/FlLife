using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Fl.Admin.Identity
{
    public class FlUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Pasword { get; set; }
    }
}