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
            Property(t => t.Password).HasMaxLength(30).IsRequired();
            Property(t => t.Salt).HasMaxLength(30).IsRequired();
        }
    }
}
