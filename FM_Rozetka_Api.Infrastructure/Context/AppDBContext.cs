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
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        public DbSet<CategorySpecification> CategorySpecifications { get; set; }
        public DbSet<CountryProduction> CountryProductions { get; set; }
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

            // Adress - AppUser
            modelBuilder.Entity<Adress>()
                .HasOne(a => a.AppUser).WithMany(u => u.Adresses)
                .HasForeignKey(a => a.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // CartItem - AppUser
            modelBuilder.Entity<CartItem>()
                .HasOne(c => c.AppUser).WithMany(u => u.CartItems)
                .HasForeignKey(c => c.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // Favorite - AppUser
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.AppUser).WithMany(u => u.Favorites)
                .HasForeignKey(f => f.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // ModeratorShop - AppUser
            modelBuilder.Entity<ModeratorShop>()
                .HasOne(m => m.AppUser).WithMany(u => u.ModeratorShops)
                .HasForeignKey(m => m.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // Order - AppUser
            modelBuilder.Entity<Order>()
                .HasOne(o => o.AppUser).WithMany(u => u.Orders)
                .HasForeignKey(o => o.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // ProductAnswer - AppUser
            modelBuilder.Entity<ProductAnswer>()
                .HasOne(pa => pa.AppUser).WithMany(u => u.ProductAnswers)
                .HasForeignKey(pa => pa.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // ProductQuestion - AppUser
            modelBuilder.Entity<ProductQuestion>()
                .HasOne(pq => pq.AppUser).WithMany(u => u.ProductQuestions)
                .HasForeignKey(pq => pq.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // Review - AppUser
            modelBuilder.Entity<Review>()
                .HasOne(r => r.AppUser).WithMany(u => u.Reviews)
                .HasForeignKey(r => r.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // Shop - AppUser
            modelBuilder.Entity<Shop>()
                .HasOne(s => s.AppUser).WithMany(u => u.Shops)
                .HasForeignKey(s => s.AppUserId).OnDelete(DeleteBehavior.Cascade);

            // Product - CategoryProduct
            modelBuilder.Entity<Product>()
                .HasOne(p => p.CategoryProduct).WithMany(cp => cp.Products)
                .HasForeignKey(p => p.CategoryProductId).OnDelete(DeleteBehavior.Restrict);

            // Shop - Company
            modelBuilder.Entity<Shop>()
                .HasOne(s => s.Company).WithMany(c => c.Shops)
                .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);

            // Product - CountryProduction
            modelBuilder.Entity<Product>()
                .HasOne(p => p.CountryProduction).WithMany(cp => cp.Products)
                .HasForeignKey(p => p.CountryProductionId).OnDelete(DeleteBehavior.Restrict);

            // OrderItem - Order
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order).WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId).OnDelete(DeleteBehavior.Cascade);

            // Payment - Order
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Order).WithMany(o => o.Payments)
                .HasForeignKey(p => p.OrderId).OnDelete(DeleteBehavior.Cascade);

            // OrderStatusHistory - Order
            modelBuilder.Entity<OrderStatusHistory>()
                .HasOne(osh => osh.Order).WithMany(o => o.OrderStatusHistories)
                .HasForeignKey(osh => osh.OrderId).OnDelete(DeleteBehavior.Cascade);

            // Shipment - Order
            modelBuilder.Entity<Shipment>()
                .HasOne(s => s.Order).WithMany(o => o.Shipments)
                .HasForeignKey(s => s.OrderId).OnDelete(DeleteBehavior.Cascade);

            // PhotoProduct - Product
            modelBuilder.Entity<PhotoProduct>()
                .HasOne(pp => pp.Product).WithMany(p => p.PhotoProducts)
                .HasForeignKey(pp => pp.ProductId).OnDelete(DeleteBehavior.Cascade);

            // Discount - Product
            modelBuilder.Entity<Discount>()
                .HasOne(d => d.Product).WithMany(p => p.Discounts)
                .HasForeignKey(d => d.ProductId).OnDelete(DeleteBehavior.Cascade);

            // Favorite - Product
            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Product).WithMany(p => p.Favorites)
                .HasForeignKey(f => f.ProductId).OnDelete(DeleteBehavior.Cascade);

            // OrderItem - Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product).WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId).OnDelete(DeleteBehavior.Restrict);

            // ProductQuestion - Product
            modelBuilder.Entity<ProductQuestion>()
                .HasOne(pq => pq.Product).WithMany(p => p.ProductQuestions)
                .HasForeignKey(pq => pq.ProductId).OnDelete(DeleteBehavior.Cascade);

            // Review - Product
            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product).WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId).OnDelete(DeleteBehavior.Cascade);

            // CartItem - Product
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product).WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId).OnDelete(DeleteBehavior.Cascade);

            // ModeratorShop - Shop
            modelBuilder.Entity<ModeratorShop>()
                .HasOne(ms => ms.Shop).WithMany(s => s.ModeratorShop)
                .HasForeignKey(ms => ms.ShopId).OnDelete(DeleteBehavior.Cascade);

            // Product - Shop
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Shop).WithMany(s => s.Products)
                .HasForeignKey(p => p.ShopId).OnDelete(DeleteBehavior.Restrict);

            // Specification - CategorySpecification
            modelBuilder.Entity<Specification>()
                .HasOne(s => s.CategorySpecification).WithMany(cs => cs.Specifications)
                .HasForeignKey(s => s.CategorySpecificationId).OnDelete(DeleteBehavior.Cascade);

            // Specification - Product
            modelBuilder.Entity<Specification>()
                .HasOne(s => s.Product).WithMany(p => p.Specifications)
                .HasForeignKey(s => s.ProductId).OnDelete(DeleteBehavior.Cascade);

            // ProductAnswer - ProductQuestion
            modelBuilder.Entity<ProductAnswer>()
                .HasOne(pa => pa.ProductQuestion).WithMany(pq => pq.ProductAnswers)
                .HasForeignKey(pa => pa.QuestionID).OnDelete(DeleteBehavior.Cascade);

            // ProductBrand - Product
            modelBuilder.Entity<ProductBrand>()
                .HasOne(pb => pb.Product).WithMany(p => p.ProductBrands)
                .HasForeignKey(pb => pb.ProductId).OnDelete(DeleteBehavior.Cascade);

            // ProductBrand - Brand
            modelBuilder.Entity<ProductBrand>()
                .HasOne(pb => pb.Brand).WithMany(b => b.ProductBrands)
                .HasForeignKey(pb => pb.BrandId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductQuestion>()
            .Property(pq => pq.OpenQuestion)
            .HasDefaultValue(true);

            modelBuilder.Entity<ProductQuestion>()
            .Property(pq => pq.hasAnswer)
            .HasDefaultValue(false);

            modelBuilder.SeedRoles();
            modelBuilder.SeedAdministrator();
            modelBuilder.SeedCountryProductions();
            modelBuilder.SeedBrands();
        }
    }
}
