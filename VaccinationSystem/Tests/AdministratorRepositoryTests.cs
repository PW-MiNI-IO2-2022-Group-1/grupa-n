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
    public class AdministratorRepositoryTests
    {


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

        [Fact]
        public async Task DeletePatient_Existing_ShouldDeleteAndReturnTrue()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var patient = context.Users.Where(user => user.LastName == "Patient").First();

            // Act
            bool result = await repo.DeletePatient(patient.Id);

            // Assert
            Assert.Null(context.Users.Find(patient.Id));
            Assert.True(result);
        }

        [Fact]
        public async Task DeletePatient_NonExisting_ShouldReturnFalse()
        {
            // Arrange
            using var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            int patientId = int.MinValue;

            // Act
            bool result = await repo.DeletePatient(patientId);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public async Task EditDoctor_Existing_ReturnTrue()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var doctor = context.Users.Where(user => user.LastName == "Doctor").First();
            string newLastName = "DoctorNewName";

            // Act
            var result = await repo.EditDoctor(doctor.Id, doctor.FirstName, newLastName, doctor.Email);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task EditDoctor_NonExisting_ShouldReturnFalse()
        {
            // Arrange
            using var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            int doctorId = int.MinValue;

            // Act
            var result = await repo.EditDoctor(doctorId, "DoctorName", "DoctorSurname", "doctorEmail");

            // Assert
            Assert.Null(result);
        }

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
            await repo.CreateDoctor(doctor.FirstName, doctor.LastName, doctor.Email, "123");
        }

        [Fact]
        public async Task EditPatient_Existing_ReturnTrue()
        {
            // Arrange
            var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            var patient = context.Users.Where(user => user.LastName == "Patient").First();
            string newLastName = "PatientNewName";

            // Act
            var result = await repo.EditPatient(patient.Id, patient.FirstName, newLastName, patient.Email);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task EditPatient_NonExisting_ShouldReturnFalse()
        {
            // Arrange
            using var context = InMemoryFactory.GetDbContext();
            var repo = InMemoryFactory.GetAdministratorRepository(context);
            int patientId = int.MinValue;

            // Act
            var result = await repo.EditPatient(patientId, "PatientName", "PatientSurname", "PatientEmail");

            // Assert
            Assert.Null(result);
        }
    }
}