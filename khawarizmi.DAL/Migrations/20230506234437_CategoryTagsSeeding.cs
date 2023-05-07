using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace khawarizmi.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTagsSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CategoryTag",
                columns: new[] { "CategoriesId", "TagsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 3, 37 },
                    { 3, 38 },
                    { 3, 39 },
                    { 3, 40 },
                    { 3, 41 },
                    { 3, 42 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 5, 1 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 15 },
                    { 5, 26 },
                    { 5, 27 },
                    { 5, 28 },
                    { 5, 29 },
                    { 5, 30 },
                    { 5, 31 },
                    { 6, 32 },
                    { 6, 33 },
                    { 6, 34 },
                    { 6, 35 },
                    { 6, 36 },
                    { 7, 43 },
                    { 7, 44 },
                    { 7, 45 },
                    { 8, 46 },
                    { 8, 47 },
                    { 8, 48 },
                    { 8, 49 },
                    { 8, 50 },
                    { 9, 51 },
                    { 9, 52 },
                    { 9, 53 },
                    { 9, 54 },
                    { 9, 55 },
                    { 9, 56 },
                    { 9, 57 },
                    { 9, 58 },
                    { 10, 59 },
                    { 10, 60 },
                    { 10, 61 },
                    { 10, 62 },
                    { 10, 63 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 19 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 21 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 22 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 23 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 24 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 3, 37 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 3, 38 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 3, 39 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 3, 40 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 3, 41 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 3, 42 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 9 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 27 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 28 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 29 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 30 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 5, 31 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 6, 32 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 6, 33 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 6, 34 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 6, 35 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 6, 36 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 7, 43 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 7, 44 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 7, 45 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 8, 46 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 8, 47 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 8, 48 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 8, 49 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 8, 50 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 51 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 52 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 53 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 54 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 55 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 56 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 57 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 9, 58 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 10, 59 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 10, 60 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 10, 61 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 10, 62 });

            migrationBuilder.DeleteData(
                table: "CategoryTag",
                keyColumns: new[] { "CategoriesId", "TagsId" },
                keyValues: new object[] { 10, 63 });
        }
    }
}
