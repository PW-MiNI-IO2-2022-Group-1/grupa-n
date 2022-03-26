using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VaccinationSystem.Data.Configurations
{
    internal class VaccinationSeedConfiguration : IEntityTypeConfiguration<Vaccination>
    {
        public void Configure(EntityTypeBuilder<Vaccination> builder)
        {
            _ = builder.HasData(
                new Vaccination
                {
                    Id = -1,
                    //Patient = patient,        - nie umiem wstawić całych struktur, to się jakoś da czy może lepiej
                    //                          w klasie Vaccination zamienić je na pojedyncze id?
                    //Doctor = doctor,
                    Status = VaccinationStatus.Planned,
                    Date = new DateTime(2022, 4, 5),    // y, m, d
                    //Vaccine = vaccine
                },
                new Vaccination
                {
                    Id = -2,
                    //Patient = patient,
                    //Doctor = doctor,
                    Status = VaccinationStatus.Cancelled,
                    Date = new DateTime(2022, 1, 15),
                    //Vaccine = vaccine
                },
                new Vaccination
                {
                    Id = -1,
                    //Patient = patient,
                    //Doctor = doctor,
                    Status = VaccinationStatus.Completed,
                    Date = new DateTime(2022, 2, 12),
                    //Vaccine = vaccine
                }
            );
        }
    }
}