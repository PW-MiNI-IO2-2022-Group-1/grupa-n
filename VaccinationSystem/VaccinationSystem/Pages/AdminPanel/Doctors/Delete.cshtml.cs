using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VaccinationSystem.Data.Classes;
using VaccinationSystem.IRepositories;

namespace VaccinationSystem.Pages.AdminPanel.Doctors
{
    [Authorize(Roles = "Administrator")]
    public class DeleteModel : PageModel
    {
        private readonly IAdministratorRepository _administratorRepository;

        public DeleteModel(IAdministratorRepository administratorRepository)
        {
            _administratorRepository = administratorRepository;
        }

        [BindProperty]
        public Doctor Doctor { get; private set; }

        public IActionResult OnGet(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Doctor = _administratorRepository.GetDoctor(id);

            if (Doctor == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (!await _administratorRepository.DeleteDoctor(id))
            {
                return NotFound();
            }

            return RedirectToPage("../Index");
        }
    }
}
