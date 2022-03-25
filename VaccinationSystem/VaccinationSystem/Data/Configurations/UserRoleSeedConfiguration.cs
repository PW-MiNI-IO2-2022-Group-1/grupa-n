using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = RoleIdentifiers.Admin, //admin
                    UserId = "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd"
                },
                new IdentityUserRole<string>
                {
                    RoleId = RoleIdentifiers.Patient, //patient
                    UserId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = RoleIdentifiers.Doctor, //doctor
                    UserId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a"
                }
            );
        }
    }
}