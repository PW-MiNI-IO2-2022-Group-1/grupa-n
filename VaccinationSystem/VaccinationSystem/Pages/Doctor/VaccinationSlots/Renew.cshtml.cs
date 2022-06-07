using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Validations;

namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    [Authorize(Roles = "Doctor")]
    public class RenewModel : PageModel
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IVisitRepository _visitRepository;

        public RenewModel(IDoctorRepository doctorRepository,
                          IVisitRepository visitRepository)
        {
            _doctorRepository = doctorRepository;
            _visitRepository = visitRepository;
        }

        [BindProperty]
        public Visit Visit { get; set; }

        [FutureDateValidation(1, ErrorMessage = "Too late to renew this slot.")]
        [BindProperty]
        public DateTime VisitDateTime { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Visit = await _visitRepository.GetAsync(id);

            if (Visit == null)
            {
                return NotFound();
            }

            VisitDateTime = Visit.Date;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (await _doctorRepository.RenewVisit(id) == null)
            {
                ModelState.AddModelError(string.Empty, "You have another visit at this time.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
