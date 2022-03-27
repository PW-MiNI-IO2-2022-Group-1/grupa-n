﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Data.Configurations
{
    internal class DoctorSeedConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            _ = builder.HasData(
                new Doctor
                {
                    Id = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a", //random guid
                    FirstName = "Default",
                    LastName = "Doctor",
                    UserName = "doctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    Email = "doctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "doctor1"),
                    EmailConfirmed = true,
                    LicenceId = -1
                }
            );
        }
    }
}