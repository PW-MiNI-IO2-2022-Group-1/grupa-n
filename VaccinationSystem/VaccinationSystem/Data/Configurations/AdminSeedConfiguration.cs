using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Data.Configurations
{
    internal class AdminSeedConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            _ = builder.HasData(
                new Administrator
                {
                    Id = -1,
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "admin1"),
                    EmailConfirmed = true,
                    SecurityStamp = "T4G4EBCXKGJUCPCGBAPXV7FMUMXNE464"
                }
            );
        }
    }
}