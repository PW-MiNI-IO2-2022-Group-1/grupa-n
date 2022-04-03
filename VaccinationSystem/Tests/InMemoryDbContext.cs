using Microsoft.EntityFrameworkCore;
using Moq;
using VaccinationSystem.Data;

namespace Tests
{
    public static class InMemoryDbContext
    {
        private static readonly DbContextOptionsBuilder<ApplicationDbContext> optionsBuilder = 
                                    new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("InMemoryDb");

        public static ApplicationDbContext Get()
        {
            var dbContext = new ApplicationDbContext(optionsBuilder.Options);
            // EnsureCreated uruchomi seeding
            dbContext.Database.EnsureCreated();
            return dbContext;
        }
    }
}
