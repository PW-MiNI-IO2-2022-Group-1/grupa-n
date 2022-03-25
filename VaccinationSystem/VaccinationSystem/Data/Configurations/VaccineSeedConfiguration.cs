using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class VaccineSeedConfiguration : IEntityTypeConfiguration<Vaccine>
    {
        public void Configure(EntityTypeBuilder<Vaccine> builder)
        {
            _ = builder.HasData(
                new Vaccine
                {
                    Id = -1,
                    Name = "Moderna",
                    SerialNo = 12345,
                    DiseaseId = -1,
                    RequiredDoses = 2
                },
                new Vaccine
                {
                    Id = -2,
                    Name = "Prizer",
                    SerialNo = 1099231,
                    DiseaseId = -1,
                    RequiredDoses = 2
                },
                new Vaccine
                {
                    Id = -3,
                    Name = "Sabina",
                    SerialNo = 109923,
                    DiseaseId = -8,
                    RequiredDoses = 1
                },
                new Vaccine
                {
                    Id = -4,
                    Name = "Smallpox",
                    SerialNo = 223453464,
                    DiseaseId = -5,
                    RequiredDoses = 1
                }
            );
        }
    }
}