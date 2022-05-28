using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VaccinationSystem.Data.Classes;

namespace VaccinationSystem.Data.Configurations
{
    public class BugReportSeedConfiguration :  IEntityTypeConfiguration<BugReport>
    {
        public void Configure(EntityTypeBuilder<BugReport> builder)
        {
            _ = builder.HasData(
                new BugReport
                {
                    Id = -1,
                    Origin = BugReportOrigin.Generated,
                    Date = new DateTime(2022, 4, 5),
                    UserId = -3,
                    Description = "Stuck on loading"
                }
            );
        }
    }
}