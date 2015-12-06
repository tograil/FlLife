using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Fl.Data.Core.Domain.Localization;

namespace Fl.Data.Core.Domain.News
{
    public class NewsPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public DateTime PostDate { get; set; } = DateTime.Now;

        public int LanguageId { get; set; }

        public Language Language { get; set; }
    }
}
