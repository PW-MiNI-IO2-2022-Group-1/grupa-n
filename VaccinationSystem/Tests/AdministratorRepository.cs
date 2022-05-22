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
            using var context = InMemoryFactory.GetDbContext();
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
            using var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            int doctorId = int.MinValue;

            // Act
            bool result = await repo.DeleteDoctor(doctorId);

            // Assert
            Assert.False(result);
        }
    }
}