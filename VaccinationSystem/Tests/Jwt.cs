using API;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VaccinationSystem.Data.Classes;
using Xunit;

namespace Tests
{
    public class Jwt
    {
        [Fact]
        public void GetJwtToken_ReturnsValidToken()
        {
            // Arrange
            var jwtHelper = InMemoryFactory.GetJwtHelper();
            var testClaim = new Claim("testType", "testValue");

            // Act
            var token = jwtHelper.GetJwtToken("test@test.com", TimeSpan.FromDays(7),
                new List<Claim>() { testClaim });

            // Assert
            Assert.Equal("localhost", token.Issuer);
            Assert.Contains("localhost", token.Audiences);
            Assert.Contains(token.Claims, claim => claim.Type == testClaim.Type && claim.Value == testClaim.Value);
        }
    }
}
