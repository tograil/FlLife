using System.Data.Entity.ModelConfiguration;
using Fl.Data.Core.Domain.UserManagement;

namespace Fl.Data.DB.Mapping.UserManagemnt
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");
            HasKey(t => t.Id);
            Property(t => t.FirstName).HasMaxLength(30).IsRequired();
            Property(t => t.LastName).HasMaxLength(30).IsRequired();

        }
    }
}
