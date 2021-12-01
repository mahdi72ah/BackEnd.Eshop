using Microsoft.EntityFrameworkCore;
using System.Linq;
using Angular.Eshop.DataLayer.Entities.Account;
using Angular.Eshop.DataLayer.Entities.access;
using Angular.Eshop.DataLayer.Entities.site.Product;
using Angular.Eshop.DataLayer.Entities.site.slider;

namespace Angular.Eshop.DataLayer.Context
{
    public class AngularEshopdbContext : DbContext
    {
       
        public AngularEshopdbContext(DbContextOptions<AngularEshopdbContext> options) : base(options)
        {
        }
     

        #region DbSet

        public DbSet<Users> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductVisit> productVisits { get; set; }
        public DbSet<ProductGllary> productGllaries { get; set; }
        public DbSet<ProductSelectedCategory> productSelectedCategories { get; set; }
        public DbSet<slider> sliders { get; set; }
        public DbSet<ProductCategory> productCategories { get; set; }

        #endregion

        #region disable cascading delete in database

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascades = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascades)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
