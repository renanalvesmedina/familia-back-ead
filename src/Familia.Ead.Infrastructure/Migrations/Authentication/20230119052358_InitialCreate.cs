using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Familia.Ead.Infrastructure.Migrations.Authentication
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePictureUri", "SecurityStamp", "Sexo", "TwoFactorEnabled", "UpdatedOn", "UserName" },
                values: new object[] { new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f"), 0, "2033bf1f-363f-48ff-8f1b-7b0fc0c4c450", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4895), "contato@igrejafamilia.net.br", false, "Familia Ead Admin", false, null, "CONTATO@IGREJAFAMILIA.NET.BR", "CONTATO@IGREJAFAMILIA.NET.BR", "AQAAAAIAAYagAAAAEL58YlvJAVotN9KxHmzjC5OoawVKajgZGVUDWrgy/MOhVGK+zXdeop8gELFLtSu0mQ==", "27996239504", false, null, "c8494782-2de5-4c38-b65b-2060f93e4866", "M", false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "contato@igrejafamilia.net.br" });

            migrationBuilder.InsertData(
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreatedOn", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("0b9f0fd1-1271-499f-bc79-a15ff2437111"), "Manager", "Create", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4651), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("214720b9-285d-493b-a012-8023ea844ecc"), "Enrollment", "Delete", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4692), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("21cd46e3-3a76-47e4-96b6-2aea5668ff27"), "Manager", "View", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4668), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2260266c-3a3d-49b6-abc4-41b19ec3f216"), "Student", "View", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4673), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("288452e5-4b74-4b33-8b37-4a89ee34d295"), "Class", "Create", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4700), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2cbcbba4-3ec6-4a84-9013-1ea45f5604ba"), "Enrollment", "Create", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4688), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3392ab3f-dd18-459a-832c-8a88f50ccc8f"), "Course", "Edit", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4694), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("59d87ba0-1963-4a92-be12-6fca8d159eea"), "Manager", "Delete", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4669), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6649874b-9959-451c-a776-3f4605ed5a05"), "Student", "Delete", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4686), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("72e1c8c4-35f7-402a-8dc8-ad85ceebd4ee"), "Course", "Create", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4693), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("74e1d49f-b927-4012-a903-bc34e2b54074"), "Student", "Edit", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4672), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89dc7c91-e11b-4353-8db9-ce6102c4c22a"), "Enrollment", "View", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4690), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ad39277f-a63c-46e8-848b-e0afac18274d"), "Student", "Create", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4670), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2d22441-64f6-4441-8c31-444607475566"), "Enrollment", "Edit", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4689), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d36cb549-f0fd-41a9-a01f-d9175ff34bab"), "Class", "View", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4703), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d78cefe3-d363-4407-8d88-3bcf0334ad6b"), "Course", "View", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4696), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7c0bf23-5820-4fac-bd96-f5abbd0ed587"), "Class", "Delete", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4704), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("dc462b0c-ae50-4439-9cca-3d1bdf47745c"), "Course", "Delete", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4699), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eeb28ad4-7634-4e03-86da-6af4fc0da663"), "Manager", "Edit", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4666), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f1e7c3e6-75fd-43fa-976f-a0d659105358"), "Class", "Edit", new DateTime(2023, 1, 19, 2, 23, 58, 491, DateTimeKind.Local).AddTicks(4701), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "Manager", "Create", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 2, "Manager", "Edit", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 3, "Manager", "Delete", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 4, "Manager", "View", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 5, "Student", "Create", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 6, "Student", "Edit", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 7, "Student", "Delete", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 8, "Student", "View", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 9, "Enrollment", "Create", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 10, "Enrollment", "Edit", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 11, "Enrollment", "Delete", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 12, "Enrollment", "View", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 13, "Course", "Create", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 14, "Course", "Edit", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 15, "Course", "Delete", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 16, "Course", "View", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 17, "Class", "Create", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 18, "Class", "Edit", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 19, "Class", "Delete", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") },
                    { 20, "Class", "View", new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f") }
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
