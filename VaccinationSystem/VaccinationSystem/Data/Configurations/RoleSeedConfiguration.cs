using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
        {
            builder.HasData(
                new IdentityRole<int>
                {
                    Id = Roles.Admin.Id,
                    Name = Roles.Admin.Name,
                    NormalizedName = Roles.Admin.Name.ToUpper(),
                },
                new IdentityRole<int>
                {
                    Id = Roles.Doctor.Id,
                    Name = Roles.Doctor.Name,
                    NormalizedName = Roles.Doctor.Name.ToUpper(),
                },
                new IdentityRole<int>
                {
                    Id = Roles.Patient.Id,
                    Name = Roles.Patient.Name,
                    NormalizedName = Roles.Patient.Name.ToUpper(),
                }
            );
        }
    }
}