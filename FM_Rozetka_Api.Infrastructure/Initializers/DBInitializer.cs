using FM_Rozetka_Api.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rozetka_Api.Core.Entities;
using System.Runtime.CompilerServices;
using Telegram.Bot.Types;

namespace FM_Rozetka_Api.Infrastructure.Initializers
{
    public static class DBInitializer
    {
        public static string AdminRoleId = Guid.NewGuid().ToString();
        public static string UserRoleId = Guid.NewGuid().ToString();
        public static string SellerRoleId = Guid.NewGuid().ToString();
        public static string ModeratorSellerRoleId = Guid.NewGuid().ToString();
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            foreach (var item in new List<(string id, string name)>() 
            { 
                (AdminRoleId, "Administrator"), 
                (UserRoleId, "User"),
                (SellerRoleId, "Seller"),
                (ModeratorSellerRoleId, "ModeratorSeller")
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
        public static void SeedCountryProductions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryProduction>().HasData(
                new CountryProduction() { Id = 1, Name = "Afghanistan" },
                new CountryProduction() { Id = 2, Name = "Albania" },
                new CountryProduction() { Id = 3, Name = "Algeria" },
                new CountryProduction() { Id = 4, Name = "Andorra" },
                new CountryProduction() { Id = 5, Name = "Angola" },
                new CountryProduction() { Id = 6, Name = "Antigua and Barbuda" },
                new CountryProduction() { Id = 7, Name = "Argentina" },
                new CountryProduction() { Id = 8, Name = "Armenia" },
                new CountryProduction() { Id = 9, Name = "Australia" },
                new CountryProduction() { Id = 10, Name = "Austria" },
                new CountryProduction() { Id = 11, Name = "Azerbaijan" },
                new CountryProduction() { Id = 12, Name = "Bahamas" },
                new CountryProduction() { Id = 13, Name = "Bahrain" },
                new CountryProduction() { Id = 14, Name = "Bangladesh" },
                new CountryProduction() { Id = 15, Name = "Barbados" },
                new CountryProduction() { Id = 16, Name = "Belarus" },
                new CountryProduction() { Id = 17, Name = "Belgium" },
                new CountryProduction() { Id = 18, Name = "Belize" },
                new CountryProduction() { Id = 19, Name = "Benin" },
                new CountryProduction() { Id = 20, Name = "Bhutan" },
                new CountryProduction() { Id = 21, Name = "Bolivia" },
                new CountryProduction() { Id = 22, Name = "Bosnia and Herzegovina" },
                new CountryProduction() { Id = 23, Name = "Botswana" },
                new CountryProduction() { Id = 24, Name = "Brazil" },
                new CountryProduction() { Id = 25, Name = "Brunei" },
                new CountryProduction() { Id = 26, Name = "Bulgaria" },
                new CountryProduction() { Id = 27, Name = "Burkina Faso" },
                new CountryProduction() { Id = 28, Name = "Burundi" },
                new CountryProduction() { Id = 29, Name = "Cabo Verde" },
                new CountryProduction() { Id = 30, Name = "Cambodia" },
                new CountryProduction() { Id = 31, Name = "Cameroon" },
                new CountryProduction() { Id = 32, Name = "Canada" },
                new CountryProduction() { Id = 33, Name = "Central African Republic" },
                new CountryProduction() { Id = 34, Name = "Chad" },
                new CountryProduction() { Id = 35, Name = "Chile" },
                new CountryProduction() { Id = 36, Name = "China" },
                new CountryProduction() { Id = 37, Name = "Colombia" },
                new CountryProduction() { Id = 38, Name = "Comoros" },
                new CountryProduction() { Id = 39, Name = "Congo (Congo-Brazzaville)" },
                new CountryProduction() { Id = 40, Name = "Costa Rica" },
                new CountryProduction() { Id = 41, Name = "Croatia" },
                new CountryProduction() { Id = 42, Name = "Cuba" },
                new CountryProduction() { Id = 43, Name = "Cyprus" },
                new CountryProduction() { Id = 44, Name = "Czech Republic (Czechia)" },
                new CountryProduction() { Id = 45, Name = "Democratic Republic of the Congo" },
                new CountryProduction() { Id = 46, Name = "Denmark" },
                new CountryProduction() { Id = 47, Name = "Djibouti" },
                new CountryProduction() { Id = 48, Name = "Dominica" },
                new CountryProduction() { Id = 49, Name = "Dominican Republic" },
                new CountryProduction() { Id = 50, Name = "East Timor (Timor-Leste)" },
                new CountryProduction() { Id = 51, Name = "Ecuador" },
                new CountryProduction() { Id = 52, Name = "Egypt" },
                new CountryProduction() { Id = 53, Name = "El Salvador" },
                new CountryProduction() { Id = 54, Name = "Equatorial Guinea" },
                new CountryProduction() { Id = 55, Name = "Eritrea" },
                new CountryProduction() { Id = 56, Name = "Estonia" },
                new CountryProduction() { Id = 57, Name = "Eswatini" },
                new CountryProduction() { Id = 58, Name = "Ethiopia" },
                new CountryProduction() { Id = 59, Name = "Fiji" },
                new CountryProduction() { Id = 60, Name = "Finland" },
                new CountryProduction() { Id = 61, Name = "France" },
                new CountryProduction() { Id = 62, Name = "Gabon" },
                new CountryProduction() { Id = 63, Name = "Gambia" },
                new CountryProduction() { Id = 64, Name = "Georgia" },
                new CountryProduction() { Id = 65, Name = "Germany" },
                new CountryProduction() { Id = 66, Name = "Ghana" },
                new CountryProduction() { Id = 67, Name = "Greece" },
                new CountryProduction() { Id = 68, Name = "Grenada" },
                new CountryProduction() { Id = 69, Name = "Guatemala" },
                new CountryProduction() { Id = 70, Name = "Guinea" },
                new CountryProduction() { Id = 71, Name = "Guinea-Bissau" },
                new CountryProduction() { Id = 72, Name = "Guyana" },
                new CountryProduction() { Id = 73, Name = "Haiti" },
                new CountryProduction() { Id = 74, Name = "Honduras" },
                new CountryProduction() { Id = 75, Name = "Hungary" },
                new CountryProduction() { Id = 76, Name = "Iceland" },
                new CountryProduction() { Id = 77, Name = "India" },
                new CountryProduction() { Id = 78, Name = "Indonesia" },
                new CountryProduction() { Id = 79, Name = "Iran" },
                new CountryProduction() { Id = 80, Name = "Iraq" },
                new CountryProduction() { Id = 81, Name = "Ireland" },
                new CountryProduction() { Id = 82, Name = "Israel" },
                new CountryProduction() { Id = 83, Name = "Italy" },
                new CountryProduction() { Id = 84, Name = "Ivory Coast (Côte d'Ivoire)" },
                new CountryProduction() { Id = 85, Name = "Jamaica" },
                new CountryProduction() { Id = 86, Name = "Japan" },
                new CountryProduction() { Id = 87, Name = "Jordan" },
                new CountryProduction() { Id = 88, Name = "Kazakhstan" },
                new CountryProduction() { Id = 89, Name = "Kenya" },
                new CountryProduction() { Id = 90, Name = "Kiribati" },
                new CountryProduction() { Id = 91, Name = "Korea, North" },
                new CountryProduction() { Id = 92, Name = "Korea, South" },
                new CountryProduction() { Id = 93, Name = "Kosovo" },
                new CountryProduction() { Id = 94, Name = "Kuwait" },
                new CountryProduction() { Id = 95, Name = "Kyrgyzstan" },
                new CountryProduction() { Id = 96, Name = "Laos" },
                new CountryProduction() { Id = 97, Name = "Latvia" },
                new CountryProduction() { Id = 98, Name = "Lebanon" },
                new CountryProduction() { Id = 99, Name = "Lesotho" },
                new CountryProduction() { Id = 100, Name = "Liberia" },
                new CountryProduction() { Id = 101, Name = "Libya" },
                new CountryProduction() { Id = 102, Name = "Liechtenstein" },
                new CountryProduction() { Id = 103, Name = "Lithuania" },
                new CountryProduction() { Id = 104, Name = "Luxembourg" },
                new CountryProduction() { Id = 105, Name = "Madagascar" },
                new CountryProduction() { Id = 106, Name = "Malawi" },
                new CountryProduction() { Id = 107, Name = "Malaysia" },
                new CountryProduction() { Id = 108, Name = "Maldives" },
                new CountryProduction() { Id = 109, Name = "Mali" },
                new CountryProduction() { Id = 110, Name = "Malta" },
                new CountryProduction() { Id = 111, Name = "Marshall Islands" },
                new CountryProduction() { Id = 112, Name = "Mauritania" },
                new CountryProduction() { Id = 113, Name = "Mauritius" },
                new CountryProduction() { Id = 114, Name = "Mexico" },
                new CountryProduction() { Id = 115, Name = "Micronesia" },
                new CountryProduction() { Id = 116, Name = "Moldova" },
                new CountryProduction() { Id = 117, Name = "Monaco" },
                new CountryProduction() { Id = 118, Name = "Mongolia" },
                new CountryProduction() { Id = 119, Name = "Montenegro" },
                new CountryProduction() { Id = 120, Name = "Morocco" },
                new CountryProduction() { Id = 121, Name = "Mozambique" },
                new CountryProduction() { Id = 122, Name = "Myanmar (Burma)" },
                new CountryProduction() { Id = 123, Name = "Namibia" },
                new CountryProduction() { Id = 124, Name = "Nauru" },
                new CountryProduction() { Id = 125, Name = "Nepal" },
                new CountryProduction() { Id = 126, Name = "Netherlands" },
                new CountryProduction() { Id = 127, Name = "New Zealand" },
                new CountryProduction() { Id = 128, Name = "Nicaragua" },
                new CountryProduction() { Id = 129, Name = "Niger" },
                new CountryProduction() { Id = 130, Name = "Nigeria" },
                new CountryProduction() { Id = 131, Name = "North Macedonia" },
                new CountryProduction() { Id = 132, Name = "Norway" },
                new CountryProduction() { Id = 133, Name = "Oman" },
                new CountryProduction() { Id = 134, Name = "Pakistan" },
                new CountryProduction() { Id = 135, Name = "Palau" },
                new CountryProduction() { Id = 136, Name = "Panama" },
                new CountryProduction() { Id = 137, Name = "Papua New Guinea" },
                new CountryProduction() { Id = 138, Name = "Paraguay" },
                new CountryProduction() { Id = 139, Name = "Peru" },
                new CountryProduction() { Id = 140, Name = "Philippines" },
                new CountryProduction() { Id = 141, Name = "Poland" },
                new CountryProduction() { Id = 142, Name = "Portugal" },
                new CountryProduction() { Id = 143, Name = "Qatar" },
                new CountryProduction() { Id = 144, Name = "Romania" },
                new CountryProduction() { Id = 145, Name = "Rwanda" },
                new CountryProduction() { Id = 146, Name = "Saint Kitts and Nevis" },
                new CountryProduction() { Id = 147, Name = "Saint Lucia" },
                new CountryProduction() { Id = 148, Name = "Saint Vincent and the Grenadines" },
                new CountryProduction() { Id = 149, Name = "Samoa" },
                new CountryProduction() { Id = 150, Name = "San Marino" },
                new CountryProduction() { Id = 151, Name = "Sao Tome and Principe" },
                new CountryProduction() { Id = 152, Name = "Saudi Arabia" },
                new CountryProduction() { Id = 153, Name = "Senegal" },
                new CountryProduction() { Id = 154, Name = "Serbia" },
                new CountryProduction() { Id = 155, Name = "Seychelles" },
                new CountryProduction() { Id = 156, Name = "Sierra Leone" },
                new CountryProduction() { Id = 157, Name = "Singapore" },
                new CountryProduction() { Id = 158, Name = "Slovakia" },
                new CountryProduction() { Id = 159, Name = "Slovenia" },
                new CountryProduction() { Id = 160, Name = "Solomon Islands" },
                new CountryProduction() { Id = 161, Name = "Somalia" },
                new CountryProduction() { Id = 162, Name = "South Africa" },
                new CountryProduction() { Id = 163, Name = "South Sudan" },
                new CountryProduction() { Id = 164, Name = "Spain" },
                new CountryProduction() { Id = 165, Name = "Sri Lanka" },
                new CountryProduction() { Id = 166, Name = "Sudan" },
                new CountryProduction() { Id = 167, Name = "Suriname" },
                new CountryProduction() { Id = 168, Name = "Sweden" },
                new CountryProduction() { Id = 169, Name = "Switzerland" },
                new CountryProduction() { Id = 170, Name = "Syria" },
                new CountryProduction() { Id = 171, Name = "Taiwan" },
                new CountryProduction() { Id = 172, Name = "Tajikistan" },
                new CountryProduction() { Id = 173, Name = "Tanzania" },
                new CountryProduction() { Id = 174, Name = "Thailand" },
                new CountryProduction() { Id = 175, Name = "Togo" },
                new CountryProduction() { Id = 176, Name = "Tonga" },
                new CountryProduction() { Id = 177, Name = "Trinidad and Tobago" },
                new CountryProduction() { Id = 178, Name = "Tunisia" },
                new CountryProduction() { Id = 179, Name = "Turkey" },
                new CountryProduction() { Id = 180, Name = "Turkmenistan" },
                new CountryProduction() { Id = 181, Name = "Tuvalu" },
                new CountryProduction() { Id = 182, Name = "Uganda" },
                new CountryProduction() { Id = 183, Name = "Ukraine" },
                new CountryProduction() { Id = 184, Name = "United Arab Emirates" },
                new CountryProduction() { Id = 185, Name = "United Kingdom" },
                new CountryProduction() { Id = 186, Name = "United States" },
                new CountryProduction() { Id = 187, Name = "Uruguay" },
                new CountryProduction() { Id = 188, Name = "Uzbekistan" },
                new CountryProduction() { Id = 189, Name = "Vanuatu" },
                new CountryProduction() { Id = 190, Name = "Vatican City" },
                new CountryProduction() { Id = 191, Name = "Venezuela" },
                new CountryProduction() { Id = 192, Name = "Vietnam" },
                new CountryProduction() { Id = 193, Name = "Yemen" },
                new CountryProduction() { Id = 194, Name = "Zambia" },
                new CountryProduction() { Id = 195, Name = "Zimbabwe" }
            );
        }
        public static void SeedBrands(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>().HasData(
                new Brand() { Id = 1, Name = "Apple" },
                new Brand() { Id = 2, Name = "Dell" },
                new Brand() { Id = 3, Name = "HP" },
                new Brand() { Id = 4, Name = "Lenovo" },
                new Brand() { Id = 5, Name = "Asus" },
                new Brand() { Id = 6, Name = "Acer" },
                new Brand() { Id = 7, Name = "MSI" },
                new Brand() { Id = 8, Name = "Razer" },
                new Brand() { Id = 9, Name = "Microsoft" },
                new Brand() { Id = 10, Name = "Toshiba" },
                new Brand() { Id = 11, Name = "Fujitsu" },
                new Brand() { Id = 12, Name = "Gateway" },
                new Brand() { Id = 13, Name = "Packard Bell" },
                new Brand() { Id = 14, Name = "Vaio" },
                new Brand() { Id = 15, Name = "OPPO" },
                new Brand() { Id = 16, Name = "vivo" },
                new Brand() { Id = 17, Name = "Google Pixel" },
                new Brand() { Id = 18, Name = "OnePlus" },
                new Brand() { Id = 19, Name = "Realme" },
                new Brand() { Id = 20, Name = "Motorola" },
                new Brand() { Id = 21, Name = "Nokia" },
                new Brand() { Id = 22, Name = "LG" },
                new Brand() { Id = 23, Name = "Bose" },
                new Brand() { Id = 24, Name = "JBL" },
                new Brand() { Id = 25, Name = "Anker" },
                new Brand() { Id = 26, Name = "Belkin" },
                new Brand() { Id = 27, Name = "Casetify" },
                new Brand() { Id = 28, Name = "Logitech" },
                new Brand() { Id = 29, Name = "Xiaomi" },
                new Brand() { Id = 30, Name = "Huawei" },
                new Brand() { Id = 31, Name = "Xbox" },
                new Brand() { Id = 32, Name = "Nintendo" },
                new Brand() { Id = 33, Name = "Wii" },
                new Brand() { Id = 34, Name = "PlayStation" },
                new Brand() { Id = 35, Name = "Canon" },
                new Brand() { Id = 36, Name = "Nikon" },
                new Brand() { Id = 37, Name = "Sony" },
                new Brand() { Id = 38, Name = "Fujifilm" },
                new Brand() { Id = 39, Name = "GoPro" },
                new Brand() { Id = 40, Name = "DJI" },
                new Brand() { Id = 41, Name = "Olympus" },
                new Brand() { Id = 42, Name = "Leica" },
                new Brand() { Id = 43, Name = "Hasselblad" },
                new Brand() { Id = 44, Name = "Tesla" },
                new Brand() { Id = 45, Name = "LGDeWalt" },
                new Brand() { Id = 46, Name = "Dyson" },
                new Brand() { Id = 47, Name = "Philips" },
                new Brand() { Id = 48, Name = "Panasonic" },
                new Brand() { Id = 49, Name = "Samsung" },
                new Brand() { Id = 50, Name = "Bosch" },
                new Brand() { Id = 51, Name = "Siemens" },
                new Brand() { Id = 52, Name = "Electrolux" },
                new Brand() { Id = 53, Name = "Whirlpool" },
                new Brand() { Id = 54, Name = "Miele" },
                new Brand() { Id = 55, Name = "Beko" },
                new Brand() { Id = 56, Name = "Candy" },
                new Brand() { Id = 57, Name = "Indesit" }
            );
        }
        public static string sellerUserId = Guid.NewGuid().ToString();
        public static void SeedSellers(this ModelBuilder modelBuilder)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            var sellerUser = new AppUser
            {
                Id = sellerUserId,
                FirstName = "seller",
                LastName = "seller",
                SurName = "seller",
                UserName = "seller@email.com",
                NormalizedUserName = "SELLER@EMAIL.COM",
                Email = "seller@email.com",
                NormalizedEmail = "SELLER@EMAIL.COM",
                EmailConfirmed = true,
                PhoneNumber = "",
                PhoneNumberConfirmed = false,
            };
            sellerUser.PasswordHash = passwordHasher.HashPassword(sellerUser, "Qwerty-1");
            modelBuilder.Entity<AppUser>().HasData(sellerUser);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = SellerRoleId,
                UserId = sellerUserId
            });
        }
        public static void SeedCompany(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(new Company()
            {
                Id = 1,
                Name = "Test",
                PhoneNumber = "Test"
            });
        }
        public static void SeedShop(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(new Shop()
            {
                Id = 1,
                AppUserId = sellerUserId,
                CompanyId = 1,
                Website = "TEST",
                HasNoWebsite = false,
                FullName = "TEST",
                Position = "TEST",
                Email = "TEST",
                PhoneNumber = "TEST",
                IsNonResident = false
            });
        }
        public static void SeedCategoryProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProduct>().HasData(
                // Основні категорії
                new CategoryProduct { Id = 1, Level = 1, TopId = null, Name = "Ноутбуки та комп'ютери", Description = "Ноутбуки та комп'ютери" },
                new CategoryProduct { Id = 2, Level = 1, TopId = null, Name = "Смартфони, ТВ і Електроніка", Description = "Смартфони, ТВ і Електроніка" },
                new CategoryProduct { Id = 3, Level = 1, TopId = null, Name = "Товари для геймерів", Description = "Товари для геймерів" },
                new CategoryProduct { Id = 4, Level = 1, TopId = null, Name = "Побутова техніка", Description = "Побутова техніка" },
                new CategoryProduct { Id = 5, Level = 1, TopId = null, Name = "Товари для дому", Description = "Товари для дому" },
                new CategoryProduct { Id = 6, Level = 1, TopId = null, Name = "Інструменти та автотовари", Description = "Інструменти та автотовари" },
                new CategoryProduct { Id = 7, Level = 1, TopId = null, Name = "Сантехніка та ремонт", Description = "Сантехніка та ремонт" },
                new CategoryProduct { Id = 8, Level = 1, TopId = null, Name = "Дача, сад, город", Description = "Дача, сад, город" },
                new CategoryProduct { Id = 9, Level = 1, TopId = null, Name = "Спорт і захоплення", Description = "Спорт і захоплення" },
                new CategoryProduct { Id = 10, Level = 1, TopId = null, Name = "Одяг, взуття та аксесуари", Description = "Одяг, взуття та аксесуари" },
                new CategoryProduct { Id = 11, Level = 1, TopId = null, Name = "Краса та здоров'я", Description = "Краса та здоров'я" },
                new CategoryProduct { Id = 12, Level = 1, TopId = null, Name = "Товари для дітей", Description = "Товари для дітей" },
                new CategoryProduct { Id = 13, Level = 1, TopId = null, Name = "Зоотовари", Description = "Зоотовари" },
                new CategoryProduct { Id = 14, Level = 1, TopId = null, Name = "Офіс, школа, книги", Description = "Офіс, школа, книги" },
                new CategoryProduct { Id = 15, Level = 1, TopId = null, Name = "Алкогольні напої та продукти", Description = "Алкогольні напої та продукти" },
                new CategoryProduct { Id = 16, Level = 1, TopId = null, Name = "Побутова хімія", Description = "Побутова хімія" },

            #region 1_1
                // Ноутбуки та комп'ютери
                new CategoryProduct { Id = 17, Level = 2, TopId = 1, Name = "Ноутбуки", Description = "Ноутбуки" },
                new CategoryProduct { Id = 18, Level = 2, TopId = 1, Name = "Планшети", Description = "Планшети" },
                new CategoryProduct { Id = 19, Level = 2, TopId = 1, Name = "Комп'ютери", Description = "Комп'ютери" },
                new CategoryProduct { Id = 20, Level = 2, TopId = 1, Name = "Комплектуючi", Description = "Комплектуючi" },
                new CategoryProduct { Id = 21, Level = 2, TopId = 1, Name = "Аксесуари для ноутбуків і ПК", Description = "Аксесуари для ноутбуків і ПК" },
                new CategoryProduct { Id = 22, Level = 2, TopId = 1, Name = "Серверне обладнання", Description = "Серверне обладнання" },
                new CategoryProduct { Id = 23, Level = 2, TopId = 1, Name = "Товари з уцінкою", Description = "Товари з уцінкою" },
                new CategoryProduct { Id = 24, Level = 2, TopId = 1, Name = "Офісна техніка", Description = "Офісна техніка" },
                new CategoryProduct { Id = 25, Level = 2, TopId = 1, Name = "Інтерактивне обладнання", Description = "Інтерактивне обладнання" },
                new CategoryProduct { Id = 26, Level = 2, TopId = 1, Name = "Мережеве обладнання", Description = "Мережеве обладнання" },
            #endregion
            #region 1_2
                // Смартфони, ТВ і Електроніка
                new CategoryProduct { Id = 27, Level = 2, TopId = 2, Name = "Телефони", Description = "Телефони" },
                new CategoryProduct { Id = 28, Level = 2, TopId = 2, Name = "Повербанки та зарядні станції", Description = "Повербанки та зарядні станції" },
                new CategoryProduct { Id = 29, Level = 2, TopId = 2, Name = "Аксесуари до телефонів", Description = "Аксесуари до телефонів" },
                new CategoryProduct { Id = 30, Level = 2, TopId = 2, Name = "Телевізори та аксесуари", Description = "Телевізори та аксесуари" },
                new CategoryProduct { Id = 31, Level = 2, TopId = 2, Name = "Фото та відео", Description = "Фото та відео" },
            #endregion
            #region 1_3
                // Товари для геймерів
                new CategoryProduct { Id = 32, Level = 2, TopId = 3, Name = "Ігрові приставки", Description = "Ігрові приставки" },
                new CategoryProduct { Id = 33, Level = 2, TopId = 3, Name = "Ігри", Description = "Ігри" },
                new CategoryProduct { Id = 34, Level = 2, TopId = 3, Name = "PlayStation", Description = "PlayStation" },
                new CategoryProduct { Id = 35, Level = 2, TopId = 3, Name = "Ігрові приставки Nintendo", Description = "Ігрові приставки Nintendo" },
                new CategoryProduct { Id = 36, Level = 2, TopId = 3, Name = "Ігрові приставки Xbox", Description = "Ігрові приставки Xbox" },
                new CategoryProduct { Id = 37, Level = 2, TopId = 3, Name = "Ігрові ноутбуки", Description = "Ігрові ноутбуки" },
                new CategoryProduct { Id = 38, Level = 2, TopId = 3, Name = "Ігрові монітори", Description = "Ігрові монітори" },
                new CategoryProduct { Id = 39, Level = 2, TopId = 3, Name = "Комплектуючі для геймерів", Description = "Комплектуючі для геймерів" },
                new CategoryProduct { Id = 40, Level = 2, TopId = 3, Name = "Ігрова периферія", Description = "Ігрова периферія" },
                new CategoryProduct { Id = 41, Level = 2, TopId = 3, Name = "Ігрові маршрутизатори", Description = "Ігрові маршрутизатори" },
                new CategoryProduct { Id = 42, Level = 2, TopId = 3, Name = "Атрибутика й сувеніри", Description = "Атрибутика й сувеніри" },
                new CategoryProduct { Id = 43, Level = 2, TopId = 3, Name = "Послуги та сервіси для електроніки", Description = "Послуги та сервіси для електроніки" },
            #endregion
            #region 1_4
                // Побутова техніка
                new CategoryProduct { Id = 44, Level = 2, TopId = 4, Name = "Велика побутова техніка", Description = "Велика побутова техніка" },
                new CategoryProduct { Id = 45, Level = 2, TopId = 4, Name = "Догляд та прибирання", Description = "Догляд та прибирання" },
                new CategoryProduct { Id = 46, Level = 2, TopId = 4, Name = "Кліматична техніка", Description = "Кліматична техніка" },
                new CategoryProduct { Id = 47, Level = 2, TopId = 4, Name = "Техніка для кухні", Description = "Техніка для кухні" },
                new CategoryProduct { Id = 48, Level = 2, TopId = 4, Name = "Дрібна побутова техніка", Description = "Дрібна побутова техніка" },
            #endregion
            #region 1_5
                // Товари для дому
                new CategoryProduct { Id = 49, Level = 2, TopId = 5, Name = "Меблі", Description = "Меблі" },
                new CategoryProduct { Id = 50, Level = 2, TopId = 5, Name = "Декор для дому", Description = "Декор для дому" },
                new CategoryProduct { Id = 51, Level = 2, TopId = 5, Name = "Системи охорони і безпеки", Description = "Системи охорони і безпеки" },
                new CategoryProduct { Id = 52, Level = 2, TopId = 5, Name = "Освітлення", Description = "Освітлення" },
                new CategoryProduct { Id = 53, Level = 2, TopId = 5, Name = "Посуд", Description = "Посуд" },
                new CategoryProduct { Id = 54, Level = 2, TopId = 5, Name = "Інвертар для дому та офісу", Description = "Інвертар для дому та офісу" },
                new CategoryProduct { Id = 55, Level = 2, TopId = 5, Name = "Господарські товари", Description = "Господарські товари" },
            #endregion
            #region 1_6
                // Інструменти та автотовари
                new CategoryProduct { Id = 56, Level = 2, TopId = 6, Name = "Інструменти", Description = "Інструменти" },
                new CategoryProduct { Id = 57, Level = 2, TopId = 6, Name = "Витратні матеріали та приладдя", Description = "Витратні матеріали та приладдя" },
                new CategoryProduct { Id = 58, Level = 2, TopId = 6, Name = "Обладнання", Description = "Обладнання" },
                new CategoryProduct { Id = 59, Level = 2, TopId = 6, Name = "Ручний інструмент", Description = "Ручний інструмент" },
                new CategoryProduct { Id = 60, Level = 2, TopId = 6, Name = "Елктромонтажне обладнання", Description = "Елктромонтажне обладнання" },
                new CategoryProduct { Id = 61, Level = 2, TopId = 6, Name = "Автотовари", Description = "Автотовари" },
            #endregion
            #region 1_7
                // Сантехніка та ремонт
                new CategoryProduct { Id = 62, Level = 2, TopId = 7, Name = "Ванни, бокси, душові", Description = "Ванни, бокси, душові" },
                new CategoryProduct { Id = 63, Level = 2, TopId = 7, Name = "Мийки, змішувачі, сифони", Description = "Мийки, змішувачі, сифони" },
                new CategoryProduct { Id = 64, Level = 2, TopId = 7, Name = "Кераміка", Description = "Кераміка" },
                new CategoryProduct { Id = 65, Level = 2, TopId = 7, Name = "Інженерна сантехніка", Description = "Інженерна сантехніка" },
                new CategoryProduct { Id = 66, Level = 2, TopId = 7, Name = "Інсталяції та комплектуючі", Description = "Інсталяції та комплектуючі" },
                new CategoryProduct { Id = 67, Level = 2, TopId = 7, Name = "Сушильники для рушників і радіатори", Description = "Сушильники для рушників і радіатори" },
                new CategoryProduct { Id = 68, Level = 2, TopId = 7, Name = "Інструменти", Description = "Інструменти" },
                new CategoryProduct { Id = 69, Level = 2, TopId = 7, Name = "Ручний інструмент", Description = "Ручний інструмент" },
                new CategoryProduct { Id = 70, Level = 2, TopId = 7, Name = "Освітлення", Description = "Освітлення" },
                new CategoryProduct { Id = 71, Level = 2, TopId = 7, Name = "Лічильники", Description = "Лічильники" },
                new CategoryProduct { Id = 72, Level = 2, TopId = 7, Name = "Меблі для ванної кімнати", Description = "Меблі для ванної кімнати" },
                new CategoryProduct { Id = 73, Level = 2, TopId = 7, Name = "Тепла підлога", Description = "Тепла підлога" },
                new CategoryProduct { Id = 74, Level = 2, TopId = 7, Name = "Будівельні матеріали", Description = "Будівельні матеріали" },
            #endregion
            #region 1_8
                // Дача, сад, город
                new CategoryProduct { Id = 75, Level = 2, TopId = 8, Name = "Садова техніка", Description = "Садова техніка" },
                new CategoryProduct { Id = 76, Level = 2, TopId = 8, Name = "Садовий інвентар", Description = "Садовий інвентар" },
                new CategoryProduct { Id = 77, Level = 2, TopId = 8, Name = "Системи поливання", Description = "Системи поливання" },
                new CategoryProduct { Id = 78, Level = 2, TopId = 8, Name = "Садовий інструмент", Description = "Садовий інструмент" },
                new CategoryProduct { Id = 79, Level = 2, TopId = 8, Name = "Рослини та догляд за ними", Description = "Рослини та догляд за ними" },
                new CategoryProduct { Id = 80, Level = 2, TopId = 8, Name = "Басейни та аксесуари", Description = "Басейни та аксесуари" },
                new CategoryProduct { Id = 81, Level = 2, TopId = 8, Name = "Благоустрій території", Description = "Благоустрій території" },
                new CategoryProduct { Id = 82, Level = 2, TopId = 8, Name = "Садовий декор", Description = "Садовий декор" },
                new CategoryProduct { Id = 83, Level = 2, TopId = 8, Name = "Снігоприбирання", Description = "Снігоприбирання" },
            #endregion
            #region 1_9
                // Спорт і захоплення
                new CategoryProduct { Id = 84, Level = 2, TopId = 9, Name = "Тренажери та спортивне обладнання", Description = "Тренажери та спортивне обладнання" },
                new CategoryProduct { Id = 85, Level = 2, TopId = 9, Name = "Фітнес та аеробіка", Description = "Фітнес та аеробіка" },
                new CategoryProduct { Id = 86, Level = 2, TopId = 9, Name = "Спортивні аксесуари", Description = "Спортивні аксесуари" },
                new CategoryProduct { Id = 87, Level = 2, TopId = 9, Name = "Велосипеди та аксесуари", Description = "Велосипеди та аксесуари" },
                new CategoryProduct { Id = 88, Level = 2, TopId = 9, Name = "Електротранспорт", Description = "Електротранспорт" },
                new CategoryProduct { Id = 89, Level = 2, TopId = 9, Name = "Ігрові види спорту", Description = "Ігрові види спорту" },
                new CategoryProduct { Id = 90, Level = 2, TopId = 9, Name = "Бокс і єдиноборства", Description = "Бокс і єдиноборства" },
                new CategoryProduct { Id = 91, Level = 2, TopId = 9, Name = "Басейн і аквафітнес", Description = "Басейн і аквафітнес" },
                new CategoryProduct { Id = 92, Level = 2, TopId = 9, Name = "Товари для відпочинку", Description = "Товари для відпочинку" },
                new CategoryProduct { Id = 93, Level = 2, TopId = 9, Name = "Квадрокоптери", Description = "Квадрокоптери" },
                new CategoryProduct { Id = 94, Level = 2, TopId = 9, Name = "Туризм і кемпінг", Description = "Туризм і кемпінг" },
                new CategoryProduct { Id = 95, Level = 2, TopId = 9, Name = "Риболовля", Description = "Риболовля" },
                new CategoryProduct { Id = 96, Level = 2, TopId = 9, Name = "Зимові види спорту", Description = "Зимові види спорту" },
                new CategoryProduct { Id = 97, Level = 2, TopId = 9, Name = "Музичні інструменти", Description = "Музичні інструменти" },
            #endregion
            #region 1_10
                // Одяг, взуття та аксесуари
                new CategoryProduct { Id = 98, Level = 2, TopId = 10, Name = "Одяг для жінок", Description = "Одяг для жінок" },
                new CategoryProduct { Id = 99, Level = 2, TopId = 10, Name = "Жіноче взуття", Description = "Жіноче взуття" },
                new CategoryProduct { Id = 100, Level = 2, TopId = 10, Name = "Аксесуари для жінок", Description = "Аксесуари для жінок" },
                new CategoryProduct { Id = 101, Level = 2, TopId = 10, Name = "Одяг для чоловіків", Description = "Одяг для чоловіків" },
                new CategoryProduct { Id = 102, Level = 2, TopId = 10, Name = "Чоловіче взуття", Description = "Чоловіче взуття" },
                new CategoryProduct { Id = 103, Level = 2, TopId = 10, Name = "Аксесуари для чоловіків", Description = "Аксесуари для чоловіків" },
                new CategoryProduct { Id = 104, Level = 2, TopId = 10, Name = "Дитячий одяг", Description = "Дитячий одяг" },
                new CategoryProduct { Id = 105, Level = 2, TopId = 10, Name = "Дитяче взуття", Description = "Дитяче взуття" },
                new CategoryProduct { Id = 106, Level = 2, TopId = 10, Name = "Аксесуари для дітей", Description = "Аксесуари для дітей" },
            #endregion
            #region 1_11
                // Краса та здоров'я
                new CategoryProduct { Id = 107, Level = 2, TopId = 11, Name = "Техніка для краси та здоров'я", Description = "Техніка для краси та здоров'я" },
                new CategoryProduct { Id = 108, Level = 2, TopId = 11, Name = "Косметика і парфюмерія", Description = "Косметика і парфюмерія" },
                new CategoryProduct { Id = 109, Level = 2, TopId = 11, Name = "Дерматокосметика", Description = "Дерматокосметика" },
                new CategoryProduct { Id = 110, Level = 2, TopId = 11, Name = "Засоби для гоління", Description = "Засоби для гоління" },
                new CategoryProduct { Id = 111, Level = 2, TopId = 11, Name = "Засоби контрацепції", Description = "Засоби контрацепції" },
                new CategoryProduct { Id = 112, Level = 2, TopId = 11, Name = "Особиста гігієна", Description = "Особиста гігієна" },
                new CategoryProduct { Id = 113, Level = 2, TopId = 11, Name = "Подарунки та сувеніри", Description = "Подарунки та сувеніри" },
                new CategoryProduct { Id = 114, Level = 2, TopId = 11, Name = "Догляд за обличчям", Description = "Догляд за обличчям" },
                new CategoryProduct { Id = 115, Level = 2, TopId = 11, Name = "Догляд за тілом", Description = "Догляд за тілом" },
                new CategoryProduct { Id = 116, Level = 2, TopId = 11, Name = "Догляд за волоссям", Description = "Догляд за волоссям" },
                new CategoryProduct { Id = 117, Level = 2, TopId = 11, Name = "Парфуми", Description = "Парфуми" },
                new CategoryProduct { Id = 118, Level = 2, TopId = 11, Name = "Товари медичного призначення", Description = "Товари медичного призначення" },
                new CategoryProduct { Id = 119, Level = 2, TopId = 11, Name = "Інтимні товари", Description = "Інтимні товари" },
                new CategoryProduct { Id = 120, Level = 2, TopId = 11, Name = "Фарбування волосся", Description = "Фарбування волосся" },
                new CategoryProduct { Id = 121, Level = 2, TopId = 11, Name = "Догляд за порожниною рота", Description = "Догляд за порожниною рота" },
                new CategoryProduct { Id = 122, Level = 2, TopId = 11, Name = "Декоративна косметика", Description = "Декоративна косметика" },
                new CategoryProduct { Id = 123, Level = 2, TopId = 11, Name = "Аксесуари", Description = "Аксесуари" },
                new CategoryProduct { Id = 124, Level = 2, TopId = 11, Name = "Косметика для догляду для дітей", Description = "Косметика для догляду для дітей" },
            #endregion
            #region 1_12
                // Товари для дітей
                new CategoryProduct { Id = 125, Level = 2, TopId = 12, Name = "Іграшки", Description = "Іграшки" },
                new CategoryProduct { Id = 126, Level = 2, TopId = 12, Name = "Дитяче харчування", Description = "Дитяче харчування" },
                new CategoryProduct { Id = 127, Level = 2, TopId = 12, Name = "Високотехнологічні іграшки", Description = "Високотехнологічні іграшки" },
                new CategoryProduct { Id = 128, Level = 2, TopId = 12, Name = "Прогулянки й активний відпочинок", Description = "Прогулянки й активний відпочинок" },
                new CategoryProduct { Id = 129, Level = 2, TopId = 12, Name = "Гігієна та догляд за дитиною", Description = "Гігієна та догляд за дитиною" },
                new CategoryProduct { Id = 130, Level = 2, TopId = 12, Name = "Дитячий одяг, взуття та аксесуари", Description = "Дитячий одяг, взуття та аксесуари" },
                new CategoryProduct { Id = 131, Level = 2, TopId = 12, Name = "Шкільне приладдя", Description = "Шкільне приладдя" },
                new CategoryProduct { Id = 132, Level = 2, TopId = 12, Name = "Новорічний декор", Description = "Новорічний декор" },
                new CategoryProduct { Id = 133, Level = 2, TopId = 12, Name = "Дитяча кімната", Description = "Дитяча кімната" },
                new CategoryProduct { Id = 134, Level = 2, TopId = 12, Name = "Розвиток і творчість", Description = "Розвиток і творчість" },
                new CategoryProduct { Id = 135, Level = 2, TopId = 12, Name = "Товари для мам", Description = "Товари для мам" },
                new CategoryProduct { Id = 136, Level = 2, TopId = 12, Name = "Транспорт для всієї родини", Description = "Транспорт для всієї родини" },
                new CategoryProduct { Id = 137, Level = 2, TopId = 12, Name = "Дитячі книги", Description = "Дитячі книги" },
            #endregion
            #region 1_13
                // Зоотовари
                new CategoryProduct { Id = 138, Level = 2, TopId = 13, Name = "Товари для кішок", Description = "Все для кішок" },
                new CategoryProduct { Id = 139, Level = 2, TopId = 13, Name = "Наповнювачі туалетів для котів", Description = "Наповнювачі туалетів для котів" },
                new CategoryProduct { Id = 140, Level = 2, TopId = 13, Name = "Товари для птахів", Description = "Товари для птахів" },
                new CategoryProduct { Id = 141, Level = 2, TopId = 13, Name = "Товари для гризунів", Description = "Товари для гризунів" },
                new CategoryProduct { Id = 142, Level = 2, TopId = 13, Name = "Товари для собак", Description = "Все для собак" },
                new CategoryProduct { Id = 143, Level = 2, TopId = 13, Name = "Засоби від паразитів", Description = "Засоби для боротьби з паразитами" },
                new CategoryProduct { Id = 144, Level = 2, TopId = 13, Name = "Акваріуми", Description = "Товари для акваріумів" },
                new CategoryProduct { Id = 145, Level = 2, TopId = 13, Name = "Тераріуми та фаунаріуми", Description = "Товари для тераріумів і фаунаріумів" },
                new CategoryProduct { Id = 146, Level = 2, TopId = 13, Name = "Стави та водойми", Description = "Товари для ставків та водойм" },
                new CategoryProduct { Id = 147, Level = 2, TopId = 13, Name = "Тваринництво", Description = "Товари для тваринництва" },
            #endregion
            #region 1_14
                // Офіс, школа, книги
                new CategoryProduct { Id = 148, Level = 2, TopId = 14, Name = "Канцелярське приладдя", Description = "Канцелярські товари" },
                new CategoryProduct { Id = 149, Level = 2, TopId = 14, Name = "Шкільне приладдя", Description = "Товари для школи" },
                new CategoryProduct { Id = 150, Level = 2, TopId = 14, Name = "Офісне приладдя", Description = "Офісне обладнання" },
                new CategoryProduct { Id = 151, Level = 2, TopId = 14, Name = "Новорічний декор", Description = "Декор для новорічних свят" },
                new CategoryProduct { Id = 152, Level = 2, TopId = 14, Name = "Книги", Description = "Книги різних жанрів" },
                new CategoryProduct { Id = 153, Level = 2, TopId = 14, Name = "Творчість", Description = "Матеріали для творчості" },
                new CategoryProduct { Id = 154, Level = 2, TopId = 14, Name = "Сувенірна продукція", Description = "Сувеніри та подарунки" },
            #endregion
            #region 1_15
                // Алкогольні напої та продукти
                new CategoryProduct { Id = 155, Level = 2, TopId = 15, Name = "Вино", Description = "Вино різних видів" },
                new CategoryProduct { Id = 156, Level = 2, TopId = 15, Name = "Лікери, вермути, сиропи", Description = "Лікери, вермути і сиропи" },
                new CategoryProduct { Id = 157, Level = 2, TopId = 15, Name = "Пиво та сидр", Description = "Пиво та сидр" },
                new CategoryProduct { Id = 158, Level = 2, TopId = 15, Name = "Сигарети", Description = "Сигарети" },
                new CategoryProduct { Id = 159, Level = 2, TopId = 15, Name = "Посуд", Description = "Посуд для алкоголю" },
                new CategoryProduct { Id = 160, Level = 2, TopId = 15, Name = "Міцні напої", Description = "Міцні алкогольні напої" },
                new CategoryProduct { Id = 161, Level = 2, TopId = 15, Name = "Електронні сигарети та аксесуари", Description = "Електронні сигарети та аксесуари" },
                new CategoryProduct { Id = 162, Level = 2, TopId = 15, Name = "Продукти", Description = "Продукти харчування" },
            #endregion
            #region 1_16
                // Побутова хімія
                new CategoryProduct { Id = 163, Level = 2, TopId = 16, Name = "Засоби для прання", Description = "Засоби для прання" },
                new CategoryProduct { Id = 164, Level = 2, TopId = 16, Name = "Засоби для догляду за будинком", Description = "Засоби для догляду за будинком" },
                new CategoryProduct { Id = 165, Level = 2, TopId = 16, Name = "Засоби для догляду за ванною та туалетом", Description = "Засоби для догляду за ванною та туалетом" },
                new CategoryProduct { Id = 166, Level = 2, TopId = 16, Name = "Засоби для миття посуду", Description = "Засоби для миття посуду" },
                new CategoryProduct { Id = 167, Level = 2, TopId = 16, Name = "Господарські товари", Description = "Господарські товари" },
                new CategoryProduct { Id = 168, Level = 2, TopId = 16, Name = "Вулична зона", Description = "Засоби для вуличної зони" },
                new CategoryProduct { Id = 169, Level = 2, TopId = 16, Name = "Екологічні та органічні засоби", Description = "Екологічні та органічні засоби" },
            #endregion
            #region 1_1_3lvl
                //Ноутбуки та комп'ютери
                // Ноутбуки
                new CategoryProduct { Id = 170, Level = 3, TopId = 17, Name = "Asus", Description = "Asus" },
                new CategoryProduct { Id = 171, Level = 3, TopId = 17, Name = "Lenovo", Description = "Lenovo" },
                new CategoryProduct { Id = 172, Level = 3, TopId = 17, Name = "Acer", Description = "Acer" },
                new CategoryProduct { Id = 173, Level = 3, TopId = 17, Name = "HP (Hewlett Packard)", Description = "HP (Hewlett Packard)" },
                new CategoryProduct { Id = 174, Level = 3, TopId = 17, Name = "Dell", Description = "Dell" },
                new CategoryProduct { Id = 175, Level = 3, TopId = 17, Name = "Apple Macbook", Description = "Apple Macbook" },

                // Планшети
                new CategoryProduct { Id = 176, Level = 3, TopId = 18, Name = "Apple iPad", Description = "Apple iPad" },
                new CategoryProduct { Id = 177, Level = 3, TopId = 18, Name = "Samsung", Description = "Samsung" },
                new CategoryProduct { Id = 178, Level = 3, TopId = 18, Name = "Lenovo", Description = "Lenovo" },
                new CategoryProduct { Id = 179, Level = 3, TopId = 18, Name = "Xiaomi", Description = "Xiaomi" },
                new CategoryProduct { Id = 180, Level = 3, TopId = 18, Name = "Чохли для планшетів", Description = "Чохли для планшетів" },
                new CategoryProduct { Id = 181, Level = 3, TopId = 18, Name = "Захисні плівки та скло", Description = "Захисні плівки та скло" },

                // Комп'ютери
                new CategoryProduct { Id = 182, Level = 3, TopId = 19, Name = "Монітори", Description = "Монітори" },
                new CategoryProduct { Id = 183, Level = 3, TopId = 19, Name = "Клавіатури та миші", Description = "Клавіатури та миші" },
                new CategoryProduct { Id = 184, Level = 3, TopId = 19, Name = "Комп'ютерні колонки", Description = "Комп'ютерні колонки" },
                new CategoryProduct { Id = 185, Level = 3, TopId = 19, Name = "Програмне забезпечення", Description = "Програмне забезпечення" },
                new CategoryProduct { Id = 186, Level = 3, TopId = 19, Name = "Джерела безперебійного живлення", Description = "Джерела безперебійного живлення" },
                new CategoryProduct { Id = 187, Level = 3, TopId = 19, Name = "Акумулятори для ДБЖ", Description = "Акумулятори для ДБЖ" },

                // Комплектуючi
                new CategoryProduct { Id = 188, Level = 3, TopId = 20, Name = "Відеокарти", Description = "Відеокарти" },
                new CategoryProduct { Id = 189, Level = 3, TopId = 20, Name = "SSD", Description = "SSD" },
                new CategoryProduct { Id = 190, Level = 3, TopId = 20, Name = "Процесори", Description = "Процесори" },
                new CategoryProduct { Id = 191, Level = 3, TopId = 20, Name = "Жорсткі диски та дискові масиви", Description = "Жорсткі диски та дискові масиви" },
                new CategoryProduct { Id = 192, Level = 3, TopId = 20, Name = "Оперативна пам'ять", Description = "Оперативна пам'ять" },
                new CategoryProduct { Id = 193, Level = 3, TopId = 20, Name = "Материнські плати", Description = "Материнські плати" },
                new CategoryProduct { Id = 194, Level = 3, TopId = 20, Name = "Блоки живлення", Description = "Блоки живлення" },
                new CategoryProduct { Id = 195, Level = 3, TopId = 20, Name = "Корпуси", Description = "Корпуси" },
                new CategoryProduct { Id = 196, Level = 3, TopId = 20, Name = "Системи охолодження", Description = "Системи охолодження" },

                // Аксесуари для ноутбуків і ПК
                new CategoryProduct { Id = 197, Level = 3, TopId = 21, Name = "Флеш пам'ять USB", Description = "Флеш пам'ять USB" },
                new CategoryProduct { Id = 198, Level = 3, TopId = 21, Name = "Мережеві фільтри, адаптери та подовжувачі", Description = "Мережеві фільтри, адаптери та подовжувачі" },
                new CategoryProduct { Id = 199, Level = 3, TopId = 21, Name = "Сумки, рюкзаки та чохли для ноутбуків", Description = "Сумки, рюкзаки та чохли для ноутбуків" },
                new CategoryProduct { Id = 200, Level = 3, TopId = 21, Name = "Підставки та столики для ноутбуків", Description = "Підставки та столики для ноутбуків" },
                new CategoryProduct { Id = 201, Level = 3, TopId = 21, Name = "Веб-камери", Description = "Веб-камери" },
                new CategoryProduct { Id = 202, Level = 3, TopId = 21, Name = "Навушники", Description = "Навушники" },
                new CategoryProduct { Id = 203, Level = 3, TopId = 21, Name = "Мікрофони", Description = "Мікрофони" },
                new CategoryProduct { Id = 204, Level = 3, TopId = 21, Name = "Універсальні мобільні батареї для ноутбуків", Description = "Універсальні мобільні батареї для ноутбуків" },
                new CategoryProduct { Id = 205, Level = 3, TopId = 21, Name = "Кабелі та перехідники", Description = "Кабелі та перехідники" },
                new CategoryProduct { Id = 206, Level = 3, TopId = 21, Name = "Графічні планшети", Description = "Графічні планшети" },

                // Офісна техніка
                new CategoryProduct { Id = 207, Level = 3, TopId = 24, Name = "БФП/Принтери", Description = "БФП/Принтери" },
                new CategoryProduct { Id = 208, Level = 3, TopId = 24, Name = "Витратні матеріали", Description = "Витратні матеріали" },
                new CategoryProduct { Id = 209, Level = 3, TopId = 24, Name = "Шредери", Description = "Шредери" },
                new CategoryProduct { Id = 210, Level = 3, TopId = 24, Name = "Телефони", Description = "Телефони" },

                // Мережеве обладнання
                new CategoryProduct { Id = 211, Level = 3, TopId = 26, Name = "Маршрутизатори", Description = "Маршрутизатори" },
                new CategoryProduct { Id = 212, Level = 3, TopId = 26, Name = "Комутатори", Description = "Комутатори" },
                new CategoryProduct { Id = 213, Level = 3, TopId = 26, Name = "Мережеві адаптери", Description = "Мережеві адаптери" },
                new CategoryProduct { Id = 214, Level = 3, TopId = 26, Name = "Ретранслятори Wi-Fi", Description = "Ретранслятори Wi-Fi" },
                new CategoryProduct { Id = 215, Level = 3, TopId = 26, Name = "Бездротові точки доступу", Description = "Бездротові точки доступу" },
                new CategoryProduct { Id = 216, Level = 3, TopId = 26, Name = "Мережеві сховища (NAS)", Description = "Мережеві сховища (NAS)" },
                new CategoryProduct { Id = 217, Level = 3, TopId = 26, Name = "Патч-корди", Description = "Патч-корди" },
                new CategoryProduct { Id = 218, Level = 3, TopId = 26, Name = "IP-телефонія", Description = "IP-телефонія" },
                new CategoryProduct { Id = 219, Level = 3, TopId = 26, Name = "Підсилювачі зв'язку", Description = "Підсилювачі зв'язку" },
            #endregion
            #region 1_2_3lvl
                // Смартфони, ТВ і Електроніка
                // Телефони
                new CategoryProduct { Id = 220, Level = 3, TopId = 27, Name = "Apple", Description = "Apple" },
                new CategoryProduct { Id = 221, Level = 3, TopId = 27, Name = "Samsung", Description = "Samsung" },
                new CategoryProduct { Id = 222, Level = 3, TopId = 27, Name = "Xiaomi", Description = "Xiaomi" },
                new CategoryProduct { Id = 223, Level = 3, TopId = 27, Name = "Motorola", Description = "Motorola" },
                new CategoryProduct { Id = 224, Level = 3, TopId = 27, Name = "Nokia", Description = "Nokia" },
                new CategoryProduct { Id = 225, Level = 3, TopId = 27, Name = "Смартфони", Description = "Смартфони" },
                new CategoryProduct { Id = 226, Level = 3, TopId = 27, Name = "Кнопкові телефони", Description = "Кнопкові телефони" },

                // Повербанки та зарядні станції
                new CategoryProduct { Id = 227, Level = 3, TopId = 28, Name = "Універсальні мобільні батареї", Description = "Універсальні мобільні батареї" },
                new CategoryProduct { Id = 228, Level = 3, TopId = 28, Name = "Зарядні станції", Description = "Зарядні станції" },

                // Аксесуари до телефонів
                new CategoryProduct { Id = 229, Level = 3, TopId = 29, Name = "Навушники", Description = "Навушники" },
                new CategoryProduct { Id = 230, Level = 3, TopId = 29, Name = "Кабелі та адаптери", Description = "Кабелі та адаптери" },
                new CategoryProduct { Id = 231, Level = 3, TopId = 29, Name = "Картки пам'яті", Description = "Картки пам'яті" },
                new CategoryProduct { Id = 232, Level = 3, TopId = 29, Name = "Чохли для мобільних телефонів", Description = "Чохли для мобільних телефонів" },
                new CategoryProduct { Id = 233, Level = 3, TopId = 29, Name = "Чохли-книжки", Description = "Чохли-книжки" },
                new CategoryProduct { Id = 234, Level = 3, TopId = 29, Name = "Бампери", Description = "Бампери" },
                new CategoryProduct { Id = 235, Level = 3, TopId = 29, Name = "Захисні плівки та скло", Description = "Захисні плівки та скло" },
                new CategoryProduct { Id = 236, Level = 3, TopId = 29, Name = "Тримачі", Description = "Тримачі" },
                new CategoryProduct { Id = 237, Level = 3, TopId = 29, Name = "Зарядні пристрої", Description = "Зарядні пристрої" },
                new CategoryProduct { Id = 238, Level = 3, TopId = 29, Name = "Мобільний інтернет", Description = "Мобільний інтернет" },

                // Телевізори та аксесуари
                new CategoryProduct { Id = 239, Level = 3, TopId = 30, Name = "Телевізори", Description = "Телевізори" },
                new CategoryProduct { Id = 240, Level = 3, TopId = 30, Name = "Samsung", Description = "Samsung" },
                new CategoryProduct { Id = 241, Level = 3, TopId = 30, Name = "LG", Description = "LG" },
                new CategoryProduct { Id = 242, Level = 3, TopId = 30, Name = "Xiaomi", Description = "Xiaomi" },
                new CategoryProduct { Id = 243, Level = 3, TopId = 30, Name = "Підставки, кріплення для ТВ", Description = "Підставки, кріплення для ТВ" },
                new CategoryProduct { Id = 244, Level = 3, TopId = 30, Name = "Кабелі та адаптери", Description = "Кабелі та адаптери" },
                new CategoryProduct { Id = 245, Level = 3, TopId = 30, Name = "ТВ-антени та ресивери", Description = "ТВ-антени та ресивери" },
                new CategoryProduct { Id = 246, Level = 3, TopId = 30, Name = "Універсальні пульти ДК", Description = "Універсальні пульти ДК" },
                new CategoryProduct { Id = 247, Level = 3, TopId = 30, Name = "ТБ запчастини та обладнання", Description = "ТБ запчастини та обладнання" },

                // Фото та відео
                new CategoryProduct { Id = 248, Level = 3, TopId = 31, Name = "Фотоапарати", Description = "Фотоапарати" },
                new CategoryProduct { Id = 249, Level = 3, TopId = 31, Name = "Відеокамери", Description = "Відеокамери" },
                new CategoryProduct { Id = 250, Level = 3, TopId = 31, Name = "Екшн-камери", Description = "Екшн-камери" },
                new CategoryProduct { Id = 251, Level = 3, TopId = 31, Name = "Об'єктиви", Description = "Об'єктиви" },
                new CategoryProduct { Id = 252, Level = 3, TopId = 31, Name = "Аксесуари для фото/відео", Description = "Аксесуари для фото/відео" },
                new CategoryProduct { Id = 253, Level = 3, TopId = 31, Name = "Зарядні пристрої для фото та відеокамер", Description = "Зарядні пристрої для фото та відеокамер" },
                new CategoryProduct { Id = 254, Level = 3, TopId = 31, Name = "Акумулятори та батарейки", Description = "Акумулятори та батарейки" },
                new CategoryProduct { Id = 255, Level = 3, TopId = 31, Name = "Штативи", Description = "Штативи" },
                new CategoryProduct { Id = 256, Level = 3, TopId = 31, Name = "Студійне обладнання", Description = "Студійне обладнання" },
                new CategoryProduct { Id = 257, Level = 3, TopId = 31, Name = "Студійне світло", Description = "Студійне світло" },
                new CategoryProduct { Id = 258, Level = 3, TopId = 31, Name = "Сумки та чохли", Description = "Сумки та чохли" },
            #endregion
            #region 1_3_3lvl
                // Товари для геймерів
                // PlayStation
                new CategoryProduct { Id = 259, Level = 3, TopId = 34, Name = "Ігрові приставки PlayStation 5", Description = "Ігрові приставки PlayStation 5" },
                new CategoryProduct { Id = 260, Level = 3, TopId = 34, Name = "Ігрові приставки PlayStation 4", Description = "Ігрові приставки PlayStation 4" },
                new CategoryProduct { Id = 261, Level = 3, TopId = 34, Name = "Ігрові приставки PlayStation", Description = "Ігрові приставки PlayStation" },
                new CategoryProduct { Id = 262, Level = 3, TopId = 34, Name = "Геймпади PlayStation", Description = "Геймпади PlayStation" },
                new CategoryProduct { Id = 263, Level = 3, TopId = 34, Name = "Шоломи VR PlayStation", Description = "Шоломи VR PlayStation" },
                new CategoryProduct { Id = 264, Level = 3, TopId = 34, Name = "Гарнітури PlayStation", Description = "Гарнітури PlayStation" },
                new CategoryProduct { Id = 265, Level = 3, TopId = 34, Name = "Аксесуари PlayStation", Description = "Аксесуари PlayStation" },
                new CategoryProduct { Id = 266, Level = 3, TopId = 34, Name = "Ігри для PlayStation 5", Description = "Ігри для PlayStation 5" },
                new CategoryProduct { Id = 267, Level = 3, TopId = 34, Name = "Ігри для PlayStation 4", Description = "Ігри для PlayStation 4" },

                // Ігрові приставки Nintendo
                new CategoryProduct { Id = 268, Level = 3, TopId = 35, Name = "Ігри для Nintendo", Description = "Ігри для Nintendo" },

                // Ігрові приставки Xbox
                new CategoryProduct { Id = 269, Level = 3, TopId = 36, Name = "Ігри для Xbox", Description = "Ігри для Xbox" },

                // Ігрові ноутбуки
                new CategoryProduct { Id = 270, Level = 3, TopId = 37, Name = "Asus", Description = "Asus" },
                new CategoryProduct { Id = 271, Level = 3, TopId = 37, Name = "HP", Description = "HP" },
                new CategoryProduct { Id = 272, Level = 3, TopId = 37, Name = "Acer", Description = "Acer" },
                new CategoryProduct { Id = 273, Level = 3, TopId = 37, Name = "MSI", Description = "MSI" },
                new CategoryProduct { Id = 274, Level = 3, TopId = 37, Name = "Dell", Description = "Dell" },
                new CategoryProduct { Id = 275, Level = 3, TopId = 37, Name = "Lenovo", Description = "Lenovo" },
                new CategoryProduct { Id = 276, Level = 3, TopId = 37, Name = "Ігри для PC", Description = "Ігри для PC" },
                new CategoryProduct { Id = 277, Level = 3, TopId = 37, Name = "ARTLINE", Description = "ARTLINE" },
                new CategoryProduct { Id = 278, Level = 3, TopId = 37, Name = "QUBE", Description = "QUBE" },
                new CategoryProduct { Id = 279, Level = 3, TopId = 37, Name = "Cobra", Description = "Cobra" },

                // Ігрові монітори
                new CategoryProduct { Id = 280, Level = 3, TopId = 38, Name = "Samsung", Description = "Samsung" },
                new CategoryProduct { Id = 281, Level = 3, TopId = 38, Name = "Acer", Description = "Acer" },
                new CategoryProduct { Id = 282, Level = 3, TopId = 38, Name = "AOC", Description = "AOC" },
                new CategoryProduct { Id = 283, Level = 3, TopId = 38, Name = "Asus", Description = "Asus" },
                new CategoryProduct { Id = 284, Level = 3, TopId = 38, Name = "MSI", Description = "MSI" },
                new CategoryProduct { Id = 285, Level = 3, TopId = 38, Name = "QUBE", Description = "QUBE" },

                // Комплектуючі для геймерів
                new CategoryProduct { Id = 286, Level = 3, TopId = 39, Name = "Відеокарти", Description = "Відеокарти" },
                new CategoryProduct { Id = 287, Level = 3, TopId = 39, Name = "Процесори", Description = "Процесори" },
                new CategoryProduct { Id = 288, Level = 3, TopId = 39, Name = "Оперативна пам'ять", Description = "Оперативна пам'ять" },
                new CategoryProduct { Id = 289, Level = 3, TopId = 39, Name = "Материнські плати", Description = "Материнські плати" },
                new CategoryProduct { Id = 290, Level = 3, TopId = 39, Name = "Жорсткі диски", Description = "Жорсткі диски" },
                new CategoryProduct { Id = 291, Level = 3, TopId = 39, Name = "Блоки живлення", Description = "Блоки живлення" },
                new CategoryProduct { Id = 292, Level = 3, TopId = 39, Name = "Системи охолодження", Description = "Системи охолодження" },
                new CategoryProduct { Id = 293, Level = 3, TopId = 39, Name = "Корпуси", Description = "Корпуси" },

                // Ігрова периферія
                new CategoryProduct { Id = 294, Level = 3, TopId = 40, Name = "Навушники", Description = "Навушники" },
                new CategoryProduct { Id = 295, Level = 3, TopId = 40, Name = "Ігрові миші", Description = "Ігрові миші" },
                new CategoryProduct { Id = 296, Level = 3, TopId = 40, Name = "Ігрові клавіатури", Description = "Ігрові клавіатури" },
                new CategoryProduct { Id = 297, Level = 3, TopId = 40, Name = "Ігрові коврики", Description = "Ігрові коврики" },
                new CategoryProduct { Id = 298, Level = 3, TopId = 40, Name = "Маніпулятори, джойстики", Description = "Маніпулятори, джойстики" },
                new CategoryProduct { Id = 299, Level = 3, TopId = 40, Name = "Геймерські крісла", Description = "Геймерські крісла" },
                new CategoryProduct { Id = 300, Level = 3, TopId = 40, Name = "Комп'ютерні столи", Description = "Комп'ютерні столи" },
                new CategoryProduct { Id = 301, Level = 3, TopId = 40, Name = "Геймерські рюкзаки", Description = "Геймерські рюкзаки" },

                // Ігрові маршрутизатори
                // (Немає категорій на рівні 3)

                // Атрибутика й сувеніри
                new CategoryProduct { Id = 302, Level = 3, TopId = 42, Name = "Браслети", Description = "Браслети" },
                new CategoryProduct { Id = 303, Level = 3, TopId = 42, Name = "Брелоки", Description = "Брелоки" },
                new CategoryProduct { Id = 304, Level = 3, TopId = 42, Name = "Гаманці", Description = "Гаманці" },
                new CategoryProduct { Id = 305, Level = 3, TopId = 42, Name = "Подушки", Description = "Подушки" },
                new CategoryProduct { Id = 306, Level = 3, TopId = 42, Name = "Чашки", Description = "Чашки" },
                new CategoryProduct { Id = 307, Level = 3, TopId = 42, Name = "Фігурки і статуетки", Description = "Фігурки і статуетки" },
                new CategoryProduct { Id = 308, Level = 3, TopId = 42, Name = "Одяг для геймерів", Description = "Одяг для геймерів" },
                new CategoryProduct { Id = 309, Level = 3, TopId = 42, Name = "Кепки і головні убори", Description = "Кепки і головні убори" },
                new CategoryProduct { Id = 310, Level = 3, TopId = 42, Name = "Рюкзаки та сумки", Description = "Рюкзаки та сумки" },
                new CategoryProduct { Id = 311, Level = 3, TopId = 42, Name = "М'які іграшки", Description = "М'які іграшки" },
                new CategoryProduct { Id = 312, Level = 3, TopId = 42, Name = "Подарункові набори для геймерів", Description = "Подарункові набори для геймерів" },
                new CategoryProduct { Id = 313, Level = 3, TopId = 42, Name = "Картинки і постери", Description = "Картинки і постери" },

// Послуги та сервіси для електроніки
// (Немає категорій на рівні 3)
            #endregion
            #region 1_4_3lvl
                // Побутова техніка
                // Велика побутова техніка
                new CategoryProduct { Id = 314, Level = 3, TopId = 44, Name = "Холодильники", Description = "Холодильники" },
                new CategoryProduct { Id = 315, Level = 3, TopId = 44, Name = "Морозильні камери", Description = "Морозильні камери" },
                new CategoryProduct { Id = 316, Level = 3, TopId = 44, Name = "Пральні машини", Description = "Пральні машини" },
                new CategoryProduct { Id = 317, Level = 3, TopId = 44, Name = "Пральні машини із сушаркою", Description = "Пральні машини із сушаркою" },
                new CategoryProduct { Id = 318, Level = 3, TopId = 44, Name = "Посудомийні машини", Description = "Посудомийні машини" },
                new CategoryProduct { Id = 319, Level = 3, TopId = 44, Name = "Мікрохвильові печі", Description = "Мікрохвильові печі" },
                new CategoryProduct { Id = 320, Level = 3, TopId = 44, Name = "Сушильні автомати", Description = "Сушильні автомати" },
                new CategoryProduct { Id = 321, Level = 3, TopId = 44, Name = "Плити", Description = "Плити" },
                new CategoryProduct { Id = 322, Level = 3, TopId = 44, Name = "Вбудовувані духові шафи", Description = "Вбудовувані духові шафи" },
                new CategoryProduct { Id = 323, Level = 3, TopId = 44, Name = "Вбудовувані варильні поверхні", Description = "Вбудовувані варильні поверхні" },
                new CategoryProduct { Id = 324, Level = 3, TopId = 44, Name = "Комплекти вбудованої техніки", Description = "Комплекти вбудованої техніки" },
                new CategoryProduct { Id = 325, Level = 3, TopId = 44, Name = "Кухонні витяжки", Description = "Кухонні витяжки" },
                new CategoryProduct { Id = 326, Level = 3, TopId = 44, Name = "Сертифікати на продовження гарантії", Description = "Сертифікати на продовження гарантії" },
                new CategoryProduct { Id = 327, Level = 3, TopId = 44, Name = "Встановлення великої побутової техніки", Description = "Встановлення великої побутової техніки" },

                // Догляд та прибирання
                new CategoryProduct { Id = 328, Level = 3, TopId = 45, Name = "Акумуляторні пилососи", Description = "Акумуляторні пилососи" },
                new CategoryProduct { Id = 329, Level = 3, TopId = 45, Name = "Роботи-пилососи", Description = "Роботи-пилососи" },
                new CategoryProduct { Id = 330, Level = 3, TopId = 45, Name = "Пилососи для сухого прибирання", Description = "Пилососи для сухого прибирання" },
                new CategoryProduct { Id = 331, Level = 3, TopId = 45, Name = "Праски", Description = "Праски" },
                new CategoryProduct { Id = 332, Level = 3, TopId = 45, Name = "Відпарювачі", Description = "Відпарювачі" },
                new CategoryProduct { Id = 333, Level = 3, TopId = 45, Name = "Прасувальні системи", Description = "Прасувальні системи" },
                new CategoryProduct { Id = 334, Level = 3, TopId = 45, Name = "Праски з парогенератором", Description = "Праски з парогенератором" },
                new CategoryProduct { Id = 335, Level = 3, TopId = 45, Name = "Миючі пилососи", Description = "Миючі пилососи" },
                new CategoryProduct { Id = 336, Level = 3, TopId = 45, Name = "Пароочисники", Description = "Пароочисники" },
                new CategoryProduct { Id = 337, Level = 3, TopId = 45, Name = "Швейна техніка та аксесуари", Description = "Швейна техніка та аксесуари" },

                // Кліматична техніка
                new CategoryProduct { Id = 338, Level = 3, TopId = 46, Name = "Настінні кондиціонери", Description = "Настінні кондиціонери" },
                new CategoryProduct { Id = 339, Level = 3, TopId = 46, Name = "Мобільні кондиціонери", Description = "Мобільні кондиціонери" },
                new CategoryProduct { Id = 340, Level = 3, TopId = 46, Name = "Вентилятори", Description = "Вентилятори" },
                new CategoryProduct { Id = 341, Level = 3, TopId = 46, Name = "Бойлери", Description = "Бойлери" },
                new CategoryProduct { Id = 342, Level = 3, TopId = 46, Name = "Очищувачі повітря", Description = "Очищувачі повітря" },
                new CategoryProduct { Id = 343, Level = 3, TopId = 46, Name = "Зволожувачі повітря", Description = "Зволожувачі повітря" },
                new CategoryProduct { Id = 344, Level = 3, TopId = 46, Name = "Осушувачі повітря", Description = "Осушувачі повітря" },
                new CategoryProduct { Id = 345, Level = 3, TopId = 46, Name = "Обігрівачі", Description = "Обігрівачі" },
                new CategoryProduct { Id = 346, Level = 3, TopId = 46, Name = "Монтаж кондиціонера", Description = "Монтаж кондиціонера" },
                new CategoryProduct { Id = 347, Level = 3, TopId = 46, Name = "Сертифікати на продовження гарантії", Description = "Сертифікати на продовження гарантії" },

                // Техніка для кухні
                new CategoryProduct { Id = 348, Level = 3, TopId = 47, Name = "Кавомашини", Description = "Кавомашини" },
                new CategoryProduct { Id = 349, Level = 3, TopId = 47, Name = "Мультипечі та аерогрилі", Description = "Мультипечі та аерогрилі" },
                new CategoryProduct { Id = 350, Level = 3, TopId = 47, Name = "Блендери", Description = "Блендери" },
                new CategoryProduct { Id = 351, Level = 3, TopId = 47, Name = "Грилі та електрошашличниці", Description = "Грилі та електрошашличниці" },
                new CategoryProduct { Id = 352, Level = 3, TopId = 47, Name = "Кухонні комбайни", Description = "Кухонні комбайни" },
                new CategoryProduct { Id = 353, Level = 3, TopId = 47, Name = "Мультиварки", Description = "Мультиварки" },
                new CategoryProduct { Id = 354, Level = 3, TopId = 47, Name = "Соковичавниці", Description = "Соковичавниці" },
                new CategoryProduct { Id = 355, Level = 3, TopId = 47, Name = "Електрочайники", Description = "Електрочайники" },
                new CategoryProduct { Id = 356, Level = 3, TopId = 47, Name = "Електричні печі", Description = "Електричні печі" },
                new CategoryProduct { Id = 357, Level = 3, TopId = 47, Name = "М'ясорубки", Description = "М'ясорубки" },
                new CategoryProduct { Id = 358, Level = 3, TopId = 47, Name = "Тостери", Description = "Тостери" },
                new CategoryProduct { Id = 359, Level = 3, TopId = 47, Name = "Хлібопічки", Description = "Хлібопічки" },
                new CategoryProduct { Id = 360, Level = 3, TopId = 47, Name = "Міксери", Description = "Міксери" },
                new CategoryProduct { Id = 361, Level = 3, TopId = 47, Name = "Фільтри-глечики", Description = "Фільтри-глечики" },
                new CategoryProduct { Id = 362, Level = 3, TopId = 47, Name = "Картриджі для фільтрів глечиків", Description = "Картриджі для фільтрів глечиків" },
                new CategoryProduct { Id = 363, Level = 3, TopId = 47, Name = "Світ кави", Description = "Світ кави" },

                // Дрібна побутова техніка
                new CategoryProduct { Id = 364, Level = 3, TopId = 48, Name = "Вентилятори", Description = "Вентилятори" },
                new CategoryProduct { Id = 365, Level = 3, TopId = 48, Name = "Пилососи", Description = "Пилососи" },
                new CategoryProduct { Id = 366, Level = 3, TopId = 48, Name = "Блендери", Description = "Блендери" },
                new CategoryProduct { Id = 367, Level = 3, TopId = 48, Name = "Кухонні комбайни", Description = "Кухонні комбайни" },
                new CategoryProduct { Id = 368, Level = 3, TopId = 48, Name = "Електричні зубні щітки", Description = "Електричні зубні щітки" },
                new CategoryProduct { Id = 369, Level = 3, TopId = 48, Name = "Праски", Description = "Праски" },
                new CategoryProduct { Id = 370, Level = 3, TopId = 48, Name = "Електрочайники", Description = "Електричні чайники" },
                new CategoryProduct { Id = 371, Level = 3, TopId = 48, Name = "Сертифікати на продовження гарантії", Description = "Сертифікати на продовження гарантії" },
            #endregion
            #region 1_5_3lvl
                //Товари для дому
                // Меблі
                new CategoryProduct { Id = 372, Level = 3, TopId = 49, Name = "Столи з регулюванням по висоті", Description = "Столи з регулюванням по висоті" },
                new CategoryProduct { Id = 373, Level = 3, TopId = 49, Name = "Комп'ютерні столи", Description = "Комп'ютерні столи" },
                new CategoryProduct { Id = 374, Level = 3, TopId = 49, Name = "Крісла", Description = "Крісла" },
                new CategoryProduct { Id = 375, Level = 3, TopId = 49, Name = "Стільці", Description = "Стільці" },
                new CategoryProduct { Id = 376, Level = 3, TopId = 49, Name = "Обідні столи", Description = "Обідні столи" },
                new CategoryProduct { Id = 377, Level = 3, TopId = 49, Name = "Кухонні гарнітури", Description = "Кухонні гарнітури" },
                new CategoryProduct { Id = 378, Level = 3, TopId = 49, Name = "Стелажі та консолі", Description = "Стелажі та консолі" },
                new CategoryProduct { Id = 379, Level = 3, TopId = 49, Name = "Меблі для спальні", Description = "Меблі для спальні" },
                new CategoryProduct { Id = 380, Level = 3, TopId = 49, Name = "Безкаркасні меблі", Description = "Безкаркасні меблі" },
                new CategoryProduct { Id = 381, Level = 3, TopId = 49, Name = "Шафи", Description = "Шафи" },
                new CategoryProduct { Id = 382, Level = 3, TopId = 49, Name = "Меблі для передпокою і вбиральні", Description = "Меблі для передпокою і вбиральні" },
                new CategoryProduct { Id = 383, Level = 3, TopId = 49, Name = "Тумби", Description = "Тумби" },
                new CategoryProduct { Id = 384, Level = 3, TopId = 49, Name = "Полиці", Description = "Полиці" },
                new CategoryProduct { Id = 385, Level = 3, TopId = 49, Name = "Меблі для саду та дачі", Description = "Меблі для саду та дачі" },
                new CategoryProduct { Id = 386, Level = 3, TopId = 49, Name = "Комоди", Description = "Комоди" },
                new CategoryProduct { Id = 387, Level = 3, TopId = 49, Name = "Металеві меблі", Description = "Металеві меблі" },

                // Декор для дому
                new CategoryProduct { Id = 388, Level = 3, TopId = 50, Name = "Аромати для дому", Description = "Аромати для дому" },
                new CategoryProduct { Id = 389, Level = 3, TopId = 50, Name = "Підсвічники", Description = "Підсвічники" },
                new CategoryProduct { Id = 390, Level = 3, TopId = 50, Name = "Настінний декор", Description = "Настінний декор" },
                new CategoryProduct { Id = 391, Level = 3, TopId = 50, Name = "Вази", Description = "Вази" },
                new CategoryProduct { Id = 392, Level = 3, TopId = 50, Name = "Інтер'єрні наклейки", Description = "Інтер'єрні наклейки" },
                new CategoryProduct { Id = 393, Level = 3, TopId = 50, Name = "Ароматерапія", Description = "Ароматерапія" },
                new CategoryProduct { Id = 394, Level = 3, TopId = 50, Name = "Ікони", Description = "Ікони" },
                new CategoryProduct { Id = 395, Level = 3, TopId = 50, Name = "Фотоальбоми", Description = "Фотоальбоми" },
                new CategoryProduct { Id = 396, Level = 3, TopId = 50, Name = "Фоторамки", Description = "Фоторамки" },
                new CategoryProduct { Id = 397, Level = 3, TopId = 50, Name = "Свічки", Description = "Свічки" },

                // Системи охорони і безпеки
                new CategoryProduct { Id = 398, Level = 3, TopId = 51, Name = "Домофони", Description = "Домофони" },
                new CategoryProduct { Id = 399, Level = 3, TopId = 51, Name = "Комплекти відеоспостереження", Description = "Комплекти відеоспостереження" },
                new CategoryProduct { Id = 400, Level = 3, TopId = 51, Name = "Комплекти сигналізацій", Description = "Комплекти сигналізацій" },
                new CategoryProduct { Id = 401, Level = 3, TopId = 51, Name = "Відеодомофони", Description = "Відеодомофони" },
                new CategoryProduct { Id = 402, Level = 3, TopId = 51, Name = "Стабілізатори напруги", Description = "Стабілізатори напруги" },
                new CategoryProduct { Id = 403, Level = 3, TopId = 51, Name = "Інвертори", Description = "Інвертори" },

                // Освітлення
                new CategoryProduct { Id = 404, Level = 3, TopId = 52, Name = "Люстри", Description = "Люстри" },
                new CategoryProduct { Id = 405, Level = 3, TopId = 52, Name = "Лампи", Description = "Лампи" },
                new CategoryProduct { Id = 406, Level = 3, TopId = 52, Name = "Настельні світильники", Description = "Настельні світильники" },
                new CategoryProduct { Id = 407, Level = 3, TopId = 52, Name = "Точкові світильники", Description = "Точкові світильники" },
                new CategoryProduct { Id = 408, Level = 3, TopId = 52, Name = "Бра і стельові світильники", Description = "Бра і стельові світильники" },
                new CategoryProduct { Id = 409, Level = 3, TopId = 52, Name = "Освітлення", Description = "Освітлення" },
                new CategoryProduct { Id = 410, Level = 3, TopId = 52, Name = "Послуги електрика", Description = "Послуги електрика" },

                // Посуд
                new CategoryProduct { Id = 411, Level = 3, TopId = 53, Name = "Келихи та фужери", Description = "Келихи та фужери" },
                new CategoryProduct { Id = 412, Level = 3, TopId = 53, Name = "Стопки та чарки", Description = "Стопки та чарки" },

                // Інвентар для дому та офісу
                new CategoryProduct { Id = 413, Level = 3, TopId = 54, Name = "Сходи", Description = "Сходи" },
                new CategoryProduct { Id = 414, Level = 3, TopId = 54, Name = "Прасувальні дошки", Description = "Прасувальні дошки" },
                new CategoryProduct { Id = 415, Level = 3, TopId = 54, Name = "Сушарки для білизни", Description = "Сушарки для білизни" },
                new CategoryProduct { Id = 416, Level = 3, TopId = 54, Name = "Господарський інвентар", Description = "Господарський інвентар" },
                new CategoryProduct { Id = 417, Level = 3, TopId = 54, Name = "Брудозахисні покриття", Description = "Брудозахисні покриття" },
                new CategoryProduct { Id = 418, Level = 3, TopId = 54, Name = "Прання та прасування", Description = "Прання та прасування" },
                new CategoryProduct { Id = 419, Level = 3, TopId = 54, Name = "Мотузяні вироби", Description = "Мотузяні вироби" },
                new CategoryProduct { Id = 420, Level = 3, TopId = 54, Name = "Клінінгові обладнання", Description = "Клінінгові обладнання" },
                new CategoryProduct { Id = 421, Level = 3, TopId = 54, Name = "Сміттєві контейнери", Description = "Сміттєві контейнери" },

                // Господарські товари
                new CategoryProduct { Id = 422, Level = 3, TopId = 55, Name = "Туалетний папір", Description = "Туалетний папір" },
                new CategoryProduct { Id = 423, Level = 3, TopId = 55, Name = "Паперові рушники", Description = "Паперові рушники" },
                new CategoryProduct { Id = 424, Level = 3, TopId = 55, Name = "Серветки", Description = "Серветки" },
                new CategoryProduct { Id = 425, Level = 3, TopId = 55, Name = "Сміттєві пакети", Description = "Сміттєві пакети" },
                new CategoryProduct { Id = 426, Level = 3, TopId = 55, Name = "Кухонні губки", Description = "Кухонні губки" },
                new CategoryProduct { Id = 427, Level = 3, TopId = 55, Name = "Харчова упаковка", Description = "Харчова упаковка" },
                new CategoryProduct { Id = 428, Level = 3, TopId = 55, Name = "Господарські рукавички", Description = "Господарські рукавички" },
                new CategoryProduct { Id = 429, Level = 3, TopId = 55, Name = "Серветки для прибирання", Description = "Серветки для прибирання" },
                new CategoryProduct { Id = 430, Level = 3, TopId = 55, Name = "Одноразовий посуд", Description = "Одноразовий посуд" },
                new CategoryProduct { Id = 431, Level = 3, TopId = 55, Name = "Гігієнічні накладки на унітаз", Description = "Гігієнічні накладки на унітаз" },
            #endregion
            #region 1_6_3lvl
            // Інструменти та автотовари
            //Інструменти
            new CategoryProduct { Id = 432, Level = 3, TopId = 56, Name = "Шурупокрути та електровикрутки", Description = "Шурупокрути та електровикрутки" },
            new CategoryProduct { Id = 433, Level = 3, TopId = 56, Name = "Болгарки", Description = "Болгарки" },
            new CategoryProduct { Id = 434, Level = 3, TopId = 56, Name = "Перфоратори", Description = "Перфоратори" },
            new CategoryProduct { Id = 435, Level = 3, TopId = 56, Name = "Дрилі та міксери", Description = "Дрилі та міксери" },
            new CategoryProduct { Id = 436, Level = 3, TopId = 56, Name = "Пили та плиткорізи", Description = "Пили та плиткорізи" },
            new CategoryProduct { Id = 437, Level = 3, TopId = 56, Name = "Фарбопульти", Description = "Фарбопульти" },
            new CategoryProduct { Id = 438, Level = 3, TopId = 56, Name = "Електролобзики", Description = "Електролобзики" },
            new CategoryProduct { Id = 439, Level = 3, TopId = 56, Name = "Вимірювальна техніка", Description = "Вимірювальна техніка" },
            new CategoryProduct { Id = 440, Level = 3, TopId = 56, Name = "Фрезери", Description = "Фрезери" },
            new CategoryProduct { Id = 441, Level = 3, TopId = 56, Name = "Багатофункційні інструменти", Description = "Багатофункційні інструменти" },
            new CategoryProduct { Id = 442, Level = 3, TopId = 56, Name = "Клейові пістолети та аксесуари", Description = "Клейові пістолети та аксесуари" },
            new CategoryProduct { Id = 443, Level = 3, TopId = 56, Name = "Електрорубанки", Description = "Електрорубанки" },
            new CategoryProduct { Id = 444, Level = 3, TopId = 56, Name = "Будівельні фени", Description = "Будівельні фени" },

            //Витратні матеріали та приладдя
            new CategoryProduct { Id = 445, Level = 3, TopId = 57, Name = "Свердла", Description = "Свердла" },
            new CategoryProduct { Id = 446, Level = 3, TopId = 57, Name = "Диски", Description = "Диски" },
            new CategoryProduct { Id = 447, Level = 3, TopId = 57, Name = "Біти", Description = "Біти" },
            new CategoryProduct { Id = 448, Level = 3, TopId = 57, Name = "Бури", Description = "Бури" },
            new CategoryProduct { Id = 449, Level = 3, TopId = 57, Name = "Пиляльні полотна", Description = "Пиляльні полотна" },
            new CategoryProduct { Id = 450, Level = 3, TopId = 57, Name = "Фрези", Description = "Фрези" },

            //Обладнання
            new CategoryProduct { Id = 451, Level = 3, TopId = 58, Name = "Зварювальне обладнання", Description = "Зварювальне обладнання" },
            new CategoryProduct { Id = 452, Level = 3, TopId = 58, Name = "Генератори", Description = "Генератори" },
            new CategoryProduct { Id = 453, Level = 3, TopId = 58, Name = "Стабілізатори напруги", Description = "Стабілізатори напруги" },
            new CategoryProduct { Id = 454, Level = 3, TopId = 58, Name = "Універсальні мийки", Description = "Універсальні мийки" },
            new CategoryProduct { Id = 455, Level = 3, TopId = 58, Name = "Бетономішалки", Description = "Бетономішалки" },
            new CategoryProduct { Id = 456, Level = 3, TopId = 58, Name = "Компресори", Description = "Компресори" },
            new CategoryProduct { Id = 457, Level = 3, TopId = 58, Name = "Теплові гармати", Description = "Теплові гармати" },
            new CategoryProduct { Id = 458, Level = 3, TopId = 58, Name = "Точильні верстати", Description = "Точильні верстати" },
            new CategoryProduct { Id = 459, Level = 3, TopId = 58, Name = "Вантажопідіймальне обладнання", Description = "Вантажопідіймальне обладнання" },
            new CategoryProduct { Id = 460, Level = 3, TopId = 58, Name = "Інвертори", Description = "Інвертори" },
            new CategoryProduct { Id = 461, Level = 3, TopId = 58, Name = "Промислові пилососи", Description = "Промислові пилососи" },

            //Ручний інструмент
            new CategoryProduct { Id = 462, Level = 3, TopId = 59, Name = "Набори інструментів", Description = "Набори інструментів" },
            new CategoryProduct { Id = 463, Level = 3, TopId = 59, Name = "Скрині та сумки для інструментів", Description = "Скрині та сумки для інструментів" },
            new CategoryProduct { Id = 464, Level = 3, TopId = 59, Name = "Ключі, знімачі", Description = "Ключі, знімачі" },
            new CategoryProduct { Id = 465, Level = 3, TopId = 59, Name = "Викрутки", Description = "Викрутки" },
            new CategoryProduct { Id = 466, Level = 3, TopId = 59, Name = "Вимірювально-розмічальний інструмент", Description = "Вимірювально-розмічальний інструмент" },
            new CategoryProduct { Id = 467, Level = 3, TopId = 59, Name = "Шарнірно-губцевий інструмент", Description = "Шарнірно-губцевий інструмент" },
            
            //Електромонтажне обладнання
            new CategoryProduct { Id = 468, Level = 3, TopId = 60, Name = "Розетки та вимикачі", Description = "Розетки та вимикачі" },
            new CategoryProduct { Id = 469, Level = 3, TopId = 60, Name = "Кабельно-провідникова продукція", Description = "Кабельно-провідникова продукція" },

            //Автотовари
            new CategoryProduct { Id = 470, Level = 3, TopId = 61, Name = "Автозапчастини", Description = "Автозапчастини" },
            new CategoryProduct { Id = 471, Level = 3, TopId = 61, Name = "Шини", Description = "Шини" },
            new CategoryProduct { Id = 472, Level = 3, TopId = 61, Name = "Автомобільні диски", Description = "Автомобільні диски" },
            new CategoryProduct { Id = 473, Level = 3, TopId = 61, Name = "Відеореєстратори", Description = "Відеореєстратори" },
            new CategoryProduct { Id = 474, Level = 3, TopId = 61, Name = "Мастила й оливи", Description = "Мастила й оливи" },
            new CategoryProduct { Id = 475, Level = 3, TopId = 61, Name = "GPS-навігатори", Description = "GPS-навігатори" },
            new CategoryProduct { Id = 476, Level = 3, TopId = 61, Name = "Автокомпресори", Description = "Автокомпресори" },
            new CategoryProduct { Id = 477, Level = 3, TopId = 61, Name = "Головні пристрої", Description = "Головні пристрої" },
            new CategoryProduct { Id = 478, Level = 3, TopId = 61, Name = "Пускозарядні пристрої", Description = "Пускозарядні пристрої" },
            new CategoryProduct { Id = 479, Level = 3, TopId = 61, Name = "Автоприладдя", Description = "Автоприладдя" },
            new CategoryProduct { Id = 480, Level = 3, TopId = 61, Name = "Автосигналізації", Description = "Автосигналізації" },
            new CategoryProduct { Id = 481, Level = 3, TopId = 61, Name = "Техдопомога", Description = "Техдопомога" },
            new CategoryProduct { Id = 482, Level = 3, TopId = 61, Name = "Домкрати", Description = "Домкрати" },
            new CategoryProduct { Id = 483, Level = 3, TopId = 61, Name = "Автоакустика", Description = "Автоакустика" },
            new CategoryProduct { Id = 484, Level = 3, TopId = 61, Name = "Паркувальні системи", Description = "Паркувальні системи" },
            new CategoryProduct { Id = 485, Level = 3, TopId = 61, Name = "Автохімія", Description = "Автохімія" },
            new CategoryProduct { Id = 486, Level = 3, TopId = 61, Name = "FM-трансмітери", Description = "FM-трансмітери" },
            new CategoryProduct { Id = 487, Level = 3, TopId = 61, Name = "Автолампи", Description = "Автолампи" },
            new CategoryProduct { Id = 488, Level = 3, TopId = 61, Name = "Автокосметика", Description = "Автокосметика" },
            new CategoryProduct { Id = 489, Level = 3, TopId = 61, Name = "Радар-детектори", Description = "Радар-детектори" },
            new CategoryProduct { Id = 490, Level = 3, TopId = 61, Name = "Штатні головні пристрої", Description = "Штатні головні пристрої" },
            new CategoryProduct { Id = 491, Level = 3, TopId = 61, Name = "Дефлектори", Description = "Дефлектори" },
            new CategoryProduct { Id = 492, Level = 3, TopId = 61, Name = "Автофарби", Description = "Автофарби" },
            new CategoryProduct { Id = 493, Level = 3, TopId = 61, Name = "Електрообладнання автомобілів", Description = "Електрообладнання автомобілів" },
            #endregion
            #region 1_7_3lvl
                // Сантехніка та ремонт
                // Ванни, бокси, душові
                new CategoryProduct { Id = 494, Level = 3, TopId = 62, Name = "Ванни", Description = "Ванни" },
                new CategoryProduct { Id = 495, Level = 3, TopId = 62, Name = "Гідромасажні бокси", Description = "Гідромасажні бокси" },
                new CategoryProduct { Id = 496, Level = 3, TopId = 62, Name = "Душові гарнітури", Description = "Душові гарнітури" },
                new CategoryProduct { Id = 497, Level = 3, TopId = 62, Name = "Душові кабіни та стінки", Description = "Душові кабіни та стінки" },
                new CategoryProduct { Id = 498, Level = 3, TopId = 62, Name = "Бойлери", Description = "Бойлери" },
                new CategoryProduct { Id = 499, Level = 3, TopId = 62, Name = "Панелі для ванн", Description = "Панелі для ванн" },
                new CategoryProduct { Id = 500, Level = 3, TopId = 62, Name = "Душові двері та перегородки", Description = "Душові двері та перегородки" },

                // Мийки, змішувачі, сифони
                new CategoryProduct { Id = 501, Level = 3, TopId = 63, Name = "Змішувачі", Description = "Змішувачі" },
                new CategoryProduct { Id = 502, Level = 3, TopId = 63, Name = "Кухонні мийки", Description = "Кухонні мийки" },
                new CategoryProduct { Id = 503, Level = 3, TopId = 63, Name = "Кухонні змішувачі", Description = "Кухонні змішувачі" },
                new CategoryProduct { Id = 504, Level = 3, TopId = 63, Name = "Сифони", Description = "Сифони" },
                new CategoryProduct { Id = 505, Level = 3, TopId = 63, Name = "Системи зворотного осмосу", Description = "Системи зворотного осмосу" },

                // Кераміка
                new CategoryProduct { Id = 506, Level = 3, TopId = 64, Name = "Унітази", Description = "Унітази" },
                new CategoryProduct { Id = 507, Level = 3, TopId = 64, Name = "Раковини", Description = "Раковини" },
                new CategoryProduct { Id = 508, Level = 3, TopId = 64, Name = "Сушарки для рук", Description = "Сушарки для рук" },
                new CategoryProduct { Id = 509, Level = 3, TopId = 64, Name = "Біде", Description = "Біде" },
                new CategoryProduct { Id = 510, Level = 3, TopId = 64, Name = "Бачки для унітазу", Description = "Бачки для унітазу" },
                new CategoryProduct { Id = 511, Level = 3, TopId = 64, Name = "Паперотримачі та полички", Description = "Паперотримачі та полички" },

                // Інсталяції та комплектуючі 
                new CategoryProduct { Id = 512, Level = 3, TopId = 66, Name = "Інсталяції для унітазу", Description = "Інсталяції для унітазу" },
                new CategoryProduct { Id = 513, Level = 3, TopId = 66, Name = "Інсталяції для біде", Description = "Інсталяції для біде" },
                new CategoryProduct { Id = 514, Level = 3, TopId = 66, Name = "Кнопки для змиву", Description = "Кнопки для змиву" },

                // Сушильники для рушників і радіатори
                new CategoryProduct { Id = 515, Level = 3, TopId = 67, Name = "Сушильники для рушників", Description = "Сушильники для рушників" },
                new CategoryProduct { Id = 516, Level = 3, TopId = 67, Name = "Радіатори", Description = "Радіатори" },

                // Інструменти
                new CategoryProduct { Id = 517, Level = 3, TopId = 68, Name = "Болгарки", Description = "Болгарки" },
                new CategoryProduct { Id = 518, Level = 3, TopId = 68, Name = "Перфоратори", Description = "Перфоратори" },
                new CategoryProduct { Id = 519, Level = 3, TopId = 68, Name = "Витратні матеріали та приладдя", Description = "Витратні матеріали та приладдя" },
                new CategoryProduct { Id = 520, Level = 3, TopId = 68, Name = "Обладнання", Description = "Обладнання" },
                new CategoryProduct { Id = 521, Level = 3, TopId = 68, Name = "Генератори", Description = "Генератори" },
                new CategoryProduct { Id = 522, Level = 3, TopId = 68, Name = "Зварювальне обладнання", Description = "Зварювальне обладнання" },
                new CategoryProduct { Id = 523, Level = 3, TopId = 68, Name = "Промислові пилососи", Description = "Промислові пилососи" },

                // Ручний інструмент
                new CategoryProduct { Id = 524, Level = 3, TopId = 69, Name = "Набори інструментів", Description = "Набори інструментів" },
                new CategoryProduct { Id = 525, Level = 3, TopId = 69, Name = "Ключі, знімачі", Description = "Ключі, знімачі" },
                new CategoryProduct { Id = 526, Level = 3, TopId = 69, Name = "Скрині та сумки для інструментів", Description = "Скрині та сумки для інструментів" },

                // Освітлення
                new CategoryProduct { Id = 527, Level = 3, TopId = 70, Name = "Люстри", Description = "Люстри" },
                new CategoryProduct { Id = 528, Level = 3, TopId = 70, Name = "Настінно-стельові світильники", Description = "Настінно-стельові світильники" },
                new CategoryProduct { Id = 529, Level = 3, TopId = 70, Name = "Точкові світильники", Description = "Точкові світильники" },
                new CategoryProduct { Id = 530, Level = 3, TopId = 70, Name = "Бра та настінні світильники", Description = "Бра та настінні світильники" },
                new CategoryProduct { Id = 531, Level = 3, TopId = 70, Name = "Настільні лампи", Description = "Настільні лампи" },
                new CategoryProduct { Id = 532, Level = 3, TopId = 70, Name = "Торшери", Description = "Торшери" },
                new CategoryProduct { Id = 533, Level = 3, TopId = 70, Name = "Світильники для ванної", Description = "Світильники для ванної" },
                new CategoryProduct { Id = 534, Level = 3, TopId = 70, Name = "Дитячі настільні лампи", Description = "Дитячі настільні лампи" },
                new CategoryProduct { Id = 535, Level = 3, TopId = 70, Name = "Вуличне освітлення", Description = "Вуличне освітлення" },
                new CategoryProduct { Id = 536, Level = 3, TopId = 70, Name = "Лампочки та аксесуари", Description = "Лампочки та аксесуари" },
                new CategoryProduct { Id = 537, Level = 3, TopId = 70, Name = "Офісно-промислове освітлення", Description = "Офісно-промислове освітлення" },

                // Лічильники
                new CategoryProduct { Id = 538, Level = 3, TopId = 71, Name = "Захист від перепадів напруги", Description = "Захист від перепадів напруги" },
                new CategoryProduct { Id = 539, Level = 3, TopId = 71, Name = "Лічильники води", Description = "Лічильники води" },
                new CategoryProduct { Id = 540, Level = 3, TopId = 71, Name = "Лічильники газу", Description = "Лічильники газу" },
                new CategoryProduct { Id = 541, Level = 3, TopId = 71, Name = "Лічильники електроенергії", Description = "Лічильники електроенергії" },

                // Меблі для ванної кімнати
                new CategoryProduct { Id = 542, Level = 3, TopId = 72, Name = "Тумби", Description = "Тумби" },
                new CategoryProduct { Id = 543, Level = 3, TopId = 72, Name = "Дзеркала", Description = "Дзеркала" },
                new CategoryProduct { Id = 544, Level = 3, TopId = 72, Name = "Пенали", Description = "Пенали" },

                // Будівельні матеріали
                new CategoryProduct { Id = 545, Level = 3, TopId = 74, Name = "Покрівля та водостік", Description = "Покрівля та водостік" },
            #endregion
            #region 1_8_3lvl
                // Дача, сад, город
                // Садова техніка
                new CategoryProduct { Id = 546, Level = 3, TopId = 75, Name = "Газонокосарки", Description = "Газонокосарки" },
                new CategoryProduct { Id = 547, Level = 3, TopId = 75, Name = "Тримери та мотокоси", Description = "Тримери та мотокоси" },
                new CategoryProduct { Id = 548, Level = 3, TopId = 75, Name = "Електрокультиватори", Description = "Електрокультиватори" },
                new CategoryProduct { Id = 549, Level = 3, TopId = 75, Name = "Кущорізи", Description = "Кущорізи" },
                new CategoryProduct { Id = 550, Level = 3, TopId = 75, Name = "Мотокультиватори", Description = "Мотокультиватори" },
                new CategoryProduct { Id = 551, Level = 3, TopId = 75, Name = "Акумуляторні пилки", Description = "Акумуляторні пилки" },
                new CategoryProduct { Id = 552, Level = 3, TopId = 75, Name = "Електропили", Description = "Електропили" },
                new CategoryProduct { Id = 553, Level = 3, TopId = 75, Name = "Садові подрібнювачі та дровоколи", Description = "Садові подрібнювачі та дровоколи" },
                new CategoryProduct { Id = 554, Level = 3, TopId = 75, Name = "Бензопили", Description = "Бензопили" },
                new CategoryProduct { Id = 555, Level = 3, TopId = 75, Name = "Повітродуви", Description = "Повітродуви" },
                new CategoryProduct { Id = 556, Level = 3, TopId = 75, Name = "Витратні матеріали для мотокос", Description = "Витратні матеріали для мотокос" },
                new CategoryProduct { Id = 557, Level = 3, TopId = 75, Name = "Мотоблоки", Description = "Мотоблоки" },
                new CategoryProduct { Id = 558, Level = 3, TopId = 75, Name = "Аератори", Description = "Аератори" },

                // Садовий інвентар
                new CategoryProduct { Id = 559, Level = 3, TopId = 76, Name = "Обприскувачі", Description = "Обприскувачі" },
                new CategoryProduct { Id = 560, Level = 3, TopId = 76, Name = "Тачки", Description = "Тачки" },
                new CategoryProduct { Id = 561, Level = 3, TopId = 76, Name = "Сітки садові", Description = "Сітки садові" },
                new CategoryProduct { Id = 562, Level = 3, TopId = 76, Name = "Агроволокно", Description = "Агроволокно" },
                new CategoryProduct { Id = 563, Level = 3, TopId = 76, Name = "Садові огорожі", Description = "Садові огорожі" },
                new CategoryProduct { Id = 564, Level = 3, TopId = 76, Name = "Компостери садові", Description = "Компостери садові" },
                new CategoryProduct { Id = 565, Level = 3, TopId = 76, Name = "Пластикові ємності", Description = "Пластикові ємності" },
                new CategoryProduct { Id = 566, Level = 3, TopId = 76, Name = "Теплиці", Description = "Теплиці" },
                new CategoryProduct { Id = 567, Level = 3, TopId = 76, Name = "Лійки для квітів", Description = "Лійки для квітів" },
                new CategoryProduct { Id = 568, Level = 3, TopId = 76, Name = "Садове приладдя", Description = "Садове приладдя" },
                new CategoryProduct { Id = 569, Level = 3, TopId = 76, Name = "Драбини, підмостки", Description = "Драбини, підмостки" },

                // Системи поливання
                new CategoryProduct { Id = 570, Level = 3, TopId = 77, Name = "Шланги", Description = "Шланги" },
                new CategoryProduct { Id = 571, Level = 3, TopId = 77, Name = "Занурювальні насоси", Description = "Занурювальні насоси" },
                new CategoryProduct { Id = 572, Level = 3, TopId = 77, Name = "Насадки", Description = "Насадки" },
                new CategoryProduct { Id = 573, Level = 3, TopId = 77, Name = "Зрошувачі", Description = "Зрошувачі" },
                new CategoryProduct { Id = 574, Level = 3, TopId = 77, Name = "Поверхневі насоси", Description = "Поверхневі насоси" },
                new CategoryProduct { Id = 575, Level = 3, TopId = 77, Name = "Комплектуючі до насосів", Description = "Комплектуючі до насосів" },
                new CategoryProduct { Id = 576, Level = 3, TopId = 77, Name = "Набори для крапельного поливу", Description = "Набори для крапельного поливу" },
                new CategoryProduct { Id = 577, Level = 3, TopId = 77, Name = "Комплектуючі для поливу", Description = "Комплектуючі для поливу" },
                new CategoryProduct { Id = 578, Level = 3, TopId = 77, Name = "Таймери для поливу", Description = "Таймери для поливу" },
                new CategoryProduct { Id = 579, Level = 3, TopId = 77, Name = "Мотопомпи", Description = "Мотопомпи" },
                new CategoryProduct { Id = 580, Level = 3, TopId = 77, Name = "Циркуляційні насоси", Description = "Циркуляційні насоси" },

                // Садовий інструмент
                new CategoryProduct { Id = 581, Level = 3, TopId = 78, Name = "Секатори", Description = "Секатори" },
                new CategoryProduct { Id = 582, Level = 3, TopId = 78, Name = "Лопати", Description = "Лопати" },
                new CategoryProduct { Id = 583, Level = 3, TopId = 78, Name = "Сокири", Description = "Сокири" },
                new CategoryProduct { Id = 584, Level = 3, TopId = 78, Name = "Сучкорізи", Description = "Сучкорізи" },
                new CategoryProduct { Id = 585, Level = 3, TopId = 78, Name = "Ручні культиватори", Description = "Ручні культиватори" },
                new CategoryProduct { Id = 586, Level = 3, TopId = 78, Name = "Садові ножиці", Description = "Садові ножиці" },
                new CategoryProduct { Id = 587, Level = 3, TopId = 78, Name = "Граблі", Description = "Граблі" },
                new CategoryProduct { Id = 588, Level = 3, TopId = 78, Name = "Пили садові", Description = "Пили садові" },
                new CategoryProduct { Id = 589, Level = 3, TopId = 78, Name = "Сапи", Description = "Сапи" },
                new CategoryProduct { Id = 590, Level = 3, TopId = 78, Name = "Садові совки", Description = "Садові совки" },
                new CategoryProduct { Id = 591, Level = 3, TopId = 78, Name = "Держаки для садового інструменту", Description = "Держаки для садового інструменту" },
                new CategoryProduct { Id = 592, Level = 3, TopId = 78, Name = "Набори садових інструментів", Description = "Набори садових інструментів" },
                new CategoryProduct { Id = 593, Level = 3, TopId = 78, Name = "Садові ножі", Description = "Садові ножі" },

                // Рослини та догляд за ними
                new CategoryProduct { Id = 594, Level = 3, TopId = 79, Name = "Насіння газонних трав", Description = "Насіння газонних трав" },
                new CategoryProduct { Id = 595, Level = 3, TopId = 79, Name = "Органічні добрива", Description = "Органічні добрива" },
                new CategoryProduct { Id = 596, Level = 3, TopId = 79, Name = "Мінеральні добрива", Description = "Мінеральні добрива" },
                new CategoryProduct { Id = 597, Level = 3, TopId = 79, Name = "Вазони", Description = "Вазони" },
                new CategoryProduct { Id = 598, Level = 3, TopId = 79, Name = "Отрута для гризунів", Description = "Отрута для гризунів" },
                new CategoryProduct { Id = 599, Level = 3, TopId = 79, Name = "Субстрати та ґрунти для рослин", Description = "Субстрати та ґрунти для рослин" },
                new CategoryProduct { Id = 600, Level = 3, TopId = 79, Name = "Пастки для гризунів та птахів", Description = "Пастки для гризунів та птахів" },
                new CategoryProduct { Id = 601, Level = 3, TopId = 79, Name = "Інсектициди", Description = "Інсектициди" },
                new CategoryProduct { Id = 602, Level = 3, TopId = 79, Name = "Фунгіциди", Description = "Фунгіциди" },
                new CategoryProduct { Id = 603, Level = 3, TopId = 79, Name = "Органомінеральні добрива", Description = "Органомінеральні добрива" },
                new CategoryProduct { Id = 604, Level = 3, TopId = 79, Name = "Стимулятори росту рослин", Description = "Стимулятори росту рослин" },
                new CategoryProduct { Id = 605, Level = 3, TopId = 79, Name = "Біодобрива", Description = "Біодобрива" },
                new CategoryProduct { Id = 606, Level = 3, TopId = 79, Name = "Насіння пряних та зелених трав", Description = "Насіння пряних та зелених трав" },

                // Басейни та аксесуари
                new CategoryProduct { Id = 607, Level = 3, TopId = 80, Name = "Басейни", Description = "Басейни" },
                new CategoryProduct { Id = 608, Level = 3, TopId = 80, Name = "Аксесуари для басейнів", Description = "Аксесуари для басейнів" },
                new CategoryProduct { Id = 609, Level = 3, TopId = 80, Name = "Обладнання для басейнів", Description = "Обладнання для басейнів" },

                // Благоустрій території
                new CategoryProduct { Id = 610, Level = 3, TopId = 81, Name = "Сміттєві контейнери", Description = "Сміттєві контейнери" },
                new CategoryProduct { Id = 611, Level = 3, TopId = 81, Name = "Вуличні урни", Description = "Вуличні урни" },

                // Садовий декор
                // Для цієї категорії поки що даних немає

            // Снігоприбирання
            // Для цієї категорії поки що даних немає
            #endregion
            #region 1_9_3lvl
                //612
                // Спорт і захоплення


            #endregion
            );
            
        }

        public static void SeedProduct(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new Product()
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                Price = 1,
                Stars = 0,
                Stock = 1,
                ImageURL = "noimage.webp",
                CreatedAt = DateTime.UtcNow,
                ShopId = 1,
                BrandId = 1,
                CategoryProductId = 1,
                CountryProductionId = 1
            });
        }
    }
}
