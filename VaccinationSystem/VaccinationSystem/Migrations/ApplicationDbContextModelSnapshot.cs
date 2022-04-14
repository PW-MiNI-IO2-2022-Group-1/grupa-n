﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VaccinationSystem.Data;

#nullable disable

namespace VaccinationSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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
                            Id = -1,
                            ConcurrencyStamp = "404b4023-d9eb-44f2-b4cb-9f8992eb5087",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = -2,
                            ConcurrencyStamp = "fd2148a6-5e42-4484-bf3b-7dace63fd69e",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = -3,
                            ConcurrencyStamp = "88356c8f-c311-4654-8117-2bef156344ff",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = -1,
                            RoleId = -1
                        },
                        new
                        {
                            UserId = -2,
                            RoleId = -2
                        },
                        new
                        {
                            UserId = -3,
                            RoleId = -3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HouseNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            City = "Warszawa",
                            HouseNumber = "1",
                            LocalNumber = "",
                            Street = "plac Politechniki",
                            ZipCode = "00-661"
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

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

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Diseases");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Name = "Covid-19"
                        },
                        new
                        {
                            Id = -2,
                            Name = "Covid-21"
                        },
                        new
                        {
                            Id = -3,
                            Name = "Flu"
                        },
                        new
                        {
                            Id = -4,
                            Name = "Chickenpox"
                        },
                        new
                        {
                            Id = -5,
                            Name = "Smallpox"
                        },
                        new
                        {
                            Id = -6,
                            Name = "Measles"
                        },
                        new
                        {
                            Id = -7,
                            Name = "Mumps"
                        },
                        new
                        {
                            Id = -8,
                            Name = "Polio"
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Vaccine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RequiredDoses")
                        .HasColumnType("int");

                    b.Property<int>("SerialNo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("Vaccines");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            DiseaseId = -1,
                            Name = "Moderna",
                            RequiredDoses = 2,
                            SerialNo = 12345
                        },
                        new
                        {
                            Id = -2,
                            DiseaseId = -1,
                            Name = "Prizer",
                            RequiredDoses = 2,
                            SerialNo = 1099231
                        },
                        new
                        {
                            Id = -3,
                            DiseaseId = -8,
                            Name = "Sabina",
                            RequiredDoses = 1,
                            SerialNo = 109923
                        },
                        new
                        {
                            Id = -4,
                            DiseaseId = -5,
                            Name = "Smallpox",
                            RequiredDoses = 1,
                            SerialNo = 223453464
                        },
                        new
                        {
                            Id = -5,
                            DiseaseId = -2,
                            Name = "Pfizer-21",
                            RequiredDoses = 2,
                            SerialNo = 12354659
                        },
                        new
                        {
                            Id = -6,
                            DiseaseId = -3,
                            Name = "Flu-21",
                            RequiredDoses = 1,
                            SerialNo = 12315659
                        },
                        new
                        {
                            Id = -7,
                            DiseaseId = -3,
                            Name = "Flu-22",
                            RequiredDoses = 1,
                            SerialNo = 56591234
                        },
                        new
                        {
                            Id = -8,
                            DiseaseId = -4,
                            Name = "Chickenpox",
                            RequiredDoses = 1,
                            SerialNo = 42565323
                        },
                        new
                        {
                            Id = -9,
                            DiseaseId = -6,
                            Name = "Measles",
                            RequiredDoses = 1,
                            SerialNo = 1142565323
                        },
                        new
                        {
                            Id = -10,
                            DiseaseId = -7,
                            Name = "Mumps",
                            RequiredDoses = 1,
                            SerialNo = 13245125
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DoctorId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("VaccineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("VaccineId");

                    b.ToTable("Visits");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            Date = new DateTime(2022, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = -2,
                            PatientId = -3,
                            Status = 0,
                            VaccineId = -1
                        },
                        new
                        {
                            Id = -2,
                            Date = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = -2,
                            PatientId = -3,
                            Status = 2,
                            VaccineId = -3
                        },
                        new
                        {
                            Id = -3,
                            Date = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = -2,
                            PatientId = -3,
                            Status = 1,
                            VaccineId = -7
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Administrator", b =>
                {
                    b.HasBaseType("VaccinationSystem.Data.Classes.ApplicationUser");

                    b.HasDiscriminator().HasValue("Administrator");

                    b.HasData(
                        new
                        {
                            Id = -1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c4e25d0f-e1a0-4f88-b467-a57568d73c13",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEBO8czXG6ikTCK/NyAEJrfBW0zd83i85d67hWqupEatuFHFJ/ksE/vqMSeVnuFbNlQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                            TwoFactorEnabled = false,
                            UserName = "admin@localhost.com"
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Doctor", b =>
                {
                    b.HasBaseType("VaccinationSystem.Data.Classes.ApplicationUser");

                    b.Property<string>("LicenceId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Doctor");

                    b.HasData(
                        new
                        {
                            Id = -2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6053ff48-fb41-4b80-bae6-47f19f70aef3",
                            Email = "doctor@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Default",
                            LastName = "Doctor",
                            LockoutEnabled = false,
                            NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                            NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEDwH8E7mRUGHHAoXQTS0eYCJLXgLF/Ynwld0YapWNAHjv2qKMvnHhFMhZaMLhXHUig==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                            TwoFactorEnabled = false,
                            UserName = "doctor@localhost.com",
                            LicenceId = "-1"
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Patient", b =>
                {
                    b.HasBaseType("VaccinationSystem.Data.Classes.ApplicationUser");

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AddressId");

                    b.HasDiscriminator().HasValue("Patient");

                    b.HasData(
                        new
                        {
                            Id = -3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5f0b3d64-becb-4eb0-9519-aab3545965c6",
                            Email = "patient@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Default",
                            LastName = "Patient",
                            LockoutEnabled = false,
                            NormalizedEmail = "PATIENT@LOCALHOST.COM",
                            NormalizedUserName = "PATIENT@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECthjZ1mx6MIgb2XPj7g3cswjv+zNHLSpCocWFb2/RhHZCslvwBDKNOCquXaq34v7g==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                            TwoFactorEnabled = false,
                            UserName = "patient@localhost.com",
                            AddressId = -1,
                            Pesel = "12345678901"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccinationSystem.Data.Classes.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Vaccine", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.Disease", "Disease")
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Visit", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VaccinationSystem.Data.Classes.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId");

                    b.HasOne("VaccinationSystem.Data.Classes.Vaccine", "Vaccine")
                        .WithMany()
                        .HasForeignKey("VaccineId");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Vaccine");
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Patient", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });
#pragma warning restore 612, 618
        }
    }
}
