using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarketPlace.DAL
{
    public class MarketContext : IdentityDbContext<User>
    {
        #region Constructor
        public MarketContext(DbContextOptions options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Products> Products { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products_Categories> Products_Categories { get; set; }

        //public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        #endregion

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Products_Categories
            builder.Entity<Products_Categories>().HasKey(pc => new
            {
                pc.Product_Id,
                pc.Category_Id
            });

            builder.Entity<Products_Categories>().HasOne(p => p.Product).WithMany(pc => pc.Products_Categories).HasForeignKey(pc => pc.Product_Id);
            builder.Entity<Products_Categories>().HasOne(c => c.Category).WithMany(pc => pc.Products_Categories).HasForeignKey(pc => pc.Category_Id);

            #endregion



            //builder.Entity<Products>(b =>
            //{
            //    b.Ignore(p => p.Categories);
            //});
            //builder.Entity<Categories>(b =>
            //{
            //    b.Ignore(p => p.Products);
            //});

            #region Seeding
            var categories = new List<Categories>
            {
                new Categories { Id = 1, Name = "Category1" },
                new Categories { Id = 2, Name = "Category2" },
                new Categories { Id = 3, Name = "Category3" }
            };

            builder.Entity<Categories>().HasData(categories);
            #endregion
        }
        #endregion
    }
}
