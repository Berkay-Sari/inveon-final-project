using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

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
                keyValues: new object[] { new Guid("3928d2db-4f98-4198-9171-baf9b01139e3"), new Guid("d70800ee-d930-458d-b7a8-cda895d5f7c6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3928d2db-4f98-4198-9171-baf9b01139e3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d70800ee-d930-458d-b7a8-cda895d5f7c6"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3205206b-12e7-45ad-9659-7835a618c338"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1cbcd6b3-95b8-4beb-a4cc-90d53ded8d5f"), 0, "ef66491c-beaa-4496-8860-9631876eb4b1", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEA5gVsLH/glQGTa8NieWkiR+ph2ydEaFK9BPrupFlg/MvcueXOCzhHjoZsL1j5s9xg==", null, false, null, null, null, false, "instructor1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3205206b-12e7-45ad-9659-7835a618c338"), new Guid("1cbcd6b3-95b8-4beb-a4cc-90d53ded8d5f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3205206b-12e7-45ad-9659-7835a618c338"), new Guid("1cbcd6b3-95b8-4beb-a4cc-90d53ded8d5f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3205206b-12e7-45ad-9659-7835a618c338"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1cbcd6b3-95b8-4beb-a4cc-90d53ded8d5f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3928d2db-4f98-4198-9171-baf9b01139e3"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("d70800ee-d930-458d-b7a8-cda895d5f7c6"), 0, "dd45ded6-314f-4117-bbee-217a19ec9bfe", null, false, "Fatih", "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEJxxaUkLNRqzF9JKuLKdYLuGMvEdX2GpOHErP0aqombzXZlPh9VxDP9XjYMb0uOSMA==", null, false, null, null, null, false, "instructor1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3928d2db-4f98-4198-9171-baf9b01139e3"), new Guid("d70800ee-d930-458d-b7a8-cda895d5f7c6") });
        }
    }
}
