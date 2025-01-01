using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7ca9f184-07a9-46fc-8f97-d44bf45c99c8"), new Guid("a0e1aa84-1f38-48ef-ae2c-9b7e674300df") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("399cb787-7c32-4be7-b42e-c082ddf3be17"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7ca9f184-07a9-46fc-8f97-d44bf45c99c8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a0e1aa84-1f38-48ef-ae2c-9b7e674300df"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("073ab2a4-63ae-4642-8cfa-17daf6504eb5"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsInstructor", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("136c5543-8f81-439d-9d08-25cb300aca4b"), 0, "9a4a9f56-4602-412b-8245-edfce6e281ec", null, false, "Fatih", false, "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEGVjZKXHhvRKbJ17fxCjMF3mRi/bZZaPegWZDH3CqD7nEdPtaeJK57rARHDWZ7wKFg==", null, false, null, null, null, false, "instructor1" },
                    { new Guid("144d421a-1e5e-4df3-8c5b-7cb3f0a3c0be"), 0, "769741ae-9810-4fe7-b219-54471982ff3b", null, false, "Arda", false, "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAELDHrHVySMr1V1KqdCtPSo5oIl4dAmj1anywpqFFwLkw2yUQUQw8HI20rAPbJzP6Xg==", null, false, null, null, null, false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("073ab2a4-63ae-4642-8cfa-17daf6504eb5"), new Guid("136c5543-8f81-439d-9d08-25cb300aca4b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("073ab2a4-63ae-4642-8cfa-17daf6504eb5"), new Guid("136c5543-8f81-439d-9d08-25cb300aca4b") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("144d421a-1e5e-4df3-8c5b-7cb3f0a3c0be"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("073ab2a4-63ae-4642-8cfa-17daf6504eb5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("136c5543-8f81-439d-9d08-25cb300aca4b"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7ca9f184-07a9-46fc-8f97-d44bf45c99c8"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsInstructor", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("399cb787-7c32-4be7-b42e-c082ddf3be17"), 0, "b123751f-20e1-4fa5-9f8f-75314bb4b20d", null, false, "Arda", false, "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAEA+ghQ5LRCD1WmoPGbASfWmFUyhTVIZFLi01VgmZIwNBY3ZnyK47MTyTZuYZYZLfUg==", null, false, null, false, "user1" },
                    { new Guid("a0e1aa84-1f38-48ef-ae2c-9b7e674300df"), 0, "08d4f0e5-0cfc-46b2-aac9-0606a2f8fec5", null, false, "Fatih", false, "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEBlQw+1DUGsmvyBW9VKkjPfJ5Lr9iqoi0RIBApl3FZNTd3bu8Q6WNISZKzcS9h3WNw==", null, false, null, false, "instructor1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7ca9f184-07a9-46fc-8f97-d44bf45c99c8"), new Guid("a0e1aa84-1f38-48ef-ae2c-9b7e674300df") });
        }
    }
}
