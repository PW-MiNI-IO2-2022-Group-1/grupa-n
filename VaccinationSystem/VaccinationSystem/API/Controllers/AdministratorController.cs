using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Data;

namespace VaccinationSystem.API.Controllers
{
    [ApiController]
    [Route("/admin")]
    [Authorize(Roles = Roles.Admin.Name)]
    public class AdministratorController : ControllerBase
    {
        IUserService _userService;

        public AdministratorController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync([FromBody] RequestModels.Login loginInfo)
        {
            bool isValidUser = await _userService.IsValidCredentialsAsync(loginInfo);
            if (!isValidUser)
            {
                return Unauthorized();
            }
            var user = await _userService.GetUserByEmailAsync(loginInfo.Email);
            var roles = await _userService.GetRolesForUser(user);
            if (!roles.Contains(Roles.Admin.Name))
            {
                return Unauthorized();
            }
            var token = _userService.GetTokenForUser(user.Email, Roles.Admin.Name);
            var apiUser = new ApiUser
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            // w przyszlosci to wyzej mozna wyciagnac do osobnej metody
            // tylko pacjent ma dodatkowe pole - adres
            var response = new ResponseModels.Admin.Login
            {
                Token = token,
                Admin = apiUser
            };
            return Ok(response);
        }
    }
}
