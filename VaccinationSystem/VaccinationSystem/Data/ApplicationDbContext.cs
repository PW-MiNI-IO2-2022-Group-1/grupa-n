﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data.Configurations;

namespace VaccinationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Vaccine> Vaccine { get; set; }
        public DbSet<Vaccination> Vaccination { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new DiseaseSeedConfiguration());
            builder.ApplyConfiguration(new RoleSeedConfiguration());
            builder.ApplyConfiguration(new AdminSeedConfiguration());
            builder.ApplyConfiguration(new DoctorSeedConfiguration());
            builder.ApplyConfiguration(new PatientSeedConfiguration());
            builder.ApplyConfiguration(new UserRoleSeedConfiguration());
        }
    }
}