using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fl.Data.Core.Domain.News;

namespace Fl.Data.DB.Mapping.News
{
    public class NewsPostMap : EntityTypeConfiguration<NewsPost>
    {
        public NewsPostMap()
        {
            ToTable("NewsPosts");
            HasKey(t => t.Id);
            Property(t => t.Title).HasMaxLength(120).IsUnicode(true).IsRequired();
            Property(t => t.Body).IsRequired().IsMaxLength().IsUnicode(true);
            Property(t => t.PostDate).IsRequired();

            HasRequired(t => t.Language).WithMany().HasForeignKey(t => t.LanguageId).WillCascadeOnDelete(true);
        }
    }
}
