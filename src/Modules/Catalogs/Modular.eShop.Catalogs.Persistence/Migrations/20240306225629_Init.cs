using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modular.eShop.Catalogs.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Catalog");

            migrationBuilder.CreateTable(
                name: "ProductBrands",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductBrands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                schema: "Catalog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    ProductBrandId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_ProductBrands_ProductBrandId",
                        column: x => x.ProductBrandId,
                        principalSchema: "Catalog",
                        principalTable: "ProductBrands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalSchema: "Catalog",
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductBrandId",
                schema: "Catalog",
                table: "Products",
                column: "ProductBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                schema: "Catalog",
                table: "Products",
                column: "ProductTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductBrands",
                schema: "Catalog");

            migrationBuilder.DropTable(
                name: "ProductTypes",
                schema: "Catalog");
        }
    }
}
