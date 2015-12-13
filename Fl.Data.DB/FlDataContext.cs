using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb, ex
                    ); 
            }
        }
    }
}
