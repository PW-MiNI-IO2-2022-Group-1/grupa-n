using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.Patient.Visits
{
    [Authorize(Roles = Roles.Patient.Name)]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientRepository _patientRepository;
        private readonly IVisitRepository _visitRepository;
        private readonly IVaccineRepository _vaccineRepository;

        [BindProperty]
        public Data.Classes.Patient Patient { get; private set; }

        [BindProperty]
        public Visit Visit { get; set; }

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IPatientRepository patientRepository,
            IVisitRepository visitRepository,
            IVaccineRepository vaccineRepository)
        {
            _userManager = userManager;
            _patientRepository = patientRepository;
            _visitRepository = visitRepository;
            _vaccineRepository = vaccineRepository;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            Patient = (Data.Classes.Patient)await _userManager.GetUserAsync(User);

            if (id is null)
            {
                return NotFound();
            }

            Visit = await _visitRepository.GetVisit(id.Value);
            if (Visit is null)
            {
                return NotFound();
            }

            ViewData["VaccineId"] = new SelectList(await _vaccineRepository.GetAllAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _patientRepository.ReserveVisit(Visit.Id, Visit.VaccineId.Value, Patient.Id);

            return RedirectToPage("../Index");
        }
    }
}
