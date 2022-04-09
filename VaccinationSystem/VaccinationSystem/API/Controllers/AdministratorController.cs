using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.API.ModelValidation;
using VaccinationSystem.API.RequestModels.Admin;
using VaccinationSystem.Data;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.API.Controllers
{
    [ApiController]
    [Route("/admin")]
    [Authorize(Roles = Roles.Admin.Name)]
    public class AdministratorController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdministratorRepository _administratorRepository;

        public AdministratorController(
            IUserService userService,
            IAdministratorRepository administratorRepository)
        {
            _userService = userService;
            _administratorRepository = administratorRepository;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> LoginAsync([FromBody] RequestModels.Login loginInfo)
        {
            bool isValidUser = await _userService.HasValidCredentialsAsync(loginInfo);
            if (!isValidUser)
            {
                return new UnauthorizedResponse();
            }
            var user = await _userService.GetUserByEmailAsync(loginInfo.Email);
            var roles = await _userService.GetRolesForUser(user);
            if (!roles.Contains(Roles.Admin.Name))
            {
                return new UnauthorizedResponse();
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

        [HttpGet("patients/{patientId}")]
        public async Task<ActionResult> GetSinglePatient(string patientId)
        {
            var patient = _administratorRepository.GetPatient(patientId);
            if (patient == null)
            {
                return new NotFoundResponse($"Patient does not exist.");
            }
            var response = new ResponseModels.Admin.GetSinglePatient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Pesel = patient.Pesel,
                Email = patient.Email,
                Address = patient.Address,
            };
            return Ok(response);
        }

        [HttpPost("doctors")]
        [ValidateModel]
        public async Task<ActionResult> CreateDoctor([FromBody] CreateDoctor body)
        {
            var doctor = await _administratorRepository.CreateDoctor(
                body.FirstName, body.LastName, body.Email, body.Password);
            var response = new ApiUser
            {
                Id = doctor.Id,
                Email = doctor.Email,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
            };
            return Ok(response);
        }

        [HttpDelete("doctors/{doctorId}")]
        public async Task<IActionResult> DeleteDoctor(string doctorId)
        {
            var result = await _administratorRepository.DeleteDoctor(doctorId);
            if (!result)
            {
                return new NotFoundResponse($"Doctor does not exist.");
            }
            return Ok(new SuccessResponse());
        }
    }
}
