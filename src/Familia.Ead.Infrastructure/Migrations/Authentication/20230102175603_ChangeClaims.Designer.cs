// <auto-generated />
using System;
using Familia.Ead.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Familia.Ead.Infrastructure.Migrations.Authentication
{
    [DbContext(typeof(AuthenticationContext))]
    [Migration("20230102175603_ChangeClaims")]
    partial class ChangeClaims
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Familia.Ead.Domain.Entities.Authentication.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureUri")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "61a20cae-d537-4d8f-865c-b9800a03b090",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(7090),
                            Email = "contato@igrejafamilia.net",
                            EmailConfirmed = false,
                            FullName = "Familia Ead Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "CONTATO@IGREJAFAMILIA.NET",
                            NormalizedUserName = "CONTATO@IGREJAFAMILIA.NET",
                            PasswordHash = "AQAAAAIAAYagAAAAEDun2V2bYannWC2B2d+eKfQkdIDoAmw8S95sJg1yeivPhJE1C1KTMbpaObUV3iG5GQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "711f8ef7-5bc2-46ea-9c69-66f07e8727df",
                            TwoFactorEnabled = false,
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserName = "contato@igrejafamilia.net"
                        });
                });

            modelBuilder.Entity("Familia.Ead.Domain.Entities.Authentication.UserClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserClaim");

                    b.HasData(
                        new
                        {
                            Id = new Guid("9fa3cae5-c45a-457a-b4bd-8c58e2e47015"),
                            ClaimType = "Manager",
                            ClaimValue = "Create",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6815),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8840df7d-f110-4452-8aca-a37ae029d6df"),
                            ClaimType = "Manager",
                            ClaimValue = "Edit",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6835),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e7900d90-f633-4cf6-ab41-da29e39ef6a1"),
                            ClaimType = "Manager",
                            ClaimValue = "View",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6845),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("eb72d7a5-60fe-41d8-ae91-50eabf49980f"),
                            ClaimType = "Manager",
                            ClaimValue = "Delete",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6847),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("41da2bc5-5a42-483d-8d26-fcebed11dac0"),
                            ClaimType = "Student",
                            ClaimValue = "Create",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6848),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a38b0933-e729-4988-9aaf-64564fca904f"),
                            ClaimType = "Student",
                            ClaimValue = "Edit",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6860),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("71c2a7f9-5480-44c8-ba56-aea716185e93"),
                            ClaimType = "Student",
                            ClaimValue = "View",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6862),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("cb2e03be-b027-4173-86b4-8aedcfa4e0ef"),
                            ClaimType = "Student",
                            ClaimValue = "Delete",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6863),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bce89f48-f492-444c-b9e4-8584248cc77f"),
                            ClaimType = "Enrollment",
                            ClaimValue = "Create",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6865),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("1b5c101c-fbf6-43b5-af93-13fe62d9aa97"),
                            ClaimType = "Enrollment",
                            ClaimValue = "Edit",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6866),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("eecdea88-e983-425e-b6b8-90613dc53fce"),
                            ClaimType = "Enrollment",
                            ClaimValue = "View",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6867),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("68cbc8d7-706e-47b1-b794-5eeb5a003a6b"),
                            ClaimType = "Enrollment",
                            ClaimValue = "Delete",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6868),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("668311d0-5f51-4743-afae-78eeb48f9128"),
                            ClaimType = "Course",
                            ClaimValue = "Create",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6870),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("8b67ef07-208c-4697-8259-1133fc163a5f"),
                            ClaimType = "Course",
                            ClaimValue = "Edit",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6872),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("39942aa3-7fe9-4fbf-90e8-e725d51d2f04"),
                            ClaimType = "Course",
                            ClaimValue = "View",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6874),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("14c70c5f-ea62-41cd-b983-128e1ac4c219"),
                            ClaimType = "Course",
                            ClaimValue = "Delete",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6876),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("e220d686-b967-48a8-9659-0b7196b45a58"),
                            ClaimType = "Class",
                            ClaimValue = "Create",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6877),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("2d680292-e9c1-4e63-befa-98e9d5f6f7aa"),
                            ClaimType = "Class",
                            ClaimValue = "Edit",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6879),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4a0aaa93-eba1-4fff-98b9-99648ba5434c"),
                            ClaimType = "Class",
                            ClaimValue = "View",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6880),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("81b96ac9-96af-418c-ba5b-dd00b4ef0d97"),
                            ClaimType = "Class",
                            ClaimValue = "Delete",
                            CreatedOn = new DateTime(2023, 1, 2, 14, 56, 2, 997, DateTimeKind.Local).AddTicks(6881),
                            UpdatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("b4cec1b6-917b-421e-bf79-6491eb6a1cdd"),
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = new Guid("7fb0e422-9a6d-4a87-a925-9815906e6475"),
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = new Guid("73b8e1eb-845f-4d03-a81f-8c634b633277"),
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "Manager",
                            ClaimValue = "Create",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "Manager",
                            ClaimValue = "Edit",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "Manager",
                            ClaimValue = "Delete",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "Manager",
                            ClaimValue = "View",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "Student",
                            ClaimValue = "Create",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "Student",
                            ClaimValue = "Edit",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "Student",
                            ClaimValue = "Delete",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "Student",
                            ClaimValue = "View",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "Enrollment",
                            ClaimValue = "Create",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "Enrollment",
                            ClaimValue = "Edit",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "Enrollment",
                            ClaimValue = "Delete",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "Enrollment",
                            ClaimValue = "View",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "Course",
                            ClaimValue = "Create",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "Course",
                            ClaimValue = "Edit",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 15,
                            ClaimType = "Course",
                            ClaimValue = "Delete",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 16,
                            ClaimType = "Course",
                            ClaimValue = "View",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 17,
                            ClaimType = "Class",
                            ClaimValue = "Create",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 18,
                            ClaimType = "Class",
                            ClaimValue = "Edit",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 19,
                            ClaimType = "Class",
                            ClaimValue = "Delete",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        },
                        new
                        {
                            Id = 20,
                            ClaimType = "Class",
                            ClaimValue = "View",
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = new Guid("6f03e211-d764-4c34-afce-3cdaac7cce5f"),
                            RoleId = new Guid("b4cec1b6-917b-421e-bf79-6491eb6a1cdd")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("Familia.Ead.Domain.Entities.Authentication.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("Familia.Ead.Domain.Entities.Authentication.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Familia.Ead.Domain.Entities.Authentication.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("Familia.Ead.Domain.Entities.Authentication.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
