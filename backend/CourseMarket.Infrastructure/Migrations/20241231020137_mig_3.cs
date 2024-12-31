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
                keyValues: new object[] { new Guid("d99c9ec5-199e-4d22-933c-1035656c534f"), new Guid("8f9b20d5-92f6-4964-aaf9-ec0591d8ce0d") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4b0080a4-29e2-4ba2-8497-d9f87f546e8f"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d99c9ec5-199e-4d22-933c-1035656c534f"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8f9b20d5-92f6-4964-aaf9-ec0591d8ce0d"));

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Files",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Files",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Storage",
                table: "Files",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_Files_CourseId",
                table: "Files",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Courses_CourseId",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_CourseId",
                table: "Files");

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

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "Storage",
                table: "Files");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d99c9ec5-199e-4d22-933c-1035656c534f"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsInstructor", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("4b0080a4-29e2-4ba2-8497-d9f87f546e8f"), 0, "e469a414-15cb-4271-8a55-2f26b68fd0c8", null, false, "Arda", false, "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAEE4epSm2185c7BbUyzfcMQTvRxia1ZoTmg2YL8bnJMRRlsCJ7TpGTKfSTzZMAsvSrQ==", null, false, null, false, "user1" },
                    { new Guid("8f9b20d5-92f6-4964-aaf9-ec0591d8ce0d"), 0, "d850b760-79b6-4982-913c-291164722ef7", null, false, "Fatih", false, "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAEKW/7GgJq9SY3QgP91Co8G1MmI5tVYmqoZogVm0ctCRibxBplekvNKiJwMoribcJnA==", null, false, null, false, "instructor1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d99c9ec5-199e-4d22-933c-1035656c534f"), new Guid("8f9b20d5-92f6-4964-aaf9-ec0591d8ce0d") });
        }
    }
}
