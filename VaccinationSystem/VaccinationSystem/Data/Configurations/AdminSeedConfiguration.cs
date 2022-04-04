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
                    Id = "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@localhost.com",
                    NormalizedUserName = "ADMIN@LOCALHOST.COM",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "ADMIN@LOCALHOST.COM",
                    PasswordHash = hasher.HashPassword(new (), "admin1"),
                    EmailConfirmed = true,
                }
            );
        }
    }
}