using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Data;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Data.Classes;
using API.ModelValidation;
using API.RequestModels.Doctor;
using API.RequestModels.Patient;
using Microsoft.AspNetCore.Cors;

namespace API.Controllers
{
    [ApiController]
    [Route("/patient")]
    [EnableCors("API_Policy")]
    [Authorize(Roles = Roles.Patient.Name)]
    public class PatientController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IPatientRepository _patientRepository;
        private readonly IVaccineRepository _vaccineRepository;

        private const int pageSize = 10;

        public PatientController(
            IUserService userService,
            IPatientRepository patientRepository,
            IVaccineRepository vaccineRepository)
        {
            _userService = userService;
            _patientRepository = patientRepository;
            _vaccineRepository = vaccineRepository;
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
            var patient = _patientRepository.GetPatientByEmail(loginInfo.Email);
            var roles = await _userService.GetRolesForUser(patient);
            if (!roles.Contains(Roles.Patient.Name))
            {
                return new UnauthorizedResponse();
            }
            var token = _userService.GetTokenForUser(patient.Email, Roles.Patient.Name, patient.Id);
            var apiPatient = new ApiPatient
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                Pesel = patient.Pesel,
                Email = patient.Email,
                Address = patient.Address
            };
            var response = new ResponseModels.Patient.Login
            {
                Token = token,
                Patient = apiPatient
            };
            return Ok(response);
        }

        [HttpGet("auth-test")]
        public async Task<ActionResult> AuthTest()
        {
            return Ok(new SuccessResponse());
        }

        [HttpPost("registration")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPatient(RequestModels.Patient.RegisterPatient body)
        {
            if (await _userService.GetUserByEmailAsync(body.Email) != null)
            {
                // Nie ma sprawdzania czy jest juz z takim peselem
                return new ConflictResponse("User with that mail already exists.");
            }
            var patient = await _patientRepository.RegisterPatient(body.FirstName, body.LastName,
                body.Pesel, body.Email, body.Password, body.Address);
            var response = new ApiPatient
            {
                FirstName = patient.FirstName,
                Id = patient.Id,
                Address = patient.Address,
                Email = patient.Email,
                LastName = patient.LastName,
                Pesel = patient.Pesel
            };
            // Jedyne miejsce gdzie 201 sie przydaje
            return new ObjectResult(response) { StatusCode = StatusCodes.Status201Created };
        }

        [HttpPut("account")]
        public async Task<ActionResult> EditPatient([FromBody] Edit body)
        {
            // Address jeszcze nie dziala bo nie jest zaimplementowany w Repository
            var patient = await _patientRepository.GetAsync(GetPatientId());
            if (patient == null)
            {
                return new NotFoundResponse("Patient does not exist.");
            }
            patient.FirstName = body.FirstName;
            patient.LastName = body.LastName;
            patient.Pesel = body.Pesel;
            patient.Email = body.Email;
            var success = await _patientRepository.UpdateAsync(patient);
            if (!success)
            {
                return new NotFoundResponse("Failed editing patient data.");
            }
            var response = new ApiPatient
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

        [HttpDelete("account")]
        public async Task<ActionResult> DeletePatient()
        {
            var result = await _patientRepository.DeleteAsync(GetPatientId());
            if (!result)
            {
                return new NotFoundResponse("Account not found.");
            }
            return Ok();
        }

        [HttpGet("vaccination-slots")]
        public async Task<IActionResult> GetVaccinationSlots()
        {
            var visits = await _patientRepository.GetAllAvailableVisits();
            var response = visits.Select(visit => new
            {
                Id = visit.Id,
                Date = visit.Date
            }).ToArray();
            return Ok(response);
        }

        [HttpGet("vaccines")]
        public async Task<IActionResult> GetVaccines([FromQuery] GetVaccines query)
        {
            // TODO: filtracja
            var vaccines = await _vaccineRepository.GetAllAsync();
            var response = vaccines.Select(vaccine => new ApiVaccine
            {
                Id = vaccine.Id,
                Disease = vaccine.Disease.Name,
                Name = vaccine.Name,
                RequiredDoses = vaccine.RequiredDoses
            }).ToArray();
            return Ok(response);
        }

        private int GetPatientId()
        {
            return User.Claims
                .Where(claim => claim.Type == "id")
                .Select(claim => int.Parse(claim.Value))
                .First();
        }
    }
}
