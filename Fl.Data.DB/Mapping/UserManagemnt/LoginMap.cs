using System.Data.Entity.ModelConfiguration;
using Fl.Data.Core.Domain.UserManagement;

namespace Fl.Data.DB.Mapping.UserManagemnt
{
    public class LoginMap : EntityTypeConfiguration<Login>
    {
        public LoginMap()
        {
            ToTable("Logins");
            HasKey(t => t.Name);
            HasKey(t => t.Email);
            Property(t => t.Name).HasMaxLength(30).IsRequired();
            Property(t => t.Email).HasMaxLength(30).IsRequired();
            Property(t => t.Password).HasMaxLength(130).IsRequired();
            
            Property(t => t.UserId).IsRequired();

            Ignore(t => t.Id);
            Ignore(t => t.UserName);

            HasRequired(t => t.User).WithMany().HasForeignKey(t => t.UserId).WillCascadeOnDelete(true);
        }
    }
}
