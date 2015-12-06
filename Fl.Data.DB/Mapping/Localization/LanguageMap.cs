using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.Localization;

namespace Fl.Data.DB.Mapping.Localization
{
    public class LanguageMap : EntityTypeConfiguration<Language>
    {
        public LanguageMap()
        {
            ToTable("Language");
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired().HasMaxLength(30);
            Property(t => t.ShortName).IsRequired().HasMaxLength(3);
            Property(t => t.CultureCode).IsRequired().HasMaxLength(10);
            Property(t => t.IsActive).IsRequired();
            Property(t => t.Order).IsRequired();
        }
    }
}
