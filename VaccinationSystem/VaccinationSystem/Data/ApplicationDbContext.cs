using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VaccinationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DiseaseDto> Diseases { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<VaccinationStatusDto> VaccinationStatuses { get; set; }
    }
}