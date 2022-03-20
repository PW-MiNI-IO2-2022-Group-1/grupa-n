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
                    Id = "c8076fe7-faf6-757b-3452-6aa5f7a33c6c", //random guid
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                },
                new IdentityRole
                {
                    Id = "53716615-3a3b-4948-9d28-8076bf328b4a", //random guid
                    Name = "Doctor",
                    NormalizedName = "DOCTOR",
                },
                new IdentityRole
                {
                    Id = "410adff7-f581-4737-b4d6-0dc9a88dec59", //random guid
                    Name = "Patient",
                    NormalizedName = "PATIENT",
                }
            );
        }
    }
}