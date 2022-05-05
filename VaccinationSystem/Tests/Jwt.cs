using API;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccinationSystem.Data.Classes;
using Xunit;

namespace Tests
{
    public class Jwt
    {
        [Fact]
        public void GetTokenForUser_ShouldReturnValidToken()
        {
            // Arrange
            var userService = InMemoryFactory.GetUserService();

            // Act
            var token = userService.GetTokenForUser("test@test.com", "admin");

            // Assert
            Assert.IsType<string>(token);
        }
    }
}
