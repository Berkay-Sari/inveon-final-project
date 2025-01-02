using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("762d67de-a737-483c-94b7-9bc5f1e586ea"), new Guid("de8a0c63-ec6b-4577-a5a8-3d6fca4ed6a0") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("555a144c-8d4b-41f9-9f9a-49f3ea72ba1a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("762d67de-a737-483c-94b7-9bc5f1e586ea"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("de8a0c63-ec6b-4577-a5a8-3d6fca4ed6a0"));

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d7472be2-abf5-4201-88a3-8ed1e7f3ec10"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("046483f7-0b13-46ee-a964-aa61dd9aa637"), 0, "dd515ab8-9843-4af2-9d50-016b82305027", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEMswwfDnQG8MsJVMYkFOXQzU5KWPjxPgUW2Dybk2lOP+10WRFyAIdQy87wA3Z6IrPQ==", null, false, null, null, null, false, "instructor1" },
                    { new Guid("ad9f4a2f-9c9f-453b-b835-0ce514a14332"), 0, "09ddc4c8-9816-4d25-abca-7a87ab2d5785", null, false, "Arda", "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAENdv6csHkzX2yo6agrPiAb5XqwSjuvOqE51PV/+Dy2yN65ctK6B7OnV9sEx2MH4ecw==", null, false, null, null, null, false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d7472be2-abf5-4201-88a3-8ed1e7f3ec10"), new Guid("046483f7-0b13-46ee-a964-aa61dd9aa637") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d7472be2-abf5-4201-88a3-8ed1e7f3ec10"), new Guid("046483f7-0b13-46ee-a964-aa61dd9aa637") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ad9f4a2f-9c9f-453b-b835-0ce514a14332"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d7472be2-abf5-4201-88a3-8ed1e7f3ec10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("046483f7-0b13-46ee-a964-aa61dd9aa637"));

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("762d67de-a737-483c-94b7-9bc5f1e586ea"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("555a144c-8d4b-41f9-9f9a-49f3ea72ba1a"), 0, "1f9019ba-bef4-43f6-861c-dd07399159e2", null, false, "Arda", "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAEKPA/kUGHphhemzPB/2t3/+JoX97JJYf+pwSGh0k9JtD85p89gg/HYdNSTlXD1FbYw==", null, false, null, null, null, false, "user1" },
                    { new Guid("de8a0c63-ec6b-4577-a5a8-3d6fca4ed6a0"), 0, "a11e1604-a3f3-41e0-a38c-d1ea566ff82d", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEONN1oMWoxcI0BnUluNUOSQUwC0lWACJvnbHooXJam88O+FyGgiUSfbNgmKBRB3JjA==", null, false, null, null, null, false, "instructor1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("762d67de-a737-483c-94b7-9bc5f1e586ea"), new Guid("de8a0c63-ec6b-4577-a5a8-3d6fca4ed6a0") });
        }
    }
}
