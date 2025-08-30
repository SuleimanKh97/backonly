using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LibraryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddProductTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TitleArabic = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SKU = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DescriptionArabic = table.Column<string>(type: "text", nullable: true),
                    ProductType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Book"),
                    AuthorId = table.Column<int>(type: "integer", nullable: true),
                    PublisherId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: true),
                    Grade = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PublicationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Pages = table.Column<int>(type: "integer", nullable: true),
                    Language = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false, defaultValue: "Arabic"),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    OriginalPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    StockQuantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CoverImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    IsNewRelease = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Rating = table.Column<decimal>(type: "numeric(3,2)", nullable: false, defaultValue: 0.0m),
                    RatingCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    ViewCount = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    ImageType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "Gallery"),
                    DisplayOrder = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2051), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2223), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2224) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2226), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2226) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2228), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2228) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2230), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(2230) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(5912), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(5993) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6098), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6098) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6104), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6104) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6109), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6109) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6123) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(468), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(469) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(964), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(964) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(967), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(967) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(969), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(969) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(970), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(970) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(971), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(972) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9599), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9689) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9770), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9773), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9773) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9775), new DateTime(2025, 8, 30, 12, 52, 42, 906, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1862), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1943) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2018), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2019) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2021), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2021) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2023), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2023) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2025), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2025) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2027), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2027) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2029), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2030) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2031), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2032) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2033), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2034) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2035), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2036) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2037), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2038) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2039), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2040) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2125), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2138), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2138) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2140), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2142), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2142) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2144), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2144) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2146), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2147) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2148), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2149) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2150), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2151) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2152), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2153) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2154), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2155) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2156), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2157) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2158), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2159) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2177), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2177) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2179), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2180) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2181), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2182) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2183), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2184) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2185), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2186) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2187), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2188) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2189), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2190) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2191), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(2192) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(693), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(778) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(857), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(871), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(872) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(874), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(874) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(876), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(877) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1048), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1049) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1051), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1052) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1054), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1054) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1056), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1059), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1059) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1061), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1061) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1082), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1082) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1084), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1087), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1087) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1089), new DateTime(2025, 8, 30, 12, 52, 42, 908, DateTimeKind.Utc).AddTicks(1100) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(9127), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(9206) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(9284), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(9288), new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(6695));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7039));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7040));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7041));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7042));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7043));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7044));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7045));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7046));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 30, 12, 52, 42, 907, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_AuthorId",
                table: "Products",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsAvailable",
                table: "Products",
                column: "IsAvailable");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsFeatured",
                table: "Products",
                column: "IsFeatured");

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsNewRelease",
                table: "Products",
                column: "IsNewRelease");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductType",
                table: "Products",
                column: "ProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PublisherId",
                table: "Products",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SKU",
                table: "Products",
                column: "SKU",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Title",
                table: "Products",
                column: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6383), new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6531) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6669), new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6669) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6672), new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6673) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6675), new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6676) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6680), new DateTime(2025, 8, 25, 23, 13, 20, 4, DateTimeKind.Utc).AddTicks(6681) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7053), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7542), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7542) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7550), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7551) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7557), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7557) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7562), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(7562) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(1684), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(1686) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2461), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2463) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2466), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2466) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2468), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2468) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2469), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2470) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2471), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(2471) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(208), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(412) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(566), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(569) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(571), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(574), new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(574) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7265), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7521), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7522) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7524), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7525) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7527), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7527) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7530), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7530) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7532), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7533) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7535), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7535) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7537), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7538) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7540), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7540) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7542), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7543) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7545), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7545) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7547), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7547) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7823), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7826), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7851), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7852) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7854), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7854) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7856), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7857) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7859), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7860) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7862), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7862) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7865), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7865) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7867), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7868) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7870), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7870) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7872), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7872) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7875), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7875) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7900), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7901) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7903), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7904) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7906), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7906) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7909), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7909) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7911), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7912) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7914), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7914) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7916), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7917) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7919), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5612), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5723) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5842), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5842) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5877), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5878) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5881), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5881) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5885), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(5886) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6064), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6065) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6068), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6068) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6071), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6071) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6074), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6074) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6077), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6077) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6080), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6080) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6106), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6114), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6117), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6117) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6120), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(6121) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(3269), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(3402) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(3523), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(3524) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(3527), new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(3528) });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 6, DateTimeKind.Utc).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(72));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(74));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 23, 13, 20, 7, DateTimeKind.Utc).AddTicks(82));
        }
    }
}
