using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    [Authorize(Roles = "Doctor")]
    public class FinishModel : PageModel
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IVisitRepository _visitRepository;

        public FinishModel(IDoctorRepository doctorRepository,
                           IVisitRepository visitRepository)
        {
            _doctorRepository = doctorRepository;
            _visitRepository = visitRepository;
        }

        [BindProperty]
        public Visit Visit { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Visit = await _visitRepository.GetAsync(id);

            if (Visit == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (await _doctorRepository.VaccinatePatient(id) == false)
            {
                ModelState.AddModelError(string.Empty, "No visit or patient.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
