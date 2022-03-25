using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data.Configurations;

namespace VaccinationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new DiseaseSeedConfiguration());
        }
        public DbSet<Disease> Diseases { get; set; }
        //public DbSet<Vaccine> Vaccines { get; set; }
    }
}