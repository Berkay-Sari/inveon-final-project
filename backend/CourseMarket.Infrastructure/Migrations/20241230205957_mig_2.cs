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
                keyValues: new object[] { new Guid("775c5887-a96a-4fda-9383-f0d7b4f42ae9"), new Guid("f11e54a8-ec1f-4d97-b668-fc482e771a89") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4e61557-89be-4619-a0b2-1eb48c376e5c"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("775c5887-a96a-4fda-9383-f0d7b4f42ae9"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("f11e54a8-ec1f-4d97-b668-fc482e771a89"));

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(21)", maxLength: 21, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("775c5887-a96a-4fda-9383-f0d7b4f42ae9"), null, "Instructor", "INSTRUCTOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IsInstructor", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("a4e61557-89be-4619-a0b2-1eb48c376e5c"), 0, "eaee46af-83b5-4286-a544-13ee862098d8", null, false, "Arda", false, "Turan", false, null, null, "USER1", "AQAAAAIAAYagAAAAEDua15tnjRpbKVzg2GQXLvuiwfZXkw1T0yIVtHyP6r6KOnr5NMdU6BLlKA6U6pFOqg==", null, false, null, false, "user1" },
                    { new Guid("f11e54a8-ec1f-4d97-b668-fc482e771a89"), 0, "72327b88-a63e-42b6-aaa8-93e28be5eee0", null, false, "Fatih", false, "Terim", false, null, null, "INSTRUCTOR1", "AQAAAAIAAYagAAAAELLRQPQf0AGyO0bCd2XqZT2BNB1M0Xl618JtPC9uVZgd1zt51CUP2eAyUi2pfRHt2w==", null, false, null, false, "instructor1" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("775c5887-a96a-4fda-9383-f0d7b4f42ae9"), new Guid("f11e54a8-ec1f-4d97-b668-fc482e771a89") });
        }
    }
}
