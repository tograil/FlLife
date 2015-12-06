namespace Fl.Data.Core.Domain.Localization
{
    public class Language
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }

        public string CultureCode { get; set; }

        public bool IsActive { get; set; }

        public int Order { get; set; }
    }
}
