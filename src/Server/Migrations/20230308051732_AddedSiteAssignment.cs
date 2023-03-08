using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanidateApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddedSiteAssignment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SiteAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Contractor = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAssignments", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reason",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Reason",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Reason",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 5,
                column: "Reason",
                value: 5);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 6,
                column: "Reason",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteAssignments");

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 1,
                column: "Reason",
                value: 0);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 2,
                column: "Reason",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 3,
                column: "Reason",
                value: 2);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 4,
                column: "Reason",
                value: 3);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 5,
                column: "Reason",
                value: 4);

            migrationBuilder.UpdateData(
                table: "TicketReasons",
                keyColumn: "Id",
                keyValue: 6,
                column: "Reason",
                value: 5);
        }
    }
}
