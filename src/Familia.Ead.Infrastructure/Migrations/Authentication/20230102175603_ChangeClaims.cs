using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Familia.Ead.Infrastructure.Migrations.Authentication
{
    /// <inheritdoc />
    public partial class ChangeClaims : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("0ca2411e-d1f1-4b9e-bacb-49dab2bba3cb"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("0f428f78-f84d-448c-ac65-8fc5509ab3e6"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("11d4e56c-0f06-4e29-af57-c338c2131d98"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("1f9bae7f-1247-4ef4-b1c1-77aa400306ae"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("231f9da4-7edc-4fc7-bdc1-1db838f9f11d"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("4660e114-56a6-4f22-ba63-62d0817db671"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("4cf1674e-a0cf-4b14-b071-1650a79b3cf5"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("5d3d8a7b-4cdb-4748-91c8-4b8522ae8fa3"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("5f9adc64-f23f-43e0-a9a7-6715f35ee4f0"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("6312c0c0-aacf-4e05-80a3-6fac5d9fae09"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("69e8c893-cd40-4d18-a406-d3b8caf064b8"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("72ba31e7-3126-4681-86ec-5fd13a362db1"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("74338dfc-da12-447a-98ac-ca21a18c996b"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("7c9737cf-c661-4929-a82a-5daa57fe7aaf"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("843013f6-0719-422d-868e-1294fcf10f82"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("8a275b40-9363-4b22-89d9-97a8793951bc"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("8ee9286c-476e-4c99-afe9-bb59cbdb1a05"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("c60e0d36-c81f-4881-89c2-71457bb502e4"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("c804dfa8-ca52-48df-9656-6abf2d0435a3"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("c845e746-97f2-446b-9c6d-b200d05349e0"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("cd55d634-5e00-410a-ab37-b918e1fbe113"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("cf23afbc-d2c9-4752-ad5c-e4bb6f9a7389"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("dd3cf41b-850a-4446-b546-f34460df4a26"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("ecf86bef-23da-4e57-9077-a82784de5e3d"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("f64edcc3-afab-4ed8-8f69-3c4725f9b1bf"));

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimValue",
                value: "Create");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Manager", "Edit" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Manager", "Delete" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Manager", "View" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Student", "Create" });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "61a20cae-d537-4d8f-865c-b9800a03b090", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(7090), "AQAAAAIAAYagAAAAEDun2V2bYannWC2B2d+eKfQkdIDoAmw8S95sJg1yeivPhJE1C1KTMbpaObUV3iG5GQ==", "711f8ef7-5bc2-46ea-9c69-66f07e8727df" });

            migrationBuilder.InsertData(
                table: "UserClaim",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "CreatedOn", "UpdatedOn" },
                values: new object[,]
                {
                    { new Guid("14c70c5f-ea62-41cd-b983-128e1ac4c219"), "Course", "Delete", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6876), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("1b5c101c-fbf6-43b5-af93-13fe62d9aa97"), "Enrollment", "Edit", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("2d680292-e9c1-4e63-befa-98e9d5f6f7aa"), "Class", "Edit", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39942aa3-7fe9-4fbf-90e8-e725d51d2f04"), "Course", "View", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("41da2bc5-5a42-483d-8d26-fcebed11dac0"), "Student", "Create", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6848), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("4a0aaa93-eba1-4fff-98b9-99648ba5434c"), "Class", "View", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("668311d0-5f51-4743-afae-78eeb48f9128"), "Course", "Create", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6870), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("68cbc8d7-706e-47b1-b794-5eeb5a003a6b"), "Enrollment", "Delete", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6868), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("71c2a7f9-5480-44c8-ba56-aea716185e93"), "Student", "View", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6862), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("81b96ac9-96af-418c-ba5b-dd00b4ef0d97"), "Class", "Delete", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6881), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8840df7d-f110-4452-8aca-a37ae029d6df"), "Manager", "Edit", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6835), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8b67ef07-208c-4697-8259-1133fc163a5f"), "Course", "Edit", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6872), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9fa3cae5-c45a-457a-b4bd-8c58e2e47015"), "Manager", "Create", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6815), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a38b0933-e729-4988-9aaf-64564fca904f"), "Student", "Edit", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bce89f48-f492-444c-b9e4-8584248cc77f"), "Enrollment", "Create", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6865), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cb2e03be-b027-4173-86b4-8aedcfa4e0ef"), "Student", "Delete", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e220d686-b967-48a8-9659-0b7196b45a58"), "Class", "Create", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6877), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7900d90-f633-4cf6-ab41-da29e39ef6a1"), "Manager", "View", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eb72d7a5-60fe-41d8-ae91-50eabf49980f"), "Manager", "Delete", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("eecdea88-e983-425e-b6b8-90613dc53fce"), "Enrollment", "View", new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("14c70c5f-ea62-41cd-b983-128e1ac4c219"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("1b5c101c-fbf6-43b5-af93-13fe62d9aa97"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("2d680292-e9c1-4e63-befa-98e9d5f6f7aa"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("39942aa3-7fe9-4fbf-90e8-e725d51d2f04"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("41da2bc5-5a42-483d-8d26-fcebed11dac0"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("4a0aaa93-eba1-4fff-98b9-99648ba5434c"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("668311d0-5f51-4743-afae-78eeb48f9128"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("68cbc8d7-706e-47b1-b794-5eeb5a003a6b"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("71c2a7f9-5480-44c8-ba56-aea716185e93"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("81b96ac9-96af-418c-ba5b-dd00b4ef0d97"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("8840df7d-f110-4452-8aca-a37ae029d6df"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("8b67ef07-208c-4697-8259-1133fc163a5f"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("9fa3cae5-c45a-457a-b4bd-8c58e2e47015"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("a38b0933-e729-4988-9aaf-64564fca904f"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("bce89f48-f492-444c-b9e4-8584248cc77f"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("cb2e03be-b027-4173-86b4-8aedcfa4e0ef"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("e220d686-b967-48a8-9659-0b7196b45a58"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("e7900d90-f633-4cf6-ab41-da29e39ef6a1"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("eb72d7a5-60fe-41d8-ae91-50eabf49980f"));

            migrationBuilder.DeleteData(
                table: "UserClaim",
                keyColumn: "Id",
                keyValue: new Guid("eecdea88-e983-425e-b6b8-90613dc53fce"));

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClaimValue",
                value: "Full");

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Student", "Full" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Enrollment", "Full" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Course", "Full" });

            migrationBuilder.UpdateData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ClaimType", "ClaimValue" },
                values: new object[] { "Class", "Full" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f"),
                columns: new[] { "ConcurrencyStamp", "CreatedOn", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06fc4f0b-0345-44e6-8175-e5ff3431cdd8", new DateTime(2023, 1, 2, 13, 25, 6, 952, DateTimeKind.Local).AddTicks(1141), "AQAAAAIAAYagAAAAEK9ifqB2OXm3hEFQQ9bF77Q2YS2Ssc1vCKHOHMR7m3NzXjl7q3KiHyy/3qIt5YcCFg==", "baec3129-3b57-4b51-99e5-cf3ec7bcf184" });

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
        }
    }
}
