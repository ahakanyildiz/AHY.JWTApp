using AHY.JWPApp.Api.Core.Domain;
using AHY.JWPApp.Api.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace AHY.JWPApp.Api.Persistance.Context
{
    public class JwtTokenContext : DbContext
    {
        public JwtTokenContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products => this.Set<Product>();
        public DbSet<Category> Categories => this.Set<Category>();
        public DbSet<AppUser> AppUsers => this.Set<AppUser>();
        public DbSet<AppRole> AppRoles => this.Set<AppRole>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}
