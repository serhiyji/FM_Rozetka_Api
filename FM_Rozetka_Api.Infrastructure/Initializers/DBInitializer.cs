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
                new CategoryProduct { Id = 1, Level = 1, TopId = null, Name = "Ноутбуки та комп'ютери", Description = "Ноутбуки та комп'ютери" },

                new CategoryProduct { Id = 2, Level = 2, TopId = 1, Name = "Ноутбуки", Description = "Ноутбуки" },
                new CategoryProduct { Id = 3, Level = 2, TopId = 1, Name = "Планшети", Description = "Планшети" },
                new CategoryProduct { Id = 4, Level = 2, TopId = 1, Name = "Комп'ютери", Description = "Комп'ютери" },
                new CategoryProduct { Id = 5, Level = 2, TopId = 1, Name = "Комплектуючi", Description = "Комплектуючi" },
                new CategoryProduct { Id = 6, Level = 2, TopId = 1, Name = "Аксесуари для ноутбуків і ПК", Description = "Аксесуари для ноутбуків і ПК" },
                new CategoryProduct { Id = 7, Level = 2, TopId = 1, Name = "Серверне обладнання", Description = "Серверне обладнання" },
                new CategoryProduct { Id = 8, Level = 2, TopId = 1, Name = "Товари з уцінкою", Description = "Товари з уцінкою" },
                new CategoryProduct { Id = 9, Level = 2, TopId = 1, Name = "Офісна техніка", Description = "Офісна техніка" },
                new CategoryProduct { Id = 10, Level = 2, TopId = 1, Name = "Інтерактивне обладнання", Description = "Інтерактивне обладнання" },
                new CategoryProduct { Id = 11, Level = 2, TopId = 1, Name = "Мережеве обладнання", Description = "Мережеве обладнання" },
                new CategoryProduct { Id = 12, Level = 2, TopId = 1, Name = "Товари для геймерів", Description = "Товари для геймерів" },

                new CategoryProduct { Id = 13, Level = 3, TopId = 2, Name = "Asus", Description = "Asus" },
                new CategoryProduct { Id = 14, Level = 3, TopId = 2, Name = "Lenovo", Description = "Lenovo" },
                new CategoryProduct { Id = 15, Level = 3, TopId = 2, Name = "Acer", Description = "Acer" },
                new CategoryProduct { Id = 16, Level = 3, TopId = 2, Name = "HP (Hewlett Packard)", Description = "HP (Hewlett Packard)" },
                new CategoryProduct { Id = 17, Level = 3, TopId = 2, Name = "Dell", Description = "Dell" },
                new CategoryProduct { Id = 18, Level = 3, TopId = 2, Name = "Apple Macbook", Description = "Apple Macbook" },

                new CategoryProduct { Id = 19, Level = 3, TopId = 3, Name = "Apple iPad", Description = "Apple iPad" },
                new CategoryProduct { Id = 20, Level = 3, TopId = 3, Name = "Samsung", Description = "Samsung" },
                new CategoryProduct { Id = 21, Level = 3, TopId = 3, Name = "Lenovo", Description = "Lenovo" },
                new CategoryProduct { Id = 22, Level = 3, TopId = 3, Name = "Xiaomi", Description = "Xiaomi" },
                new CategoryProduct { Id = 23, Level = 3, TopId = 3, Name = "Чохли для планшетів", Description = "Чохли для планшетів" },
                new CategoryProduct { Id = 24, Level = 3, TopId = 3, Name = "Захисні плівки та скло", Description = "Захисні плівки та скло" },

                new CategoryProduct { Id = 25, Level = 3, TopId = 4, Name = "Монітори", Description = "Монітори" },
                new CategoryProduct { Id = 26, Level = 3, TopId = 4, Name = "Клавіатури та миші", Description = "Клавіатури та миші" },
                new CategoryProduct { Id = 27, Level = 3, TopId = 4, Name = "Комп'ютерні колонки", Description = "Комп'ютерні колонки" },
                new CategoryProduct { Id = 28, Level = 3, TopId = 4, Name = "Програмне забезпечення", Description = "Програмне забезпечення" },
                new CategoryProduct { Id = 29, Level = 3, TopId = 4, Name = "Джерела безперебійного живлення", Description = "Джерела безперебійного живлення" },
                new CategoryProduct { Id = 30, Level = 3, TopId = 4, Name = "Акумулятори для ДБЖ", Description = "Акумулятори для ДБЖ" },

                new CategoryProduct { Id = 31, Level = 3, TopId = 5, Name = "Відеокарти", Description = "Відеокарти" },
                new CategoryProduct { Id = 32, Level = 3, TopId = 5, Name = "SSD", Description = "SSD" },
                new CategoryProduct { Id = 33, Level = 3, TopId = 5, Name = "Процесори", Description = "Процесори" },
                new CategoryProduct { Id = 34, Level = 3, TopId = 5, Name = "Жорсткі диски та дискові масиви", Description = "Жорсткі диски та дискові масиви" },
                new CategoryProduct { Id = 35, Level = 3, TopId = 5, Name = "Оперативна пам'ять", Description = "Оперативна пам'ять" },
                new CategoryProduct { Id = 36, Level = 3, TopId = 5, Name = "Материнські плати", Description = "Материнські плати" },
                new CategoryProduct { Id = 37, Level = 3, TopId = 5, Name = "Блоки живлення", Description = "Блоки живлення" },
                new CategoryProduct { Id = 38, Level = 3, TopId = 5, Name = "Корпуси", Description = "Корпуси" },
                new CategoryProduct { Id = 39, Level = 3, TopId = 5, Name = "Системи охолодження", Description = "Системи охолодження" },

                new CategoryProduct { Id = 40, Level = 3, TopId = 6, Name = "Флеш пам'ять USB", Description = "Флеш пам'ять USB" },
                new CategoryProduct { Id = 41, Level = 3, TopId = 6, Name = "Мережеві фільтри, адаптери та подовжувачі", Description = "Мережеві фільтри, адаптери та подовжувачі" },
                new CategoryProduct { Id = 42, Level = 3, TopId = 6, Name = "Сумки, рюкзаки та чохли для ноутбуків", Description = "Сумки, рюкзаки та чохли для ноутбуків" },
                new CategoryProduct { Id = 43, Level = 3, TopId = 6, Name = "Підставки та столики для ноутбуків", Description = "Підставки та столики для ноутбуків" },
                new CategoryProduct { Id = 44, Level = 3, TopId = 6, Name = "Веб-камери", Description = "Веб-камери" },
                new CategoryProduct { Id = 45, Level = 3, TopId = 6, Name = "Навушники", Description = "Навушники" },
                new CategoryProduct { Id = 46, Level = 3, TopId = 6, Name = "Мікрофони", Description = "Мікрофони" },
                new CategoryProduct { Id = 47, Level = 3, TopId = 6, Name = "Універсальні мобільні батареї для ноутбуків", Description = "Універсальні мобільні батареї для ноутбуків" },
                new CategoryProduct { Id = 48, Level = 3, TopId = 6, Name = "Кабелі та перехідники", Description = "Кабелі та перехідники" },
                new CategoryProduct { Id = 49, Level = 3, TopId = 6, Name = "Графічні планшети", Description = "Графічні планшети" },

                new CategoryProduct { Id = 50, Level = 3, TopId = 9, Name = "БФП/Принтери", Description = "БФП/Принтери" },
                new CategoryProduct { Id = 51, Level = 3, TopId = 9, Name = "Витратні матеріали", Description = "Витратні матеріали" },
                new CategoryProduct { Id = 52, Level = 3, TopId = 9, Name = "Шредери", Description = "Шредери" },
                new CategoryProduct { Id = 53, Level = 3, TopId = 9, Name = "Телефони", Description = "Телефони" },

                new CategoryProduct { Id = 54, Level = 3, TopId = 11, Name = "Маршрутизатори", Description = "Маршрутизатори" },
                new CategoryProduct { Id = 55, Level = 3, TopId = 11, Name = "Комутатори", Description = "Комутатори" },
                new CategoryProduct { Id = 56, Level = 3, TopId = 11, Name = "Мережеві адаптери", Description = "Мережеві адаптери" },
                new CategoryProduct { Id = 57, Level = 3, TopId = 11, Name = "Ретранслятори Wi-Fi", Description = "Ретранслятори Wi-Fi" },
                new CategoryProduct { Id = 58, Level = 3, TopId = 11, Name = "Бездротові точки доступу", Description = "Бездротові точки доступу" },
                new CategoryProduct { Id = 59, Level = 3, TopId = 11, Name = "Мережеві сховища (NAS)", Description = "Мережеві сховища (NAS)" },
                new CategoryProduct { Id = 60, Level = 3, TopId = 11, Name = "Патч-корди", Description = "Патч-корди" },
                new CategoryProduct { Id = 61, Level = 3, TopId = 11, Name = "IP-телефонія", Description = "IP-телефонія" },
                new CategoryProduct { Id = 62, Level = 3, TopId = 11, Name = "Підсилювачі зв'язку", Description = "Підсилювачі зв'язку" },

                new CategoryProduct { Id = 63, Level = 3, TopId = 12, Name = "PlayStation", Description = "PlayStation" },
                new CategoryProduct { Id = 64, Level = 3, TopId = 12, Name = "Sony PlayStation 5", Description = "Sony PlayStation 5" },
                new CategoryProduct { Id = 65, Level = 3, TopId = 12, Name = "Ігрові консолі та дитячі приставки", Description = "Ігрові консолі та дитячі приставки" },
                new CategoryProduct { Id = 66, Level = 3, TopId = 12, Name = "Ігрові маніпулятори та аксесуари для консолей", Description = "Ігрові маніпулятори та аксесуари для консолей" },
                new CategoryProduct { Id = 67, Level = 3, TopId = 12, Name = "Ігри", Description = "Ігри" },
                new CategoryProduct { Id = 68, Level = 3, TopId = 12, Name = "Ігрові поверхні", Description = "Ігрові поверхні" }
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
