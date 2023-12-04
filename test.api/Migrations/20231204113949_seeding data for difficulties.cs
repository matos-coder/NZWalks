using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test.api.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatafordifficulties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0dad2a68-a6a4-4fa3-b8e8-c569574755d4"), "Medium" },
                    { new Guid("7fc7a14d-7f58-4d2c-b8a8-d6a32ab24b20"), "Easy" },
                    { new Guid("a70bad79-5326-4f14-ad02-6e557855281f"), "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0dad2a68-a6a4-4fa3-b8e8-c569574755d4"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("7fc7a14d-7f58-4d2c-b8a8-d6a32ab24b20"));

            migrationBuilder.DeleteData(
                table: "difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a70bad79-5326-4f14-ad02-6e557855281f"));
        }
    }
}
