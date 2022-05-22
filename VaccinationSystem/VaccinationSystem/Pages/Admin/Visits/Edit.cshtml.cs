using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Admin.Visits
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Visit Visit { get; set; }

        private readonly IVisitRepository _visitRepository;
        private readonly IVaccineRepository _vaccineRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IPatientRepository _patientRepository;

        public EditModel(
            IVisitRepository visitRepository,
            IVaccineRepository vaccineRepository,
            IDoctorRepository doctorRepository,
            IPatientRepository patientRepository)
        {
            _visitRepository = visitRepository;
            _vaccineRepository = vaccineRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var visit = await _visitRepository.GetAsync(id.Value);

            if (visit is null)
            {
                return NotFound();
            }

            Visit = visit;

            var doctors = await _doctorRepository.GetAllAsync();
            var patients = await _patientRepository.GetAllAsync();
            var vaccines = await _vaccineRepository.GetAllAsync();
            ViewData["DoctorId"] = new SelectList(doctors, "Id", "FullName");
            ViewData["PatientId"] = new SelectList(patients, "Id", "FullName");
            ViewData["VaccineId"] = new SelectList(vaccines, "Id", "Name");
            ViewData["Statuses"] = new SelectList(Enum.GetValues(typeof(VaccinationStatus)), Visit.Status);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _visitRepository.UpdateAsync(Visit);

            return RedirectToPage("../Index");
        }
    }
}
