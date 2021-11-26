using Microsoft.EntityFrameworkCore;
using System.Linq;
using Angular.Eshop.DataLayer.Entities.Account;
using Angular.Eshop.DataLayer.Entities.access;


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
