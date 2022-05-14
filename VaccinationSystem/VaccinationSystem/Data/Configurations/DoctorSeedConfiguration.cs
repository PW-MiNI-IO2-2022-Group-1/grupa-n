using Microsoft.AspNetCore.Identity;
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
                    Id = -2,
                    FirstName = "Default",
                    LastName = "Doctor",
                    UserName = "doctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    Email = "doctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "doctor1"),
                    EmailConfirmed = true,
                    SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                    LicenceId = "-1",
                },
                new Doctor
                {
                    Id = -22,
                    FirstName = "Test",
                    LastName = "Doctor",
                    UserName = "testdoctor@localhost.com",
                    NormalizedUserName = "DOCTOR@LOCALHOST.COM",
                    Email = "testdoctor@localhost.com",
                    NormalizedEmail = "DOCTOR@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "doctor1"),
                    EmailConfirmed = true,
                    SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                    LicenceId = "-22",
                }
            );
        }
    }
}