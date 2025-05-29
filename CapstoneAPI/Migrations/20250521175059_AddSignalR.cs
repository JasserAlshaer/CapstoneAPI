using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddSignalR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SignalRConnectionId",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(9179));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(9214));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8748));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8749));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8750));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8751));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8752));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8753));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8754));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8755));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8756));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8757));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8620));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8621));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 20, 50, 58, 822, DateTimeKind.Local).AddTicks(8622));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SignalRConnectionId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(960));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(109));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(111));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(112));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(106));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(113));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(114));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(115));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(116));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(117));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(118));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(119));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(120));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(121));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 185, DateTimeKind.Local).AddTicks(9931));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 185, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 185, DateTimeKind.Local).AddTicks(9959));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 185, DateTimeKind.Local).AddTicks(9960));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 185, DateTimeKind.Local).AddTicks(9961));
        }
    }
}
