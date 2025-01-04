using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f4ed9b41-5d0a-4588-bb8c-456597d7dddd"), new Guid("220caaea-525d-4916-bbc4-90001722b78d") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f4ed9b41-5d0a-4588-bb8c-456597d7dddd"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("220caaea-525d-4916-bbc4-90001722b78d"));

            migrationBuilder.AddColumn<string>(
                name: "OrderCode",
                table: "Orders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PurchasedCourses",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a23a5978-3307-497b-8440-f9e5d0923b31"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PurchasedCourses", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b04719b9-54ff-46e7-9657-25b8813704a6"), 0, "eb9b72ee-f13a-45ea-8bd8-8b31729ea975", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEI2YNUbCsua97YS819crpPPzuEZ/2HNI4abeiTR9nIuwe+dU7/C/fgcvlYHTsGjuEA==", null, false, null, null, null, null, false, "instructor1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a23a5978-3307-497b-8440-f9e5d0923b31"), new Guid("b04719b9-54ff-46e7-9657-25b8813704a6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a23a5978-3307-497b-8440-f9e5d0923b31"), new Guid("b04719b9-54ff-46e7-9657-25b8813704a6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a23a5978-3307-497b-8440-f9e5d0923b31"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b04719b9-54ff-46e7-9657-25b8813704a6"));

            migrationBuilder.DropColumn(
                name: "OrderCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PurchasedCourses",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f4ed9b41-5d0a-4588-bb8c-456597d7dddd"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("220caaea-525d-4916-bbc4-90001722b78d"), 0, "c2d10c58-27fd-45c6-9fcc-b30d9a704102", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEG0AcGjo3KOOQEEPcND/tapF/ctB0PogMKlyndC2n+FjC9ngMoeNzM7BCD5ooRJF7A==", null, false, null, null, null, false, "instructor1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("f4ed9b41-5d0a-4588-bb8c-456597d7dddd"), new Guid("220caaea-525d-4916-bbc4-90001722b78d") });
        }
    }
}
