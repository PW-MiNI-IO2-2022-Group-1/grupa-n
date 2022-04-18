using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using API;
using VaccinationSystem.Data.Classes;

namespace API
{
    public class UserService : IUserService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IJwtHelper _jwtHelper;

        public UserService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IJwtHelper jwtHelper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtHelper = jwtHelper;
        }

        public async Task<bool> HasValidCredentialsAsync(RequestModels.Login loginInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(loginInfo.Email, loginInfo.Password, false, false);
            if (!result.Succeeded)
            {
                return false;
            }
            return true;
        }

        public string GetTokenForUser(string email, string role, int? id = null)
        {
            var claims = new List<Claim>()
            { 
                new Claim("email", email),
                new Claim(ClaimTypes.Role, role)
            };
            if (id is not null)
            {
                claims.Add(new Claim("id", id.ToString()));
            }
            // token wazny 7 dni
            var token = _jwtHelper.GetJwtToken(email, TimeSpan.FromDays(7), claims);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IList<string>> GetRolesForUser(ApplicationUser user)
        {
            // ale i tak raczej zakladamy ze moze byc tylko w jednej roli
            return await _userManager.GetRolesAsync(user);
        }
    }
}
