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
                    Id = RoleIdentifiers.Admin,
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id = RoleIdentifiers.Doctor, //random guid
                    Name = "Doctor",
                    NormalizedName = "DOCTOR",
                },
                new IdentityRole
                {
                    Id = RoleIdentifiers.Patient, //random guid
                    Name = "Patient",
                    NormalizedName = "PATIENT",
                }
            );
        }
    }
}