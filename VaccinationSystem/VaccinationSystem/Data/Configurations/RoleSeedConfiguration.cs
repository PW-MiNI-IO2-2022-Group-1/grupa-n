using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = Roles.Admin.Id,
                    Name = Roles.Admin.Name,
                    NormalizedName = Roles.Admin.Name.ToUpper(),
                },
                new IdentityRole
                {
                    Id = Roles.Doctor.Id,
                    Name = Roles.Doctor.Name,
                    NormalizedName = Roles.Doctor.Name.ToUpper(),
                },
                new IdentityRole
                {
                    Id = Roles.Patient.Id,
                    Name = Roles.Patient.Name,
                    NormalizedName = Roles.Patient.Name.ToUpper(),
                }
            );
        }
    }
}