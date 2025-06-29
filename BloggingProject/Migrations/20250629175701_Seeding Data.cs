using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloggingProject.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "", "Technology" },
                    { 2, "", "Anime" },
                    { 3, "", "Football" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Author", "CategoryId", "Content", "PublishedDate", "Title", "imagePath" },
                values: new object[,]
                {
                    { 1, "John Doe", 1, "Content of Technology Post One", new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Technology Title Post One", "tech_image.jpg" },
                    { 2, "Jane Doe", 2, "Content of Anime Post Two", new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Anime Title Post Two", "anime_image.jpg" },
                    { 3, "Jonathan Doe", 3, "Content of Football Post Three", new DateTime(2025, 6, 29, 0, 0, 0, 0, DateTimeKind.Utc), "Football Title Post Three", "football_image.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);
        }
    }
}
