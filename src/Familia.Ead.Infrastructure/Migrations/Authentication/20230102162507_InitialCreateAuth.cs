using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Familia.Ead.Infrastructure.Migrations.Authentication
{
    /// <inheritdoc />
    public partial class InitialCreateAuth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfilePictureUri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("73b8e1eb-845f-4d03-a81f-8c634b633277"), null, "Student", "STUDENT" },
                    { new Guid("7fb0e422-9a6d-4a87-a925-9815906e6475"), null, "Manager", "MANAGER" },
                    { new Guid("b4cec1b6-917b-421e-bf79-6491eb6a1cdd"), null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUri", "SecurityStamp", "TwoFactorEnabled", "UpdatedOn", "UserName" },
                values: new object[] { new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f"), 0, "06fc4f0b-0345-44e6-8175-e5ff3431cdd8", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(1141), "contato@igrejafamilia.net", false, "Familia Ead Admin", false, null, "CONTATO@IGREJAFAMILIA.NET", "CONTATO@IGREJAFAMILIA.NET", "AQAAAAIAAYagAAAAEK9ifqB2OXm3hEFQQ9bF77Q2YS2Ssc1vCKHOHMR7m3NzXjl7q3KiHyy/3qIt5YcCFg==", null, false, null, "baec3129-3b57-4b51-99e5-cf3ec7bcf184", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contato@igrejafamilia.net" });

            migrationBuilder.InsertData(
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreatedOn", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0ca2411e-d1f1-4b9e-bacb-49dab2bba3cb"), "Enrollment", "Delete", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(919), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("0f428f78-f84d-448c-ac65-8fc5509ab3e6"), "Course", "Create", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(923), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11d4e56c-0f06-4e29-af57-c338c2131d98"), "Class", "Delete", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(934), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1f9bae7f-1247-4ef4-b1c1-77aa400306ae"), "Course", "Edit", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(924), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("231f9da4-7edc-4fc7-bdc1-1db838f9f11d"), "Class", "Edit", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(930), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4660e114-56a6-4f22-ba63-62d0817db671"), "Student", "View", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(911), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4cf1674e-a0cf-4b14-b071-1650a79b3cf5"), "Course", "Full", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(920), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5d3d8a7b-4cdb-4748-91c8-4b8522ae8fa3"), "Student", "Delete", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(912), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f9adc64-f23f-43e0-a9a7-6715f35ee4f0"), "Class", "Create", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(929), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6312c0c0-aacf-4e05-80a3-6fac5d9fae09"), "Student", "Full", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(905), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("69e8c893-cd40-4d18-a406-d3b8caf064b8"), "Student", "Edit", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(908), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("72ba31e7-3126-4681-86ec-5fd13a362db1"), "Enrollment", "Full", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74338dfc-da12-447a-98ac-ca21a18c996b"), "Enrollment", "View", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(917), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7c9737cf-c661-4929-a82a-5daa57fe7aaf"), "Course", "View", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(925), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("843013f6-0719-422d-868e-1294fcf10f82"), "Manager", "View", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(902), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8a275b40-9363-4b22-89d9-97a8793951bc"), "Enrollment", "Create", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(915), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ee9286c-476e-4c99-afe9-bb59cbdb1a05"), "Enrollment", "Edit", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(916), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c60e0d36-c81f-4881-89c2-71457bb502e4"), "Course", "Delete", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(926), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c804dfa8-ca52-48df-9656-6abf2d0435a3"), "Student", "Create", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(906), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c845e746-97f2-446b-9c6d-b200d05349e0"), "Manager", "Create", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(899), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd55d634-5e00-410a-ab37-b918e1fbe113"), "Class", "Full", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(927), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cf23afbc-d2c9-4752-ad5c-e4bb6f9a7389"), "Manager", "Delete", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(904), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dd3cf41b-850a-4446-b546-f34460df4a26"), "Class", "View", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ecf86bef-23da-4e57-9077-a82784de5e3d"), "Manager", "Full", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(886), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f64edcc3-afab-4ed8-8f69-3c4725f9b1bf"), "Manager", "Edit", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(901), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manager", "Full", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 2, "Student", "Full", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 3, "Enrollment", "Full", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 4, "Course", "Full", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 5, "Class", "Full", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b4cec1b6-917b-421e-bf79-6491eb6a1cdd"), new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
