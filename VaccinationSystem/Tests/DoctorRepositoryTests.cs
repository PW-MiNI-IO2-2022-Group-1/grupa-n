using Microsoft.AspNetCore.Identity;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.Repositories;
using Xunit;
using System.Security.Cryptography;
using System;
using System.Text;

namespace Tests
{
    public class DoctorRepositoryTests
    {


        [Fact]
        public async Task CreateVisit_Past_Date()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            var doctor = context.Users.Where(user => user.LastName == "Doctor").First();
            DateTime date = DateTime.MinValue;

            // Act
            var result = await repo.CreateVisit(date, doctor.Id);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateVisit_Nonexisting_Doctor()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            int doctorID = int.MinValue;
            DateTime date = new DateTime(2022, 12, 12);

            // Act
            var result = await repo.CreateVisit(date, doctorID);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateVisit_Success()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            var doctor = context.Users.Where(user => user.LastName == "Doctor").First();
            DateTime date = new DateTime(2022, 12, 12);

            // Act
            var result = await repo.CreateVisit(date, doctor.Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task DeleteVisit_Nonexisting()
        {
            // Arrange
            using var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            int visitId = int.MinValue;

            // Act
            bool result = await repo.DeleteVisit(visitId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task DeleteVisit_Existing_ShouldDeleteAndReturnTrue()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            var entity = context.Visits.First();

            // Act
            bool result = await repo.DeleteVisit(entity.Id);

            // Assert
            Assert.Null(context.Visits.Find(entity.Id));
            Assert.True(result);
        }

        [Fact]
        public async Task VaccinatePatient_NoPatient_Failure()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            var entity = context.Visits.Where(visit => visit.Patient == null).First();

            // Act
            bool result = await repo.VaccinatePatient(entity.Id);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task VaccinatePatient_VisitNonexisting_Failure()
        {
            //Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetDoctorRepository(context);
            int visitID = int.MinValue;

            //Act
            bool result = await repo.VaccinatePatient(visitID);

            //Assert
            Assert.False(result);
        }

    }
}