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
                },
                new Vaccine
                {
                    Id = -5, 
                    Name ="Pfizer-21",
                    SerialNo = 12354659,
                    DiseaseId = -2,
                    RequiredDoses = 2
                },
                new Vaccine
                {
                    Id = -6,
                    Name = "Flu-21",
                    SerialNo = 12315659,
                    DiseaseId = -3,
                    RequiredDoses = 1
                },
                new Vaccine
                {
                    Id = -7,
                    Name = "Flu-22",
                    SerialNo = 56591234,
                    DiseaseId = -3,
                    RequiredDoses = 1
                },
                new Vaccine
                {
                    Id = -8,
                    Name = "Chickenpox",
                    SerialNo = 42565323,
                    DiseaseId = -4,
                    RequiredDoses = 1
                },
                new Vaccine
                {
                    Id = -9,
                    Name = "Measles",
                    SerialNo = 1142565323,
                    DiseaseId = -6,
                    RequiredDoses = 1
                },
                new Vaccine
                {
                    Id = -10,
                    Name = "Mumps",
                    SerialNo = 13245125,
                    DiseaseId = -7,
                    RequiredDoses = 1
                }
            );
        }
    }
}