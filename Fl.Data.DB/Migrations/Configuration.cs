using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Fl.Data.Core.Domain.Localization;
using Fl.Data.Core.Domain.News;

namespace Fl.Data.DB.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<FlDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Fl.Data.Core";
        }

        protected override void Seed(FlDataContext context)
        {
            var languages = new []
            {
                new Language { Id = 1, Name = "English", ShortName = "EN", CultureCode = "en-US", IsActive = true, Order = 2 },
                new Language { Id = 2, Name = "Russian", ShortName = "RU", CultureCode = "ru-RU", IsActive = true, Order = 1 },
                new Language { Id = 3, Name = "Ukrainian", ShortName = "UK", CultureCode = "uk-UA", IsActive = true, Order = 3 }
            };

            context.Languages.AddOrUpdate(languages);

            NewsSeed(context, languages);
        }

        private static void NewsSeed(FlDataContext context, ICollection<Language> languages)
        {
            var news = new[]
            {
                new NewsPost
                {
                    Id = 1,
                    Title = "Preventing Burnout",
                    Body = @"Burnout is very real in this field, and is common among social service occupations in general.
                            The work that we do, while extremely rewarding, can also be challenging, frustrating, disappointing, and sometimes dangerous (such as with aggressive clients). Since we are all only human, we are not immune to burnout.
                            Staff who are experiencing burnout are sloppy at their work, they make careless mistakes, they “go through the motions” without actually trying to connect with their clients, or they are snippy and irritable where they should be patient and persistent.
                            sometimes you can’t tell when you are burned out on a client, or on a job, and may think you are just temporarily tired, overwhelmed, or stressed. It’s important to regularly monitor and assess your emotional state, because you won’t be an effective professional when you are experiencing burnout and you also won’t draw satisfaction and joy from your work. Ideally, management / supervisors will be monitoring staff for signs and indications of burnout, and / or creating systems intended to minimize burnout(such as small caseloads).However, I recommend assessing yourself on a regular basis to be sure you aren’t experiencing burnout.
                            I have learned over the years to monitor my own emotional state to make sure I am far away from reaching burnout levels.I know when to decline clients or refer out, I know when to seek out help or feedback from my colleagues, and I know how to maintain a healthy life / work balance…..but I didn’t start out in this field knowing all of that.",
                    LanguageId = languages.Single(l => l.ShortName == "EN").Id,
                    Language = languages.Single(l => l.ShortName == "EN")
                },
                new NewsPost
                {
                    Id = 2,
                    Title = "Preventing Burnout (Russian)",
                    Body = @"(Russian) Burnout is very real in this field, and is common among social service occupations in general.
                            The work that we do, while extremely rewarding, can also be challenging, frustrating, disappointing, and sometimes dangerous (such as with aggressive clients). Since we are all only human, we are not immune to burnout.
                            Staff who are experiencing burnout are sloppy at their work, they make careless mistakes, they “go through the motions” without actually trying to connect with their clients, or they are snippy and irritable where they should be patient and persistent.
                            sometimes you can’t tell when you are burned out on a client, or on a job, and may think you are just temporarily tired, overwhelmed, or stressed. It’s important to regularly monitor and assess your emotional state, because you won’t be an effective professional when you are experiencing burnout and you also won’t draw satisfaction and joy from your work. Ideally, management / supervisors will be monitoring staff for signs and indications of burnout, and / or creating systems intended to minimize burnout(such as small caseloads).However, I recommend assessing yourself on a regular basis to be sure you aren’t experiencing burnout.
                            I have learned over the years to monitor my own emotional state to make sure I am far away from reaching burnout levels.I know when to decline clients or refer out, I know when to seek out help or feedback from my colleagues, and I know how to maintain a healthy life / work balance…..but I didn’t start out in this field knowing all of that.",
                    LanguageId = languages.Single(l => l.ShortName == "RU").Id,
                    Language = languages.Single(l => l.ShortName == "RU")
                },
                new NewsPost
                {
                    Id = 3,
                    Title = "Preventing Burnout (Ukrainian)",
                    Body = @"(Ukrainian) Burnout is very real in this field, and is common among social service occupations in general.
                            The work that we do, while extremely rewarding, can also be challenging, frustrating, disappointing, and sometimes dangerous (such as with aggressive clients). Since we are all only human, we are not immune to burnout.
                            Staff who are experiencing burnout are sloppy at their work, they make careless mistakes, they “go through the motions” without actually trying to connect with their clients, or they are snippy and irritable where they should be patient and persistent.
                            sometimes you can’t tell when you are burned out on a client, or on a job, and may think you are just temporarily tired, overwhelmed, or stressed. It’s important to regularly monitor and assess your emotional state, because you won’t be an effective professional when you are experiencing burnout and you also won’t draw satisfaction and joy from your work. Ideally, management / supervisors will be monitoring staff for signs and indications of burnout, and / or creating systems intended to minimize burnout(such as small caseloads).However, I recommend assessing yourself on a regular basis to be sure you aren’t experiencing burnout.
                            I have learned over the years to monitor my own emotional state to make sure I am far away from reaching burnout levels.I know when to decline clients or refer out, I know when to seek out help or feedback from my colleagues, and I know how to maintain a healthy life / work balance…..but I didn’t start out in this field knowing all of that.",
                    LanguageId = languages.Single(l => l.ShortName == "UK").Id,
                    Language = languages.Single(l => l.ShortName == "UK")
                }
            };

            context.NewsPosts.AddOrUpdate(news);
        }
    }
}
