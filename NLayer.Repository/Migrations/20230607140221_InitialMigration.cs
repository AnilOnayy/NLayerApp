using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NLayer.Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductFeatureId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6290), "Kalemler", null },
                    { 2, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6309), "Kitaplar", null },
                    { 3, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6310), "Defterler", null }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "ProductFeatureId", "Stock", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6890), "Faber Castell 0.7 Uçlu Kalem", 100m, 0, 30, null },
                    { 2, 1, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6893), "Faber Castell 0.9 Uçlu Kalem", 120m, 0, 40, null },
                    { 3, 2, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6895), "Kürk Mantolu Madonna", 170m, 0, 30, null },
                    { 4, 2, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6896), "Nietzsche Ağladığında", 80m, 0, 10, null },
                    { 5, 3, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6903), "Kareli 90 yaprak defter", 30m, 0, 100, null },
                    { 6, 3, new DateTime(2023, 6, 7, 17, 2, 21, 791, DateTimeKind.Local).AddTicks(6906), "180 yaprak düz defter", 80m, 0, 40, null }
                });

            migrationBuilder.InsertData(
                table: "ProductFeatures",
                columns: new[] { "Id", "Color", "Height", "ProductId", "Width" },
                values: new object[,]
                {
                    { 1, "Kırmızı", 30, 1, 50 },
                    { 2, "Yeşil", 30, 2, 50 },
                    { 3, "Sarı", 30, 3, 50 },
                    { 4, "Mavi", 30, 4, 50 },
                    { 5, "Turuncu", 30, 5, 50 },
                    { 6, "Mor", 30, 6, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
