using System;
using VaccinationSystem.Validations;
using Xunit;

namespace Tests
{
    public class Validations
    {
        [Fact]
        public void FutureDateValidation_ShouldReturnTrue()
        {
            // Arrange
            var validator = new FutureDateValidation(7);
            var monthAway = DateTime.Now.AddMonths(1);

            // Act
            bool result = validator.IsValid(monthAway);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void FutureDateValidation_ShouldReturnFalse()
        {
            // Arrange
            var validator = new FutureDateValidation(7);
            var fiveDaysAway = DateTime.Now.AddDays(5);

            // Act
            bool result = validator.IsValid(fiveDaysAway);

            // Assert
            Assert.False(result);
        }
    }
}
