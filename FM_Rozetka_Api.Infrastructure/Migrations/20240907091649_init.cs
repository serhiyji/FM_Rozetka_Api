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
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ref = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                });

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
                name: "Settlements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ref = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settlements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Settlements_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    OrderId = table.Column<string>(type: "text", nullable: false)
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
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ref = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    SettlementId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Settlements_SettlementId",
                        column: x => x.SettlementId,
                        principalTable: "Settlements",
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
                    { "07803623-fd20-4556-9940-dbbae345b349", null, "Administrator", "ADMINISTRATOR" },
                    { "6dee8910-19be-4f96-834f-f4a4c807dcc6", null, "User", "USER" },
                    { "aaf9d35b-6a43-4eca-8cda-373087196770", null, "Seller", "SELLER" },
                    { "ca06b9e1-c81a-47e1-bf08-0892193ebb68", null, "ModeratorSeller", "MODERATORSELLER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "SurName", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "227171ad-77ce-47c1-8b31-51246267989a", 0, "ad6a20e9-86ae-46f2-afc2-4f9012b653f6", "AppUser", "admin@email.com", true, "John", "Connor", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEHAoPavYq1ERRJC2Nnj0kRMmfw7tC8lR+G6q7edMrDsYasOxgecAdaDuBD3f4Wsb7A==", "", false, "0ff71cab-9971-4c16-ba1a-22a7de19e9bd", "Johnovych", false, "admin@email.com" },
                    { "e9a6c982-c312-4bad-a79a-4add2444aa12", 0, "2ccf5840-c078-48a6-8c2c-0e1428a3c186", "AppUser", "seller@email.com", true, "seller", "seller", false, null, "SELLER@EMAIL.COM", "SELLER@EMAIL.COM", "AQAAAAIAAYagAAAAEO55ZY3sCJ8LBz+A8fR34EIcAMg+hqulSVBonJqa27Kl3st7mV+AbU4kPVOLAQtN2Q==", "", false, "ac24fd62-4d98-41b1-afe0-d9c6de0cf73a", "seller", false, "seller@email.com" }
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
                    { 2, "Смартфони, ТВ і Електроніка", 1, "Смартфони, ТВ і Електроніка", null },
                    { 3, "Товари для геймерів", 1, "Товари для геймерів", null },
                    { 4, "Побутова техніка", 1, "Побутова техніка", null },
                    { 5, "Товари для дому", 1, "Товари для дому", null },
                    { 6, "Інструменти та автотовари", 1, "Інструменти та автотовари", null },
                    { 7, "Сантехніка та ремонт", 1, "Сантехніка та ремонт", null },
                    { 8, "Дача, сад, город", 1, "Дача, сад, город", null },
                    { 9, "Спорт і захоплення", 1, "Спорт і захоплення", null },
                    { 10, "Одяг, взуття та аксесуари", 1, "Одяг, взуття та аксесуари", null },
                    { 11, "Краса та здоров'я", 1, "Краса та здоров'я", null },
                    { 12, "Товари для дітей", 1, "Товари для дітей", null },
                    { 13, "Зоотовари", 1, "Зоотовари", null },
                    { 14, "Офіс, школа, книги", 1, "Офіс, школа, книги", null },
                    { 15, "Алкогольні напої та продукти", 1, "Алкогольні напої та продукти", null },
                    { 16, "Побутова хімія", 1, "Побутова хімія", null },
                    { 17, "Ноутбуки", 2, "Ноутбуки", 1 },
                    { 18, "Планшети", 2, "Планшети", 1 },
                    { 19, "Комп'ютери", 2, "Комп'ютери", 1 },
                    { 20, "Комплектуючi", 2, "Комплектуючi", 1 },
                    { 21, "Аксесуари для ноутбуків і ПК", 2, "Аксесуари для ноутбуків і ПК", 1 },
                    { 22, "Серверне обладнання", 2, "Серверне обладнання", 1 },
                    { 23, "Товари з уцінкою", 2, "Товари з уцінкою", 1 },
                    { 24, "Офісна техніка", 2, "Офісна техніка", 1 },
                    { 25, "Інтерактивне обладнання", 2, "Інтерактивне обладнання", 1 },
                    { 26, "Мережеве обладнання", 2, "Мережеве обладнання", 1 },
                    { 27, "Телефони", 2, "Телефони", 2 },
                    { 28, "Повербанки та зарядні станції", 2, "Повербанки та зарядні станції", 2 },
                    { 29, "Аксесуари до телефонів", 2, "Аксесуари до телефонів", 2 },
                    { 30, "Телевізори та аксесуари", 2, "Телевізори та аксесуари", 2 },
                    { 31, "Фото та відео", 2, "Фото та відео", 2 },
                    { 32, "Ігрові приставки", 2, "Ігрові приставки", 3 },
                    { 33, "Ігри", 2, "Ігри", 3 },
                    { 34, "PlayStation", 2, "PlayStation", 3 },
                    { 35, "Ігрові приставки Nintendo", 2, "Ігрові приставки Nintendo", 3 },
                    { 36, "Ігрові приставки Xbox", 2, "Ігрові приставки Xbox", 3 },
                    { 37, "Ігрові ноутбуки", 2, "Ігрові ноутбуки", 3 },
                    { 38, "Ігрові монітори", 2, "Ігрові монітори", 3 },
                    { 39, "Комплектуючі для геймерів", 2, "Комплектуючі для геймерів", 3 },
                    { 40, "Ігрова периферія", 2, "Ігрова периферія", 3 },
                    { 41, "Ігрові маршрутизатори", 2, "Ігрові маршрутизатори", 3 },
                    { 42, "Атрибутика й сувеніри", 2, "Атрибутика й сувеніри", 3 },
                    { 43, "Послуги та сервіси для електроніки", 2, "Послуги та сервіси для електроніки", 3 },
                    { 44, "Велика побутова техніка", 2, "Велика побутова техніка", 4 },
                    { 45, "Догляд та прибирання", 2, "Догляд та прибирання", 4 },
                    { 46, "Кліматична техніка", 2, "Кліматична техніка", 4 },
                    { 47, "Техніка для кухні", 2, "Техніка для кухні", 4 },
                    { 48, "Дрібна побутова техніка", 2, "Дрібна побутова техніка", 4 },
                    { 49, "Меблі", 2, "Меблі", 5 },
                    { 50, "Декор для дому", 2, "Декор для дому", 5 },
                    { 51, "Системи охорони і безпеки", 2, "Системи охорони і безпеки", 5 },
                    { 52, "Освітлення", 2, "Освітлення", 5 },
                    { 53, "Посуд", 2, "Посуд", 5 },
                    { 54, "Інвертар для дому та офісу", 2, "Інвертар для дому та офісу", 5 },
                    { 55, "Господарські товари", 2, "Господарські товари", 5 },
                    { 56, "Інструменти", 2, "Інструменти", 6 },
                    { 57, "Витратні матеріали та приладдя", 2, "Витратні матеріали та приладдя", 6 },
                    { 58, "Обладнання", 2, "Обладнання", 6 },
                    { 59, "Ручний інструмент", 2, "Ручний інструмент", 6 },
                    { 60, "Елктромонтажне обладнання", 2, "Елктромонтажне обладнання", 6 },
                    { 61, "Автотовари", 2, "Автотовари", 6 },
                    { 62, "Ванни, бокси, душові", 2, "Ванни, бокси, душові", 7 },
                    { 63, "Мийки, змішувачі, сифони", 2, "Мийки, змішувачі, сифони", 7 },
                    { 64, "Кераміка", 2, "Кераміка", 7 },
                    { 65, "Інженерна сантехніка", 2, "Інженерна сантехніка", 7 },
                    { 66, "Інсталяції та комплектуючі", 2, "Інсталяції та комплектуючі", 7 },
                    { 67, "Сушильники для рушників і радіатори", 2, "Сушильники для рушників і радіатори", 7 },
                    { 68, "Інструменти", 2, "Інструменти", 7 },
                    { 69, "Ручний інструмент", 2, "Ручний інструмент", 7 },
                    { 70, "Освітлення", 2, "Освітлення", 7 },
                    { 71, "Лічильники", 2, "Лічильники", 7 },
                    { 72, "Меблі для ванної кімнати", 2, "Меблі для ванної кімнати", 7 },
                    { 73, "Тепла підлога", 2, "Тепла підлога", 7 },
                    { 74, "Будівельні матеріали", 2, "Будівельні матеріали", 7 },
                    { 75, "Садова техніка", 2, "Садова техніка", 8 },
                    { 76, "Садовий інвентар", 2, "Садовий інвентар", 8 },
                    { 77, "Системи поливання", 2, "Системи поливання", 8 },
                    { 78, "Садовий інструмент", 2, "Садовий інструмент", 8 },
                    { 79, "Рослини та догляд за ними", 2, "Рослини та догляд за ними", 8 },
                    { 80, "Басейни та аксесуари", 2, "Басейни та аксесуари", 8 },
                    { 81, "Благоустрій території", 2, "Благоустрій території", 8 },
                    { 82, "Садовий декор", 2, "Садовий декор", 8 },
                    { 83, "Снігоприбирання", 2, "Снігоприбирання", 8 },
                    { 84, "Тренажери та спортивне обладнання", 2, "Тренажери та спортивне обладнання", 9 },
                    { 85, "Фітнес та аеробіка", 2, "Фітнес та аеробіка", 9 },
                    { 86, "Спортивні аксесуари", 2, "Спортивні аксесуари", 9 },
                    { 87, "Велосипеди та аксесуари", 2, "Велосипеди та аксесуари", 9 },
                    { 88, "Електротранспорт", 2, "Електротранспорт", 9 },
                    { 89, "Ігрові види спорту", 2, "Ігрові види спорту", 9 },
                    { 90, "Бокс і єдиноборства", 2, "Бокс і єдиноборства", 9 },
                    { 91, "Басейн і аквафітнес", 2, "Басейн і аквафітнес", 9 },
                    { 92, "Товари для відпочинку", 2, "Товари для відпочинку", 9 },
                    { 93, "Квадрокоптери", 2, "Квадрокоптери", 9 },
                    { 94, "Туризм і кемпінг", 2, "Туризм і кемпінг", 9 },
                    { 95, "Риболовля", 2, "Риболовля", 9 },
                    { 96, "Зимові види спорту", 2, "Зимові види спорту", 9 },
                    { 97, "Музичні інструменти", 2, "Музичні інструменти", 9 },
                    { 98, "Одяг для жінок", 2, "Одяг для жінок", 10 },
                    { 99, "Жіноче взуття", 2, "Жіноче взуття", 10 },
                    { 100, "Аксесуари для жінок", 2, "Аксесуари для жінок", 10 },
                    { 101, "Одяг для чоловіків", 2, "Одяг для чоловіків", 10 },
                    { 102, "Чоловіче взуття", 2, "Чоловіче взуття", 10 },
                    { 103, "Аксесуари для чоловіків", 2, "Аксесуари для чоловіків", 10 },
                    { 104, "Дитячий одяг", 2, "Дитячий одяг", 10 },
                    { 105, "Дитяче взуття", 2, "Дитяче взуття", 10 },
                    { 106, "Аксесуари для дітей", 2, "Аксесуари для дітей", 10 },
                    { 107, "Техніка для краси та здоров'я", 2, "Техніка для краси та здоров'я", 11 },
                    { 108, "Косметика і парфюмерія", 2, "Косметика і парфюмерія", 11 },
                    { 109, "Дерматокосметика", 2, "Дерматокосметика", 11 },
                    { 110, "Засоби для гоління", 2, "Засоби для гоління", 11 },
                    { 111, "Засоби контрацепції", 2, "Засоби контрацепції", 11 },
                    { 112, "Особиста гігієна", 2, "Особиста гігієна", 11 },
                    { 113, "Подарунки та сувеніри", 2, "Подарунки та сувеніри", 11 },
                    { 114, "Догляд за обличчям", 2, "Догляд за обличчям", 11 },
                    { 115, "Догляд за тілом", 2, "Догляд за тілом", 11 },
                    { 116, "Догляд за волоссям", 2, "Догляд за волоссям", 11 },
                    { 117, "Парфуми", 2, "Парфуми", 11 },
                    { 118, "Товари медичного призначення", 2, "Товари медичного призначення", 11 },
                    { 119, "Інтимні товари", 2, "Інтимні товари", 11 },
                    { 120, "Фарбування волосся", 2, "Фарбування волосся", 11 },
                    { 121, "Догляд за порожниною рота", 2, "Догляд за порожниною рота", 11 },
                    { 122, "Декоративна косметика", 2, "Декоративна косметика", 11 },
                    { 123, "Аксесуари", 2, "Аксесуари", 11 },
                    { 124, "Косметика для догляду для дітей", 2, "Косметика для догляду для дітей", 11 },
                    { 125, "Іграшки", 2, "Іграшки", 12 },
                    { 126, "Дитяче харчування", 2, "Дитяче харчування", 12 },
                    { 127, "Високотехнологічні іграшки", 2, "Високотехнологічні іграшки", 12 },
                    { 128, "Прогулянки й активний відпочинок", 2, "Прогулянки й активний відпочинок", 12 },
                    { 129, "Гігієна та догляд за дитиною", 2, "Гігієна та догляд за дитиною", 12 },
                    { 130, "Дитячий одяг, взуття та аксесуари", 2, "Дитячий одяг, взуття та аксесуари", 12 },
                    { 131, "Шкільне приладдя", 2, "Шкільне приладдя", 12 },
                    { 132, "Новорічний декор", 2, "Новорічний декор", 12 },
                    { 133, "Дитяча кімната", 2, "Дитяча кімната", 12 },
                    { 134, "Розвиток і творчість", 2, "Розвиток і творчість", 12 },
                    { 135, "Товари для мам", 2, "Товари для мам", 12 },
                    { 136, "Транспорт для всієї родини", 2, "Транспорт для всієї родини", 12 },
                    { 137, "Дитячі книги", 2, "Дитячі книги", 12 },
                    { 138, "Все для кішок", 2, "Товари для кішок", 13 },
                    { 139, "Наповнювачі туалетів для котів", 2, "Наповнювачі туалетів для котів", 13 },
                    { 140, "Товари для птахів", 2, "Товари для птахів", 13 },
                    { 141, "Товари для гризунів", 2, "Товари для гризунів", 13 },
                    { 142, "Все для собак", 2, "Товари для собак", 13 },
                    { 143, "Засоби для боротьби з паразитами", 2, "Засоби від паразитів", 13 },
                    { 144, "Товари для акваріумів", 2, "Акваріуми", 13 },
                    { 145, "Товари для тераріумів і фаунаріумів", 2, "Тераріуми та фаунаріуми", 13 },
                    { 146, "Товари для ставків та водойм", 2, "Стави та водойми", 13 },
                    { 147, "Товари для тваринництва", 2, "Тваринництво", 13 },
                    { 148, "Канцелярські товари", 2, "Канцелярське приладдя", 14 },
                    { 149, "Товари для школи", 2, "Шкільне приладдя", 14 },
                    { 150, "Офісне обладнання", 2, "Офісне приладдя", 14 },
                    { 151, "Декор для новорічних свят", 2, "Новорічний декор", 14 },
                    { 152, "Книги різних жанрів", 2, "Книги", 14 },
                    { 153, "Матеріали для творчості", 2, "Творчість", 14 },
                    { 154, "Сувеніри та подарунки", 2, "Сувенірна продукція", 14 },
                    { 155, "Вино різних видів", 2, "Вино", 15 },
                    { 156, "Лікери, вермути і сиропи", 2, "Лікери, вермути, сиропи", 15 },
                    { 157, "Пиво та сидр", 2, "Пиво та сидр", 15 },
                    { 158, "Сигарети", 2, "Сигарети", 15 },
                    { 159, "Посуд для алкоголю", 2, "Посуд", 15 },
                    { 160, "Міцні алкогольні напої", 2, "Міцні напої", 15 },
                    { 161, "Електронні сигарети та аксесуари", 2, "Електронні сигарети та аксесуари", 15 },
                    { 162, "Продукти харчування", 2, "Продукти", 15 },
                    { 163, "Засоби для прання", 2, "Засоби для прання", 16 },
                    { 164, "Засоби для догляду за будинком", 2, "Засоби для догляду за будинком", 16 },
                    { 165, "Засоби для догляду за ванною та туалетом", 2, "Засоби для догляду за ванною та туалетом", 16 },
                    { 166, "Засоби для миття посуду", 2, "Засоби для миття посуду", 16 },
                    { 167, "Господарські товари", 2, "Господарські товари", 16 },
                    { 168, "Засоби для вуличної зони", 2, "Вулична зона", 16 },
                    { 169, "Екологічні та органічні засоби", 2, "Екологічні та органічні засоби", 16 },
                    { 170, "Asus", 3, "Asus", 17 },
                    { 171, "Lenovo", 3, "Lenovo", 17 },
                    { 172, "Acer", 3, "Acer", 17 },
                    { 173, "HP (Hewlett Packard)", 3, "HP (Hewlett Packard)", 17 },
                    { 174, "Dell", 3, "Dell", 17 },
                    { 175, "Apple Macbook", 3, "Apple Macbook", 17 },
                    { 176, "Apple iPad", 3, "Apple iPad", 18 },
                    { 177, "Samsung", 3, "Samsung", 18 },
                    { 178, "Lenovo", 3, "Lenovo", 18 },
                    { 179, "Xiaomi", 3, "Xiaomi", 18 },
                    { 180, "Чохли для планшетів", 3, "Чохли для планшетів", 18 },
                    { 181, "Захисні плівки та скло", 3, "Захисні плівки та скло", 18 },
                    { 182, "Монітори", 3, "Монітори", 19 },
                    { 183, "Клавіатури та миші", 3, "Клавіатури та миші", 19 },
                    { 184, "Комп'ютерні колонки", 3, "Комп'ютерні колонки", 19 },
                    { 185, "Програмне забезпечення", 3, "Програмне забезпечення", 19 },
                    { 186, "Джерела безперебійного живлення", 3, "Джерела безперебійного живлення", 19 },
                    { 187, "Акумулятори для ДБЖ", 3, "Акумулятори для ДБЖ", 19 },
                    { 188, "Відеокарти", 3, "Відеокарти", 20 },
                    { 189, "SSD", 3, "SSD", 20 },
                    { 190, "Процесори", 3, "Процесори", 20 },
                    { 191, "Жорсткі диски та дискові масиви", 3, "Жорсткі диски та дискові масиви", 20 },
                    { 192, "Оперативна пам'ять", 3, "Оперативна пам'ять", 20 },
                    { 193, "Материнські плати", 3, "Материнські плати", 20 },
                    { 194, "Блоки живлення", 3, "Блоки живлення", 20 },
                    { 195, "Корпуси", 3, "Корпуси", 20 },
                    { 196, "Системи охолодження", 3, "Системи охолодження", 20 },
                    { 197, "Флеш пам'ять USB", 3, "Флеш пам'ять USB", 21 },
                    { 198, "Мережеві фільтри, адаптери та подовжувачі", 3, "Мережеві фільтри, адаптери та подовжувачі", 21 },
                    { 199, "Сумки, рюкзаки та чохли для ноутбуків", 3, "Сумки, рюкзаки та чохли для ноутбуків", 21 },
                    { 200, "Підставки та столики для ноутбуків", 3, "Підставки та столики для ноутбуків", 21 },
                    { 201, "Веб-камери", 3, "Веб-камери", 21 },
                    { 202, "Навушники", 3, "Навушники", 21 },
                    { 203, "Мікрофони", 3, "Мікрофони", 21 },
                    { 204, "Універсальні мобільні батареї для ноутбуків", 3, "Універсальні мобільні батареї для ноутбуків", 21 },
                    { 205, "Кабелі та перехідники", 3, "Кабелі та перехідники", 21 },
                    { 206, "Графічні планшети", 3, "Графічні планшети", 21 },
                    { 207, "БФП/Принтери", 3, "БФП/Принтери", 24 },
                    { 208, "Витратні матеріали", 3, "Витратні матеріали", 24 },
                    { 209, "Шредери", 3, "Шредери", 24 },
                    { 210, "Телефони", 3, "Телефони", 24 },
                    { 211, "Маршрутизатори", 3, "Маршрутизатори", 26 },
                    { 212, "Комутатори", 3, "Комутатори", 26 },
                    { 213, "Мережеві адаптери", 3, "Мережеві адаптери", 26 },
                    { 214, "Ретранслятори Wi-Fi", 3, "Ретранслятори Wi-Fi", 26 },
                    { 215, "Бездротові точки доступу", 3, "Бездротові точки доступу", 26 },
                    { 216, "Мережеві сховища (NAS)", 3, "Мережеві сховища (NAS)", 26 },
                    { 217, "Патч-корди", 3, "Патч-корди", 26 },
                    { 218, "IP-телефонія", 3, "IP-телефонія", 26 },
                    { 219, "Підсилювачі зв'язку", 3, "Підсилювачі зв'язку", 26 },
                    { 220, "Apple", 3, "Apple", 27 },
                    { 221, "Samsung", 3, "Samsung", 27 },
                    { 222, "Xiaomi", 3, "Xiaomi", 27 },
                    { 223, "Motorola", 3, "Motorola", 27 },
                    { 224, "Nokia", 3, "Nokia", 27 },
                    { 225, "Смартфони", 3, "Смартфони", 27 },
                    { 226, "Кнопкові телефони", 3, "Кнопкові телефони", 27 },
                    { 227, "Універсальні мобільні батареї", 3, "Універсальні мобільні батареї", 28 },
                    { 228, "Зарядні станції", 3, "Зарядні станції", 28 },
                    { 229, "Навушники", 3, "Навушники", 29 },
                    { 230, "Кабелі та адаптери", 3, "Кабелі та адаптери", 29 },
                    { 231, "Картки пам'яті", 3, "Картки пам'яті", 29 },
                    { 232, "Чохли для мобільних телефонів", 3, "Чохли для мобільних телефонів", 29 },
                    { 233, "Чохли-книжки", 3, "Чохли-книжки", 29 },
                    { 234, "Бампери", 3, "Бампери", 29 },
                    { 235, "Захисні плівки та скло", 3, "Захисні плівки та скло", 29 },
                    { 236, "Тримачі", 3, "Тримачі", 29 },
                    { 237, "Зарядні пристрої", 3, "Зарядні пристрої", 29 },
                    { 238, "Мобільний інтернет", 3, "Мобільний інтернет", 29 },
                    { 239, "Телевізори", 3, "Телевізори", 30 },
                    { 240, "Samsung", 3, "Samsung", 30 },
                    { 241, "LG", 3, "LG", 30 },
                    { 242, "Xiaomi", 3, "Xiaomi", 30 },
                    { 243, "Підставки, кріплення для ТВ", 3, "Підставки, кріплення для ТВ", 30 },
                    { 244, "Кабелі та адаптери", 3, "Кабелі та адаптери", 30 },
                    { 245, "ТВ-антени та ресивери", 3, "ТВ-антени та ресивери", 30 },
                    { 246, "Універсальні пульти ДК", 3, "Універсальні пульти ДК", 30 },
                    { 247, "ТБ запчастини та обладнання", 3, "ТБ запчастини та обладнання", 30 },
                    { 248, "Фотоапарати", 3, "Фотоапарати", 31 },
                    { 249, "Відеокамери", 3, "Відеокамери", 31 },
                    { 250, "Екшн-камери", 3, "Екшн-камери", 31 },
                    { 251, "Об'єктиви", 3, "Об'єктиви", 31 },
                    { 252, "Аксесуари для фото/відео", 3, "Аксесуари для фото/відео", 31 },
                    { 253, "Зарядні пристрої для фото та відеокамер", 3, "Зарядні пристрої для фото та відеокамер", 31 },
                    { 254, "Акумулятори та батарейки", 3, "Акумулятори та батарейки", 31 },
                    { 255, "Штативи", 3, "Штативи", 31 },
                    { 256, "Студійне обладнання", 3, "Студійне обладнання", 31 },
                    { 257, "Студійне світло", 3, "Студійне світло", 31 },
                    { 258, "Сумки та чохли", 3, "Сумки та чохли", 31 },
                    { 259, "Ігрові приставки PlayStation 5", 3, "Ігрові приставки PlayStation 5", 34 },
                    { 260, "Ігрові приставки PlayStation 4", 3, "Ігрові приставки PlayStation 4", 34 },
                    { 261, "Ігрові приставки PlayStation", 3, "Ігрові приставки PlayStation", 34 },
                    { 262, "Геймпади PlayStation", 3, "Геймпади PlayStation", 34 },
                    { 263, "Шоломи VR PlayStation", 3, "Шоломи VR PlayStation", 34 },
                    { 264, "Гарнітури PlayStation", 3, "Гарнітури PlayStation", 34 },
                    { 265, "Аксесуари PlayStation", 3, "Аксесуари PlayStation", 34 },
                    { 266, "Ігри для PlayStation 5", 3, "Ігри для PlayStation 5", 34 },
                    { 267, "Ігри для PlayStation 4", 3, "Ігри для PlayStation 4", 34 },
                    { 268, "Ігри для Nintendo", 3, "Ігри для Nintendo", 35 },
                    { 269, "Ігри для Xbox", 3, "Ігри для Xbox", 36 },
                    { 270, "Asus", 3, "Asus", 37 },
                    { 271, "HP", 3, "HP", 37 },
                    { 272, "Acer", 3, "Acer", 37 },
                    { 273, "MSI", 3, "MSI", 37 },
                    { 274, "Dell", 3, "Dell", 37 },
                    { 275, "Lenovo", 3, "Lenovo", 37 },
                    { 276, "Ігри для PC", 3, "Ігри для PC", 37 },
                    { 277, "ARTLINE", 3, "ARTLINE", 37 },
                    { 278, "QUBE", 3, "QUBE", 37 },
                    { 279, "Cobra", 3, "Cobra", 37 },
                    { 280, "Samsung", 3, "Samsung", 38 },
                    { 281, "Acer", 3, "Acer", 38 },
                    { 282, "AOC", 3, "AOC", 38 },
                    { 283, "Asus", 3, "Asus", 38 },
                    { 284, "MSI", 3, "MSI", 38 },
                    { 285, "QUBE", 3, "QUBE", 38 },
                    { 286, "Відеокарти", 3, "Відеокарти", 39 },
                    { 287, "Процесори", 3, "Процесори", 39 },
                    { 288, "Оперативна пам'ять", 3, "Оперативна пам'ять", 39 },
                    { 289, "Материнські плати", 3, "Материнські плати", 39 },
                    { 290, "Жорсткі диски", 3, "Жорсткі диски", 39 },
                    { 291, "Блоки живлення", 3, "Блоки живлення", 39 },
                    { 292, "Системи охолодження", 3, "Системи охолодження", 39 },
                    { 293, "Корпуси", 3, "Корпуси", 39 },
                    { 294, "Навушники", 3, "Навушники", 40 },
                    { 295, "Ігрові миші", 3, "Ігрові миші", 40 },
                    { 296, "Ігрові клавіатури", 3, "Ігрові клавіатури", 40 },
                    { 297, "Ігрові коврики", 3, "Ігрові коврики", 40 },
                    { 298, "Маніпулятори, джойстики", 3, "Маніпулятори, джойстики", 40 },
                    { 299, "Геймерські крісла", 3, "Геймерські крісла", 40 },
                    { 300, "Комп'ютерні столи", 3, "Комп'ютерні столи", 40 },
                    { 301, "Геймерські рюкзаки", 3, "Геймерські рюкзаки", 40 },
                    { 302, "Браслети", 3, "Браслети", 42 },
                    { 303, "Брелоки", 3, "Брелоки", 42 },
                    { 304, "Гаманці", 3, "Гаманці", 42 },
                    { 305, "Подушки", 3, "Подушки", 42 },
                    { 306, "Чашки", 3, "Чашки", 42 },
                    { 307, "Фігурки і статуетки", 3, "Фігурки і статуетки", 42 },
                    { 308, "Одяг для геймерів", 3, "Одяг для геймерів", 42 },
                    { 309, "Кепки і головні убори", 3, "Кепки і головні убори", 42 },
                    { 310, "Рюкзаки та сумки", 3, "Рюкзаки та сумки", 42 },
                    { 311, "М'які іграшки", 3, "М'які іграшки", 42 },
                    { 312, "Подарункові набори для геймерів", 3, "Подарункові набори для геймерів", 42 },
                    { 313, "Картинки і постери", 3, "Картинки і постери", 42 },
                    { 314, "Холодильники", 3, "Холодильники", 44 },
                    { 315, "Морозильні камери", 3, "Морозильні камери", 44 },
                    { 316, "Пральні машини", 3, "Пральні машини", 44 },
                    { 317, "Пральні машини із сушаркою", 3, "Пральні машини із сушаркою", 44 },
                    { 318, "Посудомийні машини", 3, "Посудомийні машини", 44 },
                    { 319, "Мікрохвильові печі", 3, "Мікрохвильові печі", 44 },
                    { 320, "Сушильні автомати", 3, "Сушильні автомати", 44 },
                    { 321, "Плити", 3, "Плити", 44 },
                    { 322, "Вбудовувані духові шафи", 3, "Вбудовувані духові шафи", 44 },
                    { 323, "Вбудовувані варильні поверхні", 3, "Вбудовувані варильні поверхні", 44 },
                    { 324, "Комплекти вбудованої техніки", 3, "Комплекти вбудованої техніки", 44 },
                    { 325, "Кухонні витяжки", 3, "Кухонні витяжки", 44 },
                    { 326, "Сертифікати на продовження гарантії", 3, "Сертифікати на продовження гарантії", 44 },
                    { 327, "Встановлення великої побутової техніки", 3, "Встановлення великої побутової техніки", 44 },
                    { 328, "Акумуляторні пилососи", 3, "Акумуляторні пилососи", 45 },
                    { 329, "Роботи-пилососи", 3, "Роботи-пилососи", 45 },
                    { 330, "Пилососи для сухого прибирання", 3, "Пилососи для сухого прибирання", 45 },
                    { 331, "Праски", 3, "Праски", 45 },
                    { 332, "Відпарювачі", 3, "Відпарювачі", 45 },
                    { 333, "Прасувальні системи", 3, "Прасувальні системи", 45 },
                    { 334, "Праски з парогенератором", 3, "Праски з парогенератором", 45 },
                    { 335, "Миючі пилососи", 3, "Миючі пилососи", 45 },
                    { 336, "Пароочисники", 3, "Пароочисники", 45 },
                    { 337, "Швейна техніка та аксесуари", 3, "Швейна техніка та аксесуари", 45 },
                    { 338, "Настінні кондиціонери", 3, "Настінні кондиціонери", 46 },
                    { 339, "Мобільні кондиціонери", 3, "Мобільні кондиціонери", 46 },
                    { 340, "Вентилятори", 3, "Вентилятори", 46 },
                    { 341, "Бойлери", 3, "Бойлери", 46 },
                    { 342, "Очищувачі повітря", 3, "Очищувачі повітря", 46 },
                    { 343, "Зволожувачі повітря", 3, "Зволожувачі повітря", 46 },
                    { 344, "Осушувачі повітря", 3, "Осушувачі повітря", 46 },
                    { 345, "Обігрівачі", 3, "Обігрівачі", 46 },
                    { 346, "Монтаж кондиціонера", 3, "Монтаж кондиціонера", 46 },
                    { 347, "Сертифікати на продовження гарантії", 3, "Сертифікати на продовження гарантії", 46 },
                    { 348, "Кавомашини", 3, "Кавомашини", 47 },
                    { 349, "Мультипечі та аерогрилі", 3, "Мультипечі та аерогрилі", 47 },
                    { 350, "Блендери", 3, "Блендери", 47 },
                    { 351, "Грилі та електрошашличниці", 3, "Грилі та електрошашличниці", 47 },
                    { 352, "Кухонні комбайни", 3, "Кухонні комбайни", 47 },
                    { 353, "Мультиварки", 3, "Мультиварки", 47 },
                    { 354, "Соковичавниці", 3, "Соковичавниці", 47 },
                    { 355, "Електрочайники", 3, "Електрочайники", 47 },
                    { 356, "Електричні печі", 3, "Електричні печі", 47 },
                    { 357, "М'ясорубки", 3, "М'ясорубки", 47 },
                    { 358, "Тостери", 3, "Тостери", 47 },
                    { 359, "Хлібопічки", 3, "Хлібопічки", 47 },
                    { 360, "Міксери", 3, "Міксери", 47 },
                    { 361, "Фільтри-глечики", 3, "Фільтри-глечики", 47 },
                    { 362, "Картриджі для фільтрів глечиків", 3, "Картриджі для фільтрів глечиків", 47 },
                    { 363, "Світ кави", 3, "Світ кави", 47 },
                    { 364, "Вентилятори", 3, "Вентилятори", 48 },
                    { 365, "Пилососи", 3, "Пилососи", 48 },
                    { 366, "Блендери", 3, "Блендери", 48 },
                    { 367, "Кухонні комбайни", 3, "Кухонні комбайни", 48 },
                    { 368, "Електричні зубні щітки", 3, "Електричні зубні щітки", 48 },
                    { 369, "Праски", 3, "Праски", 48 },
                    { 370, "Електричні чайники", 3, "Електрочайники", 48 },
                    { 371, "Сертифікати на продовження гарантії", 3, "Сертифікати на продовження гарантії", 48 },
                    { 372, "Столи з регулюванням по висоті", 3, "Столи з регулюванням по висоті", 49 },
                    { 373, "Комп'ютерні столи", 3, "Комп'ютерні столи", 49 },
                    { 374, "Крісла", 3, "Крісла", 49 },
                    { 375, "Стільці", 3, "Стільці", 49 },
                    { 376, "Обідні столи", 3, "Обідні столи", 49 },
                    { 377, "Кухонні гарнітури", 3, "Кухонні гарнітури", 49 },
                    { 378, "Стелажі та консолі", 3, "Стелажі та консолі", 49 },
                    { 379, "Меблі для спальні", 3, "Меблі для спальні", 49 },
                    { 380, "Безкаркасні меблі", 3, "Безкаркасні меблі", 49 },
                    { 381, "Шафи", 3, "Шафи", 49 },
                    { 382, "Меблі для передпокою і вбиральні", 3, "Меблі для передпокою і вбиральні", 49 },
                    { 383, "Тумби", 3, "Тумби", 49 },
                    { 384, "Полиці", 3, "Полиці", 49 },
                    { 385, "Меблі для саду та дачі", 3, "Меблі для саду та дачі", 49 },
                    { 386, "Комоди", 3, "Комоди", 49 },
                    { 387, "Металеві меблі", 3, "Металеві меблі", 49 },
                    { 388, "Аромати для дому", 3, "Аромати для дому", 50 },
                    { 389, "Підсвічники", 3, "Підсвічники", 50 },
                    { 390, "Настінний декор", 3, "Настінний декор", 50 },
                    { 391, "Вази", 3, "Вази", 50 },
                    { 392, "Інтер'єрні наклейки", 3, "Інтер'єрні наклейки", 50 },
                    { 393, "Ароматерапія", 3, "Ароматерапія", 50 },
                    { 394, "Ікони", 3, "Ікони", 50 },
                    { 395, "Фотоальбоми", 3, "Фотоальбоми", 50 },
                    { 396, "Фоторамки", 3, "Фоторамки", 50 },
                    { 397, "Свічки", 3, "Свічки", 50 },
                    { 398, "Домофони", 3, "Домофони", 51 },
                    { 399, "Комплекти відеоспостереження", 3, "Комплекти відеоспостереження", 51 },
                    { 400, "Комплекти сигналізацій", 3, "Комплекти сигналізацій", 51 },
                    { 401, "Відеодомофони", 3, "Відеодомофони", 51 },
                    { 402, "Стабілізатори напруги", 3, "Стабілізатори напруги", 51 },
                    { 403, "Інвертори", 3, "Інвертори", 51 },
                    { 404, "Люстри", 3, "Люстри", 52 },
                    { 405, "Лампи", 3, "Лампи", 52 },
                    { 406, "Настельні світильники", 3, "Настельні світильники", 52 },
                    { 407, "Точкові світильники", 3, "Точкові світильники", 52 },
                    { 408, "Бра і стельові світильники", 3, "Бра і стельові світильники", 52 },
                    { 409, "Освітлення", 3, "Освітлення", 52 },
                    { 410, "Послуги електрика", 3, "Послуги електрика", 52 },
                    { 411, "Келихи та фужери", 3, "Келихи та фужери", 53 },
                    { 412, "Стопки та чарки", 3, "Стопки та чарки", 53 },
                    { 413, "Сходи", 3, "Сходи", 54 },
                    { 414, "Прасувальні дошки", 3, "Прасувальні дошки", 54 },
                    { 415, "Сушарки для білизни", 3, "Сушарки для білизни", 54 },
                    { 416, "Господарський інвентар", 3, "Господарський інвентар", 54 },
                    { 417, "Брудозахисні покриття", 3, "Брудозахисні покриття", 54 },
                    { 418, "Прання та прасування", 3, "Прання та прасування", 54 },
                    { 419, "Мотузяні вироби", 3, "Мотузяні вироби", 54 },
                    { 420, "Клінінгові обладнання", 3, "Клінінгові обладнання", 54 },
                    { 421, "Сміттєві контейнери", 3, "Сміттєві контейнери", 54 },
                    { 422, "Туалетний папір", 3, "Туалетний папір", 55 },
                    { 423, "Паперові рушники", 3, "Паперові рушники", 55 },
                    { 424, "Серветки", 3, "Серветки", 55 },
                    { 425, "Сміттєві пакети", 3, "Сміттєві пакети", 55 },
                    { 426, "Кухонні губки", 3, "Кухонні губки", 55 },
                    { 427, "Харчова упаковка", 3, "Харчова упаковка", 55 },
                    { 428, "Господарські рукавички", 3, "Господарські рукавички", 55 },
                    { 429, "Серветки для прибирання", 3, "Серветки для прибирання", 55 },
                    { 430, "Одноразовий посуд", 3, "Одноразовий посуд", 55 },
                    { 431, "Гігієнічні накладки на унітаз", 3, "Гігієнічні накладки на унітаз", 55 },
                    { 432, "Шурупокрути та електровикрутки", 3, "Шурупокрути та електровикрутки", 56 },
                    { 433, "Болгарки", 3, "Болгарки", 56 },
                    { 434, "Перфоратори", 3, "Перфоратори", 56 },
                    { 435, "Дрилі та міксери", 3, "Дрилі та міксери", 56 },
                    { 436, "Пили та плиткорізи", 3, "Пили та плиткорізи", 56 },
                    { 437, "Фарбопульти", 3, "Фарбопульти", 56 },
                    { 438, "Електролобзики", 3, "Електролобзики", 56 },
                    { 439, "Вимірювальна техніка", 3, "Вимірювальна техніка", 56 },
                    { 440, "Фрезери", 3, "Фрезери", 56 },
                    { 441, "Багатофункційні інструменти", 3, "Багатофункційні інструменти", 56 },
                    { 442, "Клейові пістолети та аксесуари", 3, "Клейові пістолети та аксесуари", 56 },
                    { 443, "Електрорубанки", 3, "Електрорубанки", 56 },
                    { 444, "Будівельні фени", 3, "Будівельні фени", 56 },
                    { 445, "Свердла", 3, "Свердла", 57 },
                    { 446, "Диски", 3, "Диски", 57 },
                    { 447, "Біти", 3, "Біти", 57 },
                    { 448, "Бури", 3, "Бури", 57 },
                    { 449, "Пиляльні полотна", 3, "Пиляльні полотна", 57 },
                    { 450, "Фрези", 3, "Фрези", 57 },
                    { 451, "Зварювальне обладнання", 3, "Зварювальне обладнання", 58 },
                    { 452, "Генератори", 3, "Генератори", 58 },
                    { 453, "Стабілізатори напруги", 3, "Стабілізатори напруги", 58 },
                    { 454, "Універсальні мийки", 3, "Універсальні мийки", 58 },
                    { 455, "Бетономішалки", 3, "Бетономішалки", 58 },
                    { 456, "Компресори", 3, "Компресори", 58 },
                    { 457, "Теплові гармати", 3, "Теплові гармати", 58 },
                    { 458, "Точильні верстати", 3, "Точильні верстати", 58 },
                    { 459, "Вантажопідіймальне обладнання", 3, "Вантажопідіймальне обладнання", 58 },
                    { 460, "Інвертори", 3, "Інвертори", 58 },
                    { 461, "Промислові пилососи", 3, "Промислові пилососи", 58 },
                    { 462, "Набори інструментів", 3, "Набори інструментів", 59 },
                    { 463, "Скрині та сумки для інструментів", 3, "Скрині та сумки для інструментів", 59 },
                    { 464, "Ключі, знімачі", 3, "Ключі, знімачі", 59 },
                    { 465, "Викрутки", 3, "Викрутки", 59 },
                    { 466, "Вимірювально-розмічальний інструмент", 3, "Вимірювально-розмічальний інструмент", 59 },
                    { 467, "Шарнірно-губцевий інструмент", 3, "Шарнірно-губцевий інструмент", 59 },
                    { 468, "Розетки та вимикачі", 3, "Розетки та вимикачі", 60 },
                    { 469, "Кабельно-провідникова продукція", 3, "Кабельно-провідникова продукція", 60 },
                    { 470, "Автозапчастини", 3, "Автозапчастини", 61 },
                    { 471, "Шини", 3, "Шини", 61 },
                    { 472, "Автомобільні диски", 3, "Автомобільні диски", 61 },
                    { 473, "Відеореєстратори", 3, "Відеореєстратори", 61 },
                    { 474, "Мастила й оливи", 3, "Мастила й оливи", 61 },
                    { 475, "GPS-навігатори", 3, "GPS-навігатори", 61 },
                    { 476, "Автокомпресори", 3, "Автокомпресори", 61 },
                    { 477, "Головні пристрої", 3, "Головні пристрої", 61 },
                    { 478, "Пускозарядні пристрої", 3, "Пускозарядні пристрої", 61 },
                    { 479, "Автоприладдя", 3, "Автоприладдя", 61 },
                    { 480, "Автосигналізації", 3, "Автосигналізації", 61 },
                    { 481, "Техдопомога", 3, "Техдопомога", 61 },
                    { 482, "Домкрати", 3, "Домкрати", 61 },
                    { 483, "Автоакустика", 3, "Автоакустика", 61 },
                    { 484, "Паркувальні системи", 3, "Паркувальні системи", 61 },
                    { 485, "Автохімія", 3, "Автохімія", 61 },
                    { 486, "FM-трансмітери", 3, "FM-трансмітери", 61 },
                    { 487, "Автолампи", 3, "Автолампи", 61 },
                    { 488, "Автокосметика", 3, "Автокосметика", 61 },
                    { 489, "Радар-детектори", 3, "Радар-детектори", 61 },
                    { 490, "Штатні головні пристрої", 3, "Штатні головні пристрої", 61 },
                    { 491, "Дефлектори", 3, "Дефлектори", 61 },
                    { 492, "Автофарби", 3, "Автофарби", 61 },
                    { 493, "Електрообладнання автомобілів", 3, "Електрообладнання автомобілів", 61 },
                    { 494, "Ванни", 3, "Ванни", 62 },
                    { 495, "Гідромасажні бокси", 3, "Гідромасажні бокси", 62 },
                    { 496, "Душові гарнітури", 3, "Душові гарнітури", 62 },
                    { 497, "Душові кабіни та стінки", 3, "Душові кабіни та стінки", 62 },
                    { 498, "Бойлери", 3, "Бойлери", 62 },
                    { 499, "Панелі для ванн", 3, "Панелі для ванн", 62 },
                    { 500, "Душові двері та перегородки", 3, "Душові двері та перегородки", 62 },
                    { 501, "Змішувачі", 3, "Змішувачі", 63 },
                    { 502, "Кухонні мийки", 3, "Кухонні мийки", 63 },
                    { 503, "Кухонні змішувачі", 3, "Кухонні змішувачі", 63 },
                    { 504, "Сифони", 3, "Сифони", 63 },
                    { 505, "Системи зворотного осмосу", 3, "Системи зворотного осмосу", 63 },
                    { 506, "Унітази", 3, "Унітази", 64 },
                    { 507, "Раковини", 3, "Раковини", 64 },
                    { 508, "Сушарки для рук", 3, "Сушарки для рук", 64 },
                    { 509, "Біде", 3, "Біде", 64 },
                    { 510, "Бачки для унітазу", 3, "Бачки для унітазу", 64 },
                    { 511, "Паперотримачі та полички", 3, "Паперотримачі та полички", 64 },
                    { 512, "Інсталяції для унітазу", 3, "Інсталяції для унітазу", 66 },
                    { 513, "Інсталяції для біде", 3, "Інсталяції для біде", 66 },
                    { 514, "Кнопки для змиву", 3, "Кнопки для змиву", 66 },
                    { 515, "Сушильники для рушників", 3, "Сушильники для рушників", 67 },
                    { 516, "Радіатори", 3, "Радіатори", 67 },
                    { 517, "Болгарки", 3, "Болгарки", 68 },
                    { 518, "Перфоратори", 3, "Перфоратори", 68 },
                    { 519, "Витратні матеріали та приладдя", 3, "Витратні матеріали та приладдя", 68 },
                    { 520, "Обладнання", 3, "Обладнання", 68 },
                    { 521, "Генератори", 3, "Генератори", 68 },
                    { 522, "Зварювальне обладнання", 3, "Зварювальне обладнання", 68 },
                    { 523, "Промислові пилососи", 3, "Промислові пилососи", 68 },
                    { 524, "Набори інструментів", 3, "Набори інструментів", 69 },
                    { 525, "Ключі, знімачі", 3, "Ключі, знімачі", 69 },
                    { 526, "Скрині та сумки для інструментів", 3, "Скрині та сумки для інструментів", 69 },
                    { 527, "Люстри", 3, "Люстри", 70 },
                    { 528, "Настінно-стельові світильники", 3, "Настінно-стельові світильники", 70 },
                    { 529, "Точкові світильники", 3, "Точкові світильники", 70 },
                    { 530, "Бра та настінні світильники", 3, "Бра та настінні світильники", 70 },
                    { 531, "Настільні лампи", 3, "Настільні лампи", 70 },
                    { 532, "Торшери", 3, "Торшери", 70 },
                    { 533, "Світильники для ванної", 3, "Світильники для ванної", 70 },
                    { 534, "Дитячі настільні лампи", 3, "Дитячі настільні лампи", 70 },
                    { 535, "Вуличне освітлення", 3, "Вуличне освітлення", 70 },
                    { 536, "Лампочки та аксесуари", 3, "Лампочки та аксесуари", 70 },
                    { 537, "Офісно-промислове освітлення", 3, "Офісно-промислове освітлення", 70 },
                    { 538, "Захист від перепадів напруги", 3, "Захист від перепадів напруги", 71 },
                    { 539, "Лічильники води", 3, "Лічильники води", 71 },
                    { 540, "Лічильники газу", 3, "Лічильники газу", 71 },
                    { 541, "Лічильники електроенергії", 3, "Лічильники електроенергії", 71 },
                    { 542, "Тумби", 3, "Тумби", 72 },
                    { 543, "Дзеркала", 3, "Дзеркала", 72 },
                    { 544, "Пенали", 3, "Пенали", 72 },
                    { 545, "Покрівля та водостік", 3, "Покрівля та водостік", 74 },
                    { 546, "Газонокосарки", 3, "Газонокосарки", 75 },
                    { 547, "Тримери та мотокоси", 3, "Тримери та мотокоси", 75 },
                    { 548, "Електрокультиватори", 3, "Електрокультиватори", 75 },
                    { 549, "Кущорізи", 3, "Кущорізи", 75 },
                    { 550, "Мотокультиватори", 3, "Мотокультиватори", 75 },
                    { 551, "Акумуляторні пилки", 3, "Акумуляторні пилки", 75 },
                    { 552, "Електропили", 3, "Електропили", 75 },
                    { 553, "Садові подрібнювачі та дровоколи", 3, "Садові подрібнювачі та дровоколи", 75 },
                    { 554, "Бензопили", 3, "Бензопили", 75 },
                    { 555, "Повітродуви", 3, "Повітродуви", 75 },
                    { 556, "Витратні матеріали для мотокос", 3, "Витратні матеріали для мотокос", 75 },
                    { 557, "Мотоблоки", 3, "Мотоблоки", 75 },
                    { 558, "Аератори", 3, "Аератори", 75 },
                    { 559, "Обприскувачі", 3, "Обприскувачі", 76 },
                    { 560, "Тачки", 3, "Тачки", 76 },
                    { 561, "Сітки садові", 3, "Сітки садові", 76 },
                    { 562, "Агроволокно", 3, "Агроволокно", 76 },
                    { 563, "Садові огорожі", 3, "Садові огорожі", 76 },
                    { 564, "Компостери садові", 3, "Компостери садові", 76 },
                    { 565, "Пластикові ємності", 3, "Пластикові ємності", 76 },
                    { 566, "Теплиці", 3, "Теплиці", 76 },
                    { 567, "Лійки для квітів", 3, "Лійки для квітів", 76 },
                    { 568, "Садове приладдя", 3, "Садове приладдя", 76 },
                    { 569, "Драбини, підмостки", 3, "Драбини, підмостки", 76 },
                    { 570, "Шланги", 3, "Шланги", 77 },
                    { 571, "Занурювальні насоси", 3, "Занурювальні насоси", 77 },
                    { 572, "Насадки", 3, "Насадки", 77 },
                    { 573, "Зрошувачі", 3, "Зрошувачі", 77 },
                    { 574, "Поверхневі насоси", 3, "Поверхневі насоси", 77 },
                    { 575, "Комплектуючі до насосів", 3, "Комплектуючі до насосів", 77 },
                    { 576, "Набори для крапельного поливу", 3, "Набори для крапельного поливу", 77 },
                    { 577, "Комплектуючі для поливу", 3, "Комплектуючі для поливу", 77 },
                    { 578, "Таймери для поливу", 3, "Таймери для поливу", 77 },
                    { 579, "Мотопомпи", 3, "Мотопомпи", 77 },
                    { 580, "Циркуляційні насоси", 3, "Циркуляційні насоси", 77 },
                    { 581, "Секатори", 3, "Секатори", 78 },
                    { 582, "Лопати", 3, "Лопати", 78 },
                    { 583, "Сокири", 3, "Сокири", 78 },
                    { 584, "Сучкорізи", 3, "Сучкорізи", 78 },
                    { 585, "Ручні культиватори", 3, "Ручні культиватори", 78 },
                    { 586, "Садові ножиці", 3, "Садові ножиці", 78 },
                    { 587, "Граблі", 3, "Граблі", 78 },
                    { 588, "Пили садові", 3, "Пили садові", 78 },
                    { 589, "Сапи", 3, "Сапи", 78 },
                    { 590, "Садові совки", 3, "Садові совки", 78 },
                    { 591, "Держаки для садового інструменту", 3, "Держаки для садового інструменту", 78 },
                    { 592, "Набори садових інструментів", 3, "Набори садових інструментів", 78 },
                    { 593, "Садові ножі", 3, "Садові ножі", 78 },
                    { 594, "Насіння газонних трав", 3, "Насіння газонних трав", 79 },
                    { 595, "Органічні добрива", 3, "Органічні добрива", 79 },
                    { 596, "Мінеральні добрива", 3, "Мінеральні добрива", 79 },
                    { 597, "Вазони", 3, "Вазони", 79 },
                    { 598, "Отрута для гризунів", 3, "Отрута для гризунів", 79 },
                    { 599, "Субстрати та ґрунти для рослин", 3, "Субстрати та ґрунти для рослин", 79 },
                    { 600, "Пастки для гризунів та птахів", 3, "Пастки для гризунів та птахів", 79 },
                    { 601, "Інсектициди", 3, "Інсектициди", 79 },
                    { 602, "Фунгіциди", 3, "Фунгіциди", 79 },
                    { 603, "Органомінеральні добрива", 3, "Органомінеральні добрива", 79 },
                    { 604, "Стимулятори росту рослин", 3, "Стимулятори росту рослин", 79 },
                    { 605, "Біодобрива", 3, "Біодобрива", 79 },
                    { 606, "Насіння пряних та зелених трав", 3, "Насіння пряних та зелених трав", 79 },
                    { 607, "Басейни", 3, "Басейни", 80 },
                    { 608, "Аксесуари для басейнів", 3, "Аксесуари для басейнів", 80 },
                    { 609, "Обладнання для басейнів", 3, "Обладнання для басейнів", 80 },
                    { 610, "Сміттєві контейнери", 3, "Сміттєві контейнери", 81 },
                    { 611, "Вуличні урни", 3, "Вуличні урни", 81 },
                    { 612, "Бігові доріжки", 3, "Бігові доріжки", 84 },
                    { 613, "Гантелі, диски, грифи, замки", 3, "Гантелі, диски, грифи, замки", 84 },
                    { 614, "Велотренажери", 3, "Велотренажери", 84 },
                    { 615, "Орбітреки", 3, "Орбітреки", 84 },
                    { 616, "Батути й аксесуари", 3, "Батути й аксесуари", 84 },
                    { 617, "Силові тренажери", 3, "Силові тренажери", 84 },
                    { 618, "Шведські стінки та турніки", 3, "Шведські стінки та турніки", 84 },
                    { 619, "Йога", 3, "Йога", 85 },
                    { 620, "Еспандери", 3, "Еспандери", 85 },
                    { 621, "Фітнес м'ячі", 3, "Фітнес м'ячі", 85 },
                    { 622, "Пояси та рукавички для фітнесу", 3, "Пояси та рукавички для фітнесу", 85 },
                    { 623, "Скакалки", 3, "Скакалки", 85 },
                    { 624, "Аксесуари для спортивного харчування", 3, "Аксесуари для спортивного харчування", 86 },
                    { 625, "Велосипеди", 3, "Велосипеди", 87 },
                    { 626, "Велоаксесуари", 3, "Велоаксесуари", 87 },
                    { 627, "Велогума", 3, "Велогума", 87 },
                    { 628, "Велозапчастини", 3, "Велозапчастини", 87 },
                    { 629, "Електросамокати", 3, "Електросамокати", 88 },
                    { 630, "Електроскутери", 3, "Електроскутери", 88 },
                    { 631, "Електровелосипеди", 3, "Електровелосипеди", 88 },
                    { 632, "М'ячі", 3, "М'ячі", 89 },
                    { 633, "Настільний теніс", 3, "Настільний теніс", 89 },
                    { 634, "Бадмінтон, спідмінтон, сквош", 3, "Бадмінтон, спідмінтон, сквош", 89 },
                    { 635, "Рукавиці для боксу", 3, "Рукавиці для боксу", 90 },
                    { 636, "Боксерські мішки та груші", 3, "Боксерські мішки та груші", 90 },
                    { 637, "Окуляри для плавання", 3, "Окуляри для плавання", 91 },
                    { 638, "Шапочки для плавання", 3, "Шапочки для плавання", 91 },
                    { 639, "Мультиінструменти, точилки", 3, "Мультиінструменти, точилки", 92 },
                    { 640, "Рації", 3, "Рації", 92 },
                    { 641, "Біноклі", 3, "Біноклі", 92 },
                    { 642, "Складані меблі", 3, "Складані меблі", 94 },
                    { 643, "Намети й аксесуари", 3, "Намети й аксесуари", 94 },
                    { 644, "Спальники", 3, "Спальники", 94 },
                    { 645, "Туристичні килимки", 3, "Туристичні килимки", 94 },
                    { 646, "Надувні меблі й аксесуари", 3, "Надувні меблі й аксесуари", 94 },
                    { 647, "Мангали, барбекю, гриль", 3, "Мангали, барбекю, гриль", 94 },
                    { 648, "Аксесуари для мангалів", 3, "Аксесуари для мангалів", 94 },
                    { 649, "Ліхтарі й аксесуари", 3, "Ліхтарі й аксесуари", 94 },
                    { 650, "Газові балони і комплектуючі", 3, "Газові балони і комплектуючі", 94 },
                    { 651, "Туристичні пальники", 3, "Туристичні пальники", 94 },
                    { 652, "Вудилища", 3, "Вудилища", 95 },
                    { 653, "Котушки рибальські", 3, "Котушки рибальські", 95 },
                    { 654, "Човни й аксесуари", 3, "Човни й аксесуари", 95 },
                    { 655, "Ящики та сумки", 3, "Ящики та сумки", 95 },
                    { 656, "Клавішні інструменти", 3, "Клавішні інструменти", 97 },
                    { 657, "Гітари та обладнання", 3, "Гітари та обладнання", 97 },
                    { 658, "Мікрофони", 3, "Мікрофони", 97 },
                    { 659, "Музичні інструменти для дітей", 3, "Музичні інструменти для дітей", 97 },
                    { 660, "Плаття", 3, "Плаття", 98 },
                    { 661, "Футболки", 3, "Футболки", 98 },
                    { 662, "Джинси", 3, "Джинси", 98 },
                    { 663, "Спортивні костюми", 3, "Спортивні костюми", 98 },
                    { 664, "Худі, світшоти", 3, "Худі, світшоти", 98 },
                    { 665, "Піджаки та жакети", 3, "Піджаки та жакети", 98 },
                    { 666, "Сорочки та блузи", 3, "Сорочки та блузи", 98 },
                    { 667, "Купальники", 3, "Купальники", 98 },
                    { 668, "Спідня білизна", 3, "Спідня білизна", 98 },
                    { 669, "Нічний і домашній одяг", 3, "Нічний і домашній одяг", 98 },
                    { 670, "Босоніжки", 3, "Босоніжки", 99 },
                    { 671, "Сандалі", 3, "Сандалі", 99 },
                    { 672, "Кеди", 3, "Кеди", 99 },
                    { 673, "Кросівки", 3, "Кросівки", 99 },
                    { 674, "Шльопанці та крокси", 3, "Шльопанці та крокси", 99 },
                    { 675, "Туфлі та балетки", 3, "Туфлі та балетки", 99 },
                    { 676, "Кімнатне взуття", 3, "Кімнатне взуття", 99 },
                    { 677, "Сумки та рюкзаки", 3, "Сумки та рюкзаки", 100 },
                    { 678, "Головні убори", 3, "Головні убори", 100 },
                    { 679, "Сонцезахисні окуляри", 3, "Сонцезахисні окуляри", 100 },
                    { 680, "Гаманці", 3, "Гаманці", 100 },
                    { 681, "Парасолі", 3, "Парасолі", 100 },
                    { 682, "Футболки", 3, "Футболки", 101 },
                    { 683, "Спортивні костюми", 3, "Спортивні костюми", 101 },
                    { 684, "Спортивні штани", 3, "Спортивні штани", 101 },
                    { 685, "Худі та толстовки", 3, "Худі та толстовки", 101 },
                    { 686, "Шорти", 3, "Шорти", 101 },
                    { 687, "Джинси", 3, "Джинси", 101 },
                    { 688, "Сорочки", 3, "Сорочки", 101 },
                    { 689, "Нічний і домашній одяг", 3, "Нічний і домашній одяг", 101 },
                    { 690, "Спідня білизна", 3, "Спідня білизна", 101 },
                    { 691, "Шкарпетки", 3, "Шкарпетки", 101 },
                    { 692, "Сандалії", 3, "Сандалії", 102 },
                    { 693, "Кеди", 3, "Кеди", 102 },
                    { 694, "Кросівки", 3, "Кросівки", 102 },
                    { 695, "Туфлі", 3, "Туфлі", 102 },
                    { 696, "Мокасини", 3, "Мокасини", 102 },
                    { 697, "Шльопанці та крокси", 3, "Шльопанці та крокси", 102 },
                    { 698, "Кімнатне взуття", 3, "Кімнатне взуття", 102 },
                    { 699, "Рюкзаки та сумки", 3, "Рюкзаки та сумки", 103 },
                    { 700, "Головні убори", 3, "Головні убори", 103 },
                    { 701, "Сонцезахисні окуляри", 3, "Сонцезахисні окуляри", 103 },
                    { 702, "Ремені", 3, "Ремені", 103 },
                    { 703, "Парасолі", 3, "Парасолі", 103 },
                    { 704, "Футболки та сорочки для хлопчиків", 3, "Футболки та сорочки для хлопчиків", 104 },
                    { 705, "Шорти, джинси, брюки для хлопчиків", 3, "Шорти, джинси, брюки для хлопчиків", 104 },
                    { 706, "Спортивні костюми для хлопчиків", 3, "Спортивні костюми для хлопчиків", 104 },
                    { 707, "Худі та світшоти для хлопчиків", 3, "Худі та світшоти для хлопчиків", 104 },
                    { 708, "Дитячий верхній одяг", 3, "Дитячий верхній одяг", 104 },
                    { 709, "Плаття та сарафани для дівчаток", 3, "Плаття та сарафани для дівчаток", 104 },
                    { 710, "Шорти та штани для дівчаток", 3, "Шорти та штани для дівчаток", 104 },
                    { 711, "Худі, світшоти для дівчаток", 3, "Худі, світшоти для дівчаток", 104 },
                    { 712, "Спортивні костюми для дівчаток", 3, "Спортивні костюми для дівчаток", 104 },
                    { 713, "Дитяча нижня білизна", 3, "Дитяча нижня білизна", 104 },
                    { 714, "Кросівки та кеди для хлопчиків", 3, "Кросівки та кеди для хлопчиків", 105 },
                    { 715, "Шльопанці для хлопчиків", 3, "Шльопанці для хлопчиків", 105 },
                    { 716, "Сандалії для хлопчиків", 3, "Сандалії для хлопчиків", 105 },
                    { 717, "Туфлі для хлопчиків", 3, "Туфлі для хлопчиків", 105 },
                    { 718, "Кросівки для дівчаток", 3, "Кросівки для дівчаток", 105 },
                    { 719, "Туфлі для дівчаток", 3, "Туфлі для дівчаток", 105 },
                    { 720, "Шльопанці для дівчаток", 3, "Шльопанці для дівчаток", 105 },
                    { 721, "Сандалії для дівчаток", 3, "Сандалії для дівчаток", 105 },
                    { 722, "Машинки для стриження", 3, "Машинки для стриження", 107 },
                    { 723, "Триммери", 3, "Триммери", 107 },
                    { 724, "Електробритви", 3, "Електробритви", 107 },
                    { 725, "Фени", 3, "Фени", 107 },
                    { 726, "Епілятори", 3, "Епілятори", 107 },
                    { 727, "Подарункові набори", 3, "Подарункові набори", 107 },
                    { 728, "Станок для гоління", 3, "Станок для гоління", 110 },
                    { 729, "Лезо для бритви", 3, "Лезо для бритви", 110 },
                    { 730, "Косметика для гоління", 3, "Косметика для гоління", 110 },
                    { 731, "Туалетний папір", 3, "Туалетний папір", 112 },
                    { 732, "Підгузки для дорослих", 3, "Підгузки для дорослих", 112 },
                    { 733, "Вологі серветки", 3, "Вологі серветки", 112 },
                    { 734, "Крем", 3, "Крем", 114 },
                    { 735, "Маска для обличчя", 3, "Маска для обличчя", 114 },
                    { 736, "Міцелярна вода", 3, "Міцелярна вода", 114 },
                    { 737, "Засіб для вмивання", 3, "Засіб для вмивання", 114 },
                    { 738, "Патчі", 3, "Патчі", 114 },
                    { 739, "Дезодоранти і антиперспіранти", 3, "Дезодоранти і антиперспіранти", 115 },
                    { 740, "Засоби для інтимної гігієни", 3, "Засоби для інтимної гігієни", 115 },
                    { 741, "Догляд за руками", 3, "Догляд за руками", 115 },
                    { 742, "Ефірні масла", 3, "Ефірні масла", 115 },
                    { 743, "Шампуні", 3, "Шампуні", 116 },
                    { 744, "Олія для волосся", 3, "Олія для волосся", 116 },
                    { 745, "Кондиціонери", 3, "Кондиціонери", 116 },
                    { 746, "Набори по догляду за волоссям", 3, "Набори по догляду за волоссям", 116 },
                    { 747, "Маски для волосся", 3, "Маски для волосся", 116 },
                    { 748, "Чоловіча парфумерія", 3, "Чоловіча парфумерія", 117 },
                    { 749, "Жіноча парфумерія", 3, "Жіноча парфумерія", 117 },
                    { 750, "Аромати для дому", 3, "Аромати для дому", 117 },
                    { 751, "Фарба для волосся", 3, "Фарба для волосся", 120 },
                    { 752, "Тонуючі засоби", 3, "Тонуючі засоби", 120 },
                    { 753, "Зубна паста", 3, "Зубна паста", 121 },
                    { 754, "Зубні щітки", 3, "Зубні щітки", 121 },
                    { 755, "Електричні зубні щітки і іррігатори", 3, "Електричні зубні щітки і іррігатори", 121 },
                    { 756, "Лак для нігтів", 3, "Лак для нігтів", 122 },
                    { 757, "Гель-лак", 3, "Гель-лак", 122 },
                    { 758, "Губна помада", 3, "Губна помада", 122 },
                    { 759, "Блиск для губ", 3, "Блиск для губ", 122 },
                    { 760, "Туш для вій", 3, "Туш для вій", 122 },
                    { 761, "Тіні для вій", 3, "Тіні для вій", 122 },
                    { 762, "Олівці для очей", 3, "Олівці для очей", 122 },
                    { 763, "Тональні засоби", 3, "Тональні засоби", 122 },
                    { 764, "Пудра", 3, "Пудра", 122 },
                    { 765, "Для манікюру", 3, "Для манікюру", 123 },
                    { 766, "Для макіяжу", 3, "Для макіяжу", 123 },
                    { 767, "Для волосся", 3, "Для волосся", 123 },
                    { 768, "Підгузки", 3, "Підгузки", 124 },
                    { 769, "Косметика для дітей", 3, "Косметика для дітей", 124 },
                    { 770, "Засоби для купання", 3, "Засоби для купання", 124 },
                    { 771, "Дитячі конструктори", 3, "Дитячі конструктори", 125 },
                    { 772, "Інтерактивні іграшки", 3, "Інтерактивні іграшки", 125 },
                    { 773, "Настільні ігри", 3, "Настільні ігри", 125 },
                    { 774, "Творчість", 3, "Творчість", 125 },
                    { 775, "Ігрові набори", 3, "Ігрові набори", 125 },
                    { 776, "Радіокеровані іграшки", 3, "Радіокеровані іграшки", 125 },
                    { 777, "Ляльки", 3, "Ляльки", 125 },
                    { 778, "Іграшки для малюків", 3, "Іграшки для малюків", 125 },
                    { 779, "М'які іграшки", 3, "М'які іграшки", 125 },
                    { 780, "Іграшкові машинки та техніка", 3, "Іграшкові машинки та техніка", 125 },
                    { 781, "Іграшкова зброя", 3, "Іграшкова зброя", 125 },
                    { 782, "Дитячі суміші", 3, "Дитячі суміші", 126 },
                    { 783, "Стільчики для годування", 3, "Стільчики для годування", 126 },
                    { 784, "Пляшечки для годування та аксесуари", 3, "Пляшечки для годування та аксесуари", 126 },
                    { 785, "Дитячі кухонні комбайни", 3, "Дитячі кухонні комбайни", 126 },
                    { 786, "Дитячі каші", 3, "Дитячі каші", 126 },
                    { 787, "Дитяче пюре", 3, "Дитяче пюре", 126 },
                    { 788, "Дитячий посуд", 3, "Дитячий посуд", 126 },
                    { 789, "Пустушки", 3, "Пустушки", 126 },
                    { 790, "Електротранспорт", 3, "Електротранспорт", 128 },
                    { 791, "Дитячі коляски", 3, "Дитячі коляски", 128 },
                    { 792, "Дитячі автокрісла", 3, "Дитячі автокрісла", 128 },
                    { 793, "Дитячі велосипеди", 3, "Дитячі велосипеди", 128 },
                    { 794, "Дитячі самокати", 3, "Дитячі самокати", 128 },
                    { 795, "Дивомобілі, ходунки, гойдалки", 3, "Дивомобілі, ходунки, гойдалки", 128 },
                    { 796, "Роликові ковзани", 3, "Роликові ковзани", 128 },
                    { 797, "Підгузки", 3, "Підгузки", 129 },
                    { 798, "Дитячі серветки, хусточки та рушники", 3, "Дитячі серветки, хусточки та рушники", 129 },
                    { 799, "Пелюшки", 3, "Пелюшки", 129 },
                    { 800, "Косметика для догляду для дітей", 3, "Косметика для догляду для дітей", 129 },
                    { 801, "Дитячі ванночки та аксесуари", 3, "Дитячі ванночки та аксесуари", 129 },
                    { 802, "Одяг для хлопчиків", 3, "Одяг для хлопчиків", 130 },
                    { 803, "Одяг для дівчаток", 3, "Одяг для дівчаток", 130 },
                    { 804, "Одяг для малюків", 3, "Одяг для малюків", 130 },
                    { 805, "Дитяче взуття", 3, "Дитяче взуття", 130 },
                    { 806, "Шкільні набори та ранці", 3, "Шкільні набори та ранці", 131 },
                    { 807, "Шкільні пенали", 3, "Шкільні пенали", 131 },
                    { 808, "Сумки для взуття", 3, "Сумки для взуття", 131 },
                    { 809, "Радіоняньки", 3, "Радіоняньки", 133 },
                    { 810, "Парти", 3, "Парти", 133 },
                    { 811, "Манежі", 3, "Манежі", 133 },
                    { 812, "Мобілі", 3, "Мобілі", 133 },
                    { 813, "Дитячі ліжечка", 3, "Дитячі ліжечка", 133 },
                    { 814, "Творчість", 3, "Творчість", 134 },
                    { 815, "Розвивальні іграшки", 3, "Розвивальні іграшки", 134 },
                    { 816, "Дитячі книги", 3, "Дитячі книги", 134 },
                    { 817, "Корми для кішок", 3, "Корми для кішок", 138 },
                    { 818, "Вологий корм для кішок", 3, "Вологий корм для кішок", 138 },
                    { 819, "Сухий корм для кішок", 3, "Сухий корм для кішок", 138 },
                    { 820, "Корма для кошенят", 3, "Корма для кошенят", 138 },
                    { 821, "Засоби для догляду та гігієни для кішок", 3, "Засоби для догляду та гігієни для кішок", 138 },
                    { 822, "Вітаміни та ласощі для кішок", 3, "Вітаміни та ласощі для кішок", 138 },
                    { 823, "Спальні місця та перенесення для кішок", 3, "Спальні місця та перенесення для кішок", 138 },
                    { 824, "Іграшки для котів", 3, "Іграшки для котів", 138 },
                    { 825, "Туалети для кішок", 3, "Туалети для кішок", 138 },
                    { 826, "Посуд для котів", 3, "Посуд для котів", 138 },
                    { 827, "Грумінг кішкам", 3, "Грумінг кішкам", 138 },
                    { 828, "Деревні", 3, "Деревні", 139 },
                    { 829, "Бентонітові", 3, "Бентонітові", 139 },
                    { 830, "Силікагелеві", 3, "Силікагелеві", 139 },
                    { 831, "Корм для птахів", 3, "Корм для птахів", 140 },
                    { 832, "Клітки для птахів", 3, "Клітки для птахів", 140 },
                    { 833, "Корм для гризунів", 3, "Корм для гризунів", 141 },
                    { 834, "Наповнювачі туалетів для гризунів", 3, "Наповнювачі туалетів для гризунів", 141 },
                    { 835, "Клітки для гризунів", 3, "Клітки для гризунів", 141 },
                    { 836, "Корми для собак", 3, "Корми для собак", 142 },
                    { 837, "Сухий корм для собак", 3, "Сухий корм для собак", 142 },
                    { 838, "Вологий корм для собак", 3, "Вологий корм для собак", 142 },
                    { 839, "Корма для цуценят", 3, "Корма для цуценят", 142 },
                    { 840, "Вітаміни та ласощі для собак", 3, "Вітаміни та ласощі для собак", 142 },
                    { 841, "Засоби для догляду та гігієни для собак", 3, "Засоби для догляду та гігієни для собак", 142 },
                    { 842, "Посуд для тварин", 3, "Посуд для тварин", 142 },
                    { 843, "Одяг для собак", 3, "Одяг для собак", 142 },
                    { 844, "Нашийники для собак", 3, "Нашийники для собак", 142 },
                    { 845, "Повідці для собак", 3, "Повідці для собак", 142 },
                    { 846, "Спальні місця та переноски", 3, "Спальні місця та переноски", 142 },
                    { 847, "Іграшки для собак", 3, "Іграшки для собак", 142 },
                    { 848, "Засоби від бліх та кліщів", 3, "Засоби від бліх та кліщів", 143 },
                    { 849, "Засоби проти глистів", 3, "Засоби проти глистів", 143 },
                    { 850, "Протигрибкові засоби", 3, "Протигрибкові засоби", 143 },
                    { 851, "Нашийники від бліх", 3, "Нашийники від бліх", 143 },
                    { 852, "Краплі та таблетки від паразитів", 3, "Краплі та таблетки від паразитів", 143 },
                    { 853, "Засоби для обробки приміщень", 3, "Засоби для обробки приміщень", 143 },
                    { 854, "Засоби від неприємного запаху", 3, "Засоби від неприємного запаху", 143 },
                    { 855, "Для привчання до туалету", 3, "Для привчання до туалету", 143 },
                    { 856, "Корми для риб", 3, "Корми для риб", 144 },
                    { 857, "Фільтри", 3, "Фільтри", 144 },
                    { 858, "Компресори та помпи", 3, "Компресори та помпи", 144 },
                    { 859, "Освітлення", 3, "Освітлення", 144 },
                    { 860, "Декорації", 3, "Декорації", 144 },
                    { 861, "Корм для рептилій", 3, "Корм для рептилій", 145 },
                    { 862, "Освітлення", 3, "Освітлення", 145 },
                    { 863, "Фаунаріуми", 3, "Фаунаріуми", 145 },
                    { 864, "Папір офісний", 3, "Папір офісний", 148 },
                    { 865, "Ручки", 3, "Ручки", 148 },
                    { 866, "Щоденники, планінги, алфавітні книги", 3, "Щоденники, планінги, алфавітні книги", 148 },
                    { 867, "Папки-реєстратори", 3, "Папки-реєстратори", 148 },
                    { 868, "Циркулі та готувальнички", 3, "Циркулі та готувальнички", 148 },
                    { 869, "Блокноти, зошити офісні", 3, "Блокноти, зошити офісні", 148 },
                    { 870, "Олівці", 3, "Олівці", 148 },
                    { 871, "Файли", 3, "Файли", 148 },
                    { 872, "Клей", 3, "Клей", 148 },
                    { 873, "Коректори", 3, "Коректори", 148 },
                    { 874, "Лотки для паперів", 3, "Лотки для паперів", 148 },
                    { 875, "Маркери", 3, "Маркери", 148 },
                    { 876, "Папір для нотаток, стикери", 3, "Папір для нотаток, стикери", 148 },
                    { 877, "Гумки", 3, "Гумки", 148 },
                    { 878, "Степлери, скоби, антистеплери", 3, "Степлери, скоби, антистеплери", 148 },
                    { 879, "Клейкі стрічки та скотчі", 3, "Клейкі стрічки та скотчі", 148 },
                    { 880, "Конверти", 3, "Конверти", 148 },
                    { 881, "Папки з файлами", 3, "Папки з файлами", 148 },
                    { 882, "Папір для фліпчартів", 3, "Папір для фліпчартів", 148 },
                    { 883, "Стрижні, грифелі, чорнило", 3, "Стрижні, грифелі, чорнило", 148 },
                    { 884, "Лупи", 3, "Лупи", 148 },
                    { 885, "Шкільні набори та ранці", 3, "Шкільні набори та ранці", 149 },
                    { 886, "Зошити учнівські", 3, "Зошити учнівські", 149 },
                    { 887, "Пенали шкільні", 3, "Пенали шкільні", 149 },
                    { 888, "Обкладинки для зошитів і підручників", 3, "Обкладинки для зошитів і підручників", 149 },
                    { 889, "Сумки шкільні", 3, "Сумки шкільні", 149 },
                    { 890, "Бутербродниці (ланч-бокси)", 3, "Бутербродниці (ланч-бокси)", 149 },
                    { 891, "Контурні мапи та атласи", 3, "Контурні мапи та атласи", 149 },
                    { 892, "Лінійки, транспортири, косинці", 3, "Лінійки, транспортири, косинці", 149 },
                    { 893, "Ножиці шкільні", 3, "Ножиці шкільні", 149 },
                    { 894, "Калькулятори", 3, "Калькулятори", 150 },
                    { 895, "Папки пластикові", 3, "Папки пластикові", 150 },
                    { 896, "Самонабірні штампи", 3, "Самонабірні штампи", 150 },
                    { 897, "Настільні набори", 3, "Настільні набори", 150 },
                    { 898, "Діркопробивачі", 3, "Діркопробивачі", 150 },
                    { 899, "Бейджі, брелоки-ідентифікатори, настільні таблички", 3, "Бейджі, брелоки-ідентифікатори, настільні таблички", 150 },
                    { 900, "Папки-портфелі, папки-бокси", 3, "Папки-портфелі, папки-бокси", 150 },
                    { 901, "Друк візиток", 3, "Друк візиток", 150 },
                    { 902, "Художня література", 3, "Художня література", 152 },
                    { 903, "Дитячі книги", 3, "Дитячі книги", 152 },
                    { 904, "Книги для бізнесу", 3, "Книги для бізнесу", 152 },
                    { 905, "Підручники. Науково-методична література", 3, "Підручники. Науково-методична література", 152 },
                    { 906, "Релігія. Езотерика", 3, "Релігія. Езотерика", 152 },
                    { 907, "Словники. Довідники. Енциклопедії", 3, "Словники. Довідники. Енциклопедії", 152 },
                    { 908, "Книги для батьків", 3, "Книги для батьків", 152 },
                    { 909, "Кольорові олівці", 3, "Кольорові олівці", 152 },
                    { 910, "Фарби", 3, "Фарби", 152 },
                    { 911, "Кольоровий папір і картон", 3, "Кольоровий папір і картон", 152 },
                    { 912, "Альбоми для малювання", 3, "Альбоми для малювання", 152 },
                    { 913, "Пластилін", 3, "Пластилін", 152 },
                    { 914, "Фломастери", 3, "Фломастери", 152 },
                    { 915, "Пензлі", 3, "Пензлі", 152 },
                    { 916, "Мольберти, етюдники, палітри", 3, "Мольберти, етюдники, палітри", 152 },
                    { 917, "Головоломки, антистреси", 3, "Головоломки, антистреси", 154 },
                    { 918, "Вино - Червоне", 3, "Червоне", 155 },
                    { 919, "Вино - Біле", 3, "Біле", 155 },
                    { 920, "Вино - Рожеве", 3, "Рожеве", 155 },
                    { 921, "Вино - Сухе вино", 3, "Сухе вино", 155 },
                    { 922, "Вино - Напівсолодке вино", 3, "Напівсолодке вино", 155 },
                    { 923, "Вино - Напівсухе вино", 3, "Напівсухе вино", 155 },
                    { 924, "Вино - Десертне", 3, "Десертне", 155 },
                    { 925, "Вино - Ігристе шампанське", 3, "Ігристе шампанське", 155 },
                    { 926, "Лікери, вермути, сиропи - Лікери", 3, "Лікери", 156 },
                    { 927, "Лікери, вермути, сиропи - Вермути", 3, "Вермути", 156 },
                    { 928, "Лікери, вермути, сиропи - Сиропи", 3, "Сиропи", 156 },
                    { 929, "Лікери, вермути, сиропи - Набори", 3, "Набори", 156 },
                    { 930, "Посуд - Келихи та фужери", 3, "Келихи та фужери", 159 },
                    { 931, "Посуд - Стопки та чарки", 3, "Стопки та чарки", 159 },
                    { 932, "Міцні напої - Віскі бленд", 3, "Віскі бленд", 160 },
                    { 933, "Міцні напої - Віскі бурбон", 3, "Віскі бурбон", 160 },
                    { 934, "Міцні напої - Коньяк", 3, "Коньяк", 160 },
                    { 935, "Міцні напої - Віскі односолодовий", 3, "Віскі односолодовий", 160 },
                    { 936, "Міцні напої - Горілка", 3, "Горілка", 160 },
                    { 937, "Міцні напої - Ром", 3, "Ром", 160 },
                    { 938, "Міцні напої - Абсент", 3, "Абсент", 160 },
                    { 939, "Міцні напої - Текіла", 3, "Текіла", 160 },
                    { 940, "Міцні напої - Арманьяк", 3, "Арманьяк", 160 },
                    { 941, "Міцні напої - Бренді", 3, "Бренді", 160 },
                    { 942, "Міцні напої - Чача", 3, "Чача", 160 },
                    { 943, "Міцні напої - Джин", 3, "Джин", 160 },
                    { 944, "Міцні напої - Кальвадос", 3, "Кальвадос", 160 },
                    { 945, "Міцні напої - Бітер", 3, "Бітер", 160 },
                    { 946, "Міцні напої - Грапа", 3, "Грапа", 160 },
                    { 947, "Міцні напої - Саке", 3, "Саке", 160 },
                    { 948, "Електронні сигарети та аксесуари - Електронні сигарети, батарейні моди, атомайзери", 3, "Електронні сигарети, батарейні моди, атомайзери", 161 },
                    { 949, "Електронні сигарети та аксесуари - Комплектовання та аксесуари для електронних сигарет", 3, "Комплектовання та аксесуари для електронних сигарет", 161 },
                    { 950, "Електронні сигарети та аксесуари - Рідини для електронних сигарет", 3, "Рідини для електронних сигарет", 161 },
                    { 951, "Електронні сигарети та аксесуари - Компоненти для рідин", 3, "Компоненти для рідин", 161 },
                    { 952, "Продукти - Шоколад та цукерки", 3, "Шоколад та цукерки", 162 },
                    { 953, "Продукти - Кава", 3, "Кава", 162 },
                    { 954, "Продукти - Чай", 3, "Чай", 162 },
                    { 955, "Продукти - Рибні консерви", 3, "Рибні консерви", 162 },
                    { 956, "Продукти - Вода, соки, напої", 3, "Вода, соки, напої", 162 },
                    { 957, "Продукти - Олія", 3, "Олія", 162 },
                    { 958, "Продукти - Соуси", 3, "Соуси", 162 },
                    { 959, "Продукти - Макаронні вироби", 3, "Макаронні вироби", 162 },
                    { 960, "Продукти - Драже, льодяники, пастилки", 3, "Драже, льодяники, пастилки", 162 },
                    { 961, "Продукти - Батончики", 3, "Батончики", 162 },
                    { 962, "Продукти - Оливки", 3, "Оливки", 162 },
                    { 963, "Продукти - Снеки", 3, "Снеки", 162 },
                    { 964, "Продукти - Жувальна гумка", 3, "Жувальна гумка", 162 },
                    { 965, "Продукти - Джем і варення", 3, "Джем і варення", 162 },
                    { 966, "Продукти - Оцет", 3, "Оцет", 162 },
                    { 967, "Продукти - Приправи та спеції", 3, "Приправи та спеції", 162 },
                    { 968, "Продукти - Продукти для суші", 3, "Продукти для суші", 162 },
                    { 969, "Продукти - Сухі сніданки", 3, "Сухі сніданки", 162 },
                    { 970, "Продукти - Дитяче харчування", 3, "Дитяче харчування", 162 },
                    { 971, "Продукти - Крупи", 3, "Крупи", 162 },
                    { 972, "Продукти - Овочева консервація", 3, "Овочева консервація", 162 },
                    { 973, "Продукти - Сиропи та топінги", 3, "Сиропи та топінги", 162 },
                    { 974, "Продукти - Фруктова консервація", 3, "Фруктова консервація", 162 },
                    { 975, "Продукти - Слабоалкогольні напої", 3, "Слабоалкогольні напої", 162 },
                    { 976, "Продукти - Хлібці та галети", 3, "Хлібці та галети", 162 },
                    { 977, "Засоби для прання - Пральні засоби", 3, "Пральні засоби", 163 },
                    { 978, "Засоби для прання - Кондиціонери для білизни", 3, "Кондиціонери для білизни", 163 },
                    { 979, "Засоби для прання - Плямовивідники і відбілювачі", 3, "Плямовивідники і відбілювачі", 163 },
                    { 980, "Засоби для догляду за будинком - Засоби для кухні", 3, "Засоби для кухні", 164 },
                    { 981, "Засоби для догляду за будинком - Догляд за побутовою технікою", 3, "Догляд за побутовою технікою", 164 },
                    { 982, "Засоби для догляду за будинком - Засоби для миття підлог", 3, "Засоби для миття підлог", 164 },
                    { 983, "Засоби для догляду за будинком - Засоби для миття вікон", 3, "Засоби для миття вікон", 164 },
                    { 984, "Засоби для догляду за будинком - Прибирання після ремонту", 3, "Прибирання після ремонту", 164 },
                    { 985, "Засоби для догляду за ванною та туалетом - Для ванної", 3, "Для ванної", 165 },
                    { 986, "Засоби для догляду за ванною та туалетом - Для туалету", 3, "Для туалету", 165 },
                    { 987, "Засоби для догляду за ванною та туалетом - Туалетні блоки", 3, "Туалетні блоки", 165 },
                    { 988, "Засоби для догляду за ванною та туалетом - Освіжувачі повітря", 3, "Освіжувачі повітря", 165 },
                    { 989, "Засоби для миття посуду - Засоби для посудомийних машин", 3, "Засоби для посудомийних машин", 166 },
                    { 990, "Засоби для миття посуду - Мийні засоби", 3, "Мийні засоби", 166 },
                    { 991, "Засоби для миття посуду - Догляд за посудомийними машинами", 3, "Догляд за посудомийними машинами", 166 },
                    { 992, "Господарські товари - Туалетний папір", 3, "Туалетний папір", 167 },
                    { 993, "Господарські товари - Паперові рушники", 3, "Паперові рушники", 167 },
                    { 994, "Господарські товари - Серветки", 3, "Серветки", 167 },
                    { 995, "Господарські товари - Харчова упаковка", 3, "Харчова упаковка", 167 },
                    { 996, "Господарські товари - Пакети для сміття", 3, "Пакети для сміття", 167 },
                    { 997, "Вулична зона - Засоби від комах", 3, "Засоби від комах", 168 },
                    { 998, "Вулична зона - Отрута для гризунів", 3, "Отрута для гризунів", 168 },
                    { 999, "Вулична зона - Засоби для вигрібних ям та септиків", 3, "Засоби для вигрібних ям та септиків", 168 },
                    { 1000, "Вулична зона - Хімія для басейнів і систем опалення", 3, "Хімія для басейнів і систем опалення", 168 },
                    { 1001, "Екологічні та органічні засоби - Засоби для прання", 3, "Засоби для прання", 169 },
                    { 1002, "Екологічні та органічні засоби - Засоби для миття посуду", 3, "Засоби для миття посуду", 169 },
                    { 1003, "Екологічні та органічні засоби - Засоби для прибирання", 3, "Засоби для прибирання", 169 }
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
                    { "07803623-fd20-4556-9940-dbbae345b349", "227171ad-77ce-47c1-8b31-51246267989a" },
                    { "aaf9d35b-6a43-4eca-8cda-373087196770", "e9a6c982-c312-4bad-a79a-4add2444aa12" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "AppUserId", "CompanyId", "Email", "FullName", "HasNoWebsite", "IsNonResident", "PhoneNumber", "Position", "Website" },
                values: new object[] { 1, "e9a6c982-c312-4bad-a79a-4add2444aa12", 1, "TEST", "TEST", false, false, "TEST", "TEST", "TEST" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryProductId", "CountryProductionId", "CreatedAt", "Description", "HasDiscount", "ImageURL", "Name", "Price", "ShopId", "Stars", "Stock" },
                values: new object[] { 1, 1, 1, 1, new DateTime(2024, 9, 7, 9, 16, 47, 923, DateTimeKind.Utc).AddTicks(6702), "Test", false, "noimage.webp", "Test", 1m, 1, 0m, 1 });

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
                name: "IX_Settlements_AreaId",
                table: "Settlements",
                column: "AreaId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_SettlementId",
                table: "Warehouses",
                column: "SettlementId");
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
                name: "Warehouses");

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
                name: "Settlements");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Areas");

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
