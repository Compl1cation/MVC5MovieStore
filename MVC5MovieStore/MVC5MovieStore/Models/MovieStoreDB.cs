using System.Data.Entity;
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
    
        public MovieStoreDB() : base("name=MovieStoreDB", throwIfV1Schema: false)
        {
       
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<YearRange> YearRanges { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<CartItem> ShoppingCartItems { get; set; }
        
        public DbSet<Cart> Carts { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderDetail> OrderDetails { get; set; }

        public DbSet<File> Files { get; set; }
 
    }
}
