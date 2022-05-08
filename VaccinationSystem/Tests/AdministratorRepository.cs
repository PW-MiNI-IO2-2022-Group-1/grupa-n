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
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var doctor = context.Users.Where(user => user.LastName == "Doctor").First();

            // Act
            bool result = await repo.DeleteDoctor(doctor.Id);

            // Assert
            Assert.Null(context.Users.Find(doctor.Id));
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteDoctor_NonExisting_ShouldReturnFalse()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            int doctorId = int.MinValue;

            // Act
            bool result = await repo.DeleteDoctor(doctorId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task CreateDoctor_Failure()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var doctor = context.Users.Where(user => true).First();

            //Act
            var result = await repo.CreateDoctor(doctor.FirstName, doctor.LastName, doctor.Email, "123");

            //Assert
            Assert.Null(result);
        }
    }
}