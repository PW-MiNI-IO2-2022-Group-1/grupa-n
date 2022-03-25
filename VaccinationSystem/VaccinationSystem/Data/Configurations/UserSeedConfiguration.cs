using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class UserSeedConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            _ = builder.HasData(
                new ApplicationUser
                {
                    Id = "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd", //random guid
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "admin1"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                    Id = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a", //random guid
                    FirstName = "Default",
                    LastName = "Patient",
                    UserName = "patient@localhost.com",
                    NormalizedUserName = "PATIENT@LOCALHOST.COM",
                    Email = "patient@localhost.com",
                    NormalizedEmail = "PATIENT@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(null, "patient1"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
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
                }
            );
        }
    }
}