using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Admin.Visits
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Visit Visit { get; set; }

        private readonly IVisitRepository _visitRepository;
        private readonly IVaccineRepository _vaccineRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IAdministratorRepository _adminRepository;

        public CreateModel(
            IVisitRepository visitRepository,
            IVaccineRepository vaccineRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository,
            IAdministratorRepository adminRepository)
        {
            _visitRepository = visitRepository;
            _vaccineRepository = vaccineRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
            _adminRepository = adminRepository;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Visit = new();

            var doctors = await _doctorRepository.GetAllAsync();
            var patients = await _patientRepository.GetAllAsync();
            var vaccines = await _vaccineRepository.GetAllAsync();
            ViewData["DoctorId"] = new SelectList(doctors, "Id", "FullName");
            ViewData["PatientId"] = new SelectList(patients, "Id", "FullName", null);
            ViewData["VaccineId"] = new SelectList(vaccines, "Id", "Name", null);
            ViewData["Statuses"] = new SelectList(Enum.GetValues(typeof(VaccinationStatus)), Visit.Status);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _adminRepository.CreateVisit(Visit.Status, Visit.Date, Visit.DoctorId!.Value, Visit.PatientId, Visit.VaccineId);

            return RedirectToPage("../Index");
        }
    }
}
