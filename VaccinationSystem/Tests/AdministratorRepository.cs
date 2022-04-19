using Microsoft.AspNetCore.Identity;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.Repositories;
using Xunit;

namespace Tests
{
    public class AdministratorRepository
    {
        [Fact]
        public async Task DeleteDoctor_Existing_ShouldDeleteAndReturnTrue()
        {
            // Arrange
            var context = InMemoryDbContext.Get();
            var userStore = InMemoryDbContext.TestUserStore<ApplicationUser>();
            var userManager = InMemoryDbContext.TestUserManager(userStore);
            var repo = new VaccinationSystem.Repositories.AdministratorRepository(context, userManager, userStore);
            var doctor = context.Users.Where(user => user.LastName == "Doctor").First();
            int doctorId = doctor.Id;

            // Act
            bool result = await repo.DeleteDoctor(doctorId);

            // Assert
            Assert.Null(context.Users.Find(doctorId));
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteDoctor_NonExisting_ShouldReturnFalse()
        {
            // Arrange
            var context = InMemoryDbContext.Get();
            var userStore = InMemoryDbContext.TestUserStore<ApplicationUser>();
            var userManager = InMemoryDbContext.TestUserManager(userStore);
            var repo = new VaccinationSystem.Repositories.AdministratorRepository(context, userManager, userStore);
            var doctor = context.Users.FirstOrDefault(user => user.LastName == "Doctor");
            int doctorId = int.MinValue;

            // Act
            bool result = await repo.DeleteDoctor(doctorId);

            // Assert
            Assert.False(result);
        }
    }
}