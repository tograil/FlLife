using System.Collections.Generic;
using System.Globalization;

namespace Fl.Web.Public.General
{
    public class GeneralConstants
    {

        public const string DefaultLanguage = "RU";

        public static readonly Dictionary<string, CultureInfo> Languages = new Dictionary<string, CultureInfo>  
        {
            { "EN", new CultureInfo("en-US")},
            { "RU", new CultureInfo("ru-RU")},
            { "UK", new CultureInfo("uk-UA")}
        };

        public static string CurrentLanguage { get; set; } = DefaultLanguage;
    }
}
