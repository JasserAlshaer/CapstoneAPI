using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class Correction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Otpexpiry",
                table: "Clients",
                newName: "OTPExipry");

            migrationBuilder.RenameColumn(
                name: "Otp",
                table: "Clients",
                newName: "OTPCode");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsLoggedIn",
                table: "Clients",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginTime",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationDate", "Image", "IsLoggedIn", "LastLoginTime" },
                values: new object[] { new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8792), null, null, null });

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8474));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8475));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8476));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8472));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8477));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8478));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8480));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8481));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8384));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8395));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 22, 41, 34, 503, DateTimeKind.Local).AddTicks(8396));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "IsLoggedIn",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastLoginTime",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "OTPExipry",
                table: "Clients",
                newName: "Otpexpiry");

            migrationBuilder.RenameColumn(
                name: "OTPCode",
                table: "Clients",
                newName: "Otp");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1754));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1114));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1111));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1115));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1117));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1118));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1119));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1120));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1006));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 15, 21, 42, 20, 296, DateTimeKind.Local).AddTicks(1020));
        }
    }
}
