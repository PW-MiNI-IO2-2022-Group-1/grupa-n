#nullable disable

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VaccinationSystem.Data;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;
using VaccinationSystem.Validations;



namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    [Authorize(Roles = "Doctor")]
    public class CreateModel : PageModel
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public Data.Classes.Doctor Doctor { get; private set; }
        public CreateModel(
            IDoctorRepository doctorRepository,
            UserManager<ApplicationUser> userManager
            )
        {
            _doctorRepository = doctorRepository;
            _userManager = userManager;
        }
        [FutureDateValidation(1, ErrorMessage ="Too late to book this slot.")]
        [BindProperty]
        public DateTime VisitDateTime { get; set; }
        public IActionResult OnGet()
        {
            VisitDateTime = DateTime.Today;
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Doctor = (Data.Classes.Doctor)await _userManager.GetUserAsync(User);

            var visit = await _doctorRepository.CreateVisit(VisitDateTime, Doctor.Id);
            if (visit == null)
            {
                ModelState.AddModelError(string.Empty, "You have another visit at this time.");
                return Page();
            }
            return RedirectToPage("./Index");
        }
    }
}
