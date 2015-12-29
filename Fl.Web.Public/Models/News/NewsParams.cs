using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fl.Data.Core;

namespace Fl.Web.Public.Models.News
{ 
    public class NewsParams
    {
        public string Locale { get; set; }
        public Constants.NewsType Type { get; set; }
    }
}