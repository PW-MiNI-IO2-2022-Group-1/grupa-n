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
                    Id = -3,
                    FirstName = "Default",
                    LastName = "Patient",
                    UserName = "patient@localhost.com",
                    NormalizedUserName = "PATIENT@LOCALHOST.COM",
                    Email = "patient@localhost.com",
                    NormalizedEmail = "PATIENT@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "patient1"),
                    EmailConfirmed = true,
                    Pesel = "12345678901",
                    AddressId = -1,
                    SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464",
                }
            );
        }
    }
}