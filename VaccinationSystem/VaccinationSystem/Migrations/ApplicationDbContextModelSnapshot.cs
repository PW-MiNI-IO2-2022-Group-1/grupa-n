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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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
                            Id = "c8076fe7-faf6-757b-3452-6aa5f7a33c6c",
                            ConcurrencyStamp = "e58613c0-8678-4882-8e6a-03deceafc265",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "53716615-3a3b-4948-9d28-8076bf328b4a",
                            ConcurrencyStamp = "c03bf9db-52c1-48c2-a2e3-6a260e652e5f",
                            Name = "Doctor",
                            NormalizedName = "DOCTOR"
                        },
                        new
                        {
                            Id = "410adff7-f581-4737-b4d6-0dc9a88dec59",
                            ConcurrencyStamp = "9998bfd3-2f9f-4d4e-8dad-6d53bbc56ddf",
                            Name = "Patient",
                            NormalizedName = "PATIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                            RoleId = "c8076fe7-faf6-757b-3452-6aa5f7a33c6c"
                        },
                        new
                        {
                            UserId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            RoleId = "410adff7-f581-4737-b4d6-0dc9a88dec59"
                        },
                        new
                        {
                            UserId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            RoleId = "53716615-3a3b-4948-9d28-8076bf328b4a"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

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

            modelBuilder.Entity("VaccinationSystem.Data.Classes.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.Property<string>("DoctorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PatientId")
                        .HasColumnType("nvarchar(450)");

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
                            DoctorId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            PatientId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            Status = 0,
                            VaccineId = -1
                        },
                        new
                        {
                            Id = -2,
                            Date = new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            PatientId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            Status = 2,
                            VaccineId = -3
                        },
                        new
                        {
                            Id = -3,
                            Date = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            PatientId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
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
                            Id = "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "f519299f-f152-4e3e-a90f-dedca73b62e4",
                            Email = "admin@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "System",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@LOCALHOST.COM",
                            NormalizedUserName = "ADMIN@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEJitHv8MGaoALcRcrwWQ2S3rYmAhsa0nZqAwTs6o9wX98Hq5diRoIzMPrHLHGAuhEQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "8544e7ee-5914-462d-99ad-372618aaba1c",
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
                            Id = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6bae9464-5879-44a5-8eaa-983e46e82a25",
                            Email = "doctor@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Default",
                            LastName = "Doctor",
                            LockoutEnabled = false,
                            NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                            NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAECR/ExJxRFZq/ZZBLRildV76GFX7MnJp1CmSZ9igkbX1ZoxUG8YyRl3CWzif1QVOxQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "01248651-b53d-4eac-9da5-a6c3493df6d1",
                            TwoFactorEnabled = false,
                            UserName = "doctor@localhost.com",
                            LicenceId = "-1"
                        });
                });

            modelBuilder.Entity("VaccinationSystem.Data.Classes.Patient", b =>
                {
                    b.HasBaseType("VaccinationSystem.Data.Classes.ApplicationUser");

                    b.Property<string>("Pesel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Patient");

                    b.HasData(
                        new
                        {
                            Id = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "54b6cc8d-be75-42f7-91bf-d505eb10e525",
                            Email = "patient@localhost.com",
                            EmailConfirmed = true,
                            FirstName = "Default",
                            LastName = "Patient",
                            LockoutEnabled = false,
                            NormalizedEmail = "PATIENT@LOCALHOST.COM",
                            NormalizedUserName = "PATIENT@LOCALHOST.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEOed9q9vkTxFLVopQTdNiLBlysQDfu4D8OEtRSn5Il3Twdmx6xPy59hOCt7u+QFdpA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f4f68034-f39d-4608-9574-1adef98197e2",
                            TwoFactorEnabled = false,
                            UserName = "patient@localhost.com",
                            Pesel = "12345678901"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("VaccinationSystem.Data.Classes.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
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
#pragma warning restore 612, 618
        }
    }
}
