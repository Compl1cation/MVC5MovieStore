namespace MVC5MovieStore.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using MVC5MovieStore.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<MVC5MovieStore.Models.MovieStoreDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MVC5MovieStore.Models.MovieStoreDB";
        }

        protected override void Seed(MVC5MovieStore.Models.MovieStoreDB context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
          /*
            var direct = new List<Director>
            {
            new Director { Name = "Steven Speilberg"},
            new Director { Name = "George Lucas" },
           new Director { Name = "Danny Boyle" },
            new Director { Name = "Kathryn Bigelow" },
            new Director { Name = "Andrew Niccol" }
          };
          direct.ForEach(d => context.Directors.AddOrUpdate(p => p.Name, d));
          context.SaveChanges();
          */
            /*
            var gen = new List<Genre>{
            new Genre { Name = "SciFi", Description = "Science fiction is a genre of speculative fiction dealing with imaginative concepts such as futuristic settings, futuristic science and technology, space travel, time travel, faster than light travel, parallel universes and extraterrestrial life." },
            new Genre { Name = "Comedy", Description = "Comedy is a genre of film in which the main emphasis is on humour. These films are designed to make the audience laugh through amusement, and most often work by exaggerating characteristics for humorous effect. Films in this style traditionally have a happy ending, the black comedy being an exception." },
            new Genre { Name = "Drama", Description = "In the context of film, television, and radio, drama describes a genre of narrative fiction or semi-fiction intended to be more serious than humorous in tone, focusing on in-depth development of realistic characters who must deal with realistic emotional struggles." },
            new Genre { Name = "Action", Description = "Action film is a film genre in which one or more heroes are thrust into a series of challenges that typically include physical feats, extended fight scenes, violence, and frantic chases." },
            new Genre { Name = "Fantasy", Description = "Fantasy is a genre of fiction that uses magic or other supernatural elements as a main plot element, theme, or setting." },
            new Genre { Name = "War", Description = "War film is a film genre concerned with warfare, typically about naval, air, or land battles in the twentieth century, with combat scenes central to the drama."}
          };
            gen.ForEach(g => context.Genres.AddOrUpdate(q => q.Name, g));
            context.SaveChanges();
            

            var year = new List<YearRange>{
            new YearRange { Range = "1950 - 1954"},
            new YearRange { Range = "1955 - 1959"},
            new YearRange { Range = "1960 - 1964"},
            new YearRange { Range = "1965 - 1969"},
            new YearRange { Range = "1970 - 1974"},
             
         //   new YearRange { Range = "1975 - 1979"},
          //  new YearRange { Range = "1980 - 1984"},
          //  new YearRange { Range = "1985 - 1989"},
          //  new YearRange { Range = "1990 - 1994"},
          //  new YearRange { Range = "1995 - 1999"},
          //  new YearRange { Range = "2000 - 2004"},
          //  new YearRange { Range = "2005 - 2009"},
          //  new YearRange { Range = "2010 - 2014"},
         //   new YearRange { Range = "2015 - 2019"}
            };
            year.ForEach(y => context.YearRanges.AddOrUpdate(r => r.Range, y));
            context.SaveChanges();
         
            var movs = new List<Movie> 
           {
                new Movie {
                Title = "Star Wars Episode IV A new Hope",
                Director = new Director { Name = "George Lucas" },
                YearRange = new YearRange { Range = "1975 - 1979" },
                Description = "The plot focuses on the Rebel Alliance, led by Princess Leia and its attempt to destroy the Galactic Empire's space station, the Death Star ",
                Year = 1977,
                Price = 7.39,
                Rating = 10
                },

                new Movie{
                Title = "Sunshine",
                Director = new Director { Name = "Danny Boyle" },
                YearRange = new YearRange { Range = "1980 - 1985" },
                Description = "In 2057, the failure of the sun starts a solar winter and threatens Earth. Humanity, in an attempt to reignite it, loads a massive stellar bomb onto a spaceship named Icarus II",
                Year = 2007,
                Price = 12.14,
                Rating = 9
                },

            new Movie {
                Title = "The Hurt Locker",
                Director = new Director { Name = "Kathryn Bigelow" },
                YearRange = new YearRange { Range = "2005 - 2009" },
                Description = "James' maverick methods and attitude lead Sanborn and Eldridge to consider him reckless, and tensions mount. When they are assigned to destroy some explosives in a remote desert area, James returns to the detonation site to pick up his gloves",
                Year = 2008,
                Price = 14.29,
                Rating = 9
            },

            new Movie {
                Title = "Gattaca",
                Director = new Director { Name = "Andrew Niccol" },
                YearRange = new YearRange { Range = "1995 - 1999" },
                Description = "In the not-too-distant future, eugenics is common. A genetic registry database uses biometrics to classify those so created as 'valids' while those conceived by traditional means and more susceptible to genetic disorders are known as 'in-valids'. Genetic discrimination is illegal, but in practice genotype profiling is used to identify valids to qualify for professional employment while in-valids are relegated to menial jobs",
                Year = 1997,
                Price = 13.49,
                Rating = 9
            },

            new Movie{
            Title ="Black Hawk Down",
            Director = new Director {Name ="Steven Speielberg"},
            YearRange = new YearRange {Range = "2000 - 2004"},
            Description ="The film takes place in 1993 when the U.S. sent special forces into Somalia to destabilize the government and bring food and humanitarian aid to the starving population.",
            Year = 2001,
            Price = 15.44,
            Rating = 10
            },

            new Movie { 
            Title="Prometheus",
            Director = new Director {Name ="Ridley Scott"},
            YearRange = new YearRange {Range ="2010 - 2014"},
            Description="A clue to mankind's origins leads a team of explorers to deep space, where they must fight a terrifying battle to save the future of the human race.",
            Year = 2012,
            Price = 19.27,
            Rating = 6
            },

            new Movie {
            Title ="The Revenant",
            Director = new Director {Name= "Alejandro Gonazalez"},
            YearRange = new YearRange {Range="2015 - 2019"},
            Description = "While exploring the uncharted wilderness in 1823, legendary frontiersman Hugh Glass sustains injuries from a brutal bear attack.",
            Year = 2015,
            Price = 20.44,
            Rating = 8
            },

            new Movie {
            Title ="Terminator 2: Judgement Day",
            Director = new Director {Name ="James Cameron"},
            YearRange = new YearRange {Range="1990 - 1994"},
            Description ="A cyborg, identical to the one who failed to kill Sarah Connor, must now protect her young son, John Connor, from a more advanced cyborg, made out of liquid metal.",
            Year = 1991,
            Price = 9.69,
            Rating = 10
            },

            new Movie {
            Title ="Back to the Future",
            Director = new Director {Name ="Robert Zemeckis"},
            YearRange = new YearRange{Range="1985 - 1989"},
            Description="A young man is accidentally sent thirty years into the past in a time-traveling DeLorean invented by his friend, Dr. Emmett Brown, and must make sure his high-school-age parents unite in order to save his own existence.",
            Year = 1985,
            Price = 5.66,
            Rating = 7
            }


           };
            
            movs.ForEach(m => context.Movies.AddOrUpdate(t => t.Title, m));
            context.SaveChanges();
          
            //create Role Admin able to edit stuff in the movie store manager
            if (!context.Roles.Any(r => r.Name == "ContentAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "ContentAdmin" };

                manager.Create(role);
                context.SaveChanges();
            }
            //create Master Admin role able to edit other users and all content
            if (!context.Roles.Any(r => r.Name == "MasterAdmin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "MasterAdmin" };

                manager.Create(role);
                context.SaveChanges();
            }

            //create User role for normal users
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "User" };

                manager.Create(role);
                context.SaveChanges();
            }

            // -------------------------create  two more users-------------------------------------------------------
            if (!(context.Users.Any(u => u.UserName == "contentadmin")))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "contentadmin" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "ContentAdmin");
                context.SaveChanges();
            }

            if (!context.Users.Any(u => u.UserName == "masteradmin"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "masteradmin" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "MasterAdmin");
                context.SaveChanges();
            }


            if (!context.Users.Any(u => u.UserName == "user"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "user" };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "User");
                context.SaveChanges();
            }

             */
            base.Seed(context);
           
        }
    }
}
