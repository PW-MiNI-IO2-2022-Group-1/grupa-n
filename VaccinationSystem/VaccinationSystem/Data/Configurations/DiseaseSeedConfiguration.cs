using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class DiseaseSeedConfiguration : IEntityTypeConfiguration<Disease>
    {
        public void Configure(EntityTypeBuilder<Disease> builder)
        {
            _ = builder.HasData(
                new Disease
                {
                    Id = -1,
                    Name = "Covid-19"
                },
                new Disease
                {
                    Id = -2,
                    Name = "Covid-21"
                },
                new Disease
                {
                    Id = -3,
                    Name = "Flu"
                },
                new Disease
                {
                    Id = -4,
                    Name = "Chickenpox"
                },
                new Disease
                {
                    Id = -5,
                    Name = "Smallpox"
                },
                new Disease
                {
                    Id = -6,
                    Name = "Measles"
                },
                new Disease
                {
                    Id = -7,
                    Name = "Mumps"
                },
                new Disease
                {
                    Id = -8,
                    Name = "Polio"
                }
            );
        }
    }
}