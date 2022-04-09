using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Data.Configurations
{
    internal class AddressSeedConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            _ = builder.HasData(
                new Address
                {
                    Id = -1,
                    City = "Warszawa",
                    Street = "plac Politechniki",
                    ZipCode = "00-661",
                    HouseNumber = "1",
                    LocalNumber = ""
                }
            );
        }
    }
}
