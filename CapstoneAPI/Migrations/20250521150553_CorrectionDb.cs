using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CapstoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class CorrectionDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsClient",
                table: "Messages");

            migrationBuilder.AlterColumn<int>(
                name: "SenderId",
                table: "Messages",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "BirthDate", "CountryCodeId", "CreatedBy", "CreationDate", "Email", "FullName", "Image", "IsActive", "IsLoggedIn", "IsVerfied", "LastLoginTime", "OTPCode", "OTPExipry", "Password", "PhoneNumber", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 3, new DateOnly(1999, 8, 9), 1, "System", new DateTime(2025, 5, 21, 18, 5, 53, 186, DateTimeKind.Local).AddTicks(960), "d1029341b27b5ee872f092b83737bf88404dffbce91fd930353b1a87800f040da99e004dd74df9cd6b713c3b918a5616", "Ahmad AlAoush", null, true, false, true, null, null, null, "d94b764dade7631c7eb61358981202ee5ae67039bf4994dcf986fa918cd5ec90ef0c5f26dc20770c7580024dbb7efb29", null, 3, null, null });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "SenderId",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Messages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClient",
                table: "Messages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(6340));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5927));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5933));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5939));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5940));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5942));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5943));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 300,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5944));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 301,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5946));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5820));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 16, 1, 52, 381, DateTimeKind.Local).AddTicks(5836));
        }
    }
}
