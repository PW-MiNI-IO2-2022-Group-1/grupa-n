using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(
                new IdentityUserRole<int>
                {
                    RoleId = Roles.Admin.Id,
                    UserId = -1
                },
                new IdentityUserRole<int>
                {
                    RoleId = Roles.Doctor.Id,
                    UserId = -2
                },
                new IdentityUserRole<int>
                {
                    RoleId = Roles.Patient.Id,
                    UserId = -3
                }
            );
        }
    }
}