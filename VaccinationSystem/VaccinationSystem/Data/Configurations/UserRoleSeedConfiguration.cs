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
                    RoleId = "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", //admin
                    UserId = "6f5f0ee8-640a-4645-ba8b-a4e3fa51b3dd"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "410adff7-f581-4737-b4d6-0dc9a88dec59", //patient
                    UserId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "53716615-3a3b-4948-9d28-8076bf328b4a", //patient
                    UserId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a"
                }
            );
        }
    }
}