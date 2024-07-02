using FM_Rozetka_Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FM_Rozetka_Api.Infrastructure.Initializers
{
    public static class DBInitializer
    {
        public static string AdminRoleId = Guid.NewGuid().ToString();
        public static string UserRoleId = Guid.NewGuid().ToString();
        public static string SellerRoleId = Guid.NewGuid().ToString();
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            foreach (var item in new List<(string id, string name)>() 
            { 
                (AdminRoleId, "Administrator"), 
                (UserRoleId, "User"),
                (SellerRoleId, "Seller")
            })
            {
                modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole()
                {
                    Id = item.id,
                    Name = item.name,
                    NormalizedName = item.name.ToUpper()
                });
            }
        }
        public static void SeedAdministrator(this ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var adminUserId = Guid.NewGuid().ToString();
            var adminUser = new AppUser
            {
                Id = adminUserId,
                FirstName = "John",
                LastName = "Connor",
                SurName = "Johnovych",
                UserName = "admin@email.com",
                NormalizedUserName = "ADMIN@EMAIL.COM",
                Email = "admin@email.com",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "",
                PhoneNumberConfirmed = false,
            };
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Qwerty-1");
            modelBuilder.Entity<AppUser>().HasData(adminUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = AdminRoleId,
                UserId = adminUserId
            });
        }
    }
}
