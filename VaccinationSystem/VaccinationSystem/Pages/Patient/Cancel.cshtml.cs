using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Patient
{
    [Authorize(Roles = Roles.Patient.Name)]
    public class CancelModel : PageModel
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IVisitRepository _visitRepository;

        public CancelModel(IPatientRepository patientRepository,
                           IVisitRepository visitRepository)
        {
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
        }

        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public string? Doctor { get; set; }

        [BindProperty]
        public string? VaccineName { get; set; }

        public async Task<IActionResult> OnGetAsync(int visitid, int patientid)
        {
            var visit = await _visitRepository.GetAsync(visitid);

            if (visit == null)
            {
                return NotFound();
            }

            Date = visit.Date;
            Doctor = $"{visit.Doctor.FirstName} {visit.Doctor.LastName}";
            VaccineName = visit.Vaccine?.Name;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int visitid, int patientid)
        {
            if (!await _patientRepository.CancelVisit(visitid, patientid))
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
