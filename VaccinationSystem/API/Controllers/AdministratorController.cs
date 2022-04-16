using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using API.ModelValidation;
using API.RequestModels.Admin;
using VaccinationSystem.Data;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Data.Classes;

namespace API.Controllers
{
    [ApiController]
    [Route("/admin")]
    [Authorize(Roles = Roles.Admin.Name)]
    public class AdministratorController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAdministratorRepository _administratorRepository;

        private const int pageSize = 10;

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
        [HttpGet("auth-test")]
        public async Task<ActionResult> AuthTest()
        {
            return Ok(new SuccessResponse());
        }

        [HttpGet("patients")]
        public async Task<ActionResult> GetPatients([FromQuery] int page)
        {
            if (page < 1)
            {
                return new NotFoundResponse("Wrong page.");
            }
            var (patients, pagination) = Pagination<Patient>.ShrinkList(await _administratorRepository.GetAllPatients(), page, pageSize);
            var response = new ResponseModels.Admin.GetAllPatients
            {
                Pagination = pagination,
                Data = patients.Select(patient => new ApiPatient
                {
                    Id = patient.Id,
                    FirstName = patient.FirstName,
                    LastName = patient.LastName,
                    Pesel = patient.Pesel,
                    Email = patient.Email,
                    Address = patient.Address
                }).ToArray()
            };
            return Ok(response);
        }

        [HttpGet("patients/{patientId}")]
        public async Task<ActionResult> GetSinglePatient(int patientId)
        {
            var patient = _administratorRepository.GetPatient(patientId);
            if (patient == null)
            {
                return new NotFoundResponse("Patient does not exist.");
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

        [HttpPut("patients/{patientId}")]
        public async Task<ActionResult> EditPatient(int patientId, [FromBody] EditPatient body)
        {
            // Address jeszcze nie dziala bo nie jest zaimplementowany w Repository
            var patient = await _administratorRepository.EditPatient(
                patientId, body.FirstName, body.LastName, body.Pesel, body.Email);
            if (patient == null)
            {
                return new NotFoundResponse("Patient does not exist.");
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

        [HttpDelete("patients/{patientId}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            var result = await _administratorRepository.DeletePatient(patientId);
            if (!result)
            {
                return new NotFoundResponse("Patient does not exist.");
            }
            return Ok();
        }

        [HttpGet("doctors")]
        public async Task<ActionResult> GetDoctors([FromQuery] int page)
        {
            if (page < 1)
            {
                return new NotFoundResponse("Wrong page.");
            }
            var (doctors, pagination) = Pagination<Doctor>.ShrinkList(await _administratorRepository.GetAllDoctors(), page, pageSize);
            var response = new ResponseModels.Admin.GetAllDoctors
            {
                Pagination = pagination,
                Data = doctors.Select(doctor => new ApiUser
                {
                    Id = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Email = doctor.Email,
                }).ToArray()
            };
            return Ok(response);
        }

        [HttpPost("doctors")]
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

        [HttpGet("doctors/{doctorId}")]
        public async Task<ActionResult> GetSingleDoctor(int doctorId)
        {
            var doctor = _administratorRepository.GetDoctor(doctorId);
            if (doctor == null)
            {
                return new NotFoundResponse("Doctor does not exist.");
            }
            var response = new ApiUser
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email,
            };
            return Ok(response);
        }

        [HttpPut("doctors/{doctorId}")]
        public async Task<ActionResult> EditDoctor(int doctorId, [FromBody] EditDoctor body)
        {
            var doctor = await _administratorRepository.EditDoctor(
                doctorId, body.FirstName, body.LastName, body.Email);
            if (doctor == null)
            {
                return new NotFoundResponse("Doctor does not exist.");
            }
            var response = new ApiUser
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Email = doctor.Email
            };
            return Ok(response);
        }

        [HttpDelete("doctors/{doctorId}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
            var result = await _administratorRepository.DeleteDoctor(doctorId);
            if (!result)
            {
                return new NotFoundResponse("Doctor does not exist.");
            }
            return Ok(new SuccessResponse());
        }

        [HttpGet("vaccinations")]
        public async Task<IActionResult> GetVaccinations([FromQuery] GetVaccinations body)
        {
            if (body.Page < 1)
            {
                return new NotFoundResponse("Wrong page.");
            }
            // Na razie filtrowanie dla pojedynczych wartosci, 
            // powinno byc mozliwe separowanie po przecinku chorob
            var (visits, pagination) = Pagination<Visit>
                .ShrinkList(await _administratorRepository.GetAllVisits(body.Disease, body.DoctorId, body.PatientId), body.Page, pageSize);
            var data = visits.Select(visit =>
            {
                return new ApiVaccination
                {
                    Id = visit.Id,
                    Vaccine = new ApiVaccine
                    {
                        Id = visit.VaccineId == null ? int.MaxValue : (int)visit.VaccineId,
                        Name = visit.Vaccine.Name,
                        Disease = visit.Vaccine.Disease.Name,
                        RequiredDoses = visit.Vaccine.RequiredDoses
                    },
                    VaccinationSlot = new ApiVaccinationSlot
                    {
                        Id = visit.Id,
                        Date = visit.Date
                    },
                    Status = visit.Status.ToString(),
                    Patient = new ApiPatient
                    {
                        Id = visit.Patient.Id,
                        FirstName = visit.Patient.FirstName,
                        LastName = visit.Patient.LastName,
                        Pesel = visit.Patient.Pesel,
                        Email = visit.Patient.Email,
                        Address = visit.Patient.Address
                    },
                    Doctor = new ApiUser
                    {
                        Id = visit.Doctor.Id,
                        Email = visit.Doctor.Email,
                        FirstName = visit.Doctor.FirstName,
                        LastName = visit.Doctor.LastName,
                    }
                };
            }).ToArray();
            return Ok(new ResponseModels.Admin.GetVaccinations
            {
                Pagination = pagination,
                Data = data
            });
        }
    }
}
