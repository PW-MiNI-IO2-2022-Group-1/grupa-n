using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.Data.Configurations;

namespace VaccinationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Disease>? Diseases { get; set; }
        public DbSet<Vaccine>? Vaccines { get; set; }
        public DbSet<Visit>? Visit { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new AdminSeedConfiguration());
            builder.ApplyConfiguration(new DoctorSeedConfiguration());
            builder.ApplyConfiguration(new PatientSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
            builder.ApplyConfiguration(new DiseaseSeedConfiguration());
            builder.ApplyConfiguration(new VaccineSeedConfiguration());
            builder.ApplyConfiguration(new VisitSeedConfiguration());
        }
    }
}