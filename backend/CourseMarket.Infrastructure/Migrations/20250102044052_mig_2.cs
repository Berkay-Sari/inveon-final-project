using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9b81c9be-8597-40c1-8500-2034d43fbd2c"), new Guid("374fd398-9913-41d4-bb16-6998f36f60be") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a44cacbb-f52e-4699-a9e1-05ba67908e38"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9b81c9be-8597-40c1-8500-2034d43fbd2c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("374fd398-9913-41d4-bb16-6998f36f60be"));

            migrationBuilder.DropColumn(
                name: "BasketId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "BasketId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9b81c9be-8597-40c1-8500-2034d43fbd2c"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("374fd398-9913-41d4-bb16-6998f36f60be"), 0, "acd35405-1f7b-454b-a457-aaf8a421e1f1", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEHfpYKfbQAxzt9y9bvlOJGXADHJdUtXTGcUET5UI8nG9go/+PPoOL2IXPnJU83kGeQ==", null, false, null, null, null, false, "instructor1" },
                    { new Guid("a44cacbb-f52e-4699-a9e1-05ba67908e38"), 0, "11d2991f-0f44-4186-93ad-478a674572f3", null, false, "Arda", "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAECF7YGbUh10eGF8JyDdR/e78y2ClaQRUVA0bMkJJVT0jjPBMczUjpigcXBX2IHPqYQ==", null, false, null, null, null, false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9b81c9be-8597-40c1-8500-2034d43fbd2c"), new Guid("374fd398-9913-41d4-bb16-6998f36f60be") });
        }
    }
}
