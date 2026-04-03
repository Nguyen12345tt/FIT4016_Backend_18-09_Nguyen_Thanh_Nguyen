using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Sku = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerEmail = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "CreatedAt", "Description", "Name", "Price", "Sku", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "General", new DateTime(2026, 1, 21, 16, 12, 13, 5, DateTimeKind.Local).AddTicks(8019), null, "Product 1", 100m, "SKU-001", 100, null },
                    { 2, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4250), null, "Product 2", 200m, "SKU-002", 100, null },
                    { 3, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4376), null, "Product 3", 300m, "SKU-003", 100, null },
                    { 4, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4393), null, "Product 4", 400m, "SKU-004", 100, null },
                    { 5, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4407), null, "Product 5", 500m, "SKU-005", 100, null },
                    { 6, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4428), null, "Product 6", 600m, "SKU-006", 100, null },
                    { 7, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4442), null, "Product 7", 700m, "SKU-007", 100, null },
                    { 8, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4456), null, "Product 8", 800m, "SKU-008", 100, null },
                    { 9, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4470), null, "Product 9", 900m, "SKU-009", 100, null },
                    { 10, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4503), null, "Product 10", 1000m, "SKU-010", 100, null },
                    { 11, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4518), null, "Product 11", 1100m, "SKU-011", 100, null },
                    { 12, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4539), null, "Product 12", 1200m, "SKU-012", 100, null },
                    { 13, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4554), null, "Product 13", 1300m, "SKU-013", 100, null },
                    { 14, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4570), null, "Product 14", 1400m, "SKU-014", 100, null },
                    { 15, "General", new DateTime(2026, 1, 21, 16, 12, 13, 6, DateTimeKind.Local).AddTicks(4587), null, "Product 15", 1500m, "SKU-015", 100, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerEmail",
                table: "Orders",
                column: "CustomerEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderNumber",
                table: "Orders",
                column: "OrderNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Sku",
                table: "Products",
                column: "Sku",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
