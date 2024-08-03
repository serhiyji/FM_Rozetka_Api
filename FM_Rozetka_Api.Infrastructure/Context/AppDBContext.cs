using FM_Rozetka_Api.Core.Entities;
using FM_Rozetka_Api.Core.Entities.Telegram;
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

        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<CategorySpecification> CategorySpecifications { get; set; }
        public DbSet<CountryProduction> CountryProductions { get; set; }
        public DbSet<CountryProductionProduct> CountryProductionProducts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<ModeratorShop> ModeratorShops { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderStatusHistory> OrderStatusHistories { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PhotoProduct> PhotoProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductAnswer> ProductAnswers { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductQuestion> ProductQuestions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<TelegramUser> TelegramUsers { get; set; }
        public DbSet<SellerApplication> SellerApplications { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<PhoneConfirmation> PhoneConfirmations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shop>()
               .HasOne(s => s.Company)
               .WithMany(c => c.Shops)
               .HasForeignKey(s => s.CompanyId)
               .HasPrincipalKey(c => c.Id);

            modelBuilder.Entity<Product>()
            .HasOne(p => p.CountryProductionProduct)
            .WithOne(c => c.Product)
            .HasForeignKey<CountryProductionProduct>(c => c.ProductId);

            modelBuilder.Entity<SellerApplication>()
          .Property(s => s.ProcessedApplication)
          .HasDefaultValue(false);

            modelBuilder.SeedRoles();
            modelBuilder.SeedAdministrator();
        }
    }
}
