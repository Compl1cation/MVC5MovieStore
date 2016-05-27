using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5MovieStore.Models
{
    public class MovieStoreDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MovieStoreDB>
    {
        protected override void Seed(MovieStoreDB context)
        {
            context.Directors.Add(new Director { Name = "Steven Speilberg" });
            context.YearRanges.Add(new YearRange { Range = "2000 - 2005" });
            context.Genres.Add(new Genre { Name = "SciFi", Description=" Best" });
            context.Genres.Add(new Genre { Name = "Adventure", Description = "2nd Best" });
            context.Genres.Add(new Genre {Name ="Drama", Description ="Women love it"});
            context.Movies.Add(new Movie
               {
                   Title = "Star Wars: Episode IV A new Hope",
                   Director = new Director { Name = "George Lucas" },
                   YearRange = new YearRange { Range = "1975 - 1979" },
                   Year = 1977,
                   Price = 7.39,
                   Rating = 10,
               });
            context.Movies.Add(new Movie
            {
                Title = "Sunshine",
                Director = new Director { Name = "Danny Boyle" },
                Year = 2007,
                Price = 12.14,
                Rating = 9,
            });


            context.Movies.Add(new Movie
            {
                Title = "The Hurt Locker",
                Director = new Director { Name = "Kathryn Bigelow" },
                YearRange = new YearRange { Range = "2005 - 2009" },
                Year = 2008,
                Price = 14.29,
                Rating = 9,


            });
            context.Movies.Add(new Movie
                {
                    Title = "Gattaca",
                    Director = new Director { Name = "Andrew Niccol" },
                    YearRange = new YearRange { Range = "1995 - 1999" },
                    Year = 1997,
                    Price = 13.49,
                    Rating = 9,
                });

                        context.Movies.Add(new Movie
                {Title = "Black Hawk Down",
                    Director = new Director {Name="Steven Speilberg"},
                    YearRange = new YearRange {Range = "2000 - 2005"},
                    Year =2001,
                    Price =7.69,
                    Rating =7,
                });
            base.Seed(context);
        }

    }
}
