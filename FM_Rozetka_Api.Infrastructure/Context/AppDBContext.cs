using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Infrastructure.Initializers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rozetka_Api.Core.Entities;


namespace FM_Rozetka_Api.Infrastructure.Context
{
    public class AppDBContext : IdentityDbContext
    {
        public AppDBContext() : base() { }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<CategorySpecification> CategorySpecifications { get; set; }
        public DbSet<CountryProduction> CountryProductions { get; set; }
        public DbSet<CountryProductionProduct> CountryProductionProducts { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<ManufacturerProduct> ManufacturerProducts { get; set; }
        public DbSet<ModeratorShop> ModeratorShops { get; set; }
        public DbSet<PhotoProduct> PhotoProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Specification> Specifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryProductionProduct>()
            .HasOne(cp => cp.Product)
            .WithOne(p => p.CountryProductionProduct)
            .HasForeignKey<Product>(p => p.CountryProductionProductId);

            modelBuilder.Entity<ManufacturerProduct>()
            .HasOne(mp => mp.Product)
            .WithOne(p => p.ManufacturerProduct)
            .HasForeignKey<ManufacturerProduct>(mp => mp.ProductId);

            //modelBuilder.SeedAdministrator();
        }
    }
}
