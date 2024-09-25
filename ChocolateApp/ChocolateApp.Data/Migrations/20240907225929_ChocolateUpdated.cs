using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ChocolateApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChocolateUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Chocolates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    CocoaPercentage = table.Column<double>(type: "REAL", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Brand = table.Column<string>(type: "TEXT", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StockQuantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Ingredients = table.Column<string>(type: "TEXT", nullable: true),
                    NutritionalInformation = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "getdate()"),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chocolates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChocolateId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Chocolates_ChocolateId",
                        column: x => x.ChocolateId,
                        principalTable: "Chocolates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChocolateCategories",
                columns: table => new
                {
                    ChocolateId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChocolateCategories", x => new { x.ChocolateId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ChocolateCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChocolateCategories_Chocolates_ChocolateId",
                        column: x => x.ChocolateId,
                        principalTable: "Chocolates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    chocolateId = table.Column<int>(type: "INTEGER", nullable: true),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Chocolates_chocolateId",
                        column: x => x.chocolateId,
                        principalTable: "Chocolates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sütlü çikolata kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sütlü Çikolata" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bitter çikolata kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bitter Çikolata" },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beyaz çikolata kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Beyaz Çikolata" },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organik çikolata kategorisi", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vegan Çikolata" }
                });

            migrationBuilder.InsertData(
                table: "Chocolates",
                columns: new[] { "Id", "Brand", "Category", "CocoaPercentage", "CreatedDate", "Description", "ExpirationDate", "ImageUrl", "Ingredients", "IsActive", "ModifiedDate", "Name", "NutritionalInformation", "Price", "StockQuantity", "Weight" },
                values: new object[,]
                {
                    { 1, "ChocoDelight", "Sütlü Çikolata", 30.0, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4291), "Klasik sütlü çikolata, yumuşak ve kremsi.", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/Chocolates/1.jpg", "Kakao Yağı, Süt Tozu, Şeker", true, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4292), "Sütlü Çikolata", "Kalori: 540, Yağ: 30g, Şeker: 50g", 15.00m, 50, 100.0 },
                    { 2, "DarkEssence", "Bitter Çikolata", 70.0, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4295), "Yüksek kakao oranına sahip bitter çikolata.", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/Chocolates/2.jpg", "Kakao Kitlesi, Şeker, Kakao Yağı", true, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4296), "Bitter Çikolata", "Kalori: 500, Yağ: 35g, Şeker: 20g", 18.00m, 40, 100.0 },
                    { 3, "SweetBliss", "Beyaz Çikolata", 20.0, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4299), "Kremamsı ve tatlı beyaz çikolata.", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/Chocolates/3.jpg", "Süt Tozu, Kakao Yağı, Şeker", true, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4300), "Beyaz Çikolata", "Kalori: 550, Yağ: 32g, Şeker: 55g", 16.00m, 60, 100.0 },
                    { 4, "OrganicTreats", "Organik Çikolata", 50.0, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4303), "Organik kakao ile üretilmiş çikolata.", new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "images/Chocolates/4.jpg", "Organik Kakao Kitlesi, Organik Şeker, Organik Kakao Yağı", true, new DateTime(2024, 9, 8, 1, 59, 29, 98, DateTimeKind.Local).AddTicks(4304), "Organik Çikolata", "Kalori: 520, Yağ: 28g, Şeker: 22g", 20.00m, 30, 100.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ChocolateId",
                table: "CartItems",
                column: "ChocolateId");

            migrationBuilder.CreateIndex(
                name: "IX_ChocolateCategories_CategoryId",
                table: "ChocolateCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_chocolateId",
                table: "OrderItems",
                column: "chocolateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "ChocolateCategories");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Chocolates");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
