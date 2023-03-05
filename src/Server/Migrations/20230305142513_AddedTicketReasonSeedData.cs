using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CanidateApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedTicketReasonSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "TicketReasons",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Tower connection is failing." },
                    { 2, "Tower has trouble lasting through 4-hour loadshedding." },
                    { 3, "Tower has trouble lasting through 2-hour loadshedding." },
                    { 4, "Tower connection is slow." },
                    { 5, "Tower connection is unstable." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
