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
                keyValues: new object[] { new Guid("1042ce38-4246-4720-a7a0-fed83d6502c1"), new Guid("cb6b00d0-e5af-4c2b-9326-370d28154847") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a5ff819a-7b63-4b30-8b3e-d91b870d5e3a"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("1042ce38-4246-4720-a7a0-fed83d6502c1"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb6b00d0-e5af-4c2b-9326-370d28154847"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("22fb8680-262f-4849-842b-aa8d54fc1882"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0f78e669-76e7-462e-9997-9402eea80f7b"), 0, "5d6598c4-a351-48cd-8b0a-1bbfd84085f4", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEB6z9Bs+kIDsVKsg5uN0wf3wuJp/OgtGNslrr9Aq+SHzVPlsE5Jy1ez8SDLYcgOOoQ==", null, false, null, null, null, false, "instructor1" },
                    { new Guid("19195cb4-57f7-466c-b788-ac1486000d68"), 0, "b7de97b2-36d2-43f5-8f1f-281d59db510c", null, false, "Arda", "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAEIhFaDrb4J/bNhkmGeaMaB1PW1WUpBF0NaJ9D8EO/n89R09T/Few08UWUuDfaz1nEA==", null, false, null, null, null, false, "user1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("22fb8680-262f-4849-842b-aa8d54fc1882"), new Guid("0f78e669-76e7-462e-9997-9402eea80f7b") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("22fb8680-262f-4849-842b-aa8d54fc1882"), new Guid("0f78e669-76e7-462e-9997-9402eea80f7b") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("19195cb4-57f7-466c-b788-ac1486000d68"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("22fb8680-262f-4849-842b-aa8d54fc1882"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("0f78e669-76e7-462e-9997-9402eea80f7b"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("1042ce38-4246-4720-a7a0-fed83d6502c1"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a5ff819a-7b63-4b30-8b3e-d91b870d5e3a"), 0, "6daf3bc3-19d7-416f-b09c-3361b07accf1", null, false, "Arda", "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAENvlQ4iCakTHeByhauH1El71fV0UPbPZ92lk7aYfH04syQPHZ1wweZ3l5vOfi83iKw==", null, false, null, null, null, false, "user1" },
                    { new Guid("cb6b00d0-e5af-4c2b-9326-370d28154847"), 0, "a291bd67-1369-45d4-8a91-3196577aeaf8", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEESKJyLD7h21HrCyZV7fW4v5rz/RNwkcMZC+hkoURAOTOWOpxZ9B4jWrS/ADRn++gw==", null, false, null, null, null, false, "instructor1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("1042ce38-4246-4720-a7a0-fed83d6502c1"), new Guid("cb6b00d0-e5af-4c2b-9326-370d28154847") });
        }
    }
}
