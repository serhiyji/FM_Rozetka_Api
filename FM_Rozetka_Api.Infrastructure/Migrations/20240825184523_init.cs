using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FM_Rozetka_Api.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    SurName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    LastName = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    TopId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategorySpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategorySpecifications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryProductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryProductions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PossibleSpecificationItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleSpecificationItem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SellerApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    HasNoWebsite = table.Column<bool>(type: "boolean", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    IsNonResident = table.Column<bool>(type: "boolean", nullable: false),
                    ProcessedApplication = table.Column<bool>(type: "boolean", nullable: false),
                    IsApproved = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TelegramChatId = table.Column<string>(type: "text", nullable: false),
                    TelegramUserId = table.Column<string>(type: "text", nullable: false),
                    TelegramPhoneNumber = table.Column<string>(type: "text", nullable: true),
                    TgUserName = table.Column<string>(type: "text", nullable: false),
                    StatusState = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    Steet = table.Column<string>(type: "text", nullable: false),
                    zipcode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Adresses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneConfirmations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Phone = table.Column<string>(type: "text", nullable: false),
                    IsSendInTelegram = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneConfirmations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneConfirmations_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    JwtId = table.Column<string>(type: "text", nullable: false),
                    IsUsed = table.Column<bool>(type: "boolean", nullable: false),
                    IsRevoked = table.Column<bool>(type: "boolean", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    CompanyId = table.Column<int>(type: "integer", nullable: false),
                    Website = table.Column<string>(type: "text", nullable: false),
                    HasNoWebsite = table.Column<bool>(type: "boolean", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    IsNonResident = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PossibleSpecification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryProductId = table.Column<int>(type: "integer", nullable: false),
                    CategorySpecificationId = table.Column<int>(type: "integer", nullable: false),
                    PossibleSpecificationItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PossibleSpecification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PossibleSpecification_CategoryProducts_CategoryProductId",
                        column: x => x.CategoryProductId,
                        principalTable: "CategoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PossibleSpecification_CategorySpecifications_CategorySpecif~",
                        column: x => x.CategorySpecificationId,
                        principalTable: "CategorySpecifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PossibleSpecification_PossibleSpecificationItem_PossibleSpe~",
                        column: x => x.PossibleSpecificationItemId,
                        principalTable: "PossibleSpecificationItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatusHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderStatusHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    PaymentMethod = table.Column<string>(type: "text", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ShipmentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrackingNumber = table.Column<string>(type: "text", nullable: false),
                    Carrier = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shipments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ModeratorShops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ShopId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModeratorShops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ModeratorShops_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ModeratorShops_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Stars = table.Column<decimal>(type: "numeric", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    ImageURL = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ShopId = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    HasDiscount = table.Column<bool>(type: "boolean", nullable: false),
                    CategoryProductId = table.Column<int>(type: "integer", nullable: false),
                    CountryProductionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_CategoryProducts_CategoryProductId",
                        column: x => x.CategoryProductId,
                        principalTable: "CategoryProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_CountryProductions_CountryProductionId",
                        column: x => x.CountryProductionId,
                        principalTable: "CountryProductions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    DiscountPercent = table.Column<decimal>(type: "numeric", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Discounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhotoProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    NameImage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    QuestionText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OpenQuestion = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    hasAnswer = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductQuestions_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductQuestions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Specifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PossibleSpecificationItemId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Specifications_PossibleSpecificationItem_PossibleSpecificat~",
                        column: x => x.PossibleSpecificationItemId,
                        principalTable: "PossibleSpecificationItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Specifications_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    QuestionID = table.Column<int>(type: "integer", nullable: false),
                    AppUserId = table.Column<string>(type: "text", nullable: false),
                    AnswerText = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAnswers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAnswers_ProductQuestions_QuestionID",
                        column: x => x.QuestionID,
                        principalTable: "ProductQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c4f10eb-6208-42b4-b8e5-1f908880b498", null, "ModeratorSeller", "MODERATORSELLER" },
                    { "3a10af27-4406-444c-aa66-4ef46b494ee4", null, "Administrator", "ADMINISTRATOR" },
                    { "5742b477-1429-42f6-ba76-f10d4cf40d07", null, "User", "USER" },
                    { "fb56a76f-5536-4a4c-9b1c-8d1bda7ab1ac", null, "Seller", "SELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8ba6141e-0a8c-451f-ab11-3d629a6fe334", 0, "9dff9f94-085a-48a4-8657-3f4a46f12e0c", "AppUser", "seller@email.com", true, "seller", "seller", false, null, "SELLER@EMAIL.COM", "SELLER@EMAIL.COM", "AQAAAAIAAYagAAAAEDOR9+eqJ2SfmmxJAyPtXSz6uF1VVC1OfBITav8/IPiVEPGdIr4cAvve9zdaGle6Yw==", "", false, "9873cabd-435d-4af2-8ee2-e82e209077d9", "seller", false, "seller@email.com" },
                    { "e8627084-49b4-4361-8176-9d950adfbe2b", 0, "a9db301e-2642-4c34-8dcd-0ef4bb3729da", "AppUser", "admin@email.com", true, "John", "Connor", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEEc/ZpT82A2ZRZnf2pDHY4fKDn2PPRIEwY/YCHxYjRXUQIyUFQmO0gIsJBu8V1Uv6g==", "", false, "5203d944-bcd5-4ec3-9ca8-4ad03e9357f9", "Johnovych", false, "admin@email.com" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Apple" },
                    { 2, "", "Dell" },
                    { 3, "", "HP" },
                    { 4, "", "Lenovo" },
                    { 5, "", "Asus" },
                    { 6, "", "Acer" },
                    { 7, "", "MSI" },
                    { 8, "", "Razer" },
                    { 9, "", "Microsoft" },
                    { 10, "", "Toshiba" },
                    { 11, "", "Fujitsu" },
                    { 12, "", "Gateway" },
                    { 13, "", "Packard Bell" },
                    { 14, "", "Vaio" },
                    { 15, "", "OPPO" },
                    { 16, "", "vivo" },
                    { 17, "", "Google Pixel" },
                    { 18, "", "OnePlus" },
                    { 19, "", "Realme" },
                    { 20, "", "Motorola" },
                    { 21, "", "Nokia" },
                    { 22, "", "LG" },
                    { 23, "", "Bose" },
                    { 24, "", "JBL" },
                    { 25, "", "Anker" },
                    { 26, "", "Belkin" },
                    { 27, "", "Casetify" },
                    { 28, "", "Logitech" },
                    { 29, "", "Xiaomi" },
                    { 30, "", "Huawei" },
                    { 31, "", "Xbox" },
                    { 32, "", "Nintendo" },
                    { 33, "", "Wii" },
                    { 34, "", "PlayStation" },
                    { 35, "", "Canon" },
                    { 36, "", "Nikon" },
                    { 37, "", "Sony" },
                    { 38, "", "Fujifilm" },
                    { 39, "", "GoPro" },
                    { 40, "", "DJI" },
                    { 41, "", "Olympus" },
                    { 42, "", "Leica" },
                    { 43, "", "Hasselblad" },
                    { 44, "", "Tesla" },
                    { 45, "", "LGDeWalt" },
                    { 46, "", "Dyson" },
                    { 47, "", "Philips" },
                    { 48, "", "Panasonic" },
                    { 49, "", "Samsung" },
                    { 50, "", "Bosch" },
                    { 51, "", "Siemens" },
                    { 52, "", "Electrolux" },
                    { 53, "", "Whirlpool" },
                    { 54, "", "Miele" },
                    { 55, "", "Beko" },
                    { 56, "", "Candy" },
                    { 57, "", "Indesit" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProducts",
                columns: new[] { "Id", "Description", "Level", "Name", "TopId" },
                values: new object[,]
                {
                    { 1, "Ноутбуки та комп'ютери", 1, "Ноутбуки та комп'ютери", null },
                    { 2, "Ноутбуки", 2, "Ноутбуки", 1 },
                    { 3, "Планшети", 2, "Планшети", 1 },
                    { 4, "Комп'ютери", 2, "Комп'ютери", 1 },
                    { 5, "Комплектуючi", 2, "Комплектуючi", 1 },
                    { 6, "Аксесуари для ноутбуків і ПК", 2, "Аксесуари для ноутбуків і ПК", 1 },
                    { 7, "Серверне обладнання", 2, "Серверне обладнання", 1 },
                    { 8, "Товари з уцінкою", 2, "Товари з уцінкою", 1 },
                    { 9, "Офісна техніка", 2, "Офісна техніка", 1 },
                    { 10, "Інтерактивне обладнання", 2, "Інтерактивне обладнання", 1 },
                    { 11, "Мережеве обладнання", 2, "Мережеве обладнання", 1 },
                    { 12, "Товари для геймерів", 2, "Товари для геймерів", 1 },
                    { 13, "Asus", 3, "Asus", 2 },
                    { 14, "Lenovo", 3, "Lenovo", 2 },
                    { 15, "Acer", 3, "Acer", 2 },
                    { 16, "HP (Hewlett Packard)", 3, "HP (Hewlett Packard)", 2 },
                    { 17, "Dell", 3, "Dell", 2 },
                    { 18, "Apple Macbook", 3, "Apple Macbook", 2 },
                    { 19, "Apple iPad", 3, "Apple iPad", 3 },
                    { 20, "Samsung", 3, "Samsung", 3 },
                    { 21, "Lenovo", 3, "Lenovo", 3 },
                    { 22, "Xiaomi", 3, "Xiaomi", 3 },
                    { 23, "Чохли для планшетів", 3, "Чохли для планшетів", 3 },
                    { 24, "Захисні плівки та скло", 3, "Захисні плівки та скло", 3 },
                    { 25, "Монітори", 3, "Монітори", 4 },
                    { 26, "Клавіатури та миші", 3, "Клавіатури та миші", 4 },
                    { 27, "Комп'ютерні колонки", 3, "Комп'ютерні колонки", 4 },
                    { 28, "Програмне забезпечення", 3, "Програмне забезпечення", 4 },
                    { 29, "Джерела безперебійного живлення", 3, "Джерела безперебійного живлення", 4 },
                    { 30, "Акумулятори для ДБЖ", 3, "Акумулятори для ДБЖ", 4 },
                    { 31, "Відеокарти", 3, "Відеокарти", 5 },
                    { 32, "SSD", 3, "SSD", 5 },
                    { 33, "Процесори", 3, "Процесори", 5 },
                    { 34, "Жорсткі диски та дискові масиви", 3, "Жорсткі диски та дискові масиви", 5 },
                    { 35, "Оперативна пам'ять", 3, "Оперативна пам'ять", 5 },
                    { 36, "Материнські плати", 3, "Материнські плати", 5 },
                    { 37, "Блоки живлення", 3, "Блоки живлення", 5 },
                    { 38, "Корпуси", 3, "Корпуси", 5 },
                    { 39, "Системи охолодження", 3, "Системи охолодження", 5 },
                    { 40, "Флеш пам'ять USB", 3, "Флеш пам'ять USB", 6 },
                    { 41, "Мережеві фільтри, адаптери та подовжувачі", 3, "Мережеві фільтри, адаптери та подовжувачі", 6 },
                    { 42, "Сумки, рюкзаки та чохли для ноутбуків", 3, "Сумки, рюкзаки та чохли для ноутбуків", 6 },
                    { 43, "Підставки та столики для ноутбуків", 3, "Підставки та столики для ноутбуків", 6 },
                    { 44, "Веб-камери", 3, "Веб-камери", 6 },
                    { 45, "Навушники", 3, "Навушники", 6 },
                    { 46, "Мікрофони", 3, "Мікрофони", 6 },
                    { 47, "Універсальні мобільні батареї для ноутбуків", 3, "Універсальні мобільні батареї для ноутбуків", 6 },
                    { 48, "Кабелі та перехідники", 3, "Кабелі та перехідники", 6 },
                    { 49, "Графічні планшети", 3, "Графічні планшети", 6 },
                    { 50, "БФП/Принтери", 3, "БФП/Принтери", 9 },
                    { 51, "Витратні матеріали", 3, "Витратні матеріали", 9 },
                    { 52, "Шредери", 3, "Шредери", 9 },
                    { 53, "Телефони", 3, "Телефони", 9 },
                    { 54, "Маршрутизатори", 3, "Маршрутизатори", 11 },
                    { 55, "Комутатори", 3, "Комутатори", 11 },
                    { 56, "Мережеві адаптери", 3, "Мережеві адаптери", 11 },
                    { 57, "Ретранслятори Wi-Fi", 3, "Ретранслятори Wi-Fi", 11 },
                    { 58, "Бездротові точки доступу", 3, "Бездротові точки доступу", 11 },
                    { 59, "Мережеві сховища (NAS)", 3, "Мережеві сховища (NAS)", 11 },
                    { 60, "Патч-корди", 3, "Патч-корди", 11 },
                    { 61, "IP-телефонія", 3, "IP-телефонія", 11 },
                    { 62, "Підсилювачі зв'язку", 3, "Підсилювачі зв'язку", 11 },
                    { 63, "PlayStation", 3, "PlayStation", 12 },
                    { 64, "Sony PlayStation 5", 3, "Sony PlayStation 5", 12 },
                    { 65, "Ігрові консолі та дитячі приставки", 3, "Ігрові консолі та дитячі приставки", 12 },
                    { 66, "Ігрові маніпулятори та аксесуари для консолей", 3, "Ігрові маніпулятори та аксесуари для консолей", 12 },
                    { 67, "Ігри", 3, "Ігри", 12 },
                    { 68, "Ігрові поверхні", 3, "Ігрові поверхні", 12 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Name", "PhoneNumber" },
                values: new object[] { 1, "Test", "Test" });

            migrationBuilder.InsertData(
                table: "CountryProductions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Afghanistan" },
                    { 2, "Albania" },
                    { 3, "Algeria" },
                    { 4, "Andorra" },
                    { 5, "Angola" },
                    { 6, "Antigua and Barbuda" },
                    { 7, "Argentina" },
                    { 8, "Armenia" },
                    { 9, "Australia" },
                    { 10, "Austria" },
                    { 11, "Azerbaijan" },
                    { 12, "Bahamas" },
                    { 13, "Bahrain" },
                    { 14, "Bangladesh" },
                    { 15, "Barbados" },
                    { 16, "Belarus" },
                    { 17, "Belgium" },
                    { 18, "Belize" },
                    { 19, "Benin" },
                    { 20, "Bhutan" },
                    { 21, "Bolivia" },
                    { 22, "Bosnia and Herzegovina" },
                    { 23, "Botswana" },
                    { 24, "Brazil" },
                    { 25, "Brunei" },
                    { 26, "Bulgaria" },
                    { 27, "Burkina Faso" },
                    { 28, "Burundi" },
                    { 29, "Cabo Verde" },
                    { 30, "Cambodia" },
                    { 31, "Cameroon" },
                    { 32, "Canada" },
                    { 33, "Central African Republic" },
                    { 34, "Chad" },
                    { 35, "Chile" },
                    { 36, "China" },
                    { 37, "Colombia" },
                    { 38, "Comoros" },
                    { 39, "Congo (Congo-Brazzaville)" },
                    { 40, "Costa Rica" },
                    { 41, "Croatia" },
                    { 42, "Cuba" },
                    { 43, "Cyprus" },
                    { 44, "Czech Republic (Czechia)" },
                    { 45, "Democratic Republic of the Congo" },
                    { 46, "Denmark" },
                    { 47, "Djibouti" },
                    { 48, "Dominica" },
                    { 49, "Dominican Republic" },
                    { 50, "East Timor (Timor-Leste)" },
                    { 51, "Ecuador" },
                    { 52, "Egypt" },
                    { 53, "El Salvador" },
                    { 54, "Equatorial Guinea" },
                    { 55, "Eritrea" },
                    { 56, "Estonia" },
                    { 57, "Eswatini" },
                    { 58, "Ethiopia" },
                    { 59, "Fiji" },
                    { 60, "Finland" },
                    { 61, "France" },
                    { 62, "Gabon" },
                    { 63, "Gambia" },
                    { 64, "Georgia" },
                    { 65, "Germany" },
                    { 66, "Ghana" },
                    { 67, "Greece" },
                    { 68, "Grenada" },
                    { 69, "Guatemala" },
                    { 70, "Guinea" },
                    { 71, "Guinea-Bissau" },
                    { 72, "Guyana" },
                    { 73, "Haiti" },
                    { 74, "Honduras" },
                    { 75, "Hungary" },
                    { 76, "Iceland" },
                    { 77, "India" },
                    { 78, "Indonesia" },
                    { 79, "Iran" },
                    { 80, "Iraq" },
                    { 81, "Ireland" },
                    { 82, "Israel" },
                    { 83, "Italy" },
                    { 84, "Ivory Coast (Côte d'Ivoire)" },
                    { 85, "Jamaica" },
                    { 86, "Japan" },
                    { 87, "Jordan" },
                    { 88, "Kazakhstan" },
                    { 89, "Kenya" },
                    { 90, "Kiribati" },
                    { 91, "Korea, North" },
                    { 92, "Korea, South" },
                    { 93, "Kosovo" },
                    { 94, "Kuwait" },
                    { 95, "Kyrgyzstan" },
                    { 96, "Laos" },
                    { 97, "Latvia" },
                    { 98, "Lebanon" },
                    { 99, "Lesotho" },
                    { 100, "Liberia" },
                    { 101, "Libya" },
                    { 102, "Liechtenstein" },
                    { 103, "Lithuania" },
                    { 104, "Luxembourg" },
                    { 105, "Madagascar" },
                    { 106, "Malawi" },
                    { 107, "Malaysia" },
                    { 108, "Maldives" },
                    { 109, "Mali" },
                    { 110, "Malta" },
                    { 111, "Marshall Islands" },
                    { 112, "Mauritania" },
                    { 113, "Mauritius" },
                    { 114, "Mexico" },
                    { 115, "Micronesia" },
                    { 116, "Moldova" },
                    { 117, "Monaco" },
                    { 118, "Mongolia" },
                    { 119, "Montenegro" },
                    { 120, "Morocco" },
                    { 121, "Mozambique" },
                    { 122, "Myanmar (Burma)" },
                    { 123, "Namibia" },
                    { 124, "Nauru" },
                    { 125, "Nepal" },
                    { 126, "Netherlands" },
                    { 127, "New Zealand" },
                    { 128, "Nicaragua" },
                    { 129, "Niger" },
                    { 130, "Nigeria" },
                    { 131, "North Macedonia" },
                    { 132, "Norway" },
                    { 133, "Oman" },
                    { 134, "Pakistan" },
                    { 135, "Palau" },
                    { 136, "Panama" },
                    { 137, "Papua New Guinea" },
                    { 138, "Paraguay" },
                    { 139, "Peru" },
                    { 140, "Philippines" },
                    { 141, "Poland" },
                    { 142, "Portugal" },
                    { 143, "Qatar" },
                    { 144, "Romania" },
                    { 145, "Rwanda" },
                    { 146, "Saint Kitts and Nevis" },
                    { 147, "Saint Lucia" },
                    { 148, "Saint Vincent and the Grenadines" },
                    { 149, "Samoa" },
                    { 150, "San Marino" },
                    { 151, "Sao Tome and Principe" },
                    { 152, "Saudi Arabia" },
                    { 153, "Senegal" },
                    { 154, "Serbia" },
                    { 155, "Seychelles" },
                    { 156, "Sierra Leone" },
                    { 157, "Singapore" },
                    { 158, "Slovakia" },
                    { 159, "Slovenia" },
                    { 160, "Solomon Islands" },
                    { 161, "Somalia" },
                    { 162, "South Africa" },
                    { 163, "South Sudan" },
                    { 164, "Spain" },
                    { 165, "Sri Lanka" },
                    { 166, "Sudan" },
                    { 167, "Suriname" },
                    { 168, "Sweden" },
                    { 169, "Switzerland" },
                    { 170, "Syria" },
                    { 171, "Taiwan" },
                    { 172, "Tajikistan" },
                    { 173, "Tanzania" },
                    { 174, "Thailand" },
                    { 175, "Togo" },
                    { 176, "Tonga" },
                    { 177, "Trinidad and Tobago" },
                    { 178, "Tunisia" },
                    { 179, "Turkey" },
                    { 180, "Turkmenistan" },
                    { 181, "Tuvalu" },
                    { 182, "Uganda" },
                    { 183, "Ukraine" },
                    { 184, "United Arab Emirates" },
                    { 185, "United Kingdom" },
                    { 186, "United States" },
                    { 187, "Uruguay" },
                    { 188, "Uzbekistan" },
                    { 189, "Vanuatu" },
                    { 190, "Vatican City" },
                    { 191, "Venezuela" },
                    { 192, "Vietnam" },
                    { 193, "Yemen" },
                    { 194, "Zambia" },
                    { 195, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "fb56a76f-5536-4a4c-9b1c-8d1bda7ab1ac", "8ba6141e-0a8c-451f-ab11-3d629a6fe334" },
                    { "3a10af27-4406-444c-aa66-4ef46b494ee4", "e8627084-49b4-4361-8176-9d950adfbe2b" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "AppUserId", "CompanyId", "Email", "FullName", "HasNoWebsite", "IsNonResident", "PhoneNumber", "Position", "Website" },
                values: new object[] { 1, "8ba6141e-0a8c-451f-ab11-3d629a6fe334", 1, "TEST", "TEST", false, false, "TEST", "TEST", "TEST" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryProductId", "CountryProductionId", "CreatedAt", "Description", "HasDiscount", "ImageURL", "Name", "Price", "ShopId", "Stars", "Stock" },
                values: new object[] { 1, 1, 1, 1, new DateTime(2024, 8, 25, 18, 45, 22, 222, DateTimeKind.Utc).AddTicks(8092), "Test", false, "noimage.webp", "Test", 1m, 1, 0m, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_AppUserId",
                table: "Adresses",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_AppUserId",
                table: "CartItems",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_ProductId",
                table: "Discounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_AppUserId",
                table: "Favorites",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorites_ProductId",
                table: "Favorites",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeratorShops_AppUserId",
                table: "ModeratorShops",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ModeratorShops_ShopId",
                table: "ModeratorShops",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusHistories_OrderId",
                table: "OrderStatusHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_OrderId",
                table: "Payments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneConfirmations_AppUserId",
                table: "PhoneConfirmations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoProducts_ProductId",
                table: "PhotoProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleSpecification_CategoryProductId",
                table: "PossibleSpecification",
                column: "CategoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleSpecification_CategorySpecificationId",
                table: "PossibleSpecification",
                column: "CategorySpecificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PossibleSpecification_PossibleSpecificationItemId",
                table: "PossibleSpecification",
                column: "PossibleSpecificationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswers_AppUserId",
                table: "ProductAnswers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAnswers_QuestionID",
                table: "ProductAnswers",
                column: "QuestionID");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuestions_AppUserId",
                table: "ProductQuestions",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductQuestions_ProductId",
                table: "ProductQuestions",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryProductId",
                table: "Products",
                column: "CategoryProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CountryProductionId",
                table: "Products",
                column: "CountryProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShopId",
                table: "Products",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_AppUserId",
                table: "RefreshTokens",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_AppUserId",
                table: "Reviews",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId",
                table: "Reviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_OrderId",
                table: "Shipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_AppUserId",
                table: "Shops",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_CompanyId",
                table: "Shops",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_PossibleSpecificationItemId",
                table: "Specifications",
                column: "PossibleSpecificationItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Specifications_ProductId",
                table: "Specifications",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "ModeratorShops");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "OrderStatusHistories");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "PhoneConfirmations");

            migrationBuilder.DropTable(
                name: "PhotoProducts");

            migrationBuilder.DropTable(
                name: "PossibleSpecification");

            migrationBuilder.DropTable(
                name: "ProductAnswers");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "SellerApplications");

            migrationBuilder.DropTable(
                name: "Shipments");

            migrationBuilder.DropTable(
                name: "Specifications");

            migrationBuilder.DropTable(
                name: "TelegramUsers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "CategorySpecifications");

            migrationBuilder.DropTable(
                name: "ProductQuestions");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PossibleSpecificationItem");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "CategoryProducts");

            migrationBuilder.DropTable(
                name: "CountryProductions");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
