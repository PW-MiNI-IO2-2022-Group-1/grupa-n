using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Data.Configurations
{
    internal class PatientSeedConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            _ = builder.HasData(
                new Patient
                {
                    Id = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    FirstName = "Default",
                    LastName = "Patient",
                    UserName = "patient@localhost.com",
                    NormalizedUserName = "PATIENT@LOCALHOST.COM",
                    Email = "patient@localhost.com",
                    NormalizedEmail = "PATIENT@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "patient1"),
                    EmailConfirmed = true,
                    Pesel = "12345678901",
                    AddressId = -1
                }
            );
        }
    }
}