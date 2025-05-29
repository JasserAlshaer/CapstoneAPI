using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CapstoneAPI.Migrations
{
    /// <inheritdoc />
    public partial class Enhancment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardTypeId",
                table: "PaymentCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(949));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(494));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(495));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(496));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(498));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(501));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(502));

            migrationBuilder.InsertData(
                table: "LookupItems",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsActive", "Name", "TypeId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 300, "System", new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(503), true, "Visa", 5, null, null },
                    { 301, "System", new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(504), true, "Master Card", 5, null, null }
                });

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(361));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(378));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(380));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(409));

            migrationBuilder.InsertData(
                table: "LookupTypes",
                columns: new[] { "Id", "CreatedBy", "CreationDate", "IsActive", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 5, "System", new DateTime(2025, 5, 21, 14, 1, 39, 274, DateTimeKind.Local).AddTicks(410), true, "CardType", null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "CardTypeId",
                table: "PaymentCards");

            migrationBuilder.UpdateData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9910));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9473));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9474));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9475));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9472));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 100,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9476));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 101,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 200,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9477));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 201,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9478));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 202,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9479));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 203,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9480));

            migrationBuilder.UpdateData(
                table: "LookupItems",
                keyColumn: "Id",
                keyValue: 204,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9321));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9336));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9337));

            migrationBuilder.UpdateData(
                table: "LookupTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 5, 19, 15, 27, 26, 116, DateTimeKind.Local).AddTicks(9338));
        }
    }
}
