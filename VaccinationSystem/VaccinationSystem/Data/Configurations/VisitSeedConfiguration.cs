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
                    PatientId = -3,
                    DoctorId = -2,
                    Status = VaccinationStatus.Planned,
                    Date = new DateTime(2022, 4, 5),    // y, m, d
                    VaccineId = -1
                },
                new Visit
                {
                    Id = -2,
                    PatientId = -3,
                    DoctorId = -2,
                    Status = VaccinationStatus.Cancelled,
                    Date = new DateTime(2022, 1, 15),
                    VaccineId = -3
                },
                new Visit
                {
                    Id = -3,
                    PatientId = -3,
                    DoctorId = -2,
                    Status = VaccinationStatus.Completed,
                    Date = new DateTime(2022, 2, 12),
                    VaccineId = -7
                },
                new Visit
                {
                    Id = -4,
                    PatientId = null,
                    DoctorId = -2,
                    Status = VaccinationStatus.Planned,
                    Date = new DateTime(2022, 5, 5),
                    VaccineId = -7
                }
            );
        }
    }
}