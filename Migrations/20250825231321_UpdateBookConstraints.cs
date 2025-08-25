using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBookConstraints : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8289), new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8442) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8556), new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8556) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8559), new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8559) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8561), new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8562) });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8564), new DateTime(2025, 8, 25, 22, 17, 40, 814, DateTimeKind.Utc).AddTicks(8564) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1681), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1761) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1846), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1847) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1852), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1853) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1872), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1873) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1878), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(1878) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7651), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7651) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8151), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8151) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8153), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8155), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8155) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8156), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8157) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8168), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(8168) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(6825), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(6920) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7008), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7009) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7012), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7012) });

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7014), new DateTime(2025, 8, 25, 22, 17, 40, 815, DateTimeKind.Utc).AddTicks(7014) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(8835), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(8926) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9004), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9004) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9006), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9007) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9008), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9009) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9011), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9011) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9013), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9013) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9015), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9017), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9017) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9052), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9052) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9054), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9054) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9056), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9056) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9058), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9059) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9264), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9265) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9267), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9267) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9269), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9269) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9271), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9273), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9275), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9278), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9278) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9280), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9280) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9282), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9284), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9288), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9290), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9310), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9312), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9314), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9315) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9316), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9317) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9319), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9319) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9320), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9323), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9323) });

            migrationBuilder.UpdateData(
                table: "QuestionOptions",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9325), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7088), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7262), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7263) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7265), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7266) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7268), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7269) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7271), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7271) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7599), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7600) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7602), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7603) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7605), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7605) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7608), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7608) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7610), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7611) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7718), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7719) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7751), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7752) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7754), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7755) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7760), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7760) });

            migrationBuilder.UpdateData(
                table: "QuizQuestions",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7762), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(7762) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5222), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5325) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5424), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5425) });

            migrationBuilder.UpdateData(
                table: "Quizzes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5429), new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(5429) });

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2896));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2898));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2899));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2900));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2901));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2902));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 9,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "SystemSettings",
                keyColumn: "Id",
                keyValue: 10,
                column: "UpdatedAt",
                value: new DateTime(2025, 8, 25, 22, 17, 40, 816, DateTimeKind.Utc).AddTicks(2904));
        }
    }
}
