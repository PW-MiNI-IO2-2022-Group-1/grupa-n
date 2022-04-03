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



namespace VaccinationSystem.Pages.Doctor.VaccinationSlots
{
    [Authorize(Roles = "Doctor")]
    public class CreateModel : PageModel
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly VaccinationSystem.Data.ApplicationDbContext _context;

        public CreateModel(
            IDoctorRepository doctorRepository,
            VaccinationSystem.Data.ApplicationDbContext context

            )
        {
            _doctorRepository = doctorRepository;
            _context = context;
        }

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
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);
            
            var visit = await _doctorRepository.CreateVisit(VisitDateTime, user.Id);
            if (visit == null)
            {
                ModelState.AddModelError(string.Empty, "This slot is already booked.");
                return Page();
            }
                

            return RedirectToPage("./Index");
        }
    }
}
