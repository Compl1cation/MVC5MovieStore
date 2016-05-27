using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVC5MovieStore.Models
{
    public class MovieStoreDB : IdentityDbContext<ApplicationUser>
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MovieStoreDB() : base("name=MovieStoreDB")
        {
        }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.YearRange> YearRanges { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.CartItem> ShoppingCartItems { get; set; }
        
        public System.Data.Entity.DbSet<MVC5MovieStore.Models.Cart> Carts { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.Order> Orders { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.OrderDetail> OrderDetails { get; set; }

        public System.Data.Entity.DbSet<MVC5MovieStore.Models.File> Files { get; set; }
 
    }
}
