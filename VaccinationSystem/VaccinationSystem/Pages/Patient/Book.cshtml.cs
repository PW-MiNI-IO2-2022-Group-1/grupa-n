using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Patient
{
    [Authorize(Roles = Roles.Patient.Name)]
    public class BookModel : PageModel
    {
        private readonly IPatientRepository _patientRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IVaccineRepository _vaccineRepository;

        public BookModel(IPatientRepository patientRepository,
                         IVisitRepository visitRepository,
                         IVaccineRepository vaccineRepository)
        {
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
            _vaccineRepository = vaccineRepository;

        }

        [BindProperty]
        public DateTime Date { get; set; }

        [BindProperty]
        public string? Doctor { get; set; }

        [BindProperty]
        public string? VaccineName { get; set; }

        public SelectList VaccineSelect { get; set; } 

        [BindProperty]
        public int VaccineId { get; set; }

        public async Task<IActionResult> OnGetAsync(int visitid, int patientid)
        {
            var visit = await _visitRepository.GetAsync(visitid);

            if (visit == null)
            {
                return NotFound();
            }

            VaccineSelect = new SelectList(await _vaccineRepository.GetAllAsync(), "Id", "Name");
            Date = visit.Date;
            Doctor = $"{visit.Doctor.FirstName} {visit.Doctor.LastName}";
            VaccineName = visit.Vaccine == null ? null : visit.Vaccine.Name;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int visitid, int patientid)
        {
            if (!await _patientRepository.ReserveVisit(visitid, VaccineId, patientid))
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }
    }
}
