using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.Core.Domain.News;
using Fl.Data.Core.Domain.UserManagement;

namespace Fl.Data.DB
{
    public class FlDataContext : DbContext
    {
        public FlDataContext()
            : base("name=FlLife")
        {
            
            
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<NewsPost> NewsPosts { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<User> Users { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof (FlDataContext).Assembly);

            base.OnModelCreating(modelBuilder);

            
        }
    }
}
