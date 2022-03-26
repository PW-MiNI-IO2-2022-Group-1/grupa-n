using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Data.Configurations
{
    internal class VisitSeedConfiguration : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            _ = builder.HasData(
                new Visit
                {
                    Id = -1,
                    PatientId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    DoctorId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    Status = VaccinationStatus.Planned,
                    Date = new DateTime(2022, 4, 5),    // y, m, d
                    VaccineId = -1
                },
                new Visit
                {
                    Id = -2,
                    PatientId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    DoctorId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    Status = VaccinationStatus.Cancelled,
                    Date = new DateTime(2022, 1, 15),
                    VaccineId = -3
                },
                new Visit
                {
                    Id = -3,
                    PatientId = "c1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    DoctorId = "f1076fe7-abf6-420d-8810-6cb0f3a92f6a",
                    Status = VaccinationStatus.Completed,
                    Date = new DateTime(2022, 2, 12),
                    VaccineId = -7
                }
            );
        }
    }
}