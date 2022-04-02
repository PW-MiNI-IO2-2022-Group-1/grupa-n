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
                    Id = Roles.Doctor.Id,
                    FirstName = "Default",
                    LastName = "Doctor",
                    UserName = "doctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    Email = "doctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "doctor1"),
                    EmailConfirmed = true,
                    LicenceId = "-1"
                }
            );
        }
    }
}