using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace VaccinationSystem.API
{
    public interface IJwtHelper
    {
        public JwtSecurityToken GetJwtToken(
            string email,
            TimeSpan expiration,
            IEnumerable<Claim>? additionalClaims = null);
    }
}
