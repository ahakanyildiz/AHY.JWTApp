using Microsoft.EntityFrameworkCore;
using Onion.JWTApp.Persistence.Configurations;
using src.Core.Onion.JwtApp.Domain.Entities;

namespace Onion.JWTApp.Persistence.Context
{
    public class JwtContext : DbContext
    {
        public JwtContext(DbContextOptions<JwtContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
