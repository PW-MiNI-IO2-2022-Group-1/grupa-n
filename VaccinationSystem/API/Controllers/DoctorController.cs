using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VaccinationSystem.Data;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Data.Classes;
using API.ModelValidation;
using API.RequestModels.Doctor;

namespace API.Controllers
{
    [ApiController]
    [Route("/doctor")]
    [Authorize(Roles = Roles.Doctor.Name)]
    public class DoctorController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IDoctorRepository _doctorRepository;

        private const int pageSize = 10;

        public DoctorController(
            IUserService userService,
            IDoctorRepository doctorRepository)
        {
            _userService = userService;
            _doctorRepository = doctorRepository;
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
            if (!roles.Contains(Roles.Doctor.Name))
            {
                return new UnauthorizedResponse();
            }
            var token = _userService.GetTokenForUser(user.Email, Roles.Doctor.Name, user.Id);
            var apiUser = new ApiUser
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            // w przyszlosci to wyzej mozna wyciagnac do osobnej metody
            // tylko pacjent ma dodatkowe pole - adres
            var response = new ResponseModels.Doctor.Login
            {
                Token = token,
                Doctor = apiUser
            };
            return Ok(response);
        }
        [HttpGet("auth-test")]
        public async Task<ActionResult> AuthTest()
        {
            return Ok(new SuccessResponse());
        }

        [HttpGet("vaccination-slots")]
        public async Task<ActionResult> GetVaccinationSlots([FromQuery] RequestModels.Doctor.GetVaccinationSlots query)
        {
            if (query.Page < 1)
            {
                return new NotFoundResponse("Wrong page.");
            }

            var (visits, pagination) = Pagination<Visit>
                .ShrinkList(await _doctorRepository.GetVisits(
                    GetDoctorId(), query.OnlyReserved, query.StartDate, query.EndDate),
                    query.Page, pageSize);

            // _doctorRepository juz filtruje tylko te ze statusem Planned
            var response = new ResponseModels.Doctor.GetVaccinationSlots
            {
                Pagination = pagination,
                Data = visits.Select(visit => new
                {
                    Id = visit.Id,
                    Date = visit.Date,
                    Vaccination = new
                    {
                        Id = visit.Id,
                        Vaccine = visit.Vaccine != null ? new ApiVaccine
                        {
                            Id = visit.Vaccine.Id,
                            Name = visit.Vaccine.Name,
                            Disease = visit.Vaccine.Disease.Name,
                            RequiredDoses = visit.Vaccine.RequiredDoses
                        } : null,
                        Status = visit.Status.ToString(),
                        Patient = visit.Patient != null ? new ApiPatient
                        {
                            Id = visit.Patient.Id,
                            FirstName = visit.Patient.FirstName,
                            LastName = visit.Patient.LastName,
                            Pesel = visit.Patient.Pesel,
                            Email = visit.Patient.Email,
                            Address = visit.Patient.Address
                        } : null
                    }
                }).ToArray()
            };

            return Ok(response);
        }

        [HttpPost("vaccination-slots")]
        public async Task<IActionResult> CreateVaccinationSlot([FromBody] CreateVaccinationSlot body)
        {
            var result = await _doctorRepository.CreateVisit(body.Date, GetDoctorId());
            if (result is null)
            {
                return new ValidationFailedResponse(new[]
                {
                    new { Date = "Date is in the past or you already have a visit." } 
                });
                // TODO: Moze powinnismy moc sprawdzic konkretnie ktory z tych bledow zaszedl
            }
            return Ok(new SuccessResponse());
        }

        // W dokumentacji slotId jest stringiem
        [HttpPut("vaccination-slots/{vaccinationSlotId}")]
        public async Task<IActionResult> VaccinatePatient(string vaccinationSlotId, [FromBody] VaccinatePatient body)
        {
            // TODO: Repozytorium nie obsluguje opcji CANCELED
            if (body.Status == "CANCELED")
            {
                return new NotFoundResponse("Canceling not implemented.");
            }
            try
            {
                int id = int.Parse(vaccinationSlotId);
                var result = await _doctorRepository.VaccinatePatient(int.Parse(vaccinationSlotId));
                if (!result)
                {
                    return new NotFoundResponse("Slot does not exist.");
                }
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
                return new ValidationFailedResponse(new[]
                {
                    new { vaccinationSlotId = $"Exception thrown when parsing id - {ex.Message}" }
                });
            }
        }

        [HttpDelete("vaccination-slots/{vaccinationSlotId}")]
        public async Task<IActionResult> DeleteVaccinationSlot(string vaccinationSlotId)
        {
            try
            {
                int id = int.Parse(vaccinationSlotId);
                var result = await _doctorRepository.DeleteVisit(id);
                if (!result)
                {
                    return new ConflictResponse("Slot does not exist or visit is not planned.");
                }
                return Ok(new SuccessResponse());
            }
            catch (Exception ex)
            {
                return new ValidationFailedResponse(new[]
                {
                    new { vaccinationSlotId = $"Exception thrown when parsing id - {ex.Message}" }
                });
            }
        }

        private int GetDoctorId()
        {
            return User.Claims
                .Where(claim => claim.Type == "id")
                .Select(claim => int.Parse(claim.Value))
                .First();
        }
    }
}
